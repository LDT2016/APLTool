using System;
using System.Windows.Forms;

namespace APLTools.Advance.WinUI.UseImage
{
    public partial class Preview : Form
    {
        #region fields

        private readonly string _filenameNoExtension = string.Empty;

        #endregion

        #region constructors

        public Preview(string filenameNoExtension)
        {
            _filenameNoExtension = filenameNoExtension;
            InitializeComponent();
        }

        private Preview()
        {
            InitializeComponent();
        }

        #endregion

        #region methods

        private void NulcuesShow()
        {
            try
            {
                var url = $"http://nucleus.promotionalstore.com/api/v1/entity/Promo/content/{_filenameNoExtension}/image";
                pictureBox1.Load(url);
                pictureBox1.ShowTooltip(toolTip1, "url copied", 1500);
            }
            catch (Exception exception) { }
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            NulcuesShow();
        }

        #endregion
    }
}
