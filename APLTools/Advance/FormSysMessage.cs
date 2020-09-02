using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using APLTools.Properties;

namespace APLTools.Advance
{
    /// 对象名称：应用程序主窗体（用户界面层）
    /// 对象说明：该窗体用于显示应用程序执行过程的提示信息及异常信息。
    public partial class FormSysMessage : Form
    {
        #region fields

        private static readonly Size detailModeSize = new Size(700, 350);

        #endregion

        #region constructors

        public FormSysMessage()
        {
            InitializeComponent();
        }

        #endregion

        #region methods

        /// 显示异常信息，该方法为静态方法，可以直接进行调用。
        public static void ShowException(Exception exception)
        {
            var formSysMessage = new FormSysMessage();
            formSysMessage.LblMessage.Text = exception.Message;

            if (exception is CustomException)
            {
                var customException = exception as CustomException;

                switch (customException.Type)
                {
                    case ExceptionType.Info: // 提示信息
                        formSysMessage.PicLogo.Image = Resources.TipInfo;
                        formSysMessage.PicTitle.Image = Resources.MessageInfo;

                        break;

                    case ExceptionType.Warn: // 警告信息
                        formSysMessage.PicLogo.Image = Resources.TipWarn;
                        formSysMessage.PicTitle.Image = Resources.MessageWarn;

                        break;

                    default: // 错误信息
                        formSysMessage.PicLogo.Image = Resources.TipError;
                        formSysMessage.PicTitle.Image = Resources.MessageError;

                        break;
                }

                // 判断是否需要显示异常的详细信息，如具体异常原因，执行的SQL语句等。可由App.Config配置。
                if (ConfigurationManager.AppSettings["ShowExceptionDetail"] == "true")
                {
                    if (!string.IsNullOrEmpty(customException.DetailMessage))
                    {
                        formSysMessage.LblDetailMessage.Visible = true;
                        formSysMessage.LblDetailMessage.Text = customException.DetailMessage;
                        formSysMessage.Size = detailModeSize;
                    }
                }
            }

            formSysMessage.ShowDialog();
        }

        /// 显示一般类信息提示。
        public static void ShowMessage(string message)
        {
            var formSysMessage = new FormSysMessage();
            formSysMessage.LblMessage.Text = message;
            formSysMessage.ShowDialog();
        }

        /// 显示操作成功类信息提示，如果App.config中的ShowSuccessMsg为false，将不显示操作成功信息。
        public static void ShowSuccessMsg(string message)
        {
            if (ConfigurationManager.AppSettings["ShowSuccessMsg"] == "true")
            {
                var formSysMessage = new FormSysMessage();
                formSysMessage.LblMessage.Text = message;
                formSysMessage.ShowDialog();
            }
        }

        /// 用户单击“确定”按钮时的事件处理方法。
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
