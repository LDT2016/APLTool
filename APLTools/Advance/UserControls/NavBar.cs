using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using APLTools.Advance.Model;
using APLTools.Properties;

namespace APLTools.Advance.UserControls
{
    /// 对象名称：导航栏类
    /// 对象说明：主要显示系统左侧的导航栏。
    public partial class NavBar : UserControl
    {
        #region delegates

        public delegate void ButtonClickHander(object sender, string targetModule);

        #endregion

        #region fields

        /// 当前导航栏中选中的导航条编号
        private int CurrentGroupIndex;

        /// 说明：导航栏初始的功能模块列表，可以通过定义此列表设置导航栏中的导航条及图片按扭。
        /// 注意：这里定义的是一个私有的List类型变量NavButtonGroup，并不是一个私有的函数方法。
        private readonly List<ButtonGroup> NavButtonGroup = new List<ButtonGroup>
                                                            {
                                                                new ButtonGroup("Welcome")
                                                                {
                                                                    ImageButtons = GetNarBar()
                                                                },
                                                                new ButtonGroup("Exit")
                                                            };

        private static List<ImageButton> GetNarBar()
        {
            return new List<ImageButton>
                   {
                       new ImageButton("Shared Art Add", "addshared", Resources.category),
                       new ImageButton("Saved Art Add", "addsaved", Resources.category),
                       new ImageButton("Shared Art Search", "shared", Resources.devices),
                       new ImageButton("Saved Art Search", "saved", Resources.devices),
                       new ImageButton("Digital Background Add", "digital", Resources.category),
                       new ImageButton("Background Download", "bgdown", Resources.category),
                       new ImageButton("ChangeToSVG", AppToolsTargetModule.ChangeToSvg, Resources.category),
                       //new ImageButton("ItemIds Import", "itemids", Resources.category)
                   };
        }

        #endregion

        #region constructors

        /// 导航栏类的默认实例化方法，该方法在控件正式显示之前执行，
        /// 可以根据需要在此方法中对 NavButtonGroup列表进行重新定义。
        public NavBar()
        {
            InitializeComponent();

            ////示例：根据用户角色修改导航条
            //if(!NowUser.IsAdministrator)                      //如果不是管理员
            //{
            //    NavButtonGroup.RemoveAt(2);                   //删除导航栏中第3组导般条
            //    NavButtonGroup[1].ImageButtons.RemoveAt(0);   //删除导航栏中第2组导般条中的第1个图像按钮
            //}

            InitNavBar(); // 初始化导航栏，该方法必须在NavButtonGroup重新调整后执行
        }

        #endregion

        #region events

        public event ButtonClickHander ImageButtonClick;
        public event EventHandler QuitSystemClick;

        #endregion

        #region methods

        /// 导航栏中的图片按钮单击事件处理
        private void ImageButton_Click(object sender, string targetModule)
        {
            if (ImageButtonClick != null)
            {
                ImageButtonClick(sender, targetModule);
            }
        }

        /// 初始化导航栏
        private void InitNavBar()
        {
            Dock = DockStyle.Left;
            var barHeight = 22;

            for (var n = 0; n < NavButtonGroup.Count; n++)
            {
                var buttonGroup = NavButtonGroup[n];
                buttonGroup.Left = 2;
                buttonGroup.Tag = n;
                buttonGroup.TitleBarClick += TitleBar_Click;
                buttonGroup.ImageButtonClick += ImageButton_Click;
                buttonGroup.InitImageButtons();
                PnlBackGround.Controls.Add(buttonGroup);
            }

            PnlBottomLine.Top = PnlBackGround.Height - (NavButtonGroup.Count - CurrentGroupIndex - 1) * barHeight;
            ResetNavBar();
        }

        /// 导航条大小发生变更时，重新设置导航条的布局。
        private void NavBar_SizeChanged(object sender, EventArgs e)
        {
            ResetNavBar();
        }

