using System.Collections;

namespace APLTools.Advance.Model
{
    /// 对象名称：数据分页实体类（数据实体层）
    /// 对象说明：主要用于数据访问层与用户界面层中的PageBar分页控件进行数据交互。
    public class PageData
    {
        #region fields

        /// [属性]所请求的当前页数。
        private int curPage;

        /// [属性]相对于当前页的下一页
        private int nextPage;

        /// [属性]总页数。
        private int pageCount;

        /// [属性]分页过后的数据。
        private IList pageList;

        /// [属性]每页显示记录数。
        private int pageSize;

        /// [属性]相对于当前页的上一页
        private int prevPage;

        /// [属性]总记录数。
        private int recordCount;

        #endregion

        #region properties

        public int CurPage
        {
            get { return curPage; }
            set { curPage = value; }
        }

        public int NextPage
        {
            get
            {
                if (CurPage < PageCount)
                {
                    return CurPage + 1;
                }

                return PageCount;
            }
        }

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }

        public IList PageList
        {
            get { return pageList; }
            set { pageList = value; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public int PrevPage
        {
            get
            {
                if (CurPage > 1)
                {
                    return CurPage - 1;
                }

                return 1;
            }
        }

        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }

        #endregion
    }
}
