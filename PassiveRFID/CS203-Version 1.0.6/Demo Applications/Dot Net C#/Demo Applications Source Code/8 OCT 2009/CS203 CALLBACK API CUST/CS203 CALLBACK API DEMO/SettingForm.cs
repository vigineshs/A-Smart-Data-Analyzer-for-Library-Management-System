using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Reader.Constants;
using Reader.Settings;

using rfid.Constants;
using rfid.Structures;

namespace CS203DEMO
{
    public partial class SettingForm : Form
    {
        private Singulation_FixedQ singulation_fixedQ;
        private Singulation_DynamicQ singulation_dynamicQ;
        private Singulation_DynamicQ singulation_dynamicQAdjust;
        private Singulation_DynamicQ singulation_dynamicQThreshold;

        private double[] CurrentFreqList = null;
        //private Reader.Structures.Client clientip = new Reader.Structures.Client();
        //private uint tcpTimeout = 0;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            cb_fixed.Enabled = !Program.ReaderCE.IsFixedChannelOnly;
            cb_fixed.Checked = lv_frequ.Enabled = Program.ReaderCE.IsFixedChannel;
            //Load Setting
            if (Program.ReaderCE.SelectedFreqProfile == Reader.Constants.Region.JP)
            {
                cb_lbt.Enabled = true;
                cb_lbt.Checked = Program.ReaderCE.LBT_ON == LBT.ON;
            }
            else
                cb_lbt.Enabled = false;

            // get current maximum power will can set
            nb_power.Maximum = Program.ReaderCE.AvailableMaxPower;

            // hopping or fixed channel
            //lv_frequ.Enabled = Program.ReaderCE.IsFixedChannel;

            //get current link profile
            uint linkprofile = 0;
            Program.ReaderCE.GetCurrentLinkProfile(ref linkprofile);

            //Retrieve all available link profile
            foreach (uint link in Program.ReaderCE.AvailableLinkProfile)
            {
                cb_linkprofile.Items.Add(link);
            }

            //highlight the current link profile
            cb_linkprofile.SelectedItem = linkprofile;

            rfid.Structures.AntennaPortConfig cfg = new rfid.Structures.AntennaPortConfig();
            Program.ReaderCE.GetAntennaPortConfiguration(ref cfg);

            nb_dwell.Value = cfg.dwellTime;
            nb_cycle.Value = cfg.numberInventoryCycles;

            //get current power level
            uint power = 0;
            Program.ReaderCE.GetPowerLevel(ref power);
            nb_power.Value = power;

            //Retrieve all available countries
            foreach (Reader.Constants.Region fr in Program.ReaderCE.AvailableRegion)
            {
                cb_country.Items.Add(fr.ToString());
            }

            //current select frequency profile index
            cb_country.SelectedIndex = Program.ReaderCE.SelectedFreqProfileIndex;

            //Retrieve all available frequency channels
            CurrentFreqList = Program.ReaderCE.GetFrequencyTable(Program.ReaderCE.AvailableRegion[cb_country.SelectedIndex]);

            UpdateFreqList();

            if (Program.ReaderCE.IsFixedChannel)
            {
                lv_frequ.Items[(int)Program.ReaderCE.SelectedFreqChannel].Selected = true;
                lv_frequ.Items[(int)Program.ReaderCE.SelectedFreqChannel].Focused = true;
                lv_frequ.EnsureVisible((int)Program.ReaderCE.SelectedFreqChannel);
            }
            
            /*//get client IP
            if (Program.ReaderCE.GetCS203IP(ref clientip) != rfid.Constants.Result.OK)
            {
                MessageBox.Show("GetClientIP Failed");
            }

            nb_cip0.Value = clientip.IP[0];
            nb_cip1.Value = clientip.IP[1];
            nb_cip2.Value = clientip.IP[2];
            nb_cip3.Value = clientip.IP[3];

            if (Program.ReaderCE.GetTcpTimeout(ref tcpTimeout) != rfid.Constants.Result.OK)
            {
                MessageBox.Show("GetTcpTimeout Failed");
            }
            nb_tcptimeout.Value = tcpTimeout;*/


            //Load DataSource
            this.cb_operation.DataSource = Enum.GetValues(typeof(RadioOperationMode));

            this.cb_algorithm.DataSource = Enum.GetValues(typeof(SingulationAlgorithm));

            this.cb_selected.DataSource = Enum.GetValues(typeof(Selected));

            this.cb_session.DataSource = Enum.GetValues(typeof(Session));


            this.cb_target.DataSource = Enum.GetValues(typeof(SessionTarget));

            retrieveAndDisplayValues();

