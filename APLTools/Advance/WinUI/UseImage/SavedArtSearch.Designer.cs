namespace APLTools.Advance.WinUI.UseImage
{
    partial class SavedArt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblOffCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnLive = new System.Windows.Forms.RadioButton();
            this.rbtniNet = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImprintAreaCode = new System.Windows.Forms.TextBox();
            this.ProcessId = new System.Windows.Forms.Label();
            this.txtProcessId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCustomerNumber = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDamServiceCount = new System.Windows.Forms.Label();
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
            this.PnlDgvBack.Location = new System.Drawing.Point(20, 221);
            this.PnlDgvBack.Name = "PnlDgvBack";
            this.PnlDgvBack.Size = new System.Drawing.Size(790, 407);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.DgvGrid.Size = new System.Drawing.Size(790, 407);
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
            this.OriginalFilename.Width = 250;
            // 
            // FilenameNoExtension
            // 
            this.FilenameNoExtension.DataPropertyName = "FilenameNoExtension";
            this.FilenameNoExtension.HeaderText = "FilenameNoExtension";
            this.FilenameNoExtension.Name = "FilenameNoExtension";
            this.FilenameNoExtension.ReadOnly = true;
            this.FilenameNoExtension.Visible = false;
            this.FilenameNoExtension.Width = 150;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Visible = false;
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
            this.PnlTopTitle.Controls.Add(this.lblDamServiceCount);
            this.PnlTopTitle.Controls.Add(this.label7);
            this.PnlTopTitle.Controls.Add(this.btnClear);
            this.PnlTopTitle.Controls.Add(this.label1);
            this.PnlTopTitle.Controls.Add(this.PageBar);
            this.PnlTopTitle.Controls.Add(this.lblOffCount);
            this.PnlTopTitle.Controls.Add(this.panel1);
            this.PnlTopTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTopTitle.Location = new System.Drawing.Point(20, 22);
            this.PnlTopTitle.Name = "PnlTopTitle";
            this.PnlTopTitle.Size = new System.Drawing.Size(790, 199);
            this.PnlTopTitle.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(377, 170);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 44);
            this.label1.TabIndex = 23;
            this.label1.Text = "Saved Art";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PageBar
            // 
            this.PageBar.BackColor = System.Drawing.Color.White;
            this.PageBar.CurPage = 1;
            this.PageBar.DataControl = null;
            this.PageBar.DataSource = null;
            this.PageBar.Location = new System.Drawing.Point(4, 169);
            this.PageBar.MinimumSize = new System.Drawing.Size(350, 24);
            this.PageBar.Name = "PageBar";
            this.PageBar.PageSize = 50;
            this.PageBar.Size = new System.Drawing.Size(350, 24);
            this.PageBar.TabIndex = 20;
            this.PageBar.Load += new System.EventHandler(this.PageBar_Load);
            // 
            // lblOffCount
            // 
            this.lblOffCount.AutoSize = true;
            this.lblOffCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOffCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblOffCount.Location = new System.Drawing.Point(527, 11);
            this.lblOffCount.Name = "lblOffCount";
            this.lblOffCount.Size = new System.Drawing.Size(0, 13);
            this.lblOffCount.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtItemId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtImprintAreaCode);
            this.panel1.Controls.Add(this.ProcessId);
            this.panel1.Controls.Add(this.txtProcessId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtCustomerNumber);
            this.panel1.Location = new System.Drawing.Point(195, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 163);
            this.panel1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Search in ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnLive);
            this.panel2.Controls.Add(this.rbtniNet);
            this.panel2.Location = new System.Drawing.Point(338, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 20);
            this.panel2.TabIndex = 28;
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
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(1, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(500, 1);
            this.label5.TabIndex = 26;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 85);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(577, 69);
            this.listBox1.TabIndex = 25;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(251, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 20);
            this.button1.TabIndex = 24;
            this.button1.Text = "根据ItemId获取ImprintAredCode、ProcessId";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "ItemId";
            // 
            // txtItemId
            // 
            this.txtItemId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemId.Location = new System.Drawing.Point(66, 59);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(173, 20);
            this.txtItemId.TabIndex = 22;
            this.txtItemId.Text = "30303";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "ImprintAreaCode";
            // 
            // txtImprintAreaCode
            // 
            this.txtImprintAreaCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImprintAreaCode.Location = new System.Drawing.Point(338, 30);
            this.txtImprintAreaCode.Name = "txtImprintAreaCode";
            this.txtImprintAreaCode.Size = new System.Drawing.Size(173, 20);
            this.txtImprintAreaCode.TabIndex = 20;
            this.txtImprintAreaCode.Text = "ASP631";
            // 
            // ProcessId
            // 
            this.ProcessId.AutoSize = true;
            this.ProcessId.Location = new System.Drawing.Point(12, 32);
            this.ProcessId.Name = "ProcessId";
            this.ProcessId.Size = new System.Drawing.Size(54, 13);
            this.ProcessId.TabIndex = 18;
            this.ProcessId.Text = "ProcessId";
            // 
            // txtProcessId
            // 
            this.txtProcessId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessId.Location = new System.Drawing.Point(81, 29);
            this.txtProcessId.Name = "txtProcessId";
            this.txtProcessId.Size = new System.Drawing.Size(138, 20);
            this.txtProcessId.TabIndex = 16;
            this.txtProcessId.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "CustomerNo";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(516, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 48);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerNumber.Location = new System.Drawing.Point(81, 3);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(138, 20);
            this.txtCustomerNumber.TabIndex = 10;
            this.txtCustomerNumber.Text = "00000011";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Get Saved Count By Dam Sercive:";
            // 
            // lblDamServiceCount
            // 
            this.lblDamServiceCount.AutoSize = true;
            this.lblDamServiceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDamServiceCount.Location = new System.Drawing.Point(714, 169);
            this.lblDamServiceCount.Name = "lblDamServiceCount";
            this.lblDamServiceCount.Size = new System.Drawing.Size(49, 25);
            this.lblDamServiceCount.TabIndex = 26;
            this.lblDamServiceCount.Text = "N/A";
            // 
            // SavedArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlMainArea);
            this.Name = "SavedArt";
            this.Size = new System.Drawing.Size(830, 650);
            this.PnlMainArea.ResumeLayout(false);
            this.PnlDgvBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrid)).EndInit();
            this.PnlTopTitle.ResumeLayout(false);
            this.PnlTopTitle.PerformLayout();
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCustomerNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Label lblOffCount;
        private System.Windows.Forms.Label ProcessId;
        private System.Windows.Forms.TextBox txtProcessId;
        private System.Windows.Forms.DataGridView DgvGrid;
        private UserControls.PageBar PageBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImprintAreaCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilenameNoExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorSpace;
        private System.Windows.Forms.DataGridViewImageColumn Preview;
        private DMS.DataGridViewPreviewButtonColumn Nucleus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnLive;
        private System.Windows.Forms.RadioButton rbtniNet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDamServiceCount;
    }
}

