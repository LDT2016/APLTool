using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APLTools.Logic;
using APLTools.Models;

namespace APLTools
{
    public partial class SharedArtwork : Form
    {
        public SharedArtwork()
        {
            InitializeComponent();
        }

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
                this.Enabled = false;
                var fileNameNoExt = cbFileNames.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(fileNameNoExt))
                {
                    var url = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" +
                      fileNameNoExt + "}&fmt=png&wid=1000";
                    using (WebClient wc = new WebClient())
                    {
                        var fileName = fileNameNoExt + ".png";
                        var cacheFolder = DamToolsHelper.GetCacheFolder();
                        var fullFileName = cacheFolder + fileName;
                        wc.DownloadFile(url, fullFileName);
                        var meta = new MetaData
                        {
                            vendorStudioId = txtVendorId.Text.Trim(),
                            itemIds = new List<string> { txtItemId.Text.Trim() },
                            colorSpace = rbtnSingle.Checked ? colorSpace.SingleColor : colorSpace.MultipleColor,
                            originalFilename = fileName,
                            filenameNoExtension = fileNameNoExt
                        };
                        ret = DamToolsHelper.AddSharedArtwork(fullFileName, meta);
                    }
                }
            }
            catch(Exception ex)
            {
                ret = false;
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

        private void cbFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var fileName = cbFileNames.SelectedItem.ToString()
                                          .Trim();
                var url = "http://images.promotionalstore.com/is/image/PromotionalStore/i?src=is{PromotionalStore/" + fileName + "}&fmt=png&$Studio_SharedD$";
                //url = "http://nucleus.promotionalstore.com/api/v1/entity/Promo/content/Blk-37-002/image";
                WebClient wc = new WebClient();
                var fileBytes = wc.DownloadData(url);
                MemoryStream ms = new MemoryStream(fileBytes);
                pbPreview.Image = Image.FromStream(ms);
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
    }
}
