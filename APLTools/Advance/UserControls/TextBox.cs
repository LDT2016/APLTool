using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace APLTools.Advance.UserControls
{
    /// 对象名称：自定义的TextBox控件
    /// 对象说明：相对于原生的TextBox控件，具备了更好的UI显示效果。
    [DefaultProperty("Text")]
    public partial class TextBox : UserControl
    {
        #region constructors

        /// 自定义TextBox控件的默认实例化方法。使用本自定义Button控件前，请确保
        /// 应用程序的Properties.Resources资源文件中，包含了1张名为Input的图片。
        public TextBox()
        {
            InitializeComponent();
            TxtInside.BackColor = Color.White;
            TxtInside.Location = new Point(3, 6);
            TxtInside.Width = PnlWhiteBG.Width - 6;
            TxtInside.Height = PnlWhiteBG.Height - 12;
            TxtInside.GotFocus += TxtBox_GotFocus;
            TxtInside.Leave += TxtBox_Leave;
        }

        #endregion

        #region properties

        /// 获取或设置是否为多行文本框。
        [Category("设置")]
        [Description("获取或设置是否为多行文本框。")]
        [Browsable(true)]
        public bool Multiline
        {
            get { return TxtInside.Multiline; }
            set { TxtInside.Multiline = value; }
        }

        /// 获取或设置密码字符。
        [Category("设置")]
        [Description("获取或设置密码字符。")]
        [Browsable(true)]
        public char PasswordChar
        {
            get { return TxtInside.PasswordChar; }
            set { TxtInside.PasswordChar = value; }
        }

        /// 获取或设置文本框的滚动条显示方式。
        [Category("设置")]
        [Description("获取或设置文本框的滚动条显示方式。")]
        [Browsable(true)]
        public ScrollBars ScrollBars
        {
            get { return TxtInside.ScrollBars; }
            set { TxtInside.ScrollBars = value; }
        }

        /// 获取或设置文本框中的内容。
        [Category("设置")]
        [Description("获取或设置文本框中的内容。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return TxtInside.Text; }
            set { TxtInside.Text = value; }
        }

        #endregion

        #region methods

        /// 可以手动通过该方法，使TextBox获得输入焦点。
        public new void Focus()
        {
            TxtInside.Select();
        }

        /// TextBox控件大小改变时的事件处理。
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (!Multiline)
            {
                Height = 27;
            }

            TxtInside.Location = new Point(3, 5);
            TxtInside.Width = PnlWhiteBG.Width - 6;
            TxtInside.Height = PnlWhiteBG.Height - 12;
        }

        /// 获得输入焦点时，改变相关子控件的颜色。
        private void TxtBox_GotFocus(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(179, 221, 150);
            PnlBorder.BackColor = Color.FromArgb(87, 152, 43);
            TxtInside.ForeColor = Color.FromArgb(51, 102, 0);
        }

        /// 输入焦点丢失时，改变相关子控件的颜色。
        private void TxtBox_Leave(object sender, EventArgs e)
        {
            BackColor = Color.White;
            PnlBorder.BackColor = Color.FromArgb(204, 204, 204);
            TxtInside.ForeColor = Color.FromArgb(102, 102, 102);
        }

        #endregion
    }
}
