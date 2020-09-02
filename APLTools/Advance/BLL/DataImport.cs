using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APLTools.Models;

namespace APLTools.Advance.BLL
{
    public class DataImport
    {
        private static DAL.DataImport dal;
        public DataImport()
        {
            dal = new DAL.DataImport();
        }

        public void ItemIds(string[] ids, DataImportConnectionType type = DataImportConnectionType.Loacal)
        {
            dal.ItemIds(ids, type);
        }
        public void CardIds(string[] ids, DataImportConnectionType type = DataImportConnectionType.Loacal)
        {
            dal.CartIds(ids, type);
        }

    }
}
