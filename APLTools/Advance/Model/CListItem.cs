using System;

namespace APLTools.Advance.Model
{
    [Serializable]
    public class CListItem
    {
        #region fields

        #endregion

        #region constructors
        public CListItem()
        {
        }

        public CListItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public CListItem(string text)
        {
            Text = text;
            Value = text;
        }

        #endregion

        #region properties

        public string Text { get; set; }
        public string Value { get; set; }

        #endregion

        #region methods

        public override string ToString()
        {
            return Text;
        }

        #endregion
    }
}
