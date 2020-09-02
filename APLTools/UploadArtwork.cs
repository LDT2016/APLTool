using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APLTools.Logic;

namespace APLTools
{
    public partial class UploadArtwork : Form
    {
        public UploadArtwork()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var localFullFileName = txtLocalLocation.Text.Trim();
            var damFullFileName = txtTargetLocation.Text.Trim();
            var result = false;
            this.Enabled = false;
            try
            {
                result = DamToolsHelper.UploadFile(localFullFileName, damFullFileName);
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                this.Enabled = true;
                if (result)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                txtLocalLocation.Text = openFileDialog1.FileName;
            }
        }
    }
}
