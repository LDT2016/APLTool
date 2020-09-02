using System;
using System.Collections.Generic;
using System.Linq;
using APLTools.Advance.Model;

namespace APLTools.Advance.Common
{
    public static class PageDataUtil
    {
        #region methods

        public static PageData GetPageList<T>(List<T> lst, int pageSize, int curPage)
        {
            var pageData = new PageData();
            pageData.PageSize = pageSize;
            pageData.CurPage = curPage;
            pageData.RecordCount = lst.Count;
            pageData.PageCount = 1;

            //var first = (curPage - 1) * pageSize + 1;
            //var last = curPage * pageSize;

            //while (dr.Read())
            //{
            //    pageData.RecordCount++;

            //    if (pageData.RecordCount >= first && last >= pageData.RecordCount)
            //    {
            //        var md = new Model.Devices
            //                 {
            //                     RowNum = list.Count + first
            //                 };
            //        PrepareModel(md, dr);
            //        list.Add(md);
            //    }
            //}

            lst = lst.Skip((curPage - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();

            if (pageData.RecordCount > 0)
            {
                pageData.PageCount = Convert.ToInt32(Math.Ceiling(pageData.RecordCount / (double)pageSize));
            }

            pageData.PageList = lst;

            return pageData;
        }

        #endregion
    }
}
