namespace APLTools.Advance.WinUI.UseImage
{
    partial class SharedArtwork
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtVendorId = new System.Windows.Forms.TextBox();
            this.rbtnSingle = new System.Windows.Forms.RadioButton();
            this.rbtnMultiple = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picThumbnial = new System.Windows.Forms.PictureBox();
            this.cbFileNames = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageSearchName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtThumbnialUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picNucleus = new System.Windows.Forms.PictureBox();
            this.txtNucleusUrl = new System.Windows.Forms.TextBox();
            this.txtProcessId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBatchSubmit = new System.Windows.Forms.Button();
            this.txtNecleusBatchEnter = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnial)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNucleus)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PNG file|*.png|JPG file|*.jpg|JPEG file|*.jpeg|PDF file|*.pdf";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(77, 175);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(100, 20);
            this.txtItemId.TabIndex = 2;
            // 
            // txtVendorId
            // 
            this.txtVendorId.Location = new System.Drawing.Point(77, 149);
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.Size = new System.Drawing.Size(100, 20);
            this.txtVendorId.TabIndex = 3;
            // 
            // rbtnSingle
            // 
            this.rbtnSingle.AutoSize = true;
            this.rbtnSingle.Checked = true;
            this.rbtnSingle.Location = new System.Drawing.Point(89, 202);
            this.rbtnSingle.Name = "rbtnSingle";
            this.rbtnSingle.Size = new System.Drawing.Size(54, 17);
            this.rbtnSingle.TabIndex = 4;
            this.rbtnSingle.TabStop = true;
            this.rbtnSingle.Text = "Single";
            this.rbtnSingle.UseVisualStyleBackColor = true;
            // 
            // rbtnMultiple
            // 
            this.rbtnMultiple.AutoSize = true;
            this.rbtnMultiple.Location = new System.Drawing.Point(149, 202);
            this.rbtnMultiple.Name = "rbtnMultiple";
            this.rbtnMultiple.Size = new System.Drawing.Size(61, 17);
            this.rbtnMultiple.TabIndex = 5;
            this.rbtnMultiple.Text = "Multiple";
            this.rbtnMultiple.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(15, 284);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(189, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit (DropDownList ●)";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vendor Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Item Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Color Space:";
            // 
            // picThumbnial
            // 
            this.picThumbnial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picThumbnial.Location = new System.Drawing.Point(647, 129);
            this.picThumbnial.Name = "picThumbnial";
            this.picThumbnial.Size = new System.Drawing.Size(50, 50);
            this.picThumbnial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picThumbnial.TabIndex = 10;
            this.picThumbnial.TabStop = false;
            // 
            // cbFileNames
            // 
            this.cbFileNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFileNames.FormattingEnabled = true;
            this.cbFileNames.Location = new System.Drawing.Point(264, 17);
            this.cbFileNames.Name = "cbFileNames";
            this.cbFileNames.Size = new System.Drawing.Size(121, 21);
            this.cbFileNames.TabIndex = 11;
            this.cbFileNames.SelectedIndexChanged += new System.EventHandler(this.cbFileNames_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 102);
            this.label4.TabIndex = 12;
            this.label4.Text = "【使用方法】填好VenderId，ItemId，选择ColorSpace，然后在右侧Dropdown中选择一个图片，等图片在下方显示出来后点击Submit，如果弹" +
    "出成功的提示框，说明添加成功。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(2, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "程序没有校验，请确保都填好后再提交。";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 1500;
            // 
            // imageSearchName
            // 
            this.imageSearchName.Location = new System.Drawing.Point(2, 29);
            this.imageSearchName.Name = "imageSearchName";
            this.imageSearchName.Size = new System.Drawing.Size(121, 20);
            this.imageSearchName.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.imageSearchName);
            this.panel1.Location = new System.Drawing.Point(230, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 57);
            this.panel1.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Nucleus enter ■";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(221, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Submit Searched   (Nucleus Enter ■)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Search in nucleus  (Nucleus enter ■)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtThumbnialUrl
            // 
            this.txtThumbnialUrl.Location = new System.Drawing.Point(227, 129);
            this.txtThumbnialUrl.Multiline = true;
            this.txtThumbnialUrl.Name = "txtThumbnialUrl";
            this.txtThumbnialUrl.Size = new System.Drawing.Size(406, 50);
            this.txtThumbnialUrl.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Thunbmail from Sence7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Preview from nucleus";
            // 
            // picNucleus
            // 
            this.picNucleus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picNucleus.Location = new System.Drawing.Point(647, 208);
            this.picNucleus.Name = "picNucleus";
            this.picNucleus.Size = new System.Drawing.Size(50, 50);
            this.picNucleus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNucleus.TabIndex = 10;
            this.picNucleus.TabStop = false;
            // 
            // txtNucleusUrl
            // 
            this.txtNucleusUrl.Location = new System.Drawing.Point(227, 208);
            this.txtNucleusUrl.Multiline = true;
            this.txtNucleusUrl.Name = "txtNucleusUrl";
            this.txtNucleusUrl.Size = new System.Drawing.Size(406, 50);
            this.txtNucleusUrl.TabIndex = 16;
            // 
            // txtProcessId
            // 
            this.txtProcessId.Location = new System.Drawing.Point(78, 227);
            this.txtProcessId.Name = "txtProcessId";
            this.txtProcessId.Size = new System.Drawing.Size(100, 20);
            this.txtProcessId.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "ProcessId:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(224, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 31);
            this.label10.TabIndex = 23;
            this.label10.Text = "●";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.btnBatchSubmit);
            this.panel2.Controls.Add(this.txtNecleusBatchEnter);
            this.panel2.Location = new System.Drawing.Point(230, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(467, 174);
            this.panel2.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(126, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(271, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "copy from Excel cells content or split them by semicolon ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Nucleus batch enter ♠";
            // 
            // btnBatchSubmit
            // 
            this.btnBatchSubmit.Location = new System.Drawing.Point(8, 146);
            this.btnBatchSubmit.Name = "btnBatchSubmit";
            this.btnBatchSubmit.Size = new System.Drawing.Size(221, 23);
            this.btnBatchSubmit.TabIndex = 16;
            this.btnBatchSubmit.Text = "Batch Submit (Nucleus Batch Enter ♠)";
            this.btnBatchSubmit.UseVisualStyleBackColor = true;
            this.btnBatchSubmit.Click += new System.EventHandler(this.btnBatchSubmit_Click);
            // 
            // txtNecleusBatchEnter
            // 
            this.txtNecleusBatchEnter.Location = new System.Drawing.Point(8, 42);
            this.txtNecleusBatchEnter.Multiline = true;
            this.txtNecleusBatchEnter.Name = "txtNecleusBatchEnter";
            this.txtNecleusBatchEnter.Size = new System.Drawing.Size(450, 98);
            this.txtNecleusBatchEnter.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(126, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "for instance, Blk-37-026,Blk-37-025";
            // 
            // SharedArtwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProcessId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNucleusUrl);
            this.Controls.Add(this.txtThumbnialUrl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFileNames);
            this.Controls.Add(this.picNucleus);
            this.Controls.Add(this.picThumbnial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbtnMultiple);
            this.Controls.Add(this.rbtnSingle);
            this.Controls.Add(this.txtVendorId);
            this.Controls.Add(this.txtItemId);
            this.Name = "SharedArtwork";
            this.Size = new System.Drawing.Size(736, 620);
            this.Load += new System.EventHandler(this.SharedArtwork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnial)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNucleus)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.TextBox txtVendorId;
        private System.Windows.Forms.RadioButton rbtnSingle;
        private System.Windows.Forms.RadioButton rbtnMultiple;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picThumbnial;
        private System.Windows.Forms.ComboBox cbFileNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox imageSearchName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtThumbnialUrl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picNucleus;
        private System.Windows.Forms.TextBox txtNucleusUrl;
        private System.Windows.Forms.TextBox txtProcessId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBatchSubmit;
        private System.Windows.Forms.TextBox txtNecleusBatchEnter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}