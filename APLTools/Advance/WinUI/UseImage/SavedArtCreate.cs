using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using APLTools.Logic;
using APLTools.Models;

namespace APLTools.Advance.WinUI.UseImage
{
    public partial class SavedArtwork : UserControl
    {
        private enum SavedArtSubmitActionType
        {
            Single,
            Batch
        }
        private BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        private static SavedArtwork instance;

        public static SavedArtwork Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SavedArtwork();
                }

                return instance;
            }
        }

        private SavedArtwork()
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
            var type = (SavedArtSubmitActionType)e.Argument;

            switch (type)
            {
                case SavedArtSubmitActionType.Single:
                    SingleSubmitAction();

                    break;
                case SavedArtSubmitActionType.Batch:
                    BatchSubmitAction();
                    break;
                default:
                    return;
            }
        }



        private string fullFileName;
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                fullFileName = openFileDialog1.FileName;
                lblFileName.Text = Path.GetFileName(fullFileName);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Enabled = false;
            backgroundWorker1.RunWorkerAsync(SavedArtSubmitActionType.Single);
        }

        private void btnSubMultiple_Click(object sender, EventArgs e)
        {
            Enabled = false;
            backgroundWorker1.RunWorkerAsync(SavedArtSubmitActionType.Batch);
        }

        private void SingleSubmitAction()
        {
            var ret = false;

            try
            {
                GetItemIdsAndProcessIds(out _, out var processIds);

                var meta = new MetaData
                {
                    customerNumber = txtCusNum.Text.Trim(),
                    processIds = processIds,
                    imprintFormat = txtImprintFormat.Text.Trim(),
                    sequenceNumber = null,
                    originalFilename = Path.GetFileName(fullFileName)
                };

                ret = DamToolsHelper.AddSavedArtwork(fullFileName, meta);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (backgroundWorker1.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker1.CancelAsync();
                }

                //Enabled = true;
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
        private void BatchSubmitAction()
        {
            var successCount = 0;
            var failed = 0;

            try
            {
                GetItemIdsAndProcessIds(out _, out var processIds);

                for (var i = 0; i < listSavedFile.Items.Count; i++)
                {
                    var uploadfile = listSavedFile.Items[i]
                                                  .ToString();

                    var meta = new MetaData
                    {
                        customerNumber = txtCusNum.Text.Trim(),
                        processIds = processIds,
                        imprintFormat = txtImprintFormat.Text.Trim(),
                        sequenceNumber = null,
                        originalFilename = Path.GetFileName(uploadfile)
                    };

                    if (DamToolsHelper.AddSavedArtwork(uploadfile, meta))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
        private void GetItemIdsAndProcessIds(out List<string> itemIds, out List<string> processIds)
        {
            itemIds = null;
            processIds = null;

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

        private void btnChooseFilePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            var ret = folderBrowserDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                fullFileName = folderBrowserDialog1.SelectedPath;
                txtPath.Text = folderBrowserDialog1.SelectedPath;
                var allfiles = new DirectoryInfo(fullFileName).GetFiles().Select(x => x.FullName).ToArray();
                listSavedFile.Items.Clear();
                listSavedFile.Items.AddRange(allfiles);
                lblUploadFileCount.Text = listSavedFile.Items.Count.ToString();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listSavedFile.SelectedItems.Count > 0)
            {
                var selectedItems = listSavedFile.SelectedItems.Cast<string>().ToList();
                var selectedCount = selectedItems.Count;
                for (var i = 0; i < selectedCount; i++)
                {
                    listSavedFile.Items.Remove(selectedItems[i]);
                }
                lblUploadFileCount.Text = listSavedFile.Items.Count.ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Trim().Length > 0)
            {
                try
                {
                    fullFileName = txtPath.Text.Trim();

                    var allfiles = new DirectoryInfo(fullFileName).GetFiles().Select(x => x.FullName).ToArray();
                    listSavedFile.Items.Clear();
                    listSavedFile.Items.AddRange(allfiles);
                    lblUploadFileCount.Text = listSavedFile.Items.Count.ToString();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }
    }
}
