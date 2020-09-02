using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using APLTools.Logic;
using APLTools.Models;

namespace APLTools
{
    public partial class CheckDigitalBackground : Form
    {
        public CheckDigitalBackground()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(RunCheck);
            thread1.Start();
        }

        private void RunCheck()
        {
            this.Enabled = false;
            var lines = File.ReadAllLines(lblFilePath.Text);
            //DamToolsHelper damToolsHelper=new DamToolsHelper();
            var exist = 0;
            var nonExist = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var refId = lines[i].Trim();
                var connectionType = cboxDam.SelectedIndex == 0 ? ConnectionType.Live : ConnectionType.Dev;
                var checkResult = DamToolsHelper.CheckDigitalBackground(connectionType, refId);
                if (checkResult)
                {
                    lbAvailable.Items.Add(refId);
                    exist++;
                }
                else
                {
                    lbUnavailable.Items.Add(refId);
                    nonExist++;
                }
                lblProgress.Text = $"Progress: {i + 1}/{lines.Length}, Exist: {exist}, Non-Exist:{nonExist}";
            }
            this.Enabled = true;
            MessageBox.Show("Completed");
        }

        private void CheckDigitalBackground_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            cboxDam.SelectedIndex = 0;
        }
    }
}
