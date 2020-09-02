using System.Drawing;
using System.Windows.Forms;
using APLTools.Properties;

namespace DMS
{
    /// 对象名称：DataGridView操作按钮列（修改、删除）
    /// 对象说明：通过本类可以实现，在DataGridView控件中，显示一个分别包含修改和删除两个图片按钮的列。
    public class DataGridViewActionButtonColumn : DataGridViewColumn
    {
        #region constructors

        public DataGridViewActionButtonColumn()
        {
            CellTemplate = new DataGridViewActionButtonCell();
            HeaderText = "操作";
        }

        #endregion
    }

    /// DataGridView操作按钮单元格，继承自DataGridViewButtonCell类。使用本自定义列或单元格前，请确保应用程序的
    /// Properties.Resources资源文件中，包含了4张分别名为：BtnModify、BtnModify02、BtnDelete、BtnDelete02图片。
    public class DataGridViewActionButtonCell : DataGridViewButtonCell
    {
        #region fields

        private static Image ImageDelete = Resources.BtnDelete; // 删除按钮背景图片
        private static Image ImageModify = Resources.BtnModify; // 修改按钮背景图片
        private static int nowColIndex; // 当前列序号
        private static int nowRowIndex; // 当前行序号
        private static Pen penDelete = new Pen(Color.FromArgb(162, 144, 77)); // 删除按钮边框颜色
        private static Pen penModify = new Pen(Color.FromArgb(135, 163, 193)); // 修改按钮边框颜色
        private bool mouseOnDeleteButton; // 鼠标是否移动到删除按钮上
        private bool mouseOnModifyButton; // 鼠标是否移动到修改按钮上

        #endregion

        #region methods

        /// 判断用户是否单击了删除按钮，DataGridView发生CellMouseClick事件时，
        /// 因本单元格中有两个按钮，本方法通过坐标判断用户是否单击了删除按钮。
        public static bool IsDeleteButtonClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return false;
            }

