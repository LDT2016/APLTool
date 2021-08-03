namespace APLTools.Advance.WinUI.UseImage
{
    partial class ThumbnailLookup
    {
        /// 必需的设计器变量。
        private System.ComponentModel.IContainer components = null;

        /// 清理所有正在使用的资源。
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMainArea = new System.Windows.Forms.Panel();
            this.PnlDgvBack = new System.Windows.Forms.Panel();
            this.DgvGrid = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unique = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preview = new System.Windows.Forms.DataGridViewImageColumn();
            this.FilenameNoExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageNoFound = new DMS.DataGridViewPreviewButtonColumn();
            this.PnlTopTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAllCount = new System.Windows.Forms.Label();
            this.rbtnNoFound = new System.Windows.Forms.RadioButton();
            this.rbtnFound = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewPreviewButtonColumn1 = new DMS.DataGridViewPreviewButtonColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rbtnNull = new System.Windows.Forms.RadioButton();
            this.rbtnNotNull = new System.Windows.Forms.RadioButton();
            this.chkNewTb = new System.Windows.Forms.CheckBox();
            this.chkOldTb = new System.Windows.Forms.CheckBox();
            this.PnlMainArea.SuspendLayout();
            this.PnlDgvBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrid)).BeginInit();
            this.PnlTopTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMainArea
            // 
            this.PnlMainArea.Controls.Add(this.PnlDgvBack);
            this.PnlMainArea.Controls.Add(this.PnlTopTitle);
            this.PnlMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMainArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.PnlMainArea.Location = new System.Drawing.Point(0, 0);
            this.PnlMainArea.Name = "PnlMainArea";
            this.PnlMainArea.Padding = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.PnlMainArea.Size = new System.Drawing.Size(830, 650);
            this.PnlMainArea.TabIndex = 4;
            // 
            // PnlDgvBack
            // 
            this.PnlDgvBack.Controls.Add(this.DgvGrid);
            this.PnlDgvBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDgvBack.Location = new System.Drawing.Point(20, 128);
            this.PnlDgvBack.Name = "PnlDgvBack";
            this.PnlDgvBack.Size = new System.Drawing.Size(790, 500);
            this.PnlDgvBack.TabIndex = 7;
            // 
            // DgvGrid
            // 
            this.DgvGrid.AllowUserToAddRows = false;
            this.DgvGrid.AllowUserToDeleteRows = false;
            this.DgvGrid.AllowUserToOrderColumns = true;
            this.DgvGrid.BackgroundColor = System.Drawing.Color.White;
            this.DgvGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvGrid.ColumnHeadersHeight = 30;
            this.DgvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.TableName,
            this.unique,
            this.update,
            this.Preview,
            this.FilenameNoExtension,
            this.ImageNoFound});
            this.DgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGrid.GridColor = System.Drawing.Color.Silver;
            this.DgvGrid.Location = new System.Drawing.Point(0, 0);
            this.DgvGrid.MultiSelect = false;
            this.DgvGrid.Name = "DgvGrid";
            this.DgvGrid.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvGrid.RowHeadersVisible = false;
            this.DgvGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.DgvGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.DgvGrid.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DgvGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DgvGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.DgvGrid.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGrid.RowTemplate.Height = 30;
            this.DgvGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvGrid.Size = new System.Drawing.Size(790, 500);
            this.DgvGrid.TabIndex = 0;
            this.DgvGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvGrid_CellMouseClick);
            // 
            // No
            // 
            this.No.DataPropertyName = "RowNum";
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 30;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "tablename";
            this.TableName.HeaderText = "TableName";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            // 
            // unique
            // 
            this.unique.DataPropertyName = "unique";
            this.unique.HeaderText = "unique";
            this.unique.Name = "unique";
            this.unique.ReadOnly = true;
            // 
            // update
            // 
            this.update.DataPropertyName = "update";
            this.update.HeaderText = "update";
            this.update.Name = "update";
            this.update.ReadOnly = true;
            // 
            // Preview
            // 
            this.Preview.DataPropertyName = "Preview";
            this.Preview.HeaderText = "Preview";
            this.Preview.Name = "Preview";
            this.Preview.ReadOnly = true;
            this.Preview.Width = 130;
            // 
            // FilenameNoExtension
            // 
            this.FilenameNoExtension.DataPropertyName = "FilenameNoExtension";
            this.FilenameNoExtension.HeaderText = "FilenameNoExtension";
            this.FilenameNoExtension.Name = "FilenameNoExtension";
            this.FilenameNoExtension.ReadOnly = true;
            this.FilenameNoExtension.Visible = false;
            // 
            // ImageNoFound
            // 
            this.ImageNoFound.DataPropertyName = "ImageNoFound";
            this.ImageNoFound.HeaderText = "ImageNoFound";
            this.ImageNoFound.Name = "ImageNoFound";
            this.ImageNoFound.ReadOnly = true;
            this.ImageNoFound.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PnlTopTitle
            // 
            this.PnlTopTitle.Controls.Add(this.label1);
            this.PnlTopTitle.Controls.Add(this.panel1);
            this.PnlTopTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTopTitle.Location = new System.Drawing.Point(20, 22);
            this.PnlTopTitle.Name = "PnlTopTitle";
            this.PnlTopTitle.Size = new System.Drawing.Size(790, 106);
            this.PnlTopTitle.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 44);
            this.label1.TabIndex = 22;
            this.label1.Text = "Thumbnail Lookup";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkOldTb);
            this.panel1.Controls.Add(this.chkNewTb);
            this.panel1.Controls.Add(this.rbtnNotNull);
            this.panel1.Controls.Add(this.rbtnNull);
            this.panel1.Controls.Add(this.lblAllCount);
            this.panel1.Controls.Add(this.rbtnNoFound);
            this.panel1.Controls.Add(this.rbtnFound);
            this.panel1.Controls.Add(this.rbtnAll);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(11, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 39);
            this.panel1.TabIndex = 12;
            // 
            // lblAllCount
            // 
            this.lblAllCount.AutoSize = true;
            this.lblAllCount.Location = new System.Drawing.Point(495, 8);
            this.lblAllCount.Name = "lblAllCount";
            this.lblAllCount.Size = new System.Drawing.Size(13, 13);
            this.lblAllCount.TabIndex = 19;
            this.lblAllCount.Text = "0";
            // 
            // rbtnNoFound
            // 
            this.rbtnNoFound.AutoSize = true;
            this.rbtnNoFound.Location = new System.Drawing.Point(119, 9);
            this.rbtnNoFound.Name = "rbtnNoFound";
            this.rbtnNoFound.Size = new System.Drawing.Size(72, 17);
            this.rbtnNoFound.TabIndex = 18;
            this.rbtnNoFound.Text = "No Found";
            this.rbtnNoFound.UseVisualStyleBackColor = true;
            // 
            // rbtnFound
            // 
            this.rbtnFound.AutoSize = true;
            this.rbtnFound.Location = new System.Drawing.Point(58, 8);
            this.rbtnFound.Name = "rbtnFound";
            this.rbtnFound.Size = new System.Drawing.Size(55, 17);
            this.rbtnFound.TabIndex = 17;
            this.rbtnFound.Text = "Found";
            this.rbtnFound.UseVisualStyleBackColor = true;
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(16, 8);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(36, 17);
            this.rbtnAll.TabIndex = 16;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(561, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(669, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridViewPreviewButtonColumn1
            // 
            this.dataGridViewPreviewButtonColumn1.HeaderText = "Nucleus";
            this.dataGridViewPreviewButtonColumn1.Name = "dataGridViewPreviewButtonColumn1";
            this.dataGridViewPreviewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "Id";
            this.dataGridViewButtonColumn1.HeaderText = "PING监测";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "PING监测";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // rbtnNull
            // 
            this.rbtnNull.AutoSize = true;
            this.rbtnNull.Location = new System.Drawing.Point(197, 9);
            this.rbtnNull.Name = "rbtnNull";
            this.rbtnNull.Size = new System.Drawing.Size(43, 17);
            this.rbtnNull.TabIndex = 20;
            this.rbtnNull.Text = "Null";
            this.rbtnNull.UseVisualStyleBackColor = true;
            // 
            // rbtnNotNull
            // 
            this.rbtnNotNull.AutoSize = true;
            this.rbtnNotNull.Location = new System.Drawing.Point(246, 9);
            this.rbtnNotNull.Name = "rbtnNotNull";
            this.rbtnNotNull.Size = new System.Drawing.Size(63, 17);
            this.rbtnNotNull.TabIndex = 21;
            this.rbtnNotNull.Text = "Not Null";
            this.rbtnNotNull.UseVisualStyleBackColor = true;
            // 
            // chkNewTb
            // 
            this.chkNewTb.AutoSize = true;
            this.chkNewTb.Checked = true;
            this.chkNewTb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewTb.Location = new System.Drawing.Point(332, 8);
            this.chkNewTb.Name = "chkNewTb";
            this.chkNewTb.Size = new System.Drawing.Size(64, 17);
            this.chkNewTb.TabIndex = 22;
            this.chkNewTb.Text = "New Tb";
            this.chkNewTb.UseVisualStyleBackColor = true;
            // 
            // chkOldTb
            // 
            this.chkOldTb.AutoSize = true;
            this.chkOldTb.Checked = true;
            this.chkOldTb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOldTb.Location = new System.Drawing.Point(402, 8);
            this.chkOldTb.Name = "chkOldTb";
            this.chkOldTb.Size = new System.Drawing.Size(58, 17);
            this.chkOldTb.TabIndex = 23;
            this.chkOldTb.Text = "Old Tb";
            this.chkOldTb.UseVisualStyleBackColor = true;
            // 
            // ThumbnailLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlMainArea);
            this.Name = "ThumbnailLookup";
            this.Size = new System.Drawing.Size(830, 650);
            this.PnlMainArea.ResumeLayout(false);
            this.PnlDgvBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrid)).EndInit();
            this.PnlTopTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlMainArea;
        private System.Windows.Forms.Panel PnlDgvBack;
        private System.Windows.Forms.Panel PnlTopTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridView DgvGrid;
        private System.Windows.Forms.Label label1;
        private DMS.DataGridViewPreviewButtonColumn dataGridViewPreviewButtonColumn1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn unique;
        private System.Windows.Forms.DataGridViewTextBoxColumn update;
        private System.Windows.Forms.DataGridViewImageColumn Preview;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilenameNoExtension;
        private DMS.DataGridViewPreviewButtonColumn ImageNoFound;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.RadioButton rbtnFound;
        private System.Windows.Forms.RadioButton rbtnNoFound;
        private System.Windows.Forms.Label lblAllCount;
        private System.Windows.Forms.RadioButton rbtnNull;
        private System.Windows.Forms.RadioButton rbtnNotNull;
        private System.Windows.Forms.CheckBox chkNewTb;
        private System.Windows.Forms.CheckBox chkOldTb;
    }
}

