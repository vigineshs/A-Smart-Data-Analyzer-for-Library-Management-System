using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

//Import RFID Library
using CSLibrary.Constants;
using CSLibrary.Structures;

namespace CS203_CALLBACK_API_DEMO_CE
{
    public partial class TagSettingForm : Form
    {
        #region Private Variable
        private CSLibrary.Tools.TimeSync timeSync;
        private Singulation_FixedQ singulation_fixedQ;
        private Singulation_DynamicQ singulation_dynamicQ;
        private Singulation_DynamicQ singulation_dynamicQAdjust;
        private Singulation_DynamicQ singulation_dynamicQThreshold;

        private AutoResetEvent m_stop = new AutoResetEvent(false);
        private bool bStop = false;
        private double[] CurrentFreqList = null;
        private bool success = false;
        #endregion

        #region Form
        public TagSettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //RFID Initial start here
            {
                //Load DataSource
                this.cb_linkprofile.DataSource = Program.ReaderCE.GetActiveLinkProfile();

                this.cb_country.DataSource = Program.ReaderCE.GetActiveRegionCode();

                this.cb_algorithm.DataSource = EnumGetValues(typeof(SingulationAlgorithm));

                this.cb_selected.DataSource = EnumGetValues(typeof(Selected));

                this.cb_session.DataSource = EnumGetValues(typeof(Session));

                this.cb_target.DataSource = EnumGetValues(typeof(SessionTarget));

                cb_fixed.Enabled = !Program.ReaderCE.IsFixedChannelOnly;
                cb_freqlist.Enabled = cb_fixed.Checked = Program.appSetting.FixedChannel;
                //Load Setting
                if (Program.ReaderCE.SelectedRegionCode == CSLibrary.Constants.RegionCode.JP)
                {
                    cb_lbt.Enabled = true;
                    cb_lbt.Checked = Program.appSetting.Lbt;
                }
                else
                    cb_lbt.Enabled = Program.appSetting.Lbt;


                //get power level
                nb_power.Value = Program.appSetting.Power;

                //highlight the current link profile
                cb_linkprofile.SelectedItem = Program.appSetting.Link_profile;

                //current select frequency profile index
                cb_country.SelectedItem = Program.ReaderCE.SelectedRegionCode;

                this.cb_algorithm.SelectedItem = Program.appSetting.Singulation;

                this.cb_selected.SelectedItem = Program.appSetting.tagGroup.selected;

                this.cb_session.SelectedItem = Program.appSetting.tagGroup.session;

                this.cb_target.SelectedItem = Program.appSetting.tagGroup.target;

                this.cb_custInvtryCont.Checked = Program.appSetting.Cfg_continuous_mode;

                this.cb_custInvtryBlocking.Checked = Program.appSetting.Cfg_blocking_mode;

                if (Program.appSetting.FixedChannel)
                {
                    cb_freqlist.SelectedItem = CurrentFreqList[(int)Program.appSetting.Channel_number];
                }

                this.cb_debug_log.Checked = Program.appSetting.Debug_log;

                //Update maximum power
                UpdateMaxPower();

                //Update Frequency list
                UpdateFreqList();

            }

            tabControl1.SelectedIndex = 0;
            AttachCallback(true);
            timeSync = new CSLibrary.Tools.TimeSync();
            timeSync.OnSyncCompletedNotify += new CSLibrary.Tools.TimeSync.SyncCompletedNotify(ntpClient_OnSyncCompletedNotify);
            timeSync.OnSyncStateChangedNotify += new CSLibrary.Tools.TimeSync.SyncStateChangedNotify(ntpClient_OnSyncStateChangedNotify);

        }

        private void TagSettingForm_Closing(object sender, CancelEventArgs e)
        {
            if (Program.ReaderCE.State != CSLibrary.Constants.RFState.IDLE)
            {
                bStop = e.Cancel = true;
                Program.ReaderCE.TurnCarrierWaveOff();
            }
            else
            {
                AttachCallback(false);
                timeSync.OnSyncCompletedNotify -= new CSLibrary.Tools.TimeSync.SyncCompletedNotify(ntpClient_OnSyncCompletedNotify);
                timeSync.OnSyncStateChangedNotify -= new CSLibrary.Tools.TimeSync.SyncStateChangedNotify(ntpClient_OnSyncStateChangedNotify);
                this.DialogResult = success ? DialogResult.OK : DialogResult.Cancel;
            }
        }
        #endregion

