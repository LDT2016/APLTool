﻿namespace APLTools.Advance.UserControls
{
    partial class Button
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
            this.PnlBG = new System.Windows.Forms.Panel();
            this.LblText = new System.Windows.Forms.Label();
            this.PnlBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlBG
            // 
            this.PnlBG.BackgroundImage = global::APLTools.Properties.Resources.ButtonBG01;
            this.PnlBG.Controls.Add(this.LblText);
            this.PnlBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBG.Location = new System.Drawing.Point(1, 1);
            this.PnlBG.Name = "PnlBG";
            this.PnlBG.Size = new System.Drawing.Size(80, 26);
            this.PnlBG.TabIndex = 0;
            // 
            // LblText
            // 
            this.LblText.BackColor = System.Drawing.Color.Transparent;
            this.LblText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblText.Location = new System.Drawing.Point(0, 0);
            this.LblText.Name = "LblText";
            this.LblText.Size = new System.Drawing.Size(80, 26);
            this.LblText.TabIndex = 0;
            this.LblText.Text = "按钮";
            this.LblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.Controls.Add(this.PnlBG);
            this.Name = "Button";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(82, 28);
            this.PnlBG.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlBG;
        private System.Windows.Forms.Label LblText;
    }
}

