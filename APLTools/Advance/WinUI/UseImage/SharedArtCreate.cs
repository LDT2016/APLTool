using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using APLTools.Logic;
using APLTools.Models;

namespace APLTools.Advance.WinUI.UseImage
{
    public partial class SharedArtwork : UserControl
    {
        #region fields

        private static SharedArtwork instance;

        #endregion

        #region constructors

        private SharedArtwork()
        {
            InitializeComponent();
        }

        #endregion

        #region properties

        public static SharedArtwork Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SharedArtwork();
                }

                return instance;
            }
        }

        #endregion

        #region methods

        //private void btnChooseFile_Click(object sender, EventArgs e)
        //{
        //    var ret = openFileDialog1.ShowDialog();
        //    if (ret == DialogResult.OK)
        //    {
        //        var fileName = openFileDialog1.FileName;
        //        lblFileName.Text = fileName;
        //    }
        //}

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var ret = false;

            try
            {
                Enabled = false;
                var fileNameNoExt = cbFileNames.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(fileNameNoExt))
                {
                    var url = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + fileNameNoExt + "}&fmt=png&wid=1000";
                    //url = "http://nucleus.promotionalstore.com/api/v1/entity/Promo/content/" + fileNameNoExt + "/image";

                    using (var wc = new WebClient())
                    {
                        var fileName = fileNameNoExt + ".png";
                        var cacheFolder = DamToolsHelper.GetCacheFolder();
                        var fullFileName = cacheFolder + fileName;
                        wc.DownloadFile(url, fullFileName);

                        var meta = new MetaData
                        {
                            vendorStudioId = txtVendorId.Text.Trim(),
                            itemIds = new List<string>
                                                 {
                                                     txtItemId.Text.Trim()
                                                 },
                            colorSpace = rbtnSingle.Checked
                                                        ? colorSpace.SingleColor
                                                        : colorSpace.MultipleColor,
                            originalFilename = fileName,
                            filenameNoExtension = fileNameNoExt,
                            processIds = new List<string>
                                         {
                                             txtProcessId.Text.Trim()
                                         }
                        };
                        ret = DamToolsHelper.AddSharedArtwork(fullFileName, meta);
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
            }
            finally
            {
                Enabled = true;

                if (ret)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
        }

        private void cbFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var fileName = cbFileNames.SelectedItem.ToString();
                imageSearchName.Text = fileName;
                var nucleusUrl = "http://nucleus.promotionalstore.com/api/v1/entity/Promo/content/" + fileName + "/image";
                txtNucleusUrl.Text = nucleusUrl;
                var thumbnailUrl = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + fileName + "}&fmt=png&$Studio_SharedD$";
                txtThumbnialUrl.Text = thumbnailUrl;
                picThumbnial.Load(thumbnailUrl);

                var wc = new WebClient();
                var fileBytes = wc.DownloadData(nucleusUrl);
                var ms = new MemoryStream(fileBytes);
                picNucleus.Image = Image.FromStream(ms);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.Message);
            }
        }
        private void SharedArtwork_Load(object sender, EventArgs e)
        {
            var scene7FileNames = ConfigurationManager.AppSettings["Scene7FileNames"];
            var fileNames = scene7FileNames.Split(',');
            cbFileNames.Items.AddRange(fileNames);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = imageSearchName.Text
                                              .Trim();

                var nucleusUrl = "http://nucleus.promotionalstore.com/api/v1/entity/Promo/content/" + fileName + "/image";
                txtNucleusUrl.Text = nucleusUrl;
                var thumbnailUrl = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + fileName + "}&fmt=png&$Studio_SharedD$";
                txtThumbnialUrl.Text = thumbnailUrl;
                picThumbnial.Load(thumbnailUrl);

                var wc = new WebClient();
                var fileBytes = wc.DownloadData(nucleusUrl);
                var ms = new MemoryStream(fileBytes);
                picNucleus.Image = Image.FromStream(ms);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Submit Searched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var ret = false;
            try
            {
                Enabled = false;
                var fileNameNoExt = imageSearchName.Text.Trim();

                if (!string.IsNullOrEmpty(fileNameNoExt))
                {
                    var url = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + fileNameNoExt + "}&fmt=png&wid=1000";
                    //url = "http://nucleus.promotionalstore.com/api/v1/entity/Promo/content/" + fileNameNoExt + "/image";

                    using (var wc = new WebClient())
                    {
                        var fileName = fileNameNoExt + ".png";
                        var cacheFolder = DamToolsHelper.GetCacheFolder();
                        var fullFileName = cacheFolder + fileName;
                        wc.DownloadFile(url, fullFileName);

                        var meta = new MetaData
                        {
                            vendorStudioId = txtVendorId.Text.Trim(),
                            itemIds = new List<string>
                                                 {
                                                     txtItemId.Text.Trim()
                                                 },
                            colorSpace = rbtnSingle.Checked
                                                        ? colorSpace.SingleColor
                                                        : colorSpace.MultipleColor,
                            originalFilename = fileName,
                            filenameNoExtension = fileNameNoExt,
                            processIds = new List<string>
                                         {
                                             txtProcessId.Text.Trim()
                                         }
                        };
                        ret = DamToolsHelper.AddSharedArtwork(fullFileName, meta);
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
            }
            finally
            {
                Enabled = true;

                if (ret)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
        }

        class testclass
        {
            public string group { set; get; }
            public string key { set; get; }
        }

        private void btnBatchSubmit_Click(object sender, EventArgs e)
        {
            //cart format
            var list0 = new List<string>()
                       {
                           "a","b","c"
                       };


            var list1 = new List<testclass>()
                       {
                           new testclass(){group = "g0", key = "b"},
                           new testclass(){group = "g1", key = "a"},
                           new testclass(){group = "g1", key = "c"}
                       };

            var list2 = new List<string>()
                       {
                           "a",
                           "b",
                           "e",
                           "f"
                       };

            var g0 = list0.FindAll(x => list1.FindAll(m => m.group == "g0")
                                             .ToList()
                                             .Select(y => y.key)
                                             .Contains(x))
                          .ToList();

            var g1 = list0.FindAll(x => list1.FindAll(m => m.group == "g1")
                                             .ToList()
                                             .Select(y => y.key)
                                             .Contains(x))
                          .ToList();



            var ret = false;
            var successCount = 0;
            var failed = 0;
            try
            {
                Enabled = false;
                var fileNames = txtNecleusBatchEnter.Text.Trim();
                var fileNameNoExtArray = fileNames.Replace("\r\n", ";").Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var fileNameNoExt in fileNameNoExtArray)
                {
                    if (!string.IsNullOrEmpty(fileNameNoExt))
                    {
                        var url = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + fileNameNoExt + "}&fmt=png&wid=1000";

                        using (var wc = new WebClient())
                        {
                            var fileName = fileNameNoExt + ".png";
                            var cacheFolder = DamToolsHelper.GetCacheFolder();
                            var fullFileName = cacheFolder + fileName;
                            wc.DownloadFile(url, fullFileName);

                            var meta = new MetaData
                            {
                                vendorStudioId = txtVendorId.Text.Trim(),
                                itemIds = new List<string>
                                                     {
                                                         txtItemId.Text.Trim()
                                                     },
                                colorSpace = rbtnSingle.Checked
                                                            ? colorSpace.SingleColor
                                                            : colorSpace.MultipleColor,
                                originalFilename = fileName,
                                filenameNoExtension = fileNameNoExt,
                                processIds = new List<string>
                                                        {
                                                            txtProcessId.Text.Trim()
                                                        }
                            };
                            ret = DamToolsHelper.AddSharedArtwork(fullFileName, meta);

                            if (ret)
                            {
                                successCount += 1;
                            }
                            else
                            {
                                failed += 1;
                            }
                            Thread.Sleep(50);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
            }
            finally
            {
                Enabled = true;

                if (failed == 0)
                {
                    MessageBox.Show($"All succeed! (ok: {successCount})");
                }
                else
                {
                    MessageBox.Show($"Exception happend! (ok: {successCount}, failed: {failed})");
                }
            }
        }
    }
}