        #region Event

        private void AttachCallback(bool attach)
        {
            if (attach)
            {
                Program.ReaderCE.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_OnStateChanged);
            }
            else
            {
                Program.ReaderCE.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_OnStateChanged);
            }
        }

        void ReaderCE_OnStateChanged(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            switch (e.state)
            {
                case CSLibrary.Constants.RFState.IDLE:
                    if (!bStop)
                    {
                        UpdateCWBtn(true);
                    }
                    else
                    {
                        this.Close();
                    }
                    break;
                case CSLibrary.Constants.RFState.BUSY:
                    UpdateCWBtn(false);
                    break;
            }
        }

        void ntpClient_OnSyncCompletedNotify(bool success, string errorMessage)
        {
            if (success)
            {
                ts_status.Text = "Synchronization succeeded";
            }
            else
            {
                ts_status.Text = "Synchronization failed";
                MessageBox.Show(errorMessage);
            }
        }

        void ntpClient_OnSyncStateChangedNotify(CSLibrary.Tools.TimeSync.SyncState state)
        {
            switch (state)
            {
                case CSLibrary.Tools.TimeSync.SyncState.DNSResolve:
                    ts_status.Text = "Resolving remote server address...";
                    btn_startSync.Enabled = false;
                    break;
                case CSLibrary.Tools.TimeSync.SyncState.Idle:
                    ts_status.Text = "Idle";
                    btn_startSync.Text = "Time Sync";
                    btn_startSync.BackColor = Color.FromArgb(0, 192, 0);
                    btn_startSync.Enabled = true;
                    break;
                case CSLibrary.Tools.TimeSync.SyncState.Connect:
                    ts_status.Text = "Connecting...";
                    btn_startSync.Text = "Sync Stop";
                    btn_startSync.BackColor = Color.Red;
                    btn_startSync.Enabled = false;
                    break;
                case CSLibrary.Tools.TimeSync.SyncState.Request:
                    ts_status.Text = "Sending request...";
                    btn_startSync.Text = "Sync Stop";
                    btn_startSync.BackColor = Color.Red;
                    btn_startSync.Enabled = true;
                    break;
                case CSLibrary.Tools.TimeSync.SyncState.WaitResponse:
                    ts_status.Text = "Waiting for response...";
                    btn_startSync.Text = "Sync Stop";
                    btn_startSync.BackColor = Color.Red;
                    btn_startSync.Enabled = true;
                    break;
            }
        }

        #endregion

        #region UI Handle

        private void UpdateFreqList()
        {
            //Retrieve all available frequency channels
            cb_freqlist.DataSource = CurrentFreqList = Program.ReaderCE.GetAvailableFrequencyTable(Program.ReaderCE.GetActiveRegionCode()[cb_country.SelectedIndex]);
        }

        private void UpdateMaxPower()
        {
            nb_power.Maximum = Program.ReaderCE.GetActiveMaxPowerLevel((RegionCode)cb_country.SelectedItem);
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

        private void cb_algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.SuspendLayout();

            tabControl1.Controls.Remove(singulation_fixedQ);
            tabControl1.Controls.Remove(singulation_dynamicQ);
            tabControl1.Controls.Remove(singulation_dynamicQAdjust);
            tabControl1.Controls.Remove(singulation_dynamicQThreshold);

            tabControl1.Controls.Remove(this.tp_timesync);
            tabControl1.Controls.Remove(this.tp_cwonoff);

            switch (cb_algorithm.SelectedIndex)
            {
                case 0: //Add fixed Q Form
                    //Program.appSetting.Singulation = SingulationAlgorithm.FIXEDQ;
                    singulation_fixedQ = new Singulation_FixedQ
                        (
                            Program.appSetting.SingulationAlg
                        );
                    singulation_fixedQ.Text = "FixedQ";
                    singulation_fixedQ.BackColor = Color.FromArgb(192, 255, 192);
                    tabControl1.Controls.Add(singulation_fixedQ);
                    break;
                case 1:
                    //Program.appSetting.Singulation = SingulationAlgorithm.DYNAMICQ;
                    singulation_dynamicQ = new Singulation_DynamicQ
                        (
                        Program.appSetting.SingulationAlg, SingulationAlgorithm.DYNAMICQ
                        );
                    singulation_dynamicQ.Text = "DynamicQ";
                    singulation_dynamicQ.BackColor = Color.FromArgb(192, 255, 192);
                    tabControl1.Controls.Add(singulation_dynamicQ);
                    break;
                case 2:
                    //Program.appSetting.Singulation = SingulationAlgorithm.DYNAMICQ_ADJUST;
                    singulation_dynamicQAdjust = new Singulation_DynamicQ
                        (
                        Program.appSetting.SingulationAlg, SingulationAlgorithm.DYNAMICQ_ADJUST
                        );
                    singulation_dynamicQAdjust.Text = "DynamicQAdj";
                    singulation_dynamicQAdjust.BackColor = Color.FromArgb(192, 255, 192);
                    tabControl1.Controls.Add(singulation_dynamicQAdjust);
                    break;
                case 3:
                    //Program.appSetting.Singulation = SingulationAlgorithm.DYNAMICQ_THRESH;
                    singulation_dynamicQThreshold = new Singulation_DynamicQ
                        (
                        Program.appSetting.SingulationAlg, SingulationAlgorithm.DYNAMICQ_THRESH
                        );
                    singulation_dynamicQThreshold.Text = "DynamicQThres";
                    singulation_dynamicQThreshold.BackColor = Color.FromArgb(192, 255, 192);
                    tabControl1.Controls.Add(singulation_dynamicQThreshold);
                    break;
            }

            tabControl1.Controls.Add(this.tp_timesync);
            tabControl1.Controls.Add(this.tp_cwonoff);

            tabControl1.ResumeLayout();

            tabControl1.SelectedIndex = 2;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            ts_status.Text = "Applying configuration : Please wait...";
            Application.DoEvents();
            this.Enabled = false;
            //Start to apply all settings
            //Set PowerLevel
            CSLibrary.Constants.Result res = CSLibrary.Constants.Result.OK;

            if ((cb_custInvtryBlocking.Checked && cb_custInvtryCont.Checked))
            {
                if (MessageBox.Show("Please don't run in blocking and continuous mode in the same time, otherwise you can't abort the operation", "warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                }
                else
                {
                    goto ERROR;
                }
            }

            if ((res = Program.ReaderCE.SetPowerLevel((uint)nb_power.Value)) != CSLibrary.Constants.Result.OK)
            {
                ts_status.Text = string.Format("SetPowerLevel fail with err {0}", res);
                Application.DoEvents();
                goto ERROR;
            }
            //Set LinkProfile
            if ((res = Program.ReaderCE.SetCurrentLinkProfile(uint.Parse(cb_linkprofile.SelectedItem.ToString()))) != CSLibrary.Constants.Result.OK)
            {
                ts_status.Text = string.Format("SetCurrentLinkProfile fail with err {0}", res);
                Application.DoEvents();
                goto ERROR;
            }

            //Set Region and Frequency
            if (cb_fixed.Checked)
            {

                if (cb_freqlist.SelectedIndex < 0 || cb_freqlist.SelectedIndex >= cb_freqlist.Items.Count)
                {
                    ts_status.Text = "Please select a channel first";
                    Application.DoEvents();
                    goto ERROR;
                }

                if ((res = Program.ReaderCE.SetFixedChannel(Program.ReaderCE.GetActiveRegionCode()[cb_country.SelectedIndex], (uint)cb_freqlist.SelectedIndex, cb_lbt.Checked ? LBT.ON : LBT.OFF)) != CSLibrary.Constants.Result.OK)
                {
                    ts_status.Text = string.Format("SetFixedChannel fail with err {0}", res);
                    Application.DoEvents();
                    goto ERROR;
                }
            }
            else
            {
                if ((res = Program.ReaderCE.SetHoppingChannels(Program.ReaderCE.GetActiveRegionCode()[cb_country.SelectedIndex])) != CSLibrary.Constants.Result.OK)
                {
                    ts_status.Text = string.Format("SetHoppingChannels fail with err {0}", res);
                    Application.DoEvents();
                    goto ERROR;
                }

            }

            {

                Program.appSetting.Cfg_blocking_mode = cb_custInvtryBlocking.Checked;

                Program.appSetting.Singulation = (SingulationAlgorithm)cb_algorithm.SelectedItem;

                Program.appSetting.Cfg_continuous_mode = cb_custInvtryCont.Checked;

                Program.appSetting.FixedChannel = cb_fixed.Checked;

                Program.appSetting.tagGroup = new TagGroup
                                            (
                                                (Selected)cb_selected.SelectedItem,
                                                (Session)cb_session.SelectedItem,
                                                (SessionTarget)cb_target.SelectedItem
                                            );

                switch (Program.appSetting.Singulation)
                {
                    case SingulationAlgorithm.DYNAMICQ:
                        Program.appSetting.SingulationAlg = singulation_dynamicQ.DynamicQ;
                        break;
                    case SingulationAlgorithm.DYNAMICQ_ADJUST:
                        Program.appSetting.SingulationAlg = singulation_dynamicQAdjust.DynamicQAdjust;
                        break;
                    case SingulationAlgorithm.DYNAMICQ_THRESH:
                        Program.appSetting.SingulationAlg = singulation_dynamicQThreshold.DynamicQThreshold;
                        break;
                    case SingulationAlgorithm.FIXEDQ:
                        Program.appSetting.SingulationAlg = singulation_fixedQ.FixedQ;
                        break;
                }
            }

            Program.ReaderCE.WriteToLog = Program.appSetting.Debug_log = this.cb_debug_log.Checked;

            //Save all settings to config file
            if (cb_save.Checked)
            {
                Program.SaveSettings();
            }

            ts_status.Text = string.Format("Apply Configuration Successful");
            Application.DoEvents();

            this.Enabled = true;

            success = true;

            return;

        ERROR:

            success = false;

            this.Enabled = true;

            ts_status.Text = "Apply Configuration failed";
            Application.DoEvents();

        }

        private void cb_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFreqList();
            UpdateMaxPower();
        }

        private void cb_fixed_CheckedChanged(object sender, EventArgs e)
        {
            cb_freqlist.Enabled = cb_fixed.Checked;
        }
        /// <summary>
        /// Same as full framework Enum.GetValues
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private object[] EnumGetValues(Type enumType)
        {
            if (enumType.BaseType ==
                typeof(Enum))
            {
                //get the public static fields (members of the enum)  
                FieldInfo[] fi = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
                //create a new enum array  
                object[] values = new object[fi.Length];
                //populate with the values  
                for (int iEnum = 0; iEnum < fi.Length; iEnum++)
                {
                    values[iEnum] = fi[iEnum].GetValue(null);
                }
                //return the array  
                return values;
            }

            //the type supplied does not derive from enum  
            throw new ArgumentException("enumType parameter is not a System.Enum");

        }

        private void btn_cwon_Click(object sender, EventArgs e)
        {
            Program.ReaderCE.TurnCarrierWaveOn(cb_withData.Checked);
        }

        private void btn_cwoff_Click(object sender, EventArgs e)
        {
            Program.ReaderCE.TurnCarrierWaveOff();
        }

        private void UpdateCWBtn(bool en)
        {
            cb_withData.Enabled = btn_cwon.Enabled = en;
            btn_cwoff.Enabled = !en;
            if (en)
            {
                //CSLibrary.Device.Device.MelodyPlay(CSLibrary.Device.RingTone.T1, CSLibrary.Device.BuzzerVolume.HIGH);
            }
            else
            {
                //CSLibrary.Device.Device.MelodyPlay(CSLibrary.Device.RingTone.T2, CSLibrary.Device.BuzzerVolume.HIGH);
            }
        }

        private void btn_startSync_Click(object sender, EventArgs e)
        {
            if (timeSync.ClientState == CSLibrary.Tools.TimeSync.SyncState.Idle)
            {
                timeSync.TimeServer = tb_ntpServer.Text;
                timeSync.SyncStart();
            }
            else
            {
                timeSync.SyncStop();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}