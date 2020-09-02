using System;
using System.Drawing;
using System.Windows.Forms;

namespace APLTools.Advance
{
    public static class DataValid
    {
        #region methods

        public static byte[] GetBinary(this object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                return (byte[])obj;
            }

            return null;
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个布尔（bool)类型返回。
        public static bool GetBool(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            value = value.Trim();

            return Convert.ToBoolean(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个byte类型返回。
        public static byte GetByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new byte();
            }

            value = value.Trim();

            return Convert.ToByte(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个char类型返回。
        public static char GetChar(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new char();
            }

            value = value.Trim();

            return Convert.ToChar(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个DateTime类型返回。
        public static DateTime GetDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new DateTime(1900, 1, 1);
            }

            value = value.Trim();

            return Convert.ToDateTime(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个Decimal类型返回。
        public static decimal GetDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToDecimal(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个double类型返回。
        public static double GetDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToDouble(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个float类型返回。
        public static float GetFloat(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToSingle(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个Guid类型返回。
        public static Guid GetGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Guid.Empty;
            }

            value = value.Trim();

            return new Guid(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个int类型返回。
        public static int GetInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToInt32(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个int类型返回。
        public static int GetIntOrZero(this string value)
        {
            try
            {
                return Convert.ToInt32(value.Trim());
            }
            catch
            {
                return 0;
            }
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个long类型返回。
        public static long GetLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToInt64(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个sbyte类型返回。
        public static sbyte GetSByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new sbyte();
            }

            value = value.Trim();

            return Convert.ToSByte(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个short类型返回。
        public static short GetShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToInt16(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，Trim()后返回该字符串。
        public static string GetString(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            value = value.Trim();

            return value;
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个uint类型返回。
        public static uint GetUInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToUInt32(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个ulong类型返回。
        public static ulong GetULong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToUInt64(value);
        }

        /// 对所传入的字符串进行判断，如果字符串为空，直接返回null值。
        /// 如字符串不为空，尝试将该字符串转换为一个ushort类型返回。
        public static ushort GetUShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            value = value.Trim();

            return Convert.ToUInt16(value);
        }

        /// 判断一个字符串是否是一个有效的布尔（bool)类型。
        public static bool IsBool(this string value)
        {
            try
            {
                Convert.ToBoolean(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的正整数。
        public static bool IsByte(this string value)
        {
            try
            {
                Convert.ToByte(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的Char类型。
        public static bool IsChar(this string value)
        {
            try
            {
                Convert.ToChar(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的日期。
        public static bool IsDateTime(this string value)
        {
            try
            {
                Convert.ToDateTime(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的数字。
        public static bool IsDecimal(this string value)
        {
            try
            {
                Convert.ToDecimal(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的数字。
        public static bool IsDouble(this string value)
        {
            try
            {
                Convert.ToDouble(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的数字。
        public static bool IsFloat(this string value)
        {
            try
            {
                Convert.ToSingle(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的Guid。
        public static bool IsGuid(this string value)
        {
            try
            {
                var guid = new Guid(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的整数。
        public static bool IsInt(this string value)
        {
            try
            {
                Convert.ToInt32(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的整数。
        public static bool IsLong(this string value)
        {
            try
            {
                Convert.ToInt64(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个对象是否为空，如传入对象为string类型，
        /// 该方法会判断所传入的string是否包含内容。
        public static bool IsNull(this object obj)
        {
            if (obj == null)
            {
                return true;
            }

            if (obj is string)
            {
                var tmpStr = (string)obj;

                return string.IsNullOrEmpty(tmpStr.Trim());
            }

            return false;
        }

        public static bool IsNullDateTime(this DateTime obj)
        {
            if (obj.Year == 1900 && obj.Month == 1 && obj.Day == 1)
            {
                return true;
            }

            return false;
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的布尔（bool)类型。
        public static bool IsNullOrBool(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToBoolean(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的正整数。
        public static bool IsNullOrByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToByte(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的Char类型。
        public static bool IsNullOrChar(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToChar(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的日期。
        public static bool IsNullOrDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToDateTime(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的数字。
        public static bool IsNullOrDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToDecimal(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的数字。
        public static bool IsNullOrDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToDouble(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的数字。
        public static bool IsNullOrFloat(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToSingle(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的Guid。
        public static bool IsNullOrGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                var guid = new Guid(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的整数。
        public static bool IsNullOrInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToInt32(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的整数。
        public static bool IsNullOrLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToInt64(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的整数。
        public static bool IsNullOrSByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToSByte(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的整数。
        public static bool IsNullOrShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToInt16(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的正整数。
        public static bool IsNullOrUInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToUInt32(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的正整数。
        public static bool IsNullOrULong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToUInt64(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否为空，当所传入的字符串不会空时，
        /// 将检测该字符串是否是一个有效的正整数。
        public static bool IsNullOrUShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            value = value.Trim();

            try
            {
                Convert.ToUInt16(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断所传入字符串的长度，是否超过指定长度。
        /// 如果字符串为空或null，返回false。
        public static bool IsOutLength(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            if (value.Length > maxLength)
            {
                return true;
            }

            return false;
        }

        /// 判断一个字符串是否是一个有效的整数。
        public static bool IsSByte(this string value)
        {
            try
            {
                Convert.ToSByte(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的整数。
        public static bool IsShort(this string value)
        {
            try
            {
                Convert.ToInt16(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的正整数。
        public static bool IsUInt(this string value)
        {
            try
            {
                Convert.ToUInt32(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的正整数。
        public static bool IsULong(this string value)
        {
            try
            {
                Convert.ToUInt64(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 判断一个字符串是否是一个有效的正整数。
        public static bool IsUShort(this string value)
        {
            try
            {
                Convert.ToUInt16(value.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static TEnum ToEnumAdvance<TEnum>(this string str) where TEnum : struct
        {
            TEnum flag;
            Enum.TryParse(str, out flag);

            return flag;
        }

        #endregion
    }

    public static class TooltipToolV2
    {
        /// <summary>
        /// 为控件提供Tooltip
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="tip">ToolTip</param>
        /// <param name="message">提示消息</param>
        public static void ShowTooltip(this Control control, ToolTip tip, string message)
        {
            Point _mousePoint = Control.MousePosition;
            int _x = control.PointToClient(_mousePoint).X;
            int _y = control.PointToClient(_mousePoint).Y;
            tip.Show(message, control, _x, _y);
            tip.Active = true;
        }
        /// <summary>
        /// 为控件提供Tooltip
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="tip">ToolTip</param>
        /// <param name="message">提示消息</param>
        /// <param name="durationTime">保持提示的持续时间</param>
        public static void ShowTooltip(this Control control, ToolTip tip, string message, int durationTime)
        {
            Point _mousePoint = Control.MousePosition;
            int _x = control.PointToClient(_mousePoint).X;
            int _y = control.PointToClient(_mousePoint).Y;
            tip.Show(message, control, _x, _y, durationTime);
            tip.Active = true;
        }
        /// <summary>
        /// 为控件提供Tooltip
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="tip">ToolTip</param>
        /// <param name="message">提示消息</param>
        /// <param name="xoffset">水平偏移量</param>
        /// <param name="yoffset">垂直偏移量</param>
        public static void ShowTooltip(this Control control, ToolTip tip, string message, int xoffset, int yoffset)
        {
            Point _mousePoint = Control.MousePosition;
            int _x = control.PointToClient(_mousePoint).X;
            int _y = control.PointToClient(_mousePoint).Y;
            tip.Show(message, control, _x + xoffset, _y + yoffset);
            tip.Active = true;
        }
        /// <summary>
        /// 为控件提供Tooltip
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="tip">ToolTip</param>
        /// <param name="message">提示消息</param>
        /// <param name="xoffset">水平偏移量</param>
        /// <param name="yoffset">垂直偏移量</param>
        /// <param name="durationTime">保持提示的持续时间</param>
        public static void ShowTooltip(this Control control, ToolTip tip, string message, int xoffset, int yoffset, int durationTime)
        {
            Point _mousePoint = Control.MousePosition;
            int _x = control.PointToClient(_mousePoint).X;
            int _y = control.PointToClient(_mousePoint).Y;
            tip.Show(message, control, _x + xoffset, _y + yoffset, durationTime);
            tip.Active = true;
        }
    }

}
