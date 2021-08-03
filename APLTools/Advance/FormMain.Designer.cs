namespace APLTools.Advance
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        private void InitializeComponent()
        {
            this.PnlContent = new System.Windows.Forms.Panel();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.PicCompanyLogo = new System.Windows.Forms.PictureBox();
            this.NavBar = new APLTools.Advance.UserControls.NavBar();
            this.PnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlContent
            // 
            this.PnlContent.AutoScroll = true;
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(154, 85);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(836, 600);
            this.PnlContent.TabIndex = 2;
            // 
            // PnlHeader
            // 
            this.PnlHeader.BackgroundImage = global::APLTools.Properties.Resources.HeaderBG;
            this.PnlHeader.Controls.Add(this.PicCompanyLogo);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(990, 85);
            this.PnlHeader.TabIndex = 0;
            // 
            // PicCompanyLogo
            // 
            this.PicCompanyLogo.Image = global::APLTools.Properties.Resources.CompanyLogo;
            this.PicCompanyLogo.Location = new System.Drawing.Point(0, 0);
            this.PicCompanyLogo.Name = "PicCompanyLogo";
            this.PicCompanyLogo.Size = new System.Drawing.Size(200, 20);
            this.PicCompanyLogo.TabIndex = 0;
            this.PicCompanyLogo.TabStop = false;
            // 
            // NavBar
            // 
            this.NavBar.AutoScroll = true;
            this.NavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavBar.Location = new System.Drawing.Point(0, 85);
            this.NavBar.Name = "NavBar";
            this.NavBar.Size = new System.Drawing.Size(154, 600);
            this.NavBar.TabIndex = 1;
            this.NavBar.ImageButtonClick += new APLTools.Advance.UserControls.NavBar.ButtonClickHander(this.NavBar_ImageButtonClick);
            this.NavBar.QuitSystemClick += new System.EventHandler(this.NavBar_QuitSystemClick);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(990, 685);
            this.Controls.Add(this.PnlContent);
            this.Controls.Add(this.NavBar);
            this.Controls.Add(this.PnlHeader);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance";
            this.PnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicCompanyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.PictureBox PicCompanyLogo;
        private APLTools.Advance.UserControls.NavBar NavBar;
        private System.Windows.Forms.Panel PnlContent;
    }
}