        /// 重新设置导航栏的布局。
        private void ResetNavBar()
        {
            var barHeight = 22;

            for (var n = 0; n < NavButtonGroup.Count; n++)
            {
                var buttonGroup = NavButtonGroup[n];

                if (n <= CurrentGroupIndex)
                {
                    buttonGroup.Top = 1 + n * barHeight;
                }
                else
                {
                    buttonGroup.Top = PnlBackGround.Height - (NavButtonGroup.Count - n) * barHeight;
                }

                if (n == CurrentGroupIndex)
                {
                    buttonGroup.Height = PnlBackGround.Height - (NavButtonGroup.Count - 1) * barHeight;
                }
                else
                {
                    buttonGroup.Height = barHeight;
                }
            }

            PnlBottomLine.Top = PnlBackGround.Height - (NavButtonGroup.Count - CurrentGroupIndex - 1) * barHeight - 1;
        }

        /// 导航栏中的导航条单击事件处理
        private void TitleBar_Click(object sender, EventArgs e)
        {
            if (sender is ButtonGroup)
            {
                var buttonGroup = (ButtonGroup)sender;

                if (buttonGroup.Text == "Exit")
                {
                    if (QuitSystemClick != null)
                    {
                        QuitSystemClick(buttonGroup, e);
                    }

                    return;
                }

                CurrentGroupIndex = (int)buttonGroup.Tag;
                ResetNavBar();
            }
        }

        #endregion

        #region nested types

        /// 导航栏中的导航条
        public class ButtonGroup : UserControl
        {
            #region fields

            private readonly Panel ButtonArea = new Panel();
            private readonly Label TitleBar = new Label();

            #endregion

            #region constructors

            public ButtonGroup(string text)
            {
                Text = text;
                InitializeControl();
            }

            #endregion

            #region events

            public event ButtonClickHander ImageButtonClick;
            public event EventHandler TitleBarClick;

            #endregion

            #region properties

            /// <summary>
            /// 导航条所包含或关联的图片按钮
            /// </summary>
            public List<ImageButton> ImageButtons { get; set; } = new List<ImageButton>();

            /// <summary>
            /// 导航条上的标题栏的文字
            /// </summary>
            public new string Text
            {
                get
                {
                    return TitleBar.Text;
                }
                set
                {
                    TitleBar.Text = value;
                }
            }

            #endregion

            #region methods

            /// <summary>
            /// 初始化导航条所包含或关联的图片按钮
            /// </summary>
            public void InitImageButtons()
            {
                var imageButtonHeight = 70;

                //
                // 导航条上的按钮区域（Panel)
                //
                ButtonArea.Location = new Point(0, 22);
                ButtonArea.Size = new Size(153, imageButtonHeight * ImageButtons.Count);

                //
                // 导航条上的图片按钮
                //
                for (var n = 0; n < ImageButtons.Count; n++)
                {
                    var imageButton = ImageButtons[n];
                    imageButton.Left = 0;
                    imageButton.Top = n * imageButtonHeight;
                    imageButton.ImageButtonClick += ImageButton_Click;
                    ButtonArea.Controls.Add(imageButton);
                }
            }

            /// <summary>
            /// 单击图片按钮事件处理
            /// </summary>
            private void ImageButton_Click(object sender, string targetModule)
            {
                if (ImageButtonClick != null)
                {
                    ImageButtonClick(sender, targetModule);
                }
            }

            /// <summary>
            /// 初始化导航条
            /// </summary>
            private void InitializeControl()
            {
                //
                // 导航条上的标题栏
                //
                TitleBar.Cursor = Cursors.Hand;
                TitleBar.TextAlign = ContentAlignment.MiddleCenter;
                TitleBar.ForeColor = Color.FromArgb(102, 102, 102);
                TitleBar.Location = new Point(0, 0);
                TitleBar.Size = new Size(153, 22);
                //TitleBar.BackgroundImage = Resources.NavBarBG01;
                TitleBar.MouseMove += TitleBar_MouseMove;
                TitleBar.MouseLeave += TitleBar_MouseLeave;
                TitleBar.Click += TitleBar_Click;

                //
                //ButtonGroup导航条 
                //
                Width = 153;
                Height = 22;
                Controls.Add(TitleBar);
                Controls.Add(ButtonArea);
            }

