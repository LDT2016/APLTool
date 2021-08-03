using System;
using System.Windows.Forms;
using APLTools.Advance.Model;
using APLTools.Advance.WinUI.Devices;
using APLTools.Advance.WinUI.Devices.Main;
using APLTools.Advance.WinUI.Import;
using APLTools.Advance.WinUI.UseImage;

namespace APLTools.Advance
{
    /// 对象名称：应用程序主窗体（用户界面层）
    /// 对象说明：该窗体由上部的Header、左侧的导航栏及中部的模块区域（PnlContent）组成。
    /// 用户通过单击导航栏中的按钮，来切换窗体中部模块区域中的功能模块的显示。
    public partial class FormMain : Form
    {
        #region fields

        private static FormMain instance;

        #endregion

        #region constructors

        /// 私有的窗体实例化方法，创建实例只能通过主窗体的Instance属性实现，以控制主窗体的唯一性。
        public FormMain()
        {
            // 初始化主窗体中的控件，载入默认模块到窗体的PnlContent控件中。
            InitializeComponent();
            //WindowState = FormWindowState.Maximized;

            PnlContent.Controls.Add(SharedArt.Instance);

        }

        #endregion

        #region properties

        /// 返回该窗体的唯一实例。如果之前该窗体没有被创建，进行创建并返回该窗体的唯一实例。
        /// 此处采用单键模式对窗体的唯一实例进行控制，以便外界窗体或控件可以随时访问本窗体。
        public static FormMain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormMain();
                }

                return instance;
            }
        }


        #endregion

        #region methods

        /// 载入一个新的功能模块控件，并将其显示在窗体中部模块区域。
        public static void LoadNewControl(Control control, bool checkLicense = true)
        {
            Instance.PnlContent.Controls.Clear();

            Instance.PnlContent.Controls.Add(control);
        }

        /// 用户单击窗体左侧“导航栏”中按钮时的事件处理方法。
        private void NavBar_ImageButtonClick(object sender, string targetModule)
        {
            switch (targetModule)
            {
                case "Main": // “欢迎使用”功能模块
                    LoadNewControl(Default.Instance);

                    break;

                case "shared":
                    LoadNewControl(SharedArt.Instance);

                    break;

                case "saved":
                    LoadNewControl(SavedArt.Instance);
                    break;

                case "addshared":
                    LoadNewControl(APLTools.Advance.WinUI.UseImage.SharedArtwork.Instance);

                    break;

                case "thumbnaillookup":
                    LoadNewControl(ThumbnailLookup.Instance);

                    break;

                case "addsaved":
                    LoadNewControl(APLTools.Advance.WinUI.UseImage.SavedArtwork.Instance);
                    break;
                
                case "itemids":
                    LoadNewControl(ItemIds.Instance);

                    break;
                case "digital":
                    LoadNewControl(DigitalBackgroundCreate.Instance);
                    break;
                case "bgdown":
                    LoadNewControl(BackgroundProductionFileDownloader.BackgroundProductionFileDownloader.Instance);
                    break;
                case AppToolsTargetModule.ChangeToSvg: // “欢迎使用”功能模块
                    LoadNewControl(ChangeToSVG.Instance);

                    break;
            }
        }

        /// 用户单击窗体左侧“导航栏”中“退出系统”导航条时的事件处理方法。
        private void NavBar_QuitSystemClick(object sender, EventArgs e)
        {
            Close();
            //Application.Exit();
        }

        protected override void OnClosed(EventArgs eventArgs)
        {
            //Application.Exit();
            //            Close();
            //instance.Dispose();
        }
        #endregion
    }
}
