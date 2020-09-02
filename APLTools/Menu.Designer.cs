namespace APLTools
{
    partial class Menu
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
            this.btnSharedArtwork = new System.Windows.Forms.Button();
            this.btnSavedArtwork = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnCheckDigitalBackground = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSharedArtwork
            // 
            this.btnSharedArtwork.Location = new System.Drawing.Point(12, 12);
            this.btnSharedArtwork.Name = "btnSharedArtwork";
            this.btnSharedArtwork.Size = new System.Drawing.Size(168, 82);
            this.btnSharedArtwork.TabIndex = 0;
            this.btnSharedArtwork.Text = "添加Shared Artwork";
            this.btnSharedArtwork.UseVisualStyleBackColor = true;
            this.btnSharedArtwork.Click += new System.EventHandler(this.btnSharedArtwork_Click);
            // 
            // btnSavedArtwork
            // 
            this.btnSavedArtwork.Location = new System.Drawing.Point(186, 12);
            this.btnSavedArtwork.Name = "btnSavedArtwork";
            this.btnSavedArtwork.Size = new System.Drawing.Size(168, 82);
            this.btnSavedArtwork.TabIndex = 1;
            this.btnSavedArtwork.Text = "添加Saved Artwork";
            this.btnSavedArtwork.UseVisualStyleBackColor = true;
            this.btnSavedArtwork.Click += new System.EventHandler(this.btnSavedArtwork_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(12, 100);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(168, 82);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "上传Artwork";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(186, 100);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(168, 82);
            this.btnTransfer.TabIndex = 3;
            this.btnTransfer.Text = "从LIVE复制Artwork";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnCheckDigitalBackground
            // 
            this.btnCheckDigitalBackground.Location = new System.Drawing.Point(12, 188);
            this.btnCheckDigitalBackground.Name = "btnCheckDigitalBackground";
            this.btnCheckDigitalBackground.Size = new System.Drawing.Size(168, 82);
            this.btnCheckDigitalBackground.TabIndex = 4;
            this.btnCheckDigitalBackground.Text = "检查DigtalBackground";
            this.btnCheckDigitalBackground.UseVisualStyleBackColor = true;
            this.btnCheckDigitalBackground.Click += new System.EventHandler(this.btnCheckDigitalBackground_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 82);
            this.button1.TabIndex = 5;
            this.button1.Text = "Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCheckDigitalBackground);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnSavedArtwork);
            this.Controls.Add(this.btnSharedArtwork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSharedArtwork;
        private System.Windows.Forms.Button btnSavedArtwork;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnCheckDigitalBackground;
        private System.Windows.Forms.Button button1;
    }
}