            if (sender is DataGridView)
            {
                var DgvGrid = (DataGridView)sender;

                if (DgvGrid.Columns[e.ColumnIndex] is DataGridViewActionButtonColumn)
                {
                    var cellBounds = DgvGrid[e.ColumnIndex, e.RowIndex]
                        .ContentBounds;
                    var recDelete = new Rectangle(cellBounds.Location.X + cellBounds.Width / 2 + 2, cellBounds.Location.Y + (cellBounds.Height - ImageDelete.Height) / 2, ImageDelete.Width, ImageDelete.Height);

                    if (IsInRect(e.X, e.Y, recDelete))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// 判断用户是否单击了修改按钮，DataGridView发生CellMouseClick事件时，
        /// 因本单元格中有两个按钮，本方法通过坐标判断用户是否单击了修改按钮。
        public static bool IsModifyButtonClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return false;
            }

            if (sender is DataGridView)
            {
                var DgvGrid = (DataGridView)sender;

                if (DgvGrid.Columns[e.ColumnIndex] is DataGridViewActionButtonColumn)
                {
                    var cellBounds = DgvGrid[e.ColumnIndex, e.RowIndex]
                        .ContentBounds;

                    var recModify = new Rectangle(cellBounds.Location.X + cellBounds.Width / 2 - ImageModify.Width - 2,
                                                  cellBounds.Location.Y + (cellBounds.Height - ImageModify.Height) / 2,
                                                  ImageModify.Width,
                                                  ImageModify.Height);

                    if (IsInRect(e.X, e.Y, recModify))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// 鼠标从单元格内移出时的事件处理，调用私有的重绘方法进行重绘。
        protected override void OnMouseLeave(int rowIndex)
        {
            if (mouseOnModifyButton || mouseOnDeleteButton)
            {
                mouseOnModifyButton = false;
                mouseOnDeleteButton = false;

                var paintCellBounds = DataGridView.GetCellDisplayRectangle(nowColIndex, nowRowIndex, true);

                paintCellBounds.Width = DataGridView.Columns[nowColIndex]
                                                    .Width;

                paintCellBounds.Height = DataGridView.Rows[nowRowIndex]
                                                     .Height;

                PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, nowRowIndex, DataGridView.RowTemplate.DefaultCellStyle, false);
                DataGridView.Cursor = Cursors.Default;
            }
        }

        /// 鼠标移动到单元格内时的事件处理，通过坐标判断鼠标是否移动到了修改或删除按钮上，并调用私有的重绘方法进行重绘。
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            if (DataGridView == null)
            {
                return;
            }

            nowColIndex = e.ColumnIndex;
            nowRowIndex = e.RowIndex;

            var cellBounds = DataGridView[e.ColumnIndex, e.RowIndex]
                .ContentBounds;
            var recModify = new Rectangle(cellBounds.Location.X + cellBounds.Width / 2 - ImageModify.Width - 2, cellBounds.Location.Y + (cellBounds.Height - ImageModify.Height) / 2, ImageModify.Width, ImageModify.Height);
            var recDelete = new Rectangle(cellBounds.Location.X + cellBounds.Width / 2 + 2, cellBounds.Location.Y + (cellBounds.Height - ImageDelete.Height) / 2, ImageDelete.Width, ImageDelete.Height);
            var paintCellBounds = DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            paintCellBounds.Width = DataGridView.Columns[nowColIndex]
                                                .Width;

            paintCellBounds.Height = DataGridView.Rows[nowRowIndex]
                                                 .Height;

            if (IsInRect(e.X, e.Y, recModify)) // 鼠标移动到修改按钮上
            {
                if (!mouseOnModifyButton)
                {
                    mouseOnModifyButton = true;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (mouseOnModifyButton)
                {
                    mouseOnModifyButton = false;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Default;
                }
            }

            if (IsInRect(e.X, e.Y, recDelete)) // 鼠标移动到删除按钮上
            {
                if (!mouseOnDeleteButton)
                {
                    mouseOnDeleteButton = true;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (mouseOnDeleteButton)
                {
                    mouseOnDeleteButton = false;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Default;
                }
            }
        }

        /// 对单元格的重绘事件进行的方法重写。
        protected override void Paint(Graphics graphics,
                                      Rectangle clipBounds,
                                      Rectangle cellBounds,
                                      int rowIndex,
                                      DataGridViewElementStates cellState,
                                      object value,
                                      object formattedValue,
                                      string errorText,
                                      DataGridViewCellStyle cellStyle,
                                      DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                      DataGridViewPaintParts paintParts)
        {
            cellBounds = PrivatePaint(graphics, cellBounds, rowIndex, cellStyle, true);
            base.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            nowColIndex = DataGridView.Columns.Count - 1;
        }

        /// 判断鼠标坐标是否在指定的区域内。
        private static bool IsInRect(int x, int y, Rectangle area)
        {
            if (x > area.Left && x < area.Right && y > area.Top && y < area.Bottom)
            {
                return true;
            }

            return false;
        }

        /// 私有的单元格重绘方法，根据鼠标是否移动到按钮上，对按钮的不同背景和边框进行绘制。
        private Rectangle PrivatePaint(Graphics graphics, Rectangle cellBounds, int rowIndex, DataGridViewCellStyle cellStyle, bool clearBackground)
        {
            if (mouseOnModifyButton) // 鼠标移动到修改按钮上，更换背景及边框颜色
            {
                ImageModify = Resources.BtnModify02;
                penModify = new Pen(Color.FromArgb(162, 144, 77));
            }
            else
            {
                ImageModify = Resources.BtnModify;
                penModify = new Pen(Color.FromArgb(135, 163, 193));
            }

            if (mouseOnDeleteButton) // 鼠标移动到删除按钮上，更换背景及边框颜色
            {
                ImageDelete = Resources.BtnDelete02;
                penDelete = new Pen(Color.FromArgb(162, 144, 77));
            }
            else
            {
                ImageDelete = Resources.BtnDelete;
                penDelete = new Pen(Color.FromArgb(135, 163, 193));
            }

            if (clearBackground) // 是否需要重绘单元格的背景颜色
            {
                Brush brushCellBack = rowIndex == DataGridView.CurrentRow.Index
                                          ? new SolidBrush(cellStyle.SelectionBackColor)
                                          : new SolidBrush(cellStyle.BackColor);
                graphics.FillRectangle(brushCellBack, cellBounds.X + 1, cellBounds.Y + 1, cellBounds.Width - 2, cellBounds.Height - 2);
            }

            var recModify = new Rectangle(cellBounds.Location.X + cellBounds.Width / 2 - ImageModify.Width - 2, cellBounds.Location.Y + (cellBounds.Height - ImageModify.Height) / 2, ImageModify.Width, ImageModify.Height);
            var recDelete = new Rectangle(cellBounds.Location.X + cellBounds.Width / 2 + 2, cellBounds.Location.Y + (cellBounds.Height - ImageDelete.Height) / 2, ImageDelete.Width, ImageDelete.Height);

            graphics.DrawImage(ImageModify, recModify);
            graphics.DrawImage(ImageDelete, recDelete);
            graphics.DrawRectangle(penModify, recModify.X, recModify.Y - 1, recModify.Width, recModify.Height);
            graphics.DrawRectangle(penDelete, recDelete.X, recDelete.Y - 1, recDelete.Width, recDelete.Height);

            return cellBounds;
        }

        #endregion
    }
}
