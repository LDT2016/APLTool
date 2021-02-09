namespace APLTools.Advance.WinUI.UseImage

{
    partial class SavedArtwork
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCusNum = new System.Windows.Forms.TextBox();
            this.txtProcessId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImprintFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listSavedFile = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSubMultiple = new System.Windows.Forms.Button();
            this.btnChooseFilePath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblUploadFileCount = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Number:";
            // 
            // txtCusNum
            // 
            this.txtCusNum.Location = new System.Drawing.Point(108, 87);
            this.txtCusNum.Name = "txtCusNum";
            this.txtCusNum.Size = new System.Drawing.Size(100, 20);
            this.txtCusNum.TabIndex = 1;
            // 
            // txtProcessId
            // 
            this.txtProcessId.Location = new System.Drawing.Point(108, 122);
            this.txtProcessId.Name = "txtProcessId";
            this.txtProcessId.Size = new System.Drawing.Size(100, 20);
            this.txtProcessId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Process Id:";
            // 
            // txtImprintFormat
            // 
            this.txtImprintFormat.Location = new System.Drawing.Point(108, 157);
            this.txtImprintFormat.Name = "txtImprintFormat";
            this.txtImprintFormat.Size = new System.Drawing.Size(100, 20);
            this.txtImprintFormat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Imprint Format:";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(12, 198);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(90, 23);
            this.btnChooseFile.TabIndex = 6;
            this.btnChooseFile.Text = "● Choose File...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 227);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(196, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit Single ●";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(108, 203);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(103, 13);
            this.lblFileName.TabIndex = 8;
            this.lblFileName.Text = "Please Choose a file";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(8, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 75);
            this.label7.TabIndex = 16;
            this.label7.Text = "【使用方法】Customer Number为必填项，ProcessId和ImprintFormat为选填，然后选取一个本地的图片，完成后点提交，如果出现成功提示，" +
    "则添加成功。";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listSavedFile
            // 
            this.listSavedFile.ContextMenuStrip = this.contextMenuStrip1;
            this.listSavedFile.FormattingEnabled = true;
            this.listSavedFile.Location = new System.Drawing.Point(12, 324);
            this.listSavedFile.Name = "listSavedFile";
            this.listSavedFile.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listSavedFile.Size = new System.Drawing.Size(521, 134);
            this.listSavedFile.TabIndex = 17;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.removeToolStripMenuItem.Text = "remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // btnSubMultiple
            // 
            this.btnSubMultiple.Location = new System.Drawing.Point(11, 464);
            this.btnSubMultiple.Name = "btnSubMultiple";
            this.btnSubMultiple.Size = new System.Drawing.Size(196, 23);
            this.btnSubMultiple.TabIndex = 7;
            this.btnSubMultiple.Text = "Submit Nultiple ◆";
            this.btnSubMultiple.UseVisualStyleBackColor = true;
            this.btnSubMultiple.Click += new System.EventHandler(this.btnSubMultiple_Click);
            // 
            // btnChooseFilePath
            // 
            this.btnChooseFilePath.Location = new System.Drawing.Point(12, 265);
            this.btnChooseFilePath.Name = "btnChooseFilePath";
            this.btnChooseFilePath.Size = new System.Drawing.Size(90, 23);
            this.btnChooseFilePath.TabIndex = 6;
            this.btnChooseFilePath.Text = "◆ Choose Path";
            this.btnChooseFilePath.UseVisualStyleBackColor = true;
            this.btnChooseFilePath.Click += new System.EventHandler(this.btnChooseFilePath_Click);
            // 
            // lblUploadFileCount
            // 
            this.lblUploadFileCount.AutoSize = true;
            this.lblUploadFileCount.Location = new System.Drawing.Point(539, 324);
            this.lblUploadFileCount.Name = "lblUploadFileCount";
            this.lblUploadFileCount.Size = new System.Drawing.Size(0, 13);
            this.lblUploadFileCount.TabIndex = 20;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(54, 295);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(479, 20);
            this.txtPath.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Path";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "◆ Loading Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SavedArtwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblUploadFileCount);
            this.Controls.Add(this.listSavedFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnSubMultiple);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnChooseFilePath);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.txtImprintFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProcessId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCusNum);
            this.Controls.Add(this.label1);
            this.Name = "SavedArtwork";
            this.Size = new System.Drawing.Size(612, 545);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCusNum;
        private System.Windows.Forms.TextBox txtProcessId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImprintFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listSavedFile;
        private System.Windows.Forms.Button btnSubMultiple;
        private System.Windows.Forms.Button btnChooseFilePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Label lblUploadFileCount;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}