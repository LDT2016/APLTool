using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using APLTools.Advance.DBUtility;
using APLTools.Advance.Model;

namespace APLTools.Advance.DAL
{
    /// 数据访问类 Devices
    public partial class ImprintFormat : DALHelper
    {
        #region methods

     
        
        /// 获取泛型数据列表
        public List<Model.ImprintFormat> GetMultipleFormats(string itemId)
        {
            var strSql = new StringBuilder();
            strSql.Append($@"SELECT A.ImprintAreaCode,A.Description,A.ImprintRule,A.ImprintGroup,A.StyleId,A.Location,A.IsDefault,A.Sequence, A.ShowOnWeb,B.ProcessId, B.LogoOnly
            from prod_MultipleImprints A WITH (NOLOCK) LEFT JOIN prod_ImprintAreaHeader B WITH(NOLOCK) ON A.ImprintAreaCode = B.ImprintAreaCode 
            where ItemId='{itemId}' and (A.ImprintAreaCode <>'PERS') and A.ImprintRule not like 'X%'
            and (A.ShowOnWeb = 'Y' or (A.ShowOnWeb <> 'Y' and A.ImprintRule like 'M%'))
            order by IsDefault desc, ImprintGroup, ImprintRule, Sequence");

            using (var dr = LocalDbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                var lst = new List<Model.ImprintFormat>();

                ExecuteReaderAction(dr,
                                    r =>
                                    {
                                        var md = GetModel(r);
                                        md.RowNum = lst.Count + 1;
                                        lst.Add(md);
                                    });

                return lst;
            }
        }
        public List<Model.ImprintFormat> GetDefaultFormats(string itemId)
        {
            var strSql = new StringBuilder();
            strSql.Append($@"select a.ImprintAreaCode, 
                    'Standant' as [Description],
                    'NA' as ImprintRule,'NA' as ImprintGroup, 
                    'NA' as StyleId, 'NA' as [Location], 1 as IsDefault, -1 as [Sequence], 
                    1 as ShowOnWeb,b.ProcessId, b.LogoOnly 
                    from prod_Products a left join prod_ImprintAreaHeader b on a.ImprintAreaCode = b.ImprintAreaCode 
                    where a.ItemId ='{itemId}'");

            using (var dr = LocalDbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                var lst = new List<Model.ImprintFormat>();

                ExecuteReaderAction(dr,
                                    r =>
                                    {
                                        var md = GetModel(r);
                                        md.RowNum = lst.Count + 1;
                                        lst.Add(md);
                                    });

                return lst;
            }
        }


        private Model.ImprintFormat GetModel(IDataReader dr)
        {
            var model = new Model.ImprintFormat();
            PrepareModel(model, dr);

            return model;
        }
        public  void PrepareModel(Model.ImprintFormat model, IDataReader dr)
        {
            model.ImprintAreaCode = DbValue.GetString(dr["ImprintAreaCode"]);
            model.Description = DbValue.GetString(dr["Description"]);
            model.ImprintRule = DbValue.GetString(dr["ImprintRule"]);
            model.ImprintGroup = DbValue.GetString(dr["ImprintGroup"]);
            model.StyleId = DbValue.GetString(dr["StyleId"]);
            model.Location = DbValue.GetString(dr["Location"]);
            model.IsDefault = DbValue.GetBool(dr["IsDefault"]);
            model.Sequence = DbValue.GetInt(dr["Sequence"]);
            model.ShowOnWeb = DbValue.GetBool(dr["ShowOnWeb"]);
            model.ProcessId = DbValue.GetInt(dr["ProcessId"]);
            model.LogoOnly = DbValue.GetBool(dr["LogoOnly"]);
        }

        #endregion
    }
}
