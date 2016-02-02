using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203DEMO
{
    public partial class PowerForm : Form
    {
        private uint power = 300;
        private bool Close = false;

        #region Form
        public PowerForm()
        {
            InitializeComponent();
        }

        private void PowerForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(320 - Width, 240 - Height);
            Program.ReaderCE.GetPowerLevel(ref power);
            lb_pwr.Text = string.Format("{0:F1} dBm", (double)power / 10);
        }
        private void PowerForm_LostFocus(object sender, EventArgs e)
        {
            CloseAndApply();
        }

        private void PowerForm_GotFocus(object sender, EventArgs e)
        {
            Close = false;
        }
        #endregion

        private void tmr_autohide_Tick(object sender, EventArgs e)
        {
            CloseAndApply();
        }

        #region Function
        public void PowerUp()
        {
            if (Program.ReaderCE.MyState != Reader.Constants.ReaderOperationMode.Idle)
                return;
            this.Show();
            power += 5;
            if (power > Program.ReaderCE.AvailableMaxPower)
            {
                power = Program.ReaderCE.AvailableMaxPower;
            }
            lb_pwr.Text = string.Format("{0:F1} dBm", (double)power / 10);

            ResetTimer();
        }

        public void PowerDown()
        {
            if (Program.ReaderCE.MyState != Reader.Constants.ReaderOperationMode.Idle)
                return;
            this.Show();
            power -= 5;
            if (power < 0)
            {
                power = 0;
            }
            lb_pwr.Text = string.Format("{0:F1} dBm", (double)power / 10);
            
            ResetTimer();
        }

        private void ResetTimer()
        {
            tmr_autohide.Enabled = false;
            tmr_autohide.Enabled = true;
        }

        
        private void PowerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)0x1B)
            {
                CloseAndApply();
            }
        }

        private void CloseAndApply()
        {
            if (!Close)
            {
                Close = true;
                if (Program.ReaderCE.MyState == Reader.Constants.ReaderOperationMode.Idle)
                {
                    Program.ReaderCE.SetPowerLevel((uint)power);
                }
                else
                {

                }
                this.Hide();
                tmr_autohide.Enabled = false;
            }
        }
        #endregion

    }
}