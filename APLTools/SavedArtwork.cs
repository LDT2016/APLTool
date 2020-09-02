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
using APLTools.Models;

namespace APLTools
{
    public partial class SavedArtwork : Form
    {
       public SavedArtwork()
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var ret = false;
            try
            {
                this.Enabled = false;
                var meta = new MetaData
                {
                    customerNumber = txtCusNum.Text.Trim(),
                    processIds = string.IsNullOrEmpty(txtProcessId.Text.Trim())?null: new List<string> { txtProcessId.Text.Trim() },
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
    }
}
