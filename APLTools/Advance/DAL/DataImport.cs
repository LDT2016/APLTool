using System;
using System.Data;
using System.Linq;
using APLTools.Advance.DBUtility;
using APLTools.Models;

namespace APLTools.Advance.DAL
{
    public class DataImport : DALHelper
    {
        public void ItemIds(string[] ids, DataImportConnectionType type)
        {
            var vals = ids.Aggregate(string.Empty, (x, y) => x + $"('{y}'),")
                          .TrimEnd(",".ToCharArray());

            var sql = $@"use Performance_LIVE
                insert into IMPData20161124_ItemID(ItemID)
                select*from(
                values
                 {vals}
                ) a(b)";

            var dbHelper = LocalDbHelper;
            switch (type)
            {
                case DataImportConnectionType.Loacal:
                    dbHelper = LocalIMPDataHelper;
                    break;
                case DataImportConnectionType.Test:
                    dbHelper = TestIMPDataHelper;
                    break;
                case DataImportConnectionType.Live:
                    dbHelper = LiveIMPDataHelper;
                    break;
                default:

                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            dbHelper.ExecuteScalar(CommandType.Text, sql);

        }

        public void CartIds(string[] ids, DataImportConnectionType type)
        {
            var vals = ids.Aggregate(string.Empty, (x, y) => x + $"('{y}'),")
                          .TrimEnd(",".ToCharArray());

            var sql = $@"use Performance_LIVE
                insert into IMPData20161124_ItemID(ID_ShoppingCart)
                select*from(
                values
                 {vals}
                ) a(b)";

            var dbHelper = LocalDbHelper;
            switch (type)
            {
                case DataImportConnectionType.Loacal:
                    dbHelper = LocalIMPDataHelper;
                    break;
                case DataImportConnectionType.Test:
                    dbHelper = TestIMPDataHelper;
                    break;
                case DataImportConnectionType.Live:
                    dbHelper = LiveIMPDataHelper;
                    break;
                default:

                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            dbHelper.ExecuteScalar(CommandType.Text, sql);
        }

    }
}
