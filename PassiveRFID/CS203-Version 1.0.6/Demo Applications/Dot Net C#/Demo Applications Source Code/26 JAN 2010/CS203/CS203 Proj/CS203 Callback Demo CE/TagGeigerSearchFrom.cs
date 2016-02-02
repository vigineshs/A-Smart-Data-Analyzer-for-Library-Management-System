using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CS203_CALLBACK_API_DEMO_CE
{
    using CSLibrary.Constants;
    using CSLibrary.Structures;
    using CSLibrary.Text;

    using CSLibrary.HotKeys;

    public partial class GeigerSearchForm : Form
    {
        #region Private Member
        /*private RingTone[] RingMelody = new RingTone[4]
            {
                RingTone.T1,
                RingTone.T1,
                RingTone.T3,
                RingTone.T5,
            };*/

        private int[] ThresholdArr = new int[] { 0, 50, 65, 70};
        private int rssi = 0;
        private bool bTone = true;
        private string TargetEPC = "";
        private bool m_stop = false;

        #endregion

        #region Form
        public GeigerSearchForm()
        {
            InitializeComponent();
        }
        private void GeigerSearchForm_Load(object sender, EventArgs e)
        {
            lb_threshold.Text = tk_threshold.Value.ToString();
            tb_epc.Text = TargetEPC;
            AttachCallback(true);
        }

        private void GeigerSearchForm_Closing(object sender, CancelEventArgs e)
        {
            tmr_tone.Enabled = tmr_ZeroDetector.Enabled = false;
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                e.Cancel = m_stop = true;
                Program.ReaderCE.StopOperation(true);
            }
            else
            {
                AttachCallback(false);
            }
        }
        #endregion

        #region Button Handle

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                Program.ReaderCE.StopOperation(true);
                return;
            }

            Start();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stop()
        {
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                Program.ReaderCE.StopOperation(true);
            }
        }

        private void Start()
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.ENABLE_TOGGLE;
                Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(tb_epc.Text);
                Program.ReaderCE.Options.TagSelected.epcMaskLength = Hex.GetBitCount(tb_epc.Text);

                Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true);

                Program.ReaderCE.SetOperationMode(Program.appSetting.Cfg_continuous_mode ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
                Program.ReaderCE.Options.TagSearchOne.avgRssi = cb_averaging.Checked;
                Program.ReaderCE.StartOperation(Operation.TAG_SEARCHING, false);
            }
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            //Stop current operation
            if (Program.ReaderCE.State == RFState.BUSY)
            {
                Program.ReaderCE.StopOperation(true);
            }
            while (Program.ReaderCE.State != RFState.IDLE)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }

            AttachCallback(false);

            using (TagSearchForm inv = new TagSearchForm())
            {
                if (inv.ShowDialog() == DialogResult.OK)
                {
                    TargetEPC = tb_epc.Text = inv.epc;
                }
            }
            AttachCallback(true);
        }

        #endregion

        #region Timer Handle

        void StopOORDetectTmr()
        {
            tmr_ZeroDetector.Enabled = false;
        }

        private void tmr_ZeroDetector_Tick(object sender, EventArgs e)
        {
            StopOORDetectTmr();
            UpdateRssiLb(String.Empty);
            UpdateProgressValue(0);
            tmr_tone.Enabled = false;
        }
        private void tmr_tone_Tick(object sender, EventArgs e)
        {
            if (bTone)
            {
                if (rssi > ThresholdArr[3])
                {
                    //Device.MelodyPlay(RingMelody[3], BuzzerVolume.HIGH);
                }
                else if (rssi <= ThresholdArr[3] && rssi > ThresholdArr[2])
                {
                    //Device.MelodyPlay(RingMelody[2], BuzzerVolume.HIGH);
                }
                else if (rssi <= ThresholdArr[2] && rssi > ThresholdArr[1])
                {
                    //Device.MelodyPlay(RingMelody[1], BuzzerVolume.HIGH);
                }
                else if (rssi <= ThresholdArr[1])
                {
                    //Device.MelodyPlay(RingMelody[0], BuzzerVolume.HIGH);
                }
            }
        }

        #endregion

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                HotKeys.OnKeyEvent += new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
                Program.ReaderCE.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderCE_TagSearchOneEvent);
                Program.ReaderCE.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
            }
            else
            {
                HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
                Program.ReaderCE.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderCE_TagSearchOneEvent);
                Program.ReaderCE.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
            }
        }

        void ReaderCE_TagSearchOneEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            switch (e.type)
            {
                case CallbackType.TAG_SEARCHING:
                    rssi = (int)((TagCallbackInfo)e.info).rssi;

                    UpdateRssiLb(rssi.ToString());
                    //lb_rssi.Text = rssi.ToString();

                    UpdateProgressValue(rssi);

                    //Tone
                    EnToneTmr(true);

                    if (rssi < 0)
                        UpdateRssiLb(String.Empty);
                    else
                        RestartOORDetectTmr();

                    if (Program.appSetting.Cfg_blocking_mode)
                    {
                        Application.DoEvents();
                    }

                    break;
            }
        }

        void ReaderCE_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            switch (e.state)
            {
                case RFState.IDLE:
                    if (!m_stop)
                    {
                        //Device.MelodyPlay(RingTone.T1, BuzzerVolume.HIGH);
                        UpdateStartButton(true);
                        EnableForm(true);
                    }
                    else
                    {
                        CloseForm();
                    }
                    break;
                case RFState.BUSY:
                    //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);
                    UpdateStartButton(false);
                    break;
                case RFState.ABORT:
                    EnableForm(false);
                    break;
            }
        }

        void HotKeys_OnKeyEvent(Key KeyCode, bool KeyDown)
        {
            if (KeyDown)
            {
                switch (KeyCode)
                {
                    case Key.F2:
                        Program.Profile.ProfileUp();
                        break;
                    case Key.F3:
                        Program.Profile.ProfileDown();
                        break;
                    case Key.F4:
                        //PowerUp
                        Program.Power.PowerUp();
                        break;
                    case Key.F5:
                        //PowerDown
                        Program.Power.PowerDown();
                        break;
                    case Key.F11:
                        Start();
                        break;
                }
            }
            else
            {
                if (KeyCode == Key.F11)
                {
                    Stop();
                }
            }

        }

        #endregion

        #region UI Update
        private void UpdateStartButton(bool start)
        {
            if (start)
            {
                btn_start.Text = "Start";
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.ForeColor = Color.Black;
                cb_averaging.Enabled = true;
                tmr_tone.Enabled = false;
                tmr_ZeroDetector.Enabled = false;
            }
            else
            {
                btn_start.Text = "Stop";
                btn_start.BackColor = Color.Red;
                btn_start.ForeColor = Color.White;
                cb_averaging.Enabled = false;
                tmr_tone.Enabled = true;
                tmr_ZeroDetector.Enabled = true;
            }
        }
        void RestartOORDetectTmr()
        {
            tmr_ZeroDetector.Enabled = false;
            tmr_ZeroDetector.Enabled = true; // OK?
        }
        private void ShowMsg(string msg)
        {

            MessageBox.Show(msg);
        }
        private void EnToneTmr(bool en)
        {
            if (tmr_tone.Enabled != en)
                tmr_tone.Enabled = en;
        }
        private void UpdateRssiLb(string msg)
        {
            lb_rssi.Text = msg;
        }
        private void UpdateProgressValue(int value)
        {
            if (value > 100)
                pg_rssi.Value = 100;
            else if (value < 0)
                pg_rssi.Value = 0;
            else
                pg_rssi.Value = value;
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void EnableForm(bool en)
        {
            this.Enabled = en;
        }
        #endregion

        #region Other Handle
        private void tk_threshold_ValueChanged(object sender, EventArgs e)
        {
            ThresholdArr[3] = tk_threshold.Value;
            lb_threshold.Text = tk_threshold.Value.ToString();
        }
        private void cb_sound_CheckStateChanged(object sender, EventArgs e)
        {
            bTone = cb_sound.Checked;
        }

        private void tb_epc_TextChanged(object sender, EventArgs e)
        {
            TargetEPC = tb_epc.Text;
        }
        #endregion

    }
}