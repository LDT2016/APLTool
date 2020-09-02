﻿using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace APLTools.Advance.DBUtility
{
    #region SqlServer操作类

    public class SqlServer : DbHelper
    {
        #region methods

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public override DbDataAdapter CreateDataAdapter(IDbCommand selectCommand, IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand)
        {
            var adapter = new SqlDataAdapter();

            if (selectCommand != null)
            {
                adapter.SelectCommand = selectCommand as SqlCommand;
            }

            if (insertCommand != null)
            {
                adapter.InsertCommand = insertCommand as SqlCommand;
            }

            if (deleteCommand != null)
            {
                adapter.DeleteCommand = deleteCommand as SqlCommand;
            }

            if (updateCommand != null)
            {
                adapter.UpdateCommand = updateCommand as SqlCommand;
            }

            return adapter;
        }

        public override IDbDataParameter CreateDbParameter(string parameterName)
        {
            IDbDataParameter parameter = new SqlParameter();

            parameter.ParameterName = parameterName.Replace("?", "@")
                                                   .Replace(":", "@");

            return parameter;
        }

        #endregion
    }

    #endregion
}
