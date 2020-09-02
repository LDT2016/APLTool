using System;
using System.Text;

namespace APLTools.Advance.Model
{
    public class ImprintFormat
    {
        #region fields

        private const string DASH = "-";

        #endregion

        #region properties
        /// RowNum
        public int RowNum { get; set; } = 0;

        public string Description { get; set; }
        public string ImprintAreaCode { get; set; }
        public string ImprintGroup { get; set; }
        public string ImprintRule { get; set; }
        public bool IsDefault { get; set; }
        public bool IsInsideCover => Description.IndexOf("inside", StringComparison.OrdinalIgnoreCase) >= 0;

        public string Key
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append(ImprintAreaCode);
                builder.Append(DASH);
                builder.Append(Location);
                builder.Append(DASH);
                builder.Append(StyleId);

                return builder.ToString();
            }
        }

        public string Location { get; set; }
        public bool LogoOnly { get; set; }
        public int ProcessId { get; set; }
        public int Sequence { get; set; }
        public bool ShowOnWeb { get; set; }
        public string StyleId { get; set; }

        #endregion
    }
}
