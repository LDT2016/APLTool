using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private enum SharedArtSubmitActionType
        {
            Single,
            Batch
        }
        private BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        #endregion

        #region constructors

        private SharedArtwork()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var type = (SharedArtSubmitActionType)e.Argument;

            switch (type)
            {
                case SharedArtSubmitActionType.Single:
                    SingleSubmitAction();

                    break;
                case SharedArtSubmitActionType.Batch:
                    BatchSubmitAction();
                    break;
                default:
                    return;
            }
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
            Enabled = false;

            backgroundWorker1.RunWorkerAsync(SharedArtSubmitActionType.Single);
        }

        private void SingleSubmitAction()
        {
            var ret = false;

            try
            {
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

                        GetItemIdsAndProcessIds(out var itemIds, out var processIds);

                        var meta = new MetaData
                        {
                            vendorStudioId = txtVendorId.Text.Trim(),
                            colorSpace = rbtnSingle.Checked
                                                        ? colorSpace.SingleColor
                                                        : colorSpace.MultipleColor,
                            originalFilename = fileName,
                            filenameNoExtension = fileNameNoExt,



                            itemIds = itemIds,
                            processIds = processIds
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
                if (backgroundWorker1.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker1.CancelAsync();
                }

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

        private void GetItemIdsAndProcessIds(out List<string> itemIds, out List<string> processIds)
        {
            itemIds = null;
            processIds = null;

            if (txtItemId.Text.Trim()
                         .Length
                > 0)
            {
                if (txtItemId.Text.Trim()
                             .IndexOf(";", StringComparison.Ordinal)
                    > -1)
                {
                    itemIds = txtItemId.Text.Trim()
                                       .Replace("\r\n", ";")
                                       .Replace(" ", string.Empty)
                                       .Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                       .ToList();

                }
                else
                {
                    itemIds = new List<string>
                              {
                                  txtItemId.Text.Replace(" ", string.Empty)
                              };
                }
            }

            if (txtProcessId.Text.Trim()
                            .Length
                > 0)
            {
                if (txtProcessId.Text.Trim()
                                .IndexOf(";", StringComparison.Ordinal)
                    > -1)
                {
                    processIds = txtProcessId.Text.Trim()
                                             .Replace("\r\n", ";")
                                             .Replace(" ", string.Empty)
                                             .Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                             .ToList();

                }
                else
                {
                    processIds = new List<string>
                                 {
                                     txtProcessId.Text.Replace(" ", string.Empty)
                                 };
                }
            }

        }

        private void btnBatchSubmit_Click(object sender, EventArgs e)
        {
            Enabled = false;

            backgroundWorker1.RunWorkerAsync(SharedArtSubmitActionType.Batch);
        }

        private void BatchSubmitAction()
        {
            var ret = false;
            var successCount = 0;
            var failed = 0;
            try
            {

                var fileNames = txtNecleusBatchEnter.Text.Trim();
                var fileNameNoExtArray = fileNames.Replace("\r\n", ";").Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                GetItemIdsAndProcessIds(out var itemIds, out var processIds);

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
                                itemIds = itemIds,
                                colorSpace = rbtnSingle.Checked
                                                            ? colorSpace.SingleColor
                                                            : colorSpace.MultipleColor,
                                originalFilename = fileName,
                                filenameNoExtension = fileNameNoExt,
                                processIds = processIds
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
                if (backgroundWorker1.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker1.CancelAsync();
                }

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
    }
}
