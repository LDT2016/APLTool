namespace APLTools.Advance.WinUI.Devices.Main
{
    partial class Default
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
            this.PnlScrollArea = new System.Windows.Forms.Panel();
            this.SpaceBottom = new System.Windows.Forms.Panel();
            this.PnlInfo = new System.Windows.Forms.Panel();
            this.PnlInfoBack = new System.Windows.Forms.Panel();
            this.PnlControlArea = new System.Windows.Forms.Panel();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.PnlInfoTopLine = new System.Windows.Forms.Panel();
            this.PnlInfoTitle = new System.Windows.Forms.Panel();
            this.LblModuleTitle = new System.Windows.Forms.Label();
            this.PnlFooter = new System.Windows.Forms.Panel();
            this.PnlScrollArea.SuspendLayout();
            this.PnlInfo.SuspendLayout();
            this.PnlInfoBack.SuspendLayout();
            this.PnlControlArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.PnlInfoTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlScrollArea
            // 
            this.PnlScrollArea.AutoScroll = true;
            this.PnlScrollArea.Controls.Add(this.SpaceBottom);
            this.PnlScrollArea.Controls.Add(this.PnlInfo);
            this.PnlScrollArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlScrollArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.PnlScrollArea.Location = new System.Drawing.Point(0, 0);
            this.PnlScrollArea.Name = "PnlScrollArea";
            this.PnlScrollArea.Padding = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.PnlScrollArea.Size = new System.Drawing.Size(830, 596);
            this.PnlScrollArea.TabIndex = 2;
            // 
            // SpaceBottom
            // 
            this.SpaceBottom.BackColor = System.Drawing.Color.White;
            this.SpaceBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.SpaceBottom.Location = new System.Drawing.Point(20, 455);
            this.SpaceBottom.Name = "SpaceBottom";
            this.SpaceBottom.Size = new System.Drawing.Size(790, 22);
            this.SpaceBottom.TabIndex = 6;
            // 
            // PnlInfo
            // 
            this.PnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PnlInfo.Controls.Add(this.PnlInfoBack);
            this.PnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInfo.Location = new System.Drawing.Point(20, 22);
            this.PnlInfo.Name = "PnlInfo";
            this.PnlInfo.Padding = new System.Windows.Forms.Padding(1);
            this.PnlInfo.Size = new System.Drawing.Size(790, 433);
            this.PnlInfo.TabIndex = 0;
            // 
            // PnlInfoBack
            // 
            this.PnlInfoBack.BackColor = System.Drawing.Color.White;
            this.PnlInfoBack.Controls.Add(this.PnlControlArea);
            this.PnlInfoBack.Controls.Add(this.PnlInfoTopLine);
            this.PnlInfoBack.Controls.Add(this.PnlInfoTitle);
            this.PnlInfoBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlInfoBack.Location = new System.Drawing.Point(1, 1);
            this.PnlInfoBack.Name = "PnlInfoBack";
            this.PnlInfoBack.Size = new System.Drawing.Size(788, 431);
            this.PnlInfoBack.TabIndex = 2;
            // 
            // PnlControlArea
            // 
            this.PnlControlArea.BackColor = System.Drawing.Color.White;
            this.PnlControlArea.Controls.Add(this.PicLogo);
            this.PnlControlArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlControlArea.Location = new System.Drawing.Point(0, 28);
            this.PnlControlArea.Name = "PnlControlArea";
            this.PnlControlArea.Padding = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.PnlControlArea.Size = new System.Drawing.Size(788, 403);
            this.PnlControlArea.TabIndex = 4;
            // 
            // PicLogo
            // 
            this.PicLogo.Image = global::APLTools.Properties.Resources.LogoMain;
            this.PicLogo.Location = new System.Drawing.Point(20, 22);
            this.PicLogo.Margin = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(100, 108);
            this.PicLogo.TabIndex = 0;
            this.PicLogo.TabStop = false;
            // 
            // PnlInfoTopLine
            // 
            this.PnlInfoTopLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PnlInfoTopLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInfoTopLine.Location = new System.Drawing.Point(0, 27);
            this.PnlInfoTopLine.Name = "PnlInfoTopLine";
            this.PnlInfoTopLine.Size = new System.Drawing.Size(788, 1);
            this.PnlInfoTopLine.TabIndex = 3;
            // 
            // PnlInfoTitle
            // 
            this.PnlInfoTitle.BackColor = System.Drawing.Color.White;
            this.PnlInfoTitle.BackgroundImage = global::APLTools.Properties.Resources.TableHeaderBG;
            this.PnlInfoTitle.Controls.Add(this.LblModuleTitle);
            this.PnlInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInfoTitle.Location = new System.Drawing.Point(0, 0);
            this.PnlInfoTitle.Name = "PnlInfoTitle";
            this.PnlInfoTitle.Size = new System.Drawing.Size(788, 27);
            this.PnlInfoTitle.TabIndex = 2;
            // 
            // LblModuleTitle
            // 
            this.LblModuleTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblModuleTitle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblModuleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.LblModuleTitle.Location = new System.Drawing.Point(5, 1);
            this.LblModuleTitle.Name = "LblModuleTitle";
            this.LblModuleTitle.Size = new System.Drawing.Size(300, 25);
            this.LblModuleTitle.TabIndex = 1;
            this.LblModuleTitle.Text = "欢迎使用";
            this.LblModuleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlFooter
            // 
            this.PnlFooter.BackgroundImage = global::APLTools.Properties.Resources.FooterBG;
            this.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlFooter.Location = new System.Drawing.Point(0, 596);
            this.PnlFooter.Name = "PnlFooter";
            this.PnlFooter.Size = new System.Drawing.Size(830, 54);
            this.PnlFooter.TabIndex = 1;
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlScrollArea);
            this.Controls.Add(this.PnlFooter);
            this.Name = "Default";
            this.Size = new System.Drawing.Size(830, 650);
            this.PnlScrollArea.ResumeLayout(false);
            this.PnlInfo.ResumeLayout(false);
            this.PnlInfoBack.ResumeLayout(false);
            this.PnlControlArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.PnlInfoTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlFooter;
        private System.Windows.Forms.Panel PnlScrollArea;
        private System.Windows.Forms.Panel SpaceBottom;
        private System.Windows.Forms.Panel PnlInfo;
        private System.Windows.Forms.Panel PnlInfoBack;
        private System.Windows.Forms.Panel PnlControlArea;
        private System.Windows.Forms.PictureBox PicLogo;
        private System.Windows.Forms.Panel PnlInfoTopLine;
        private System.Windows.Forms.Panel PnlInfoTitle;
        private System.Windows.Forms.Label LblModuleTitle;
    }
}

