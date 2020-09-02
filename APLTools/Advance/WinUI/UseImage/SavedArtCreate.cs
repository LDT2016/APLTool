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

        private void button2_Click(object sender, EventArgs e)
        {
            var ret = false;
            try
            {
                this.Enabled = false;
                var meta = new MetaData
                {
                    imageType = imageType.StockArt,
                    stockArtType = stockArtType.DigitalBackground
                };

                ret = DamToolsHelper.AddDigitalBackgroundFile(fullFileName, meta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                this.Enabled = true;
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var ret = false;
            try
            {
                this.Enabled = false;
                var meta = new MetaData
                {
                    customerNumber = txtCusNum.Text.Trim(),
                    processIds = string.IsNullOrEmpty(txtProcessId.Text.Trim()) ? null : new List<string> { txtProcessId.Text.Trim() },
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
                this.Enabled = true;
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

        private void btnSubMultiple_Click(object sender, EventArgs e)
        {
            var ret = false;
            var successCount = 0;
            var failed = 0;
            try
            {
                this.Enabled = false;

                for (var i = 0; i < listSavedFile.Items.Count; i++)
                {
                    var uploadfile = listSavedFile.Items[i].ToString();
                    var meta = new MetaData
                    {
                        customerNumber = txtCusNum.Text.Trim(),
                        processIds = string.IsNullOrEmpty(txtProcessId.Text.Trim()) ? null : new List<string> { txtProcessId.Text.Trim() },
                        imprintFormat = txtImprintFormat.Text.Trim(),
                        sequenceNumber = null,
                        originalFilename = Path.GetFileName(uploadfile)
                    };

                    ret = DamToolsHelper.AddSavedArtwork(uploadfile, meta);

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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                this.Enabled = true;

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
