using System;
using System.Windows.Forms;
using APLTools.Advance.Model;
using APLTools.Advance.Model;

namespace APLTools.Advance.UserControls
{
    /// 对象名称：数据分页用户控件
    /// 对象说明：采用DataReader进行高效数据分页，通过关联Repeater、DataGrid或DataList控件进行数据显示。
    public partial class PageBar : UserControl
    {
        #region fields

        private int curPage;
        private int pageSize;

        #endregion

        #region constructors

        /// 控件实例化方法
        public PageBar()
        {
            InitializeComponent();
        }

        #endregion

        #region events

        public event EventHandler PageChanged; //事件：控件的当前页码发生变更。

        #endregion

        #region properties

        /// 当前页数
        public int CurPage
        {
            get
            {
                if (curPage <= 0)
                {
                    curPage = 1;
                }

                return curPage;
            }
            set
            {
                curPage = value;

                if (PageChanged != null)
                {
                    PageChanged(this, null); //触发当件页码变更事件。
                }
            }
        }

        /// PageBar分页控件所关联的DataGridView数据控件，当PageBar分页控件执行DataBind()数据绑定
        /// 方法时，PageBar分页控件会自动将分页后的数据，绑定给关联的DataGridView控件进行显示。
        public DataGridView DataControl { get; set; }

        /// PageBar分页控件的数据源，数据源为数据实体层中所定义的PageData类型。
        public PageData DataSource { get; set; }

        /// 每页显示记录数。
        public int PageSize
        {
            get
            {
                if (pageSize <= 0)
                {
                    pageSize = 14;
                }

                return pageSize;
            }
            set { pageSize = value; }
        }

        #endregion

        #region methods

        /// 进行数据绑定，将数据源中的IList类型数据，绑定给关联的数据控件进行显示。
        public void DataBind()
        {
            if (DataSource == null)
            {
                return;
            }

            if (DataSource.CurPage > DataSource.PageCount) //如果所请求的当前页大于数据源的总页数，转向到最后1页。
            {
                CurPage = DataSource.PageCount;
            }

            LblTotalRecord.Text = "总记录数：" + DataSource.RecordCount + "条（" + DataSource.PageSize + "条/页）";
            LblCurPage.Text = DataSource.CurPage + "/" + DataSource.PageCount;
            TextJumpPage.Text = DataSource.CurPage.ToString();

            DataControl.AutoGenerateColumns = false;
            DataControl.DataSource = DataSource.PageList;
        }

        /// 用户单击“第一页”按钮时的事件处理方法。
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            CurPage = 1;
        }

        /// 用户单击“跳转”按钮时的事件处理方法。
        private void BtnGO_Click(object sender, EventArgs e)
        {
            var page = TextJumpPage.Text.GetIntOrZero();

            if (page > 0)
            {
                CurPage = page;
            }
            else
            {
                CurPage = 1;
            }
        }

        /// 用户单击“最后一页”按钮时的事件处理方法。
        private void BtnLast_Click(object sender, EventArgs e)
        {
            CurPage = DataSource.PageCount;
        }

        /// 用户单击“下一页”按钮时的事件处理方法。
        private void BtnNext_Click(object sender, EventArgs e)
        {
            CurPage = DataSource.NextPage;
        }

        /// 用户单击“前一页”按钮时的事件处理方法。
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            CurPage = DataSource.PrevPage;
        }

        #endregion
    }
}
