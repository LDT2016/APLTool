﻿namespace APLTools.Advance.UserControls
{
    partial class LabelMuti
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
            this.LineText = new APLTools.Advance.UserControls.LabelLine();
            this.SuspendLayout();
            // 
            // LineText
            // 
            this.LineText.AutoHeight = false;
            this.LineText.Location = new System.Drawing.Point(0, 0);
            this.LineText.MinimumSize = new System.Drawing.Size(0, 24);
            this.LineText.Name = "LineText";
            this.LineText.Size = new System.Drawing.Size(150, 24);
            this.LineText.TabIndex = 0;
            // 
            // LabelMuti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.LineText);
            this.Name = "LabelMuti";
            this.Size = new System.Drawing.Size(150, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private LabelLine LineText;
    }
}

