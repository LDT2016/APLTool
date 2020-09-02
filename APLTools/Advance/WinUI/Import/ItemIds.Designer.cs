namespace APLTools.Advance.WinUI.Import
{
    partial class ItemIds
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
            this.PnlMainArea = new System.Windows.Forms.Panel();
            this.PnlDgvBack = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PnlTopTitle = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOffCount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtItemid = new APLTools.Advance.UserControls.TextBox();
            this.button3 = new APLTools.Advance.UserControls.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PnlMainArea.SuspendLayout();
            this.PnlDgvBack.SuspendLayout();
            this.PnlTopTitle.SuspendLayout();
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
            this.PnlDgvBack.Controls.Add(this.richTextBox1);
            this.PnlDgvBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDgvBack.Location = new System.Drawing.Point(20, 176);
            this.PnlDgvBack.Name = "PnlDgvBack";
            this.PnlDgvBack.Size = new System.Drawing.Size(790, 452);
            this.PnlDgvBack.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(790, 452);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // PnlTopTitle
            // 
            this.PnlTopTitle.Controls.Add(this.button2);
            this.PnlTopTitle.Controls.Add(this.button4);
            this.PnlTopTitle.Controls.Add(this.button6);
            this.PnlTopTitle.Controls.Add(this.txtItemid);
            this.PnlTopTitle.Controls.Add(this.listBox1);
            this.PnlTopTitle.Controls.Add(this.button3);
            this.PnlTopTitle.Controls.Add(this.button1);
            this.PnlTopTitle.Controls.Add(this.label1);
            this.PnlTopTitle.Controls.Add(this.lblOffCount);
            this.PnlTopTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTopTitle.Location = new System.Drawing.Point(20, 22);
            this.PnlTopTitle.Name = "PnlTopTitle";
            this.PnlTopTitle.Size = new System.Drawing.Size(790, 154);
            this.PnlTopTitle.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 44);
            this.label1.TabIndex = 23;
            this.label1.Text = "ItemIds";
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 69);
            this.listBox1.TabIndex = 32;
            // 
            // txtItemid
            // 
            this.txtItemid.BackColor = System.Drawing.Color.White;
            this.txtItemid.Location = new System.Drawing.Point(9, 44);
            this.txtItemid.Multiline = false;
            this.txtItemid.Name = "txtItemid";
            this.txtItemid.Padding = new System.Windows.Forms.Padding(1);
            this.txtItemid.PasswordChar = '\0';
            this.txtItemid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtItemid.Size = new System.Drawing.Size(120, 27);
            this.txtItemid.TabIndex = 34;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.button3.Location = new System.Drawing.Point(700, 13);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(1);
            this.button3.Size = new System.Drawing.Size(82, 26);
            this.button3.TabIndex = 31;
            this.button3.Text = "test";
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
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
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(144, 44);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 36;
            this.button6.Text = "Add";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button4_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(144, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 37;
            this.button4.Text = "Go!";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button5_Click);
            // 
            // ItemIds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlMainArea);
            this.Name = "ItemIds";
            this.Size = new System.Drawing.Size(830, 650);
            this.PnlMainArea.ResumeLayout(false);
            this.PnlDgvBack.ResumeLayout(false);
            this.PnlTopTitle.ResumeLayout(false);
            this.PnlTopTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlMainArea;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Panel PnlDgvBack;
        private System.Windows.Forms.Panel PnlTopTitle;
        private System.Windows.Forms.Label lblOffCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private UserControls.Button button3;
        private UserControls.TextBox txtItemid;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
    }
}

