using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using APLTools.Advance.Common;
using APLTools.Advance.Model;
using APLTools.Logic;
using APLTools.Models;
using DMS;

namespace APLTools.Advance.WinUI.UseImage
{
    public partial class SharedArt : UserControl
    {
        #region fields

        private static SharedArt instance;
        private List<UserImage> sharedArtWorkList = new List<UserImage>();
        private static List<CListItem> vendorlist = new List<CListItem>();
        #endregion

        #region constructors

        private SharedArt()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region properties

        public static SharedArt Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SharedArt();
                }

                instance.DgvGrid.AutoGenerateColumns = false;
                instance.PageBar.DataControl = instance.DgvGrid;
                init();

                return instance;
            }
        }

        #endregion

        #region methods

        private static void init()
        {
            var vendorlistConf = ConfigurationManager.AppSettings["VendorList"];
            var jss = new JavaScriptSerializer();
            vendorlist = jss.Deserialize<List<CListItem>>(vendorlistConf);
            vendorlist = vendorlist.OrderByDescending(x => x.Value.GetInt()).ToList();
            instance.combVendor.Items.Clear();
            instance.combVendor.Items.AddRange(vendorlist.ToArray());

            VendorSelect("100010");
        }

        private void ArtBind()
        {
            instance.PageBar.DataSource = PageDataUtil.GetPageList(sharedArtWorkList, instance.PageBar.PageSize, instance.PageBar.CurPage);
            instance.PageBar.DataBind();

            var t = new Thread(delegate ()
                               {
                                   for (var i = 0; i < sharedArtWorkList.Count; i++)
                                   {
                                       var userImage = sharedArtWorkList[i];

                                       try
                                       {
                                           var sharedArtworkUrl = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + userImage.FilenameNoExtension + "}&$Studio_SharedT$";
                                           var pictureBox1 = new PictureBox();
                                           pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                           pictureBox1.Load(sharedArtworkUrl);
                                           var imgPreview = new Bitmap(pictureBox1.Image, 120, 25);
                                           userImage.Preview = imgPreview;
                                       }
                                       catch (Exception exception)
                                       {
                                           Console.WriteLine(exception);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            instance.btnSearch.Enabled = false;
            instance.PageBar.DataSource = null;
            instance.PageBar.DataBind();

            var vendorId = txtVendorId.Text.Trim();
            var itemId = txtItemId.Text.Trim();
            var processId = txtProcessId.Text.Trim();

            var meta = new MetaData
            {
                imageType = imageType.CustomerSuppliedStockArt,
                customerArtworkType = customerArtworkType.WebPreview,
                vendorStudioId = vendorId,
                itemIds = new List<string>
                                     {
                                         itemId
                                     },
                processIds = new List<string>
                                        {
                                            processId
                                        }
            };

            var conType = rbtniNet.Checked
                              ? ConnectionType.Dev
                              : ConnectionType.Live;
            var damConnector = new DamConnector(conType);
            var metaDataList = damConnector.GetArtworkMetaDataListAdvance(meta);

            if (metaDataList == null || metaDataList.Count == 0)
            {
                instance.btnSearch.Enabled = true;
                FormSysMessage.ShowMessage("Sreach Exception - can't find metaDataList on server!");
                return;
            }

            sharedArtWorkList = metaDataList.Select((x, i) => new UserImage
            {
                RowNum = i + 1,
                OriginalFilename = x.originalFilename,
                ColorSpace = x.colorSpace,
                FilenameNoExtension = x.filenameNoExtension,
                Type = UserImageType.SharedArt
            })
                                            .ToList();

            ArtBind();

            instance.btnSearch.Enabled = true;
        }

        private void DgvGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DataGridViewPreviewButtonCell.IsPreivewButtonClick(sender, e))
            {
                var filenameNoExtension = DgvGrid["FilenameNoExtension", e.RowIndex]
                                          .Value.ToString();
                var url = $"http://nucleus.promotionalstore.com/api/v1/entity/Promo/content/{filenameNoExtension}/image";
                var sharedArtworkUrl = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + filenameNoExtension + "}&$Studio_SharedT$";

                var clipData = "{\"thumbnail\":\"" + sharedArtworkUrl + "\",\"preview\":\"" + url + "\"'}";
                Clipboard.SetDataObject(clipData);

                try
                {
                    var wc = new WebClient();
                    var fileBytes = wc.DownloadData(url);
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

        private void combVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combVendor.SelectedItem != null)
            {
                var selectedItem = (CListItem)combVendor.SelectedItem;

                if (selectedItem != null)
                {
                    txtVendorId.Text = selectedItem.Value;
                }
            }
        }
        private static void VendorSelect(string vendorid)
        {
            if (vendorlist.Any(x => x.Value.Equals(vendorid)))
            {
                instance.combVendor.SelectedItem = vendorlist.Find(x => x.Value.Equals(vendorid));
            }
        }

        private void txtVendorId_TextChange(object sender, EventArgs e)
        {
            if (txtVendorId.Text.Trim()
                           .Length
                > 0)
            {
                VendorSelect(txtVendorId.Text.Trim());
            }
        }

        private List<ImprintFormat> imprintFormat = new List<ImprintFormat>();
        private void button1_Click(object sender, EventArgs e)
        {
            var bll = new BLL.ImprintFormat();
            imprintFormat = bll.GetMultipleFormats(txtItemId.Text.Trim());
            listBox1.Items.Clear();
            imprintFormat.ForEach(x => { listBox1.Items.Add(new CListItem(x.Key.ToUpper() + $" (ProcessId: {x.ProcessId})", x.Key.ToUpper())); });
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
                        txtProcessId.Text = selecedFormat.ProcessId.ToString();
                    }
                }
            }

        }
    }
}