            tb_serverIP.Text = LocalSettings.ServerIP;
            tb_serverName.Text = LocalSettings.ServerName;
            tb_dbName.Text = LocalSettings.DBName;
            tb_userID.Text = LocalSettings.UserID;
           // tb_userID.Text = LocalSettings.ServerName;
           // tb_password.Text = LocalSettings.ServerName;
            tb_password.Text = LocalSettings.Password;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateFreqList()
        {
            lv_frequ.BeginUpdate();
            lv_frequ.Items.Clear();
            for (int i = 0; i < CurrentFreqList.Length; i++)
            {
                //Japan Start From channel 2
                if (Program.ReaderCE.SelectedFreqProfile == Reader.Constants.Region.JP)
                    lv_frequ.Items.Add(new ListViewItem(new String[2] { (i + 2).ToString(), String.Format("{0:F2} MHz", CurrentFreqList[i]) }));
                else
                    lv_frequ.Items.Add(new ListViewItem(new String[2] { (i + 1).ToString(), String.Format("{0:F2} MHz", CurrentFreqList[i]) }));
            }
            lv_frequ.EndUpdate();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }

        protected void retrieveAndDisplayValues()
        {
            this.gb_singulation.Controls.Remove(singulation_fixedQ);
            this.gb_singulation.Controls.Remove(singulation_dynamicQ);
            this.gb_singulation.Controls.Remove(singulation_dynamicQAdjust);
            this.gb_singulation.Controls.Remove(singulation_dynamicQThreshold);
            this.gb_singulation.Refresh();


            singulation_fixedQ = new Singulation_FixedQ(Settings.FixedQParms);
            singulation_fixedQ.Location = new Point(6, 50);
            singulation_fixedQ.Visible = false;

            singulation_dynamicQ = new Singulation_DynamicQ(Settings.DynamicQParms, SingulationAlgorithm.DYNAMICQ);
            singulation_dynamicQ.Location = new Point(6, 50);
            singulation_dynamicQ.Visible = false;

            singulation_dynamicQAdjust = new Singulation_DynamicQ(Settings.DynamicQAdjustParms, SingulationAlgorithm.DYNAMICQ_ADJUST);
            singulation_dynamicQAdjust.Location = new Point(6, 50);
            singulation_dynamicQAdjust.Visible = false;

            singulation_dynamicQThreshold = new Singulation_DynamicQ(Settings.DynamicQThresholdParms, SingulationAlgorithm.DYNAMICQ_THRESH);
            singulation_dynamicQThreshold.Location = new Point(6, 50);
            singulation_dynamicQThreshold.Visible = false;


            this.cb_algorithm.SelectedItem = Program.ReaderCE.RdrOpParms.RunBasicSearchParms.Singulation;

            this.cb_selected.SelectedItem = Program.ReaderCE.RdrOpParms.RunBasicSearchParms.TagGroup.selected;

            this.cb_session.SelectedItem = Program.ReaderCE.RdrOpParms.RunBasicSearchParms.TagGroup.session;

            this.cb_target.SelectedItem = Program.ReaderCE.RdrOpParms.RunBasicSearchParms.TagGroup.target;

            this.cb_operation.SelectedItem = Program.ReaderCE.RdrOpParms.RunBasicSearchParms.OperationMode;

            switch (Program.ReaderCE.RdrOpParms.RunBasicSearchParms.Singulation)
            {
                case SingulationAlgorithm.FIXEDQ:
                    singulation_fixedQ.Visible = true;
                    break;
                case SingulationAlgorithm.DYNAMICQ:
                    singulation_dynamicQ.Visible = true;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    singulation_dynamicQAdjust.Visible = true;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    singulation_dynamicQThreshold.Visible = true;
                    break;
            }

            gb_singulation.Controls.AddRange(new Control[] { singulation_fixedQ, singulation_dynamicQ , singulation_dynamicQAdjust, singulation_dynamicQThreshold});


        }

