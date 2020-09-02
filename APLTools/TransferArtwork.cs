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
    public partial class TransferArtwork : Form
    {
        public TransferArtwork()
        {
            InitializeComponent();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            var result = false;
            try
            {
                this.Enabled = false;
                var livePath = txtLive.Text.Trim();
                var devPath = txtDev.Text.Trim();

                result = DamToolsHelper.TransferFromLiveToDev(livePath, devPath);
            }
            catch
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
    }
}
