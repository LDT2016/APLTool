namespace APLTools.Advance.WinUI.UseImage
{
    partial class SharedArt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMainArea = new System.Windows.Forms.Panel();
            this.PnlDgvBack = new System.Windows.Forms.Panel();
            this.DgvGrid = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilenameNoExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preview = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nucleus = new DMS.DataGridViewPreviewButtonColumn();
            this.PnlTopTitle = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PageBar = new APLTools.Advance.UserControls.PageBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.combVendor = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnLive = new System.Windows.Forms.RadioButton();
            this.rbtniNet = new System.Windows.Forms.RadioButton();
            this.ProcessId = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOffCount = new System.Windows.Forms.Label();
            this.txtVendorId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProcessId = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewPreviewButtonColumn1 = new DMS.DataGridViewPreviewButtonColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PnlMainArea.SuspendLayout();
            this.PnlDgvBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrid)).BeginInit();
            this.PnlTopTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.PnlDgvBack.Location = new System.Drawing.Point(20, 287);
            this.PnlDgvBack.Name = "PnlDgvBack";
            this.PnlDgvBack.Size = new System.Drawing.Size(790, 341);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvGrid.ColumnHeadersHeight = 30;
            this.DgvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.OriginalFilename,
            this.FilenameNoExtension,
            this.Type,
            this.ColorSpace,
            this.Preview,
            this.Nucleus});
            this.DgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGrid.GridColor = System.Drawing.Color.Silver;
            this.DgvGrid.Location = new System.Drawing.Point(0, 0);
            this.DgvGrid.MultiSelect = false;
            this.DgvGrid.Name = "DgvGrid";
            this.DgvGrid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.DgvGrid.Size = new System.Drawing.Size(790, 341);
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
            // OriginalFilename
            // 
            this.OriginalFilename.DataPropertyName = "OriginalFilename";
            this.OriginalFilename.HeaderText = "OriginalFilename";
            this.OriginalFilename.Name = "OriginalFilename";
            this.OriginalFilename.ReadOnly = true;
            this.OriginalFilename.Width = 150;
            // 
            // FilenameNoExtension
            // 
            this.FilenameNoExtension.DataPropertyName = "FilenameNoExtension";
            this.FilenameNoExtension.HeaderText = "FilenameNoExtension";
            this.FilenameNoExtension.Name = "FilenameNoExtension";
            this.FilenameNoExtension.ReadOnly = true;
            this.FilenameNoExtension.Width = 150;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 75;
            // 
            // ColorSpace
            // 
            this.ColorSpace.DataPropertyName = "ColorSpace";
            this.ColorSpace.HeaderText = "ColorSpace";
            this.ColorSpace.Name = "ColorSpace";
            this.ColorSpace.ReadOnly = true;
            // 
            // Preview
            // 
            this.Preview.DataPropertyName = "Preview";
            this.Preview.HeaderText = "Preview";
            this.Preview.Name = "Preview";
            this.Preview.ReadOnly = true;
            this.Preview.Width = 130;
            // 
            // Nucleus
            // 
            this.Nucleus.HeaderText = "Nucleus";
            this.Nucleus.Name = "Nucleus";
            this.Nucleus.ReadOnly = true;
            this.Nucleus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PnlTopTitle
            // 
            this.PnlTopTitle.Controls.Add(this.btnClear);
            this.PnlTopTitle.Controls.Add(this.label1);
            this.PnlTopTitle.Controls.Add(this.PageBar);
            this.PnlTopTitle.Controls.Add(this.panel1);
            this.PnlTopTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTopTitle.Location = new System.Drawing.Point(20, 22);
            this.PnlTopTitle.Name = "PnlTopTitle";
            this.PnlTopTitle.Size = new System.Drawing.Size(790, 265);
            this.PnlTopTitle.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(383, 235);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 44);
            this.label1.TabIndex = 22;
            this.label1.Text = "Shared Art";
            // 
            // PageBar
            // 
            this.PageBar.BackColor = System.Drawing.Color.White;
            this.PageBar.CurPage = 1;
            this.PageBar.DataControl = null;
            this.PageBar.DataSource = null;
            this.PageBar.Location = new System.Drawing.Point(11, 235);
            this.PageBar.MinimumSize = new System.Drawing.Size(350, 24);
            this.PageBar.Name = "PageBar";
            this.PageBar.PageSize = 50;
            this.PageBar.Size = new System.Drawing.Size(350, 24);
            this.PageBar.TabIndex = 20;
            this.PageBar.PageChanged += new System.EventHandler(this.PageBar_PageChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.combVendor);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ProcessId);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtItemId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblOffCount);
            this.panel1.Controls.Add(this.txtVendorId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtProcessId);
            this.panel1.Location = new System.Drawing.Point(11, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 178);
            this.panel1.TabIndex = 12;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 100);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(340, 69);
            this.listBox1.TabIndex = 29;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(7, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 20);
            this.button1.TabIndex = 28;
            this.button1.Text = "根据ItemId获取ProcessId";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // combVendor
            // 
            this.combVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combVendor.FormattingEnabled = true;
            this.combVendor.Location = new System.Drawing.Point(62, 4);
            this.combVendor.Name = "combVendor";
            this.combVendor.Size = new System.Drawing.Size(614, 21);
            this.combVendor.TabIndex = 22;
            this.combVendor.SelectedIndexChanged += new System.EventHandler(this.combVendor_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnLive);
            this.panel2.Controls.Add(this.rbtniNet);
            this.panel2.Location = new System.Drawing.Point(502, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 20);
            this.panel2.TabIndex = 21;
            // 
            // rbtnLive
            // 
            this.rbtnLive.AutoSize = true;
            this.rbtnLive.Location = new System.Drawing.Point(54, 1);
            this.rbtnLive.Name = "rbtnLive";
            this.rbtnLive.Size = new System.Drawing.Size(45, 17);
            this.rbtnLive.TabIndex = 1;
            this.rbtnLive.Text = "Live";
            this.rbtnLive.UseVisualStyleBackColor = true;
            // 
            // rbtniNet
            // 
            this.rbtniNet.AutoSize = true;
            this.rbtniNet.Checked = true;
            this.rbtniNet.Location = new System.Drawing.Point(4, 1);
            this.rbtniNet.Name = "rbtniNet";
            this.rbtniNet.Size = new System.Drawing.Size(44, 17);
            this.rbtniNet.TabIndex = 0;
            this.rbtniNet.TabStop = true;
            this.rbtniNet.Text = "iNet";
            this.rbtniNet.UseVisualStyleBackColor = true;
            // 
            // ProcessId
            // 
            this.ProcessId.AutoSize = true;
            this.ProcessId.Location = new System.Drawing.Point(157, 36);
            this.ProcessId.Name = "ProcessId";
            this.ProcessId.Size = new System.Drawing.Size(54, 13);
            this.ProcessId.TabIndex = 18;
            this.ProcessId.Text = "ProcessId";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(682, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Search in ";
            // 
            // txtItemId
            // 
            this.txtItemId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemId.Location = new System.Drawing.Point(62, 32);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(89, 20);
            this.txtItemId.TabIndex = 17;
            this.txtItemId.Text = "30303";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "VendorId";
            // 
            // lblOffCount
            // 
            this.lblOffCount.AutoSize = true;
            this.lblOffCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOffCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblOffCount.Location = new System.Drawing.Point(219, 4);
            this.lblOffCount.Name = "lblOffCount";
            this.lblOffCount.Size = new System.Drawing.Size(0, 13);
            this.lblOffCount.TabIndex = 19;
            // 
            // txtVendorId
            // 
            this.txtVendorId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendorId.Location = new System.Drawing.Point(682, 4);
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.Size = new System.Drawing.Size(93, 20);
            this.txtVendorId.TabIndex = 10;
            this.txtVendorId.Text = "100010";
            this.txtVendorId.TextChanged += new System.EventHandler(this.txtVendorId_TextChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "ItemId";
            // 
            // txtProcessId
            // 
            this.txtProcessId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessId.Location = new System.Drawing.Point(215, 32);
            this.txtProcessId.Name = "txtProcessId";
            this.txtProcessId.Size = new System.Drawing.Size(89, 20);
            this.txtProcessId.TabIndex = 16;
            this.txtProcessId.Text = "1";
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
            // SharedArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlMainArea);
            this.Name = "SharedArt";
            this.Size = new System.Drawing.Size(830, 650);
            this.PnlMainArea.ResumeLayout(false);
            this.PnlDgvBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrid)).EndInit();
            this.PnlTopTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlMainArea;
        private System.Windows.Forms.Panel PnlDgvBack;
        private System.Windows.Forms.Panel PnlTopTitle;
        private System.Windows.Forms.TextBox txtVendorId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Label lblOffCount;
        private System.Windows.Forms.Label ProcessId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProcessId;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.DataGridView DgvGrid;
        private UserControls.PageBar PageBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilenameNoExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorSpace;
        private System.Windows.Forms.DataGridViewImageColumn Preview;
        private DMS.DataGridViewPreviewButtonColumn Nucleus;
        private System.Windows.Forms.Label label1;
        private DMS.DataGridViewPreviewButtonColumn dataGridViewPreviewButtonColumn1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox combVendor;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbtniNet;
        private System.Windows.Forms.RadioButton rbtnLive;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

