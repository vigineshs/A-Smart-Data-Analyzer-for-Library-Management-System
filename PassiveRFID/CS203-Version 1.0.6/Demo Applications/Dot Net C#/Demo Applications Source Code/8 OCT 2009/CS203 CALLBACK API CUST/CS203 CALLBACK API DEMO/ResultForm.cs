using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203DEMO
{
    public partial class ResultForm : Form
    {
        private bool Result = true;

        public ResultForm()
        {
            InitializeComponent();
        }
        private delegate void UpdateResultDeleg(bool success);
        public void UpdateResult(bool success)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateResultDeleg(UpdateResult), new object[] { success });
                return;
            }
            this.Show();
            if (Result != success)
            {
                if (success)
                {
                    lb_result.Text = "Success";
                    BackColor = Color.Green;
                }
                else
                {
                    lb_result.Text = "Fail";
                    BackColor = Color.Red;
                }
                Result = success;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((320 - Width) / 2, (240 - Height) / 2);
        }

    }
}