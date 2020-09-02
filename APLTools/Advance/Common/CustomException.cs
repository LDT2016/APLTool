using System;

namespace APLTools.Advance
{
    /// 对象名称：系统自定义异常类
    /// 对象说明：继承自应用程序异常类，扩展了异常类型和详细信息属性。
    public class CustomException : ApplicationException
    {
        #region constructors

        /// 系统自定义异常类，默认实例化方法，异常类型为警告。
        /// <param name="message">异常信息</param>
        public CustomException(string message) : base(message)
        {
            Type = ExceptionType.Warn;
        }

        /// 系统自定义异常类，扩展实例化方法，可以指定异常类型。
        /// <param name="message">异常信息</param>
        /// <param name="type">异常类型</param>
        public CustomException(string message, ExceptionType type) : base(message)
        {
            Type = type;
        }

        /// 系统自定义异常类，扩展实例化方法，可以指定异常类型及异常详细信息。
        /// <param name="message">异常信息</param>
        /// <param name="type">异常类型</param>
        /// <param name="detailMessage">异常详细信息</param>
        public CustomException(string message, ExceptionType type, string detailMessage) : base(message)
        {
            Type = type;
            DetailMessage = detailMessage;
        }

        #endregion

        #region properties

        /// 异常详细信息
        public string DetailMessage { get; set; }

        /// 异常类型
        public ExceptionType Type { get; set; }

        #endregion
    }

    /// 异常类型枚举，分别为提示、警告、错误。
    public enum ExceptionType
    {
        Info,
        Warn,
        Error
    }
}
