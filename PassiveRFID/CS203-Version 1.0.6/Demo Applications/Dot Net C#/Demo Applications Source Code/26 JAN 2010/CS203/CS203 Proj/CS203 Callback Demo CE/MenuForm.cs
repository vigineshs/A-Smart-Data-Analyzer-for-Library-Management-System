using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO_CE
{
    using CSLibrary.Constants;

    public partial class MenuForm : Form
    {
        #region Member
        enum E_MENU
        {
            Inventory,
            Ranging,
            ReadWrite,
            Geiger,
            Security,
            Kill,
            Setup,
            Exit
        }
        public string TargetEPC = "";
        #endregion

        #region Form
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            AttachCallback(true);

            lb_rfidlib.Text = Program.rfidLibraryVersion.ToString();
            lb_firmware.Text = Program.firmwareVersion.ToString();
            lb_software.Text = Program.Version;
            lb_cslib.Text = Program.cslibraryVersion.ToString();
            lb_macaddr.Text = Program.macAddress;
            Program.Power.Show();
            UpdateSetting();
            AddMenu();
            CSLibrary.Windows.UI.SplashScreen.Stop();
        }

        private void MenuForm_Closing(object sender, CancelEventArgs e)
        {
            AttachCallback(false);
            DialogResult = DialogResult.Abort;
        }
        private void MenuForm_Activated(object sender, EventArgs e)
        {
            UpdatePower();
        }
        private void AttachCallback(bool en)
        {
            if (en)
            {
                CSLibrary.HotKeys.HotKeys.OnKeyEvent += new CSLibrary.HotKeys.HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
            }
            else
            {
                CSLibrary.HotKeys.HotKeys.OnKeyEvent -= new CSLibrary.HotKeys.HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
            }
        }

        void HotKeys_OnKeyEvent(CSLibrary.HotKeys.Key KeyCode, bool KeyDown)
        {
            if (!KeyDown)
            {
                switch (KeyCode)
                {
                    case CSLibrary.HotKeys.Key.F1:
                        AttachCallback(false);
                        using (ReaderInfomation info = new ReaderInfomation())
                        {
                            info.ShowDialog();
                        }
                        AttachCallback(true);
                        break;
                }
            }
        }
        #endregion

        #region Button Handle
        private void menuBar1_ButtonClick(object sender, EventArgs e)
        {
            AttachCallback(false);
            switch ((E_MENU)menuBar1.SelectedIndex)
            {
                case E_MENU.Exit:
                    this.Close();
                    break;
                case E_MENU.Geiger:
                    using (GeigerSearchForm search = new GeigerSearchForm())
                    {
                        search.ShowDialog();
                    }
                    break;
                case E_MENU.Inventory:
                    using (TagInventoryForm InvForm = new TagInventoryForm())
                    {
                        InvForm.ShowDialog();
                    }
                    break;
                case E_MENU.Kill:
                    using (TagKillForm kill = new TagKillForm())
                    {
                        kill.ShowDialog();
                    }
                    break;
                case E_MENU.ReadWrite:
                    using (TagReadWriteForm rw = new TagReadWriteForm())
                    {
                        rw.ShowDialog();
                    }
                    break;
                case E_MENU.Security:
                    using (TagSecurityForm security = new TagSecurityForm())
                    {
                        security.TargetEPC = TargetEPC;
                        security.ShowDialog();
                    }
                    break;
                case E_MENU.Setup:
                    using (TagSettingForm setting = new TagSettingForm())
                    {
                        if (setting.ShowDialog() == DialogResult.OK)
                        {
                            UpdateSetting();
                        }
                    }
                    break;
                case E_MENU.Ranging:
                    using (TagRangingForm form = new TagRangingForm())
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            UpdateSetting();
                        }
                    }
                    break;
                default:
                    break;
            }
            AttachCallback(true);
        }   


        #endregion

        #region Private Function
        private void UpdateSetting()
        {
            uint link = 0, power = 0;
            Program.ReaderCE.GetCurrentLinkProfile(ref link);
            Program.ReaderCE.GetPowerLevel(ref power);

            lb_freqProfile.Text = string.Format("Frequency Profile : {0}", Program.ReaderCE.SelectedRegionCode);
            lb_freqtype.Text = Program.ReaderCE.IsFixedChannel ? String.Format("Fixed Frequency : {0} MHz", Program.ReaderCE.SelectedFrequencyBand) : "Frequency : Hopping";
            lb_profile.Text = String.Format("Profile : {0}", link);
            lb_power.Text = String.Format("Power : {0}", power);
        }
        private void UpdatePower()
        {
            uint power = 0;
            Program.ReaderCE.GetPowerLevel(ref power);
            lb_power.Text = String.Format("Power : {0}", power);
        }
        private void AddMenu()
        {
            menuBar1.Add(new Button("Inventory", Color.AliceBlue, Color.Black));
            menuBar1.Add(new Button("Ranging", Color.Orange, Color.Black));
            menuBar1.Add(new Button("Read Write", Color.LightCyan, Color.Black));
            menuBar1.Add(new Button("Geiger", Color.LightGoldenrodYellow, Color.Black));
            menuBar1.Add(new Button("Security", Color.LightGreen, Color.Black));
            menuBar1.Add(new Button("Kill", Color.LightSkyBlue, Color.Black));
            menuBar1.Add(new Button("Setup", Color.LightPink, Color.Black));
            menuBar1.Add(new Button("Exit", Color.Black, Color.White));
            menuBar1.UpdateItems();
        }
        #endregion
    }
}