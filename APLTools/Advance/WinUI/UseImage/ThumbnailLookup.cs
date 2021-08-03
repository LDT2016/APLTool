using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using APLTools.Advance.Common;
using APLTools.Advance.DAL;
using APLTools.Advance.Model;
using APLTools.Logic;
using APLTools.Models;
using DMS;
using Model;
using ImprintFormat = APLTools.Advance.Model.ImprintFormat;

namespace APLTools.Advance.WinUI.UseImage
{
    public partial class ThumbnailLookup : UserControl
    {
        #region fields

        private static ThumbnailLookup instance;
        private List<UserImage> sharedArtWorkList = new List<UserImage>();
        private static List<CListItem> vendorlist = new List<CListItem>();
        #endregion

        #region constructors

        private ThumbnailLookup()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

        }
        #endregion

        #region properties

        public static ThumbnailLookup Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ThumbnailLookup();
                }

                instance.DgvGrid.AutoGenerateColumns = false;
                init();

                return instance;
            }
        }

        #endregion

        #region methods
        private BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        private static void init()
        {
        }

        private void ArtBind()
        {
            instance.DgvGrid.DataSource = sharedArtWorkList;


            var t = new Thread(delegate ()
                               {
                                   for (var i = 0; i < sharedArtWorkList.Count; i++)
                                   {
                                       var userImage = sharedArtWorkList[i];


                                       var tbname = userImage.Type == UserImageType.SavedArt
                                                        ? "ThumbnailsOldTable"
                                                        : "ThumbnailsNewTable";
                                       var sql = "";
                                       var sharedArtworkUrl = "";
                                       try
                                       {
                                           sharedArtworkUrl = "http://images.promotionalstore.com/is/image/Amsterdam/imprintthumb_" + userImage.FilenameNoExtension + "?$Studio_ImprintThumb$";
                                           var wc = new WebClient();
                                           var fileBytes = wc.DownloadData(sharedArtworkUrl);
                                           var ms = new MemoryStream(fileBytes);
                                           var preview = Image.FromStream(ms);
                                           userImage.Preview = preview;

                                           sql = "update [test].dbo." + tbname + " set ImageNoFound=0 where id=" + userImage.unique;
                                       }
                                       catch (Exception exception)
                                       {
                                           sql = "update [test].dbo." + tbname + " set ImageNoFound=1 where id=" + userImage.unique;
                                       }
                                       finally
                                       {
                                           userImage.update = "yes";
                                           DALHelper.ThumbnailLookupDbHelper.ExecuteNonQuery(CommandType.Text, sql);
                                       }
                                   }
                               })
            {
                IsBackground = true
            };
            t.Start();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            instance.DgvGrid.DataSource = null;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // "Done!";
            if (InvokeRequired)
            {
                Invoke(new Action(delegate
                                  {
                                      ArtBind();
                                      instance.btnSearch.Enabled = true;
                                      lblAllCount.Text = sharedArtWorkList.Count.ToString();
                                  }));
            }
            else
            {
                ArtBind();
                instance.btnSearch.Enabled = true;
                lblAllCount.Text = sharedArtWorkList.Count.ToString();
            }

            if (e.Cancelled)
            {
                // "Canceled!";
            }
            else if (e.Error != null)
            {
                // "Error: " + e.Error.Message;
            }
            else
            {

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SearchAction();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            instance.btnSearch.Enabled = false;

            backgroundWorker1.RunWorkerAsync();
        }

        private void SearchAction()
        {
            sharedArtWorkList.Clear();

            var thumbnailsOldTableList = new List<ThumbnailsOldTable>();

            var sqlwhere = string.Empty;

            if (rbtnFound.Checked)
            {
                sqlwhere = " where imagenofound=0 ";
            }
            else if (rbtnNoFound.Checked)
            {
                sqlwhere = " where imagenofound=1 ";
            }
            else if (rbtnNull.Checked)
            {
                sqlwhere = " where imagenofound is null ";
            }
            else if (rbtnNotNull.Checked)
            {
                sqlwhere = " where imagenofound is not null ";
            }

            if (chkOldTb.Checked)
            {
                using (var dr = DALHelper.ThumbnailLookupDbHelper.ExecuteReader(CommandType.Text, "select * from [test].dbo.ThumbnailsOldTable" + sqlwhere))
                {

                    while (dr.Read())
                    {
                        thumbnailsOldTableList.Add(new ThumbnailsOldTable
                                                   {
                                                       Combination = dr["Combination"] != DBNull.Value
                                                                         ? dr["Combination"]
                                                                               ?.ToString()
                                                                           ?? ""
                                                                         : "",
                                                       Company = dr["Company"] != DBNull.Value
                                                                     ? dr["Company"]
                                                                           ?.ToString()
                                                                       ?? ""
                                                                     : "",
                                                       Description = dr["Description"] != DBNull.Value
                                                                         ? dr["Description"]
                                                                               ?.ToString()
                                                                           ?? ""
                                                                         : "",
                                                       Division = dr["Division"] != DBNull.Value
                                                                      ? dr["Division"]
                                                                            ?.ToString()
                                                                        ?? ""
                                                                      : "",
                                                       Filename = dr["Filename"] != DBNull.Value
                                                                      ? dr["Filename"]
                                                                            ?.ToString()
                                                                        ?? ""
                                                                      : "",
                                                       ID = dr["ID"] != DBNull.Value
                                                                ? Convert.ToInt32(dr["ID"])
                                                                : 0,
                                                       ImageNoFound = dr["ImageNoFound"] != DBNull.Value && Convert.ToBoolean(dr["ImageNoFound"]),
                                                       ItemId = dr["ID"] != DBNull.Value
                                                                    ? dr["ItemId"]
                                                                          ?.ToString()
                                                                      ?? ""
                                                                    : ""
                                                   });
                    }

                    dr.Dispose();
                }

                sharedArtWorkList.AddRange(thumbnailsOldTableList.Select((x, i) => new UserImage
                                                                                   {
                                                                                       tablename = "Old",
                                                                                       unique = x.ID,
                                                                                       RowNum = i + 1,
                                                                                       FilenameNoExtension = x.Filename,
                                                                                       Type = UserImageType.SavedArt
                                                                                   })
                                                                 .ToList());

            }

            if (chkNewTb.Checked)
            {

                var thumbnailsNewTableList = new List<ThumbnailsNewTable>();

                using (var dr = DALHelper.ThumbnailLookupDbHelper.ExecuteReader(CommandType.Text, "select * from [test].dbo.ThumbnailsNewTable" + sqlwhere))
                {
                    while (dr.Read())
                    {
                        thumbnailsNewTableList.Add(new ThumbnailsNewTable
                                                   {
                                                       CombinationId = dr["CombinationId"] != DBNull.Value
                                                                           ? dr["CombinationId"]
                                                                                 ?.ToString()
                                                                             ?? ""
                                                                           : "",
                                                       Company = dr["Company"] != DBNull.Value
                                                                     ? dr["Company"]
                                                                           ?.ToString()
                                                                       ?? ""
                                                                     : "",
                                                       Description = dr["Description"] != DBNull.Value
                                                                         ? dr["Description"]
                                                                               ?.ToString()
                                                                           ?? ""
                                                                         : "",
                                                       Division = dr["Division"] != DBNull.Value
                                                                      ? dr["Division"]
                                                                            ?.ToString()
                                                                        ?? ""
                                                                      : "",
                                                       Filename = dr["Filename"] != DBNull.Value
                                                                      ? dr["Filename"]
                                                                            ?.ToString()
                                                                        ?? ""
                                                                      : "",
                                                       ID = dr["ID"] != DBNull.Value
                                                                ? Convert.ToInt32(dr["ID"])
                                                                : 0,
                                                       ImageNoFound = dr["ImageNoFound"] != DBNull.Value && Convert.ToBoolean(dr["ImageNoFound"]),
                                                       ItemId = dr["ID"] != DBNull.Value
                                                                    ? dr["ItemId"]
                                                                          ?.ToString()
                                                                      ?? ""
                                                                    : ""
                                                   });
                    }

                    dr.Dispose();
                }


                sharedArtWorkList.AddRange(thumbnailsNewTableList.Select((x, i) => new UserImage
                                                                                   {
                                                                                       tablename = "New",
                                                                                       unique = x.ID,
                                                                                       RowNum = i + 1,
                                                                                       FilenameNoExtension = x.Filename,
                                                                                       Type = UserImageType.SharedArt
                                                                                   })
                                                                 .ToList());
            }


            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void DgvGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DataGridViewPreviewButtonCell.IsPreivewButtonClick(sender, e))
            {
                var filenameNoExtension = DgvGrid["FilenameNoExtension", e.RowIndex]
                                          .Value.ToString();
                //var url = $"http://nucleus.promotionalstore.com/api/v1/entity/Promo/content/{filenameNoExtension}/image";
                //var sharedArtworkUrl = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + filenameNoExtension + "}&$Studio_SharedT$";
                var sharedArtworkUrl = "http://images.promotionalstore.com/is/image/Amsterdam/imprintthumb_" + filenameNoExtension + "?$Studio_ImprintThumb$";

                var clipData = "{\"thumbnail\":\"" + sharedArtworkUrl + "\",\"preview\":\"" + sharedArtworkUrl + "\"'}";
                Clipboard.SetDataObject(clipData);

                try
                {
                    var wc = new WebClient();
                    var fileBytes = wc.DownloadData(sharedArtworkUrl);
                    var ms = new MemoryStream(fileBytes);
                    var preview = Image.FromStream(ms);
                    new SavedPreview(preview).Show();
                }
                catch (Exception exception)
                {
                    FormSysMessage.ShowMessage($"Sreach Exception - {exception.Message}");
                }
            }
        }

        private void PageBar_PageChanged(object sender, EventArgs e)
        {
            ArtBind();
        }

        #endregion


        private List<ImprintFormat> imprintFormat = new List<ImprintFormat>();

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            instance.DgvGrid.DataSource = null;
            lblAllCount.Text = "0";
        }
    }
}
