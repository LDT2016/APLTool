using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace APLTools.Advance.UserControls
{
    /// 对象名称：自定义的多行Label控件
    /// 对象说明：相对于原生的Label控件，具备了更好的UI显示效果，多行内容显示时，可以自动显示滚动条。
    [DefaultProperty("Text")]
    public partial class LabelMuti : UserControl
    {
        #region fields

        private bool mutiLine;

        #endregion

        #region constructors

        /// 自定义LabelMuti控件的默认实例化方法。
        public LabelMuti()
        {
            InitializeComponent();
            MutiLine = false;
            Width = 150;
            Height = 24;
            SizeChanged += LabelMuti_SizeChanged;
        }

        #endregion

        #region properties

        /// 获取或设置自定义Label控件的行高。
        [Category("设置")]
        [Description("获取或设置自定义Label控件的行高。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int LineHeight
        {
            get { return LineText.LineHeight; }
            set { LineText.LineHeight = value; }
        }

        /// 获取或设置Label是否为多行模式。
        [Category("设置")]
        [Description("获取或设置Label是否为多行模式")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MutiLine
        {
            get { return mutiLine; }
            set
            {
                mutiLine = value;
                ResetInsideControl();
            }
        }

        /// 获取或设置Label上的文字。
        [Category("设置")]
        [Description("获取或设置Label上的文字。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return LineText.Text; }
            set
            {
                LineText.Text = value;
                ResetInsideControl();
            }
        }

        /// 获取或设置自定义Label控件的前景色。
        [Category("设置")]
        [Description("获取或设置自定义Label控件字体的前景色。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TextColor
        {
            get { return LineText.ForeColor; }
            set { LineText.ForeColor = value; }
        }

        /// 获取或设置自定义Label控件的字体。
        [Category("设置")]
        [Description("获取或设置自定义Label控件的字体。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TextFont
        {
            get { return LineText.Font; }
            set { LineText.Font = value; }
        }

        #endregion

        #region methods

        /// 控件大小发生变更时的事件处理方法。
        private void LabelMuti_SizeChanged(object sender, EventArgs e)
        {
            ResetInsideControl();
        }

        /// 重新设置内部控件的状态。
        private void ResetInsideControl()
        {
            if (mutiLine)
            {
                if (Height < 100)
                {
                    Height = 100;
                }

                LineText.AutoHeight = true;
                LineText.MinimumSize = new Size(0, Height);
                LineText.Width = Width - 20;

                if (LineText.Height <= Height)
                {
                    LineText.Width = Width;
                }

                AutoScroll = true;
            }
            else
            {
                Height = 24;
                LineText.AutoHeight = false;
                LineText.MinimumSize = new Size(0, 24);
                LineText.Width = Width;
                AutoScroll = false;
            }
        }

        #endregion
    }
}
