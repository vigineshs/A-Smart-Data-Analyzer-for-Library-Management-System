using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
namespace CS203DEMO
{
    using rfid.Constants;

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
                rfid.Structures.Version rfidVers = Program.ReaderCE.GetDriverVersion();
                //Get Firmware Version
                rfid.Structures.Version FirmVers = Program.ReaderCE.GetFirmwareVersion();
                //Get CSLibrary Version
                rfid.Structures.Version cslib = Reader.Utility.Version.GetVersion();
                //Get 8051 Ethernet Application Version
                rfid.Structures.Version c51app = Program.ReaderCE.GetC51AppVersion();
                if (c51app.major == 0)
                {
                    c51app = Program.ReaderCE.GetImageVersion();
                }

                //Get 8051 Ethernet Bootloader Version
                rfid.Structures.Version c51bldr = Program.ReaderCE.GetC51BootLoaderVersion();
                if (c51bldr.major == 0)
                {
                    c51bldr = Program.ReaderCE.GetBootLoaderVersion();
                }

                //Get User Interface Version
                lb_software.Text = Program.Version;
                lb_rfidlib.Text = string.Format("{0}.{1}.{2}", rfidVers.major, rfidVers.minor, rfidVers.patch);
                lb_firmware.Text = string.Format("{0}.{1}.{2}", FirmVers.major, FirmVers.minor, FirmVers.patch);
                lb_c51App.Text = string.Format("{0}.{1}.{2}", c51app.major, c51app.minor, c51app.patch);
                lb_c51bldr.Text = string.Format("{0}.{1}.{2}", c51bldr.major, c51bldr.minor, c51bldr.patch);
                lb_cslib.Text = string.Format("{0}.{1}.{2}", cslib.major, cslib.minor, cslib.patch);

                //No use
                //Program.Power.Show();

                //Refresh Reader Configuration, e.g. frequency channel, power, country
                UpdateSetting();
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
            using (ReadWriteForm rw = new ReadWriteForm())
            {
                rw.TargetEPC = TargetEPC;
                rw.ShowDialog();
                // Update to written EPC
                TargetEPC = rw.TargetEPC;
            }
            UpdatePower();
        }

        private void btn_geiger_Click(object sender, EventArgs e)
        {
            using (GeigerSearchForm search = new GeigerSearchForm())
            {
                search.ShowDialog();
            }
            UpdatePower();
        }

        private void btn_security_Click(object sender, EventArgs e)
        {
            using (TagSecurityForm security = new TagSecurityForm())
            {
                security.TargetEPC = TargetEPC;
                security.ShowDialog();
            }
            UpdatePower();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_inv_Click(object sender, EventArgs e)
        {
            using (InventoryForm InvForm = new InventoryForm(false))
            {
                InvForm.ShowDialog();
            }
            UpdatePower();
        }

        private void btn_setup_Click(object sender, EventArgs e)
        {
            using (SettingForm setting = new SettingForm())
            {
                setting.ShowDialog();
                {
                    UpdateSetting();
                }
            }
        }
        private void pb_logo_Click(object sender, EventArgs e)
        {
            // Goto CSL Homepage
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://www.convergence.com.hk/";
            proc.Start();
        }

        #endregion

        #region Private Function
        private void UpdateSetting()
        {
            uint link = 0, power = 0;
            Program.ReaderCE.GetPowerLevel(ref power);

            Program.ReaderCE.GetCurrentLinkProfile(ref link);

            lb_freqProfile.Text = string.Format("Frequency Profile : {0}", Program.ReaderCE.SelectedFreqProfile);
            lb_freqtype.Text = Program.ReaderCE.IsFixedChannel ? String.Format("Fixed Frequency : {0} MHz", Program.ReaderCE.SelectedFrequency) : "Frequency : Hopping";
            lb_profile.Text = String.Format("Profile : {0}", link);
            lb_power.Text = String.Format("Power : {0}", power);
        }
        private void UpdatePower()
        {
            uint power = 0;
            Program.ReaderCE.GetPowerLevel(ref power);
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