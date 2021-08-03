//如果要从UI中设置数据库，请取消注释下一行，如果从配置中读取，请注释下一行
//#define UISET

using System;
using System.Configuration;
using System.Data;
using APLTools.Advance.DBUtility;

namespace APLTools.Advance.DAL
{
    public class DALHelper
    {
#if UISET
        public static LocalDbHelper LocalDbHelper;

        /// 设置数据库连接
        /// <param name="dbType">不区分大小写，可选值：Advantage、Asa、Ase、DB2、Firebird、Mimer、MySql、NexusDB、OleDb、Oracle、
        /// PervasiveSql、PostgreSql、SQLite、SqlServer、SqlServerCe、Teradata、VistaDB</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static void SetHelper(string dbType, string connectionString)
        {
            LocalDbHelper = LocalDbHelper.Create(dbType);
            LocalDbHelper.ConnectionString = connectionString;
        }
#else
        
        public static DbHelper LocalDbHelper = GetHelper("APL");
        public static DbHelper ThumbnailLookupDbHelper = GetHelper("ThumbnailLookup");
        public static DbHelper TestDbHelper = GetHelper("APL");
        public static DbHelper LiveDbHelper = GetHelper("APL");
        public static DbHelper LocalIMPDataHelper = GetHelper("APL");
        public static DbHelper TestIMPDataHelper = GetHelper("APL");
        public static DbHelper LiveIMPDataHelper = GetHelper("APL");
        /// 从Web.config从读取数据库的连接以及数据库类型
        private static DbHelper GetHelper(string connectionStringName)
        {
            var connectionSetting = ConfigurationManager.ConnectionStrings[connectionStringName];
            //var className = connectionSetting.ProviderName;
            var db = DBUtility.DbHelper.Create();
            db.ConnectionString = connectionSetting.ConnectionString;

            return db;
        }
#endif
        /// 对IDataReader读取依次执行事件
        public static void ExecuteReaderAction(IDataReader dr, Action<IDataReader> readAction)
        {
            while (dr.Read())
            {
                if (readAction != null)
                {
                    readAction(dr);
                }
            }
        }

        /// 对IDataReader读取依次执行事件
        public static void ExecuteReaderAction(IDataReader dr, int first, int count, Action<IDataReader> readAction)
        {
            for (var i = 0; i < first; i++)
            {
                if (!dr.Read())
                {
                    return;
                }
            }

            var resultsFetched = 0;

            while (resultsFetched < count && dr.Read())
            {
                if (readAction != null)
                {
                    readAction(dr);
                }

                resultsFetched++;
            }
        }
    }
}
