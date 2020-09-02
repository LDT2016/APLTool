using System;
using System.Drawing;
using System.Windows.Forms;

namespace APLTools.Advance.WinUI.UseImage
{
    public partial class SavedPreview : Form
    {
        #region fields

        private Image _preview;

        #endregion

        #region constructors

        public SavedPreview(Image preview)
        {
            _preview = preview;
            InitializeComponent();
        }

        private SavedPreview()
        {
            InitializeComponent();
        }

        #endregion

        #region methods

        private void NulcuesShow()
        {
            try
            {
                if (_preview != null)
                {
                    pictureBox1.Image = _preview;
                }
            }
            catch (Exception exception) { }
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            NulcuesShow();
        }

        protected override void OnClosed(EventArgs e)
        {
            _preview = null;
            base.OnClosed(e);
        }

        #endregion
    }
}
