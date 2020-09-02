namespace BackgroundProductionFileDownloader
{
    partial class BackgroundProductionFileDownloader
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtItemID = new System.Windows.Forms.TextBox();
            this.RdAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.RdSpecified = new System.Windows.Forms.RadioButton();
            this.NumTimes = new System.Windows.Forms.NumericUpDown();
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.BtnExecute = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item ID:";
            // 
            // TxtItemID
            // 
            this.TxtItemID.Location = new System.Drawing.Point(35, 47);
            this.TxtItemID.Multiline = true;
            this.TxtItemID.Name = "TxtItemID";
            this.TxtItemID.Size = new System.Drawing.Size(88, 175);
            this.TxtItemID.TabIndex = 1;
            // 
            // RdAll
            // 
            this.RdAll.AutoSize = true;
            this.RdAll.Location = new System.Drawing.Point(200, 61);
            this.RdAll.Name = "RdAll";
            this.RdAll.Size = new System.Drawing.Size(36, 17);
            this.RdAll.TabIndex = 2;
            this.RdAll.Text = "All";
            this.RdAll.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Execute design_GetImageById times:";
            // 
            // RdSpecified
            // 
            this.RdSpecified.AutoSize = true;
            this.RdSpecified.Checked = true;
            this.RdSpecified.Location = new System.Drawing.Point(271, 61);
            this.RdSpecified.Name = "RdSpecified";
            this.RdSpecified.Size = new System.Drawing.Size(69, 17);
            this.RdSpecified.TabIndex = 4;
            this.RdSpecified.TabStop = true;
            this.RdSpecified.Text = "Specified";
            this.RdSpecified.UseVisualStyleBackColor = true;
            // 
            // NumTimes
            // 
            this.NumTimes.Location = new System.Drawing.Point(346, 61);
            this.NumTimes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumTimes.Name = "NumTimes";
            this.NumTimes.Size = new System.Drawing.Size(67, 20);
            this.NumTimes.TabIndex = 5;
            this.NumTimes.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // TxtOutput
            // 
            this.TxtOutput.Location = new System.Drawing.Point(12, 241);
            this.TxtOutput.Multiline = true;
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.ReadOnly = true;
            this.TxtOutput.Size = new System.Drawing.Size(776, 197);
            this.TxtOutput.TabIndex = 6;
            // 
            // BtnExecute
            // 
            this.BtnExecute.Location = new System.Drawing.Point(200, 104);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(75, 23);
            this.BtnExecute.TabIndex = 7;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.UseVisualStyleBackColor = true;
            this.BtnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(314, 104);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnExecute);
            this.Controls.Add(this.TxtOutput);
            this.Controls.Add(this.NumTimes);
            this.Controls.Add(this.RdSpecified);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RdAll);
            this.Controls.Add(this.TxtItemID);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Background Production File Downloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtItemID;
        private System.Windows.Forms.RadioButton RdAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RdSpecified;
        private System.Windows.Forms.NumericUpDown NumTimes;
        private System.Windows.Forms.TextBox TxtOutput;
        private System.Windows.Forms.Button BtnExecute;
        private System.Windows.Forms.Button BtnCancel;
    }
}

