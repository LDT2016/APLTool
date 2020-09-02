using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APLTools.Logic;
using APLTools.Models;

namespace APLTools
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void OpenWindow(WindowType type)
        {
            switch (type)
            {
                case WindowType.SharedArtwork:
                    var form1 = new SharedArtwork();
                    form1.Show();
                    break;
                case WindowType.SavedArtwork:
                    var form2 = new SavedArtwork();
                    form2.Show();
                    break;
                case WindowType.UploadArtwork:
                    var form3 = new UploadArtwork();
                    form3.Show();
                    break;
                case WindowType.TransferArtwrok:
                    var form4 = new TransferArtwork();
                    form4.Show();
                    break;
                case WindowType.CheckDigitalBackground:
                    var form5 = new CheckDigitalBackground();
                    form5.Show();
                    break;
            }
        }
        private void btnSharedArtwork_Click(object sender, EventArgs e)
        {
            OpenWindow(WindowType.SharedArtwork);
        }

        private void btnSavedArtwork_Click(object sender, EventArgs e)
        {
            OpenWindow(WindowType.SavedArtwork);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenWindow(WindowType.UploadArtwork);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            OpenWindow(WindowType.TransferArtwrok);
        }

        private void btnCheckDigitalBackground_Click(object sender, EventArgs e)
        {
            OpenWindow(WindowType.CheckDigitalBackground);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            APLTools.Advance.FormMain.Instance.ShowDialog();
        }
    }
}