        private void cb_algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (singulation_fixedQ == null || singulation_dynamicQ == null)
                return;
            switch (cb_algorithm.SelectedIndex)
            {
                case 0: //Add fixed Q Form
                    singulation_fixedQ.Visible = true;
                    singulation_dynamicQ.Visible = false;
                    singulation_dynamicQAdjust.Visible = false;
                    singulation_dynamicQThreshold.Visible = false;
                    break;
                case 1:
                    singulation_fixedQ.Visible = false;
                    singulation_dynamicQ.Visible = true;
                    singulation_dynamicQAdjust.Visible = false;
                    singulation_dynamicQThreshold.Visible = false;
                    break;
                case 2:
                    singulation_fixedQ.Visible = false;
                    singulation_dynamicQ.Visible = false;
                    singulation_dynamicQAdjust.Visible = true;
                    singulation_dynamicQThreshold.Visible = false;
                    break;
                case 3:
                    singulation_fixedQ.Visible = false;
                    singulation_dynamicQ.Visible = false;
                    singulation_dynamicQAdjust.Visible = false;
                    singulation_dynamicQThreshold.Visible = true;
                    break;
                default:
                    singulation_fixedQ.Visible = false;
                    singulation_dynamicQ.Visible = false;
                    singulation_dynamicQAdjust.Visible = false;
                    singulation_dynamicQThreshold.Visible = false;
                    break;
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            //Start to apply all settings
            //Set PowerLevel
            Result res = Result.OK;

            if ((res = Program.ReaderCE.SetPowerLevel((uint)nb_power.Value)) != Result.OK)
            {
                ts_status.Text = string.Format("SetPowerLevel fail with err {0}", res);
            }
            //Set LinkProfile
            if ((res = Program.ReaderCE.SetCurrentLinkProfile(uint.Parse(cb_linkprofile.SelectedItem.ToString()))) != Result.OK)
            {
                ts_status.Text = string.Format("SetCurrentLinkProfile fail with err {0}", res);
            }

            //Set Region and Frequency
            if (cb_fixed.Checked)
            {
                if (lv_frequ.SelectedIndices.Count == 0 || lv_frequ.SelectedIndices[0] < 0 || lv_frequ.SelectedIndices[0] >= lv_frequ.Items.Count)
                    MessageBox.Show("Please select a channel first");
                if ((res = Program.ReaderCE.SetFixedChannel(Program.ReaderCE.AvailableRegion[cb_country.SelectedIndex], (uint)lv_frequ.SelectedIndices[0], cb_lbt.Checked ? LBT.ON : LBT.OFF)) != rfid.Constants.Result.OK)
                {
                    ts_status.Text = string.Format("SetFixedChannel fail with err {0}", res);
                }
            }
            else
            {
                if ((res = Program.ReaderCE.SetHoppingChannels(Program.ReaderCE.AvailableRegion[cb_country.SelectedIndex])) != rfid.Constants.Result.OK)
                {
                    ts_status.Text = string.Format("SetHoppingChannels fail with err {0}", res);
                }

            }

            //Save other to InventorySetting

            Program.ReaderCE.RdrOpParms.RunBasicSearchParms.Singulation = (SingulationAlgorithm)cb_algorithm.SelectedItem;

            Program.ReaderCE.RdrOpParms.RunBasicSearchParms.OperationMode = (RadioOperationMode)cb_operation.SelectedItem;

            Program.ReaderCE.RdrOpParms.RunBasicSearchParms.TagGroup.selected = (Selected)cb_selected.SelectedItem;

            Program.ReaderCE.RdrOpParms.RunBasicSearchParms.TagGroup.session = (Session)cb_session.SelectedItem;

            Program.ReaderCE.RdrOpParms.RunBasicSearchParms.TagGroup.target = (SessionTarget)cb_target.SelectedItem;

            switch ((SingulationAlgorithm)cb_algorithm.SelectedItem)
            {
                case SingulationAlgorithm.FIXEDQ:
                    Program.ReaderCE.RdrOpParms.RunBasicSearchParms.SingulationParms = singulation_fixedQ.FixedQ;
                    break;
                case SingulationAlgorithm.DYNAMICQ:
                    Program.ReaderCE.RdrOpParms.RunBasicSearchParms.SingulationParms = singulation_dynamicQ.DynamicQ;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    Program.ReaderCE.RdrOpParms.RunBasicSearchParms.SingulationParms = singulation_dynamicQAdjust.DynamicQAdjust;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    Program.ReaderCE.RdrOpParms.RunBasicSearchParms.SingulationParms = singulation_dynamicQThreshold.DynamicQThreshold;
                    break;
            }

            Program.hours = (int)nb_hour.Value;

            LocalSettings.ServerIP = tb_serverIP.Text;
            LocalSettings.ServerName = tb_serverName.Text;
            LocalSettings.DBName = tb_dbName.Text;
            LocalSettings.UserID = tb_userID.Text;
            LocalSettings.Password = tb_password.Text;

            ts_status.Text = string.Format("Apply Configuration Successful");
        }

        private void cb_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Retrieve all available frequency channels
            CurrentFreqList = Program.ReaderCE.GetFrequencyTable(Program.ReaderCE.AvailableRegion[cb_country.SelectedIndex]);

            UpdateFreqList();

        }

        private void cb_fixed_CheckedChanged(object sender, EventArgs e)
        {
            lv_frequ.Enabled = cb_fixed.Checked;
        }

    }
}