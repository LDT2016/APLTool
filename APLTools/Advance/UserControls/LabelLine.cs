using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace APLTools.Advance.UserControls
{
    /// 对象名称：自定义的带下划线Label控件
    /// 对象说明：相对于原生的Label控件，具备了更好的UI显示效果，可以通过LineHeight设置行高并增加了下划线。
    [DefaultProperty("Text")]
    public class LabelLine : Label
    {
        #region fields

        private int lineHeight = 24;
        private int showLineCount = 1;
        private int textAreaWidth = 144;
        private int textHeight;
        private List<string> textLines = new List<string>();
        private int textPadTop = 3;

        #endregion

        #region constructors

        /// 自定义Label控件的默认实例化方法。
        public LabelLine()
        {
            AutoSize = false;
            AutoHeight = false;
            Width = 150;
            Height = 24;
            MinimumSize = new Size(30, 24);
            SizeChanged += Control_SizeChanged;
            TextChanged += Control_TextChanged;
            FontChanged += Control_FontChanged;
        }

        #endregion

        #region properties

        /// 获取或设置自定义Label控件是否启用自动高度调整。
        [Category("设置")]
        [Description("获取或设置自定义Label控件是否启用自动高度调整。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AutoHeight { get; set; }

        /// 取消原生的AutoSize属性。
        [Browsable(false)]
        public override bool AutoSize => false;

        /// 获取或设置自定义Label控件的行高。
        [Category("设置")]
        [Description("获取或设置自定义Label控件的行高。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int LineHeight
        {
            get { return lineHeight; }
            set
            {
                lineHeight = value;
                PreparePaintData();
                Refresh();
            }
        }

        #endregion

        #region methods

        /// 重写的重绘事件处理方法。
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            DrawText(g);
            DrawLine(g);
        }

        /// 控件Font属性发生变化时的事件处理方法。
        private void Control_FontChanged(object sender, EventArgs e)
        {
            PreparePaintData();
        }

        /// 控件Size属性发生变化时的事件处理方法。
        private void Control_SizeChanged(object sender, EventArgs e)
        {
            PreparePaintData();
        }

        /// 控件Text属性发生变化时的事件处理方法。
        private void Control_TextChanged(object sender, EventArgs e)
        {
            PreparePaintData();

            if (AutoHeight)
            {
                Height = MinimumSize.Height;

                if (textLines.Count * LineHeight > Height)
                {
                    Height = textLines.Count * LineHeight;
                }
            }

            showLineCount = Height / LineHeight;
        }

        /// 绘制控件上的下划线。
        private void DrawLine(Graphics g)
        {
            var linePen = new Pen(ForeColor);
            linePen.DashStyle = DashStyle.Dash;

            for (var n = 0; n < showLineCount; n++)
            {
                g.DrawLine(linePen, 0, LineHeight * (n + 1) - 1, Width, LineHeight * (n + 1) - 1);
            }
        }

        /// 绘制控件上的文字。
        private void DrawText(Graphics g)
        {
            Brush textBrush = new SolidBrush(ForeColor);

            for (var n = 0; n < textLines.Count; n++)
            {
                g.DrawString(textLines[n], Font, textBrush, 3, LineHeight * n + textPadTop);
            }
        }

        /// 准备绘制前的所需数据。
        private void PreparePaintData()
        {
            textAreaWidth = Width - 6;
            var g = Graphics.FromHwnd(Handle);

            var textSize = g.MeasureString(Text, Font); //文本的矩形区域大小   
            textHeight = Convert.ToInt32(textSize.Height);
            textPadTop = (LineHeight - textHeight) / 2 + 2;

            textLines = new List<string>();
            var lineText = "";

            for (var n = 0; n < Text.Length; n++)
            {
                lineText += Text[n];
                var tmpText = lineText;

                if (n + 1 < Text.Length)
                {
                    tmpText += Text[n + 1];
                }

                textSize = g.MeasureString(tmpText, Font);

                if (Convert.ToInt32(textSize.Width) > textAreaWidth || n == Text.Length - 1)
                {
                    textLines.Add(lineText);
                    lineText = "";
                }
            }

            showLineCount = Height / LineHeight;
        }

        #endregion
    }
}
