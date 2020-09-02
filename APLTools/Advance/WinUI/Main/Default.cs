using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace APLTools.Advance.WinUI.Devices.Main
{
    /// 对象名称：“欢迎使用”用户控件（用户界面层）
    /// 对象说明：用户进入系统时，用于显时系统相关欢迎信息的模块。
    public partial class Default : UserControl
    {
        #region fields

        private static Default instance;

        #endregion

        #region constructors

        /// 私有的控件实例化方法，创建实例只能通过该控件的Instance属性实现。
        private Default()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region properties

        /// 返回一个该控件的实例。如果之前该控件已经被创建，直接返回已创建的控件。
        /// 此处采用单键模式对控件实例进行缓存，避免因界面切换重复创建和销毁对象。
        public static Default Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Default();
                }

                return instance;
            }
        }

        #endregion

        private void button2_Click(object sender, System.EventArgs e)
        {

        }

    }
}
