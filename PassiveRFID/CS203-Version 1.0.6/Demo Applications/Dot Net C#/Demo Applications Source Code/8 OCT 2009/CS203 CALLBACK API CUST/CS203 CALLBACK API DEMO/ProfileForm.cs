using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203DEMO
{
    public partial class ProfileForm : Form
    {
        #region Private Member
        //private uint profile = 2;
        private bool Close = false;
        private uint MaxProfile = 0;
        private int SelectProfileIndex = 0;
        private uint[] Profile;
        #endregion

        #region Form
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 240 - Height);
            //profile = Program.ReaderCE.GetCurrentLinkProfile();
            Profile = Program.ReaderCE.AvailableLinkProfile;
            MaxProfile = Profile[Profile.Length - 1];
            SelectProfileIndex = (int)Program.ReaderCE.SelectedLinkProfileIndex;
            lb_profile.Text = SelectProfileIndex.ToString();
        }

        private void ProfileForm_Closing(object sender, CancelEventArgs e)
        {

        }
        private void ProfileForm_GotFocus(object sender, EventArgs e)
        {
            Close = false;
        }

        private void ProfileForm_LostFocus(object sender, EventArgs e)
        {
            CloseAndApply();
        }
        private void ProfileForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)0x1B)
            {
                CloseAndApply();
            }
        }
        #endregion

        #region Timer
        private void tmr_autoclose_Tick(object sender, EventArgs e)
        {
            CloseAndApply();
        }
        #endregion

        #region Function
        public void ProfileUp()
        {
            if (Program.ReaderCE.MyState != Reader.Constants.ReaderOperationMode.Idle)
                return;

            this.Show();

            SelectProfileIndex++;
            if (SelectProfileIndex >= Profile.Length)
            {
                SelectProfileIndex = Profile.Length - 1;
            }

            lb_profile.Text = Profile[SelectProfileIndex].ToString();
            ResetTimer();
        }

        public void ProfileDown()
        {
            if (Program.ReaderCE.MyState != Reader.Constants.ReaderOperationMode.Idle)
                return;
            this.Show();
            SelectProfileIndex--;
            if (SelectProfileIndex < 0)
            {
                SelectProfileIndex = 0;
            }

            lb_profile.Text = Profile[SelectProfileIndex].ToString();
            ResetTimer();
        }

        private void ResetTimer()
        {
            tmr_autohide.Enabled = false;
            tmr_autohide.Enabled = true;
        }
        private void CloseAndApply()
        {
            if (!Close)
            {
                Close = true;
                if (Program.ReaderCE.MyState == Reader.Constants.ReaderOperationMode.Idle)
                {
                    Program.ReaderCE.SetCurrentLinkProfile(Profile[SelectProfileIndex]);
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