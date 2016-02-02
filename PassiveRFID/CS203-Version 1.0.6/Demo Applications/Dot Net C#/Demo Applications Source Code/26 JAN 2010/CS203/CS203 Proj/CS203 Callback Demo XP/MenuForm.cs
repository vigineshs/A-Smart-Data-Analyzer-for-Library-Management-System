using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
namespace CS203_CALLBACK_API_DEMO
{
    

    public partial class MenuForm : Form
    {
        #region Member
        public string TargetEPC = "";
        #endregion

        #region Form
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Show MAC and IP
                Text = String.Format("IP = {0}, MAC = {1}", Program.IP, Program.MAC);

                //Get RFID Library Version
                CSLibrary.Structures.Version rfidVers = Program.ReaderXP.GetDriverVersion();
                //Get Firmware Version
                CSLibrary.Structures.Version FirmVers = Program.ReaderXP.GetFirmwareVersion();
                //Get CSLibrary Version
                CSLibrary.Structures.Version cslib = Program.ReaderXP.GetCSLibraryVersion();
                //Get 8051 Ethernet Application Version
                CSLibrary.Structures.Version c51app = Program.ReaderXP.GetC51AppVersion();
                if (c51app.major == 0)
                {
                    c51app = Program.ReaderXP.GetImageVersion();
                }

                //Get 8051 Ethernet Bootloader Version
                CSLibrary.Structures.Version c51bldr = Program.ReaderXP.GetC51BootLoaderVersion();
                if (c51bldr.major == 0)
                {
                    c51bldr = Program.ReaderXP.GetBootLoaderVersion();
                }

                //Get User Interface Version
                lb_software.Text = Program.GetDemoVersion().ToString(); ;
                lb_rfidlib.Text = rfidVers.ToString();
                lb_firmware.Text = FirmVers.ToString();
                lb_c51App.Text = c51app.ToString();
                lb_c51bldr.Text = c51bldr.ToString();
                lb_cslib.Text = cslib.ToString();

                //No use
                //Program.Power.Show();

                //Refresh Reader Configuration, e.g. frequency channel, power, country
                UpdateSetting();

                CSLibrary.Windows.UI.SplashScreen.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Reader Startup fail : {0}", ex));
                this.Close();
            }
        }

        #endregion

        #region Button Handle
        private void btn_rw_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (TagReadWriteForm rw = new TagReadWriteForm())
            {
                rw.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void btn_geiger_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (GeigerSearchForm search = new GeigerSearchForm())
            {
                search.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void btn_security_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (TagSecurityForm security = new TagSecurityForm())
            {
                security.TargetEPC = TargetEPC;
                security.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_inv_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (InventoryForm InvForm = new InventoryForm(false))
            {
                InvForm.ShowDialog();
            }
            UpdatePower();
            this.Show();
        }

        private void btn_setup_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (TagSettingForm setting = new TagSettingForm())
            {
                setting.ShowDialog();
                {
                    UpdateSetting();
                }
            }
            this.Show();
        }
        private void pb_logo_Click(object sender, EventArgs e)
        {
            // Goto CSL Homepage
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://www.convergence.com.hk/";
            proc.Start();
        }

        private void btn_kill_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (TagKillForm kill = new TagKillForm())
            {
                kill.ShowDialog();
            }
            this.Show();
        }
        private void btn_writeany_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (TagWriteAnyEPCForm form = new TagWriteAnyEPCForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        #endregion

        #region Private Function
        private void UpdateSetting()
        {
            uint link = 0, power = 0;
            Program.ReaderXP.GetPowerLevel(ref power);

            Program.ReaderXP.GetCurrentLinkProfile(ref link);

            lb_freqProfile.Text = string.Format("Frequency Profile : {0}", Program.ReaderXP.SelectedRegionCode);
            lb_freqtype.Text = Program.ReaderXP.IsFixedChannel ? String.Format("Fixed Frequency : {0} MHz", Program.ReaderXP.SelectedFrequencyBand) : "Frequency : Hopping";
            lb_profile.Text = String.Format("Profile : {0}", link);
            lb_power.Text = String.Format("Power : {0}", power);
        }
        private void UpdatePower()
        {
            uint power = 0;
            Program.ReaderXP.GetPowerLevel(ref power);
            lb_power.Text = String.Format("Power : {0}", power);
        }

        private void pb_logo_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pb_logo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        #endregion

    }
}