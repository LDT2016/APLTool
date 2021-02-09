using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using APLTools.Advance.Common;
using APLTools.Advance.Model;
using APLTools.Logic;
using APLTools.Models;
using Configurator.Models.Scene7;
using DMS;

namespace APLTools.Advance.WinUI.UseImage
{
    public partial class SavedArt : UserControl
    {
        #region fields

        private static int currentSearchStatus = 0;
        private static SavedArt instance;
        private string _offLineCount = string.Empty;
        private string _onLineCount = string.Empty;

        //private BindingList<Model.Devices> devicesBindList = new BindingList<Model.Devices>();
        private List<UserImage> savedArtWorkList = new List<UserImage>();

        #endregion

        #region constructors

        private SavedArt()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        // This event handler is where the time-consuming work is done.
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SearchAction();
        }
        private void SearchAction()
        {
            var cusNumber = txtCustomerNumber.Text.Trim();
            var imprintFormat = txtImprintAreaCode.Text.Trim();
            var processId = txtProcessId.Text.Trim();

            var meta = new MetaData
            {
                customerNumber = cusNumber,
                processIds = new List<string>
                                        {
                                            processId
                                        },
                imprintFormat = imprintFormat
            };

            var conType = rbtniNet.Checked
                              ? ConnectionType.Dev
                              : ConnectionType.Live;
            var damConnector = new DamConnector(conType);
            var metaDataList = damConnector.GetSavedArtThumbnailsByPage(meta, -1, -1);

            if (metaDataList == null)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(delegate
                   {
                       instance.btnSearch.Enabled = true;
                       FormSysMessage.ShowMessage("Sreach Exception - can't find metaDataList on server!");
                   }));
                }
                else
                {
                    instance.btnSearch.Enabled = true;
                    FormSysMessage.ShowMessage("Sreach Exception - can't find metaDataList on server!");
                }
                return;
            }

            savedArtWorkList = metaDataList.Select((x, i) => new UserImage
            {
                RowNum = i + 1,
                OriginalFilename = x.originalFilename,
                ColorSpace = x.colorSpace,
                FilenameNoExtension = x.filenameNoExtension,
                Type = UserImageType.SavedArt,
                FileBytes = x.fileBytes
            })
                                           .ToList();


            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        // This event handler updates the progress.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        // This event handler deals with the results of the background operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(delegate
                                  {
                                      ArtBind();
                                      instance.btnSearch.Enabled = true;
                                  }));
            }
            else
            {
                ArtBind();
                instance.btnSearch.Enabled = true;
            }

            if (e.Cancelled )
            {
                // "Canceled!";
            }
            else if (e.Error != null)
            {
                // "Error: " + e.Error.Message;
            }
            else
            {
                // "Done!";
            }
        }
        #endregion

        #region properties

        public static SavedArt Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SavedArt();
                }

                instance.DgvGrid.AutoGenerateColumns = false;

                return instance;
            }
        }


        #endregion

        #region methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            instance.btnSearch.Enabled = false;
            instance.PageBar.DataSource = null;
            instance.PageBar.DataBind();


            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }

        }

        private void ArtBind()
        {
            instance.PageBar.DataControl = instance.DgvGrid;
            instance.PageBar.DataSource = PageDataUtil.GetPageList(savedArtWorkList, instance.PageBar.PageSize, instance.PageBar.CurPage);
            instance.PageBar.DataBind();

            var t = new Thread(delegate ()
                               {
                                   for (var i = 0; i < savedArtWorkList.Count; i++)
                                   {
                                       var userImage = savedArtWorkList[i];

                                       try
                                       {
                                           var ms = new MemoryStream(userImage.FileBytes);
                                           var imgPreview = new Bitmap(ms);
                                           userImage.Preview = new Bitmap(imgPreview, 120, 25);
                                       }
                                       catch (Exception exception)
                                       {
                                           Console.WriteLine(exception);
                                       }
                                   }
                               });
            t.IsBackground = true;
            t.Start();
        }

        private void DgvGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DataGridViewPreviewButtonCell.IsPreivewButtonClick(sender, e))
            {
                var preview = (Image)DgvGrid["Preview", e.RowIndex].Value;
                new SavedPreview(preview).Show();

            }
        }

        #endregion

        private void PageBar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private List<ImprintFormat> imprintFormat = new List<ImprintFormat>();
        private void button1_Click(object sender, EventArgs e)
        {
            var bll = new BLL.ImprintFormat();
            imprintFormat = bll.GetMultipleFormats(txtItemId.Text.Trim());
            listBox1.Items.Clear();
            imprintFormat.ForEach(x => { listBox1.Items.Add(new CListItem(x.Key.ToUpper() + $" (ProcessId: {x.ProcessId})", x.Key.ToUpper())); });
            //new CListItem(x.Key.ToUpper() + $" (ProcessId: {x.ProcessId})",""))}


        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var formatItem = (CListItem)listBox1.SelectedItem;

                if (formatItem != null)
                {
                    var formatKey = formatItem.Value;
                    if (imprintFormat.Find(x => x.Key.Equals(formatKey)) != null)
                    {
                        var selecedFormat = imprintFormat.Find(x => x.Key.Equals(formatKey));
                        txtImprintAreaCode.Text = selecedFormat.ImprintAreaCode;
                        txtProcessId.Text = selecedFormat.ProcessId.ToString();
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            instance.DgvGrid.DataSource = null;
            lblDamServiceCount.Text = "N/A";
        }

        private bool NewFxgLogoPanel = true;
        public string GetUploadLogoPreviewUrl(UserImage userImage)
        {
            var url = new StringBuilder();
            url.Append(GetScene7ImageURL(userImage.Scene7FileName, Scene7URLBO.FXG_FORMAT_PNGALPHA));
            //AppendCropParameter(url, userImage.Info);
            //AppendRotateParameter(url, userImage.Direction);
            return url.ToString();
        }
        //private static void AppendCropParameter(StringBuilder url, ImageInfo info)
        //{
        //    if (info != null && !info.FinalCroppedSize.IsEmpty)
        //    {
        //        url.Append(Scene7URLBO.AND);
        //        AppendCropParameter(url, info.FinalCroppedPos, info.FinalCroppedSize);
        //    }
        //}
        //private static void AppendRotateParameter(StringBuilder url, int direction)
        //{
        //    if (direction > 0)
        //    {
        //        url.Append(Scene7URLBO.AND);
        //        AppendRotateParameter(url, direction);
        //    }
        //}


        private string GetScene7ImageURL(string fileName, string fmt)
        {
            var url = new StringBuilder();
            url.Append(GetScene7ImageURL(fileName));

            if (!NewFxgLogoPanel)
            {
                url.Append(Scene7URLBO.AND);
                url.Append(Scene7URLBO.FXG_FORMAT);
                url.Append(Scene7URLBO.EQUALS);
                url.Append(fmt);
            }
            else
            {
                url.Append(Scene7URLBO.QUESTION_MARK);
            }

            return url.ToString();
        }

        private string GetScene7ImageURL(string fileName)
        {
            var url = new StringBuilder();
            url.Append(GetImageUrlPrefix()); // //images.promotionalstore.com/is/image/PromotionalStore/i?src=is{

            url.Append(GetNucleusAliasWithImagePostFix(fileName));
            BuildUrlEnd(url);
            return url.ToString();
        }
        private string GetImageUrlPrefix()
        {
            var imageUrl = new StringBuilder();
            var nucleusHostName = "https://nucleus.promotionalstore.com/"; //ConfigurationManager.AppSettings["NucleusHostName"];
            imageUrl.Append(nucleusHostName);
            imageUrl.Append(Scene7URLBO.IBALANCET_USER_GENERATE_CONTENT_DIMENSION);
            return imageUrl.ToString();

            //var imageUrl = new StringBuilder();
            //if (logoPanelRenderOptionsNewFxgLogoPanel)
            //{
            //    var nucleusHostName = ConfigurationManager.AppSettings["NucleusHostName"];
            //    imageUrl.Append(nucleusHostName);
            //    imageUrl.Append(Scene7URLBO.IBALANCET_USER_GENERATE_CONTENT_DIMENSION);
            //}
            //else
            //{
            //    GetImageUrlPrefix2(imageUrl, scene7ImagePath);
            //}

            //return imageUrl.ToString();
        }
        private string GetNucleusAliasWithImagePostFix(string fileName)
        {
            string nucleusAlias = GetNucleusAlias(fileName);
            if (NewFxgLogoPanel)
                nucleusAlias += Scene7URLBO.IBALANCER_IMAGE;
            return nucleusAlias;
        }
        private string GetNucleusAlias(string fileName)
        {
            if (NewFxgLogoPanel)
            {
                if (fileName.IndexOf(Scene7URLBO.SLASH, StringComparison.Ordinal) > -1)
                {
                    var s = fileName.Split('/');
                    var alias = s[s.Length - 1];
                    return alias;
                }
                else if (fileName.IndexOf(Scene7URLBO.COMMA, StringComparison.Ordinal) > -1)
                {
                    var alias = fileName.Split(',');
                    return alias[0];
                }
            }

            return fileName;
        }
        private void BuildUrlEnd(StringBuilder builder)
        {
            if (!NewFxgLogoPanel)
            {
                builder.Append(Scene7URLBO.BRACE_RIGHT);
            }
        }

    }
}
