using System.Collections.Generic;
using System.Data;
using APLTools.Advance.Model;

namespace APLTools.Advance.BLL
{
    /// 业务逻辑类 ImprintFormat
    public class ImprintFormat
    {
        #region fields

        private static DAL.ImprintFormat dal;

        #endregion

        #region constructors

        public ImprintFormat()
        {
            dal = new DAL.ImprintFormat();
        }

        #endregion

        #region methods

      

        public List<Model.ImprintFormat> GetMultipleFormats(string itemId)
        {
            var lst = dal.GetMultipleFormats(itemId);

            if (lst.Count == 0)
            {
                lst = dal.GetDefaultFormats(itemId);
            }
            return lst;
        }


        #endregion
    }
}
