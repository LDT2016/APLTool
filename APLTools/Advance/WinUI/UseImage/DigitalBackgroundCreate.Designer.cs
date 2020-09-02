namespace APLTools.Advance.WinUI.UseImage

{
    partial class DigitalBackgroundCreate
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
            this.txtImageId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
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
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtImageId
            // 
            this.txtImageId.Location = new System.Drawing.Point(152, 9);
            this.txtImageId.Name = "txtImageId";
            this.txtImageId.Size = new System.Drawing.Size(111, 20);
            this.txtImageId.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ImageId ( metaData.refId ):";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(17, 50);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(90, 23);
            this.btnChooseFile.TabIndex = 6;
            this.btnChooseFile.Text = "● Choose File...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(17, 79);
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
            this.lblFileName.Location = new System.Drawing.Point(113, 55);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(103, 13);
            this.lblFileName.TabIndex = 8;
            this.lblFileName.Text = "Please Choose a file";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listSavedFile
            // 
            this.listSavedFile.ContextMenuStrip = this.contextMenuStrip1;
            this.listSavedFile.FormattingEnabled = true;
            this.listSavedFile.HorizontalScrollbar = true;
            this.listSavedFile.Location = new System.Drawing.Point(17, 184);
            this.listSavedFile.Name = "listSavedFile";
            this.listSavedFile.ScrollAlwaysVisible = true;
            this.listSavedFile.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listSavedFile.Size = new System.Drawing.Size(521, 238);
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
            this.btnSubMultiple.Location = new System.Drawing.Point(16, 426);
            this.btnSubMultiple.Name = "btnSubMultiple";
            this.btnSubMultiple.Size = new System.Drawing.Size(196, 23);
            this.btnSubMultiple.TabIndex = 7;
            this.btnSubMultiple.Text = "Submit Nultiple ◆";
            this.btnSubMultiple.UseVisualStyleBackColor = true;
            this.btnSubMultiple.Click += new System.EventHandler(this.btnSubMultiple_Click);
            // 
            // btnChooseFilePath
            // 
            this.btnChooseFilePath.Location = new System.Drawing.Point(17, 123);
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
            this.lblUploadFileCount.Location = new System.Drawing.Point(544, 222);
            this.lblUploadFileCount.Name = "lblUploadFileCount";
            this.lblUploadFileCount.Size = new System.Drawing.Size(0, 13);
            this.lblUploadFileCount.TabIndex = 20;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(59, 155);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(479, 20);
            this.txtPath.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Path";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "◆ Loading Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(-4, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1300, 1);
            this.label1.TabIndex = 24;
            // 
            // DigitalBackgroundCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblUploadFileCount);
            this.Controls.Add(this.listSavedFile);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnSubMultiple);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnChooseFilePath);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.txtImageId);
            this.Controls.Add(this.label3);
            this.Name = "DigitalBackgroundCreate";
            this.Size = new System.Drawing.Size(612, 545);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtImageId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblFileName;
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
        private System.Windows.Forms.Label label1;
    }
}