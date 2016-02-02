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

namespace CS203_CALLBACK_API_DEMO
{
    public partial class TagSettingForm : Form
    {
        private Singulation_FixedQ singulation_fixedQ;
        private Singulation_DynamicQ singulation_dynamicQ;
        private Singulation_DynamicQ singulation_dynamicQAdjust;
        private Singulation_DynamicQ singulation_dynamicQThreshold;
        private bool m_stop = false;
        private double[] CurrentFreqList = null;

        public TagSettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //RFID Initial start here
            {
                //Load DataSource
                this.cb_linkprofile.DataSource = Program.ReaderXP.GetActiveLinkProfile();

                this.cb_country.DataSource = Program.ReaderXP.GetActiveRegionCode();

                this.cb_algorithm.DataSource = EnumGetValues(typeof(SingulationAlgorithm));

                this.cb_selected.DataSource = EnumGetValues(typeof(Selected));

                this.cb_session.DataSource = EnumGetValues(typeof(Session));

                this.cb_target.DataSource = EnumGetValues(typeof(SessionTarget));

                cb_fixed.Enabled = !Program.ReaderXP.IsFixedChannelOnly;
                cb_freqlist.Enabled = cb_fixed.Checked = Program.appSetting.FixedChannel;
                //Load Setting
                if (Program.ReaderXP.SelectedRegionCode == CSLibrary.Constants.RegionCode.JP)
                {
                    cb_lbt.Enabled = true;
                    cb_lbt.Checked = Program.appSetting.Lbt;
                }
                else
                    cb_lbt.Enabled = Program.appSetting.Lbt;

                //highlight the current link profile
                cb_linkprofile.SelectedItem = Program.appSetting.Link_profile;

                //current select frequency profile index
                cb_country.SelectedItem = Program.ReaderXP.SelectedRegionCode;

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

                //get power level
                nb_power.Value = Program.appSetting.Power;


                nb_reconnectTimeout.Value = Program.appSetting.ReconnectTimeout;
            }

            tabControl1.SelectedIndex = 0;

            AttachCallback(true);
        }

        private void TagSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ReaderXP.State != CSLibrary.Constants.RFState.IDLE)
            {
                m_stop = e.Cancel = true;
                Program.ReaderXP.TurnCarrierWaveOff();
            }
            else
            {
                AttachCallback(false);
            }
        }

        private void AttachCallback(bool attach)
        {
            if (attach)
            {
                Program.ReaderXP.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);
            }
            else
            {
                Program.ReaderXP.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);
            }
        }

        void ReaderXP_OnStateChanged(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            switch (e.state)
            {
                case CSLibrary.Constants.RFState.IDLE:
                    if (!m_stop)
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateFreqList()
        {
            //Retrieve all available frequency channels
            cb_freqlist.DataSource = CurrentFreqList = Program.ReaderXP.GetAvailableFrequencyTable(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex]);
        }

        private void UpdateMaxPower()
        {
            nb_power.Maximum = Program.ReaderXP.GetActiveMaxPowerLevel((RegionCode)cb_country.SelectedItem);
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

#if ENGINEERING_MODE
            tabControl1.Controls.Remove(this.tp_cwonoff);
#endif
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

#if ENGINEERING_MODE
            tabControl1.Controls.Add(this.tp_cwonoff);
#endif
            tabControl1.ResumeLayout();

            tabControl1.SelectedIndex = 2;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            Text = "Applying configuration : Please wait...";
            this.Enabled = false;
            //Start to apply all settings
            //Set PowerLevel
            Result res = Result.OK;

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

            if ((res = Program.ReaderXP.SetPowerLevel((uint)nb_power.Value)) != Result.OK)
            {
                ts_status.Text = string.Format("SetPowerLevel fail with err {0}", res);
                goto ERROR;
            }
            //Set LinkProfile
            if ((res = Program.ReaderXP.SetCurrentLinkProfile(uint.Parse(cb_linkprofile.SelectedItem.ToString()))) != Result.OK)
            {
                ts_status.Text = string.Format("SetCurrentLinkProfile fail with err {0}", res);
                goto ERROR;
            }

            //Set Region and Frequency
            if (cb_fixed.Checked)
            {
                //if (freq.ListItems.SelectedIndices.Count == 0 || freq.ListItems.SelectedIndices[0] < 0 || freq.ListItems.SelectedIndices[0] >= freq.ListItems.Items.Count)
                if (cb_freqlist.SelectedIndex < 0 || cb_freqlist.SelectedIndex >= cb_freqlist.Items.Count)
                {
                    ts_status.Text = "Please select a channel first";
                    goto ERROR;
                }
                //if ((res = Program.ReaderXP.SetFixedChannel(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex], (uint)freq.ListItems.SelectedIndices[0], cb_lbt.Checked ? LBT.ON : LBT.OFF)) != CSLibrary.Constants.Result.OK)
                if ((res = Program.ReaderXP.SetFixedChannel(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex], (uint)cb_freqlist.SelectedIndex, cb_lbt.Checked ? LBT.ON : LBT.OFF)) != CSLibrary.Constants.Result.OK)
                {
                    ts_status.Text = string.Format("SetFixedChannel fail with err {0}", res);
                    goto ERROR;
                }
            }
            else
            {
                if ((res = Program.ReaderXP.SetHoppingChannels(Program.ReaderXP.GetActiveRegionCode()[cb_country.SelectedIndex])) != CSLibrary.Constants.Result.OK)
                {
                    ts_status.Text = string.Format("SetHoppingChannels fail with err {0}", res);
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

            Program.ReaderXP.WriteToLog = Program.appSetting.Debug_log = this.cb_debug_log.Checked;
            Program.ReaderXP.ReconnectTimeout = Program.appSetting.ReconnectTimeout = (uint)this.nb_reconnectTimeout.Value;

            //Save all settings to config file
            if (cb_save.Checked)
            {
                Program.SaveSettings();
            }

            ts_status.Text = string.Format("Apply Configuration Successful");

            this.Enabled = true;

            this.DialogResult = DialogResult.OK;

            Text = "Apply Configuration Successful";

            return;

        ERROR:
            //ts_status.Text = string.Format("Apply Configuration failed");

            this.Enabled = true;

            //this.DialogResult = DialogResult.Cancel;

            Text = "Apply Configuration failed";

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
            Program.ReaderXP.TurnCarrierWaveOn(cb_withData.Checked);
        }

        private void btn_cwoff_Click(object sender, EventArgs e)
        {
            Program.ReaderXP.TurnCarrierWaveOff();
        }

        private void UpdateCWBtn(bool en)
        {
            cb_withData.Enabled = btn_cwon.Enabled = en;
            btn_cwoff.Enabled = !en;
        }

        private void lk_antenna_port_cfg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (AntennaPortCfgForm ant = new AntennaPortCfgForm())
            {
                ant.ShowDialog();
            }
        }

        private void lb_detail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (LinkProfileInformation info = new LinkProfileInformation(uint.Parse(cb_linkprofile.Text)))
            {
                info.ShowDialog();
            }
        }
    }
}