            /// <summary>
            /// 单击导航条上的标题事件处理
            /// </summary>
            private void TitleBar_Click(object sender, EventArgs e)
            {
                if (TitleBarClick != null)
                {
                    TitleBarClick(this, e);
                }
            }

            /// <summary>
            /// 鼠标从导航条上的标题上移开时事件处理
            /// </summary>
            private void TitleBar_MouseLeave(object sender, EventArgs e)
            {
                if (sender is Label)
                {
                    var tmpLabel = (Label)sender;
                    tmpLabel.BackgroundImage = Resources.NavBarBG01;
                }
            }

            /// <summary>
            /// 鼠标移动到导航条上的标题上时事件处理
            /// </summary>
            private void TitleBar_MouseMove(object sender, MouseEventArgs e)
            {
                if (sender is Label)
                {
                    var tmpLabel = (Label)sender;
                    tmpLabel.BackgroundImage = Resources.NavBarBG02;
                }
            }

            #endregion
        }

        /// 导航栏中的图片按钮
        public class ImageButton : UserControl
        {
            #region fields

            private readonly PictureBox ButtonImage = new PictureBox();
            private readonly Label ButtonText = new Label();

            #endregion

            #region constructors

            public ImageButton(string text, string targetModule, Image image)
            {
                Text = text;
                TargetModule = targetModule;
                Image = image;
                InitializeControl();
            }

            #endregion

            #region events

            public event ButtonClickHander ImageButtonClick;

            #endregion

            #region properties

            /// <summary>
            /// 图片按钮中显示的图片
            /// </summary>
            public Image Image
            {
                get
                {
                    return ButtonImage.Image;
                }
                set
                {
                    ButtonImage.Image = value;
                }
            }

            /// <summary>
            /// 用户点击图片按钮后，期望转向的模块名称
            /// </summary>
            public string TargetModule
            {
                get; set;
            }

            /// <summary>
            /// 图片按钮中图片下方的文字
            /// </summary>
            public new string Text
            {
                get
                {
                    return ButtonText.Text;
                }
                set
                {
                    ButtonText.Text = value;
                }
            }

            #endregion

            #region methods

            /// <summary>
            /// 图片按钮单击事件处理
            /// </summary>
            private void ButtonImage_Click(object sender, EventArgs e)
            {
                if (ImageButtonClick != null)
                {
                    ImageButtonClick(this, TargetModule);
                }
            }

            /// <summary>
            /// 鼠标从图片按钮上移开时事件处理
            /// </summary>
            private void ButtonImage_MouseLeave(object sender, EventArgs e)
            {
                if (sender is PictureBox)
                {
                    var tmpPictureBox = (PictureBox)sender;
                    tmpPictureBox.BackgroundImage = null;
                }
            }

            /// <summary>
            /// 鼠标移动到图片按钮上时事件处理
            /// </summary>
            private void ButtonImage_MouseMove(object sender, MouseEventArgs e)
            {
                if (sender is PictureBox)
                {
                    var tmpPictureBox = (PictureBox)sender;
                    tmpPictureBox.BackgroundImage = Resources.NavBtnBG;
                }
            }

            /// <summary>
            /// 初始化图片按钮
            /// </summary>
            private void InitializeControl()
            {
                //
                // 图像按钮上的图像
                //
                ButtonImage.Cursor = Cursors.Hand;
                ButtonImage.Location = new Point(56, 12);
                ButtonImage.Size = new Size(40, 40);
                ButtonImage.MouseMove += ButtonImage_MouseMove;
                ButtonImage.MouseLeave += ButtonImage_MouseLeave;
                ButtonImage.Click += ButtonImage_Click;
                ButtonImage.SizeMode = PictureBoxSizeMode.CenterImage;

                //
                // 图像按钮上的文字
                //
                ButtonText.TextAlign = ContentAlignment.MiddleCenter;
                ButtonText.ForeColor = Color.FromArgb(68, 68, 68);
                ButtonText.Location = new Point(0, 55);
                ButtonText.Size = new Size(153, 15);

                //
                //ImageButton图像按钮 
                //
                Width = 153;
                Height = 70;
                Controls.Add(ButtonText);
                Controls.Add(ButtonImage);
            }

            #endregion
        }

        #endregion
    }
}
