using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CS203DEMO
{
    //using Reader.Device;
    using Reader.Constants;

    public partial class GeigerSearchForm : Form
    {
        #region Private Member
        /*private Device.RingTone[] RingMelody = new Device.RingTone[4]
            {
                Device.RingTone.T1,
                Device.RingTone.T1,
                Device.RingTone.T3,
                Device.RingTone.T5,
            };*/

        private int[] ThresholdArr = new int[] { 0, 50, 65, 70};
        private int rssi = 0;
        private bool bTone = true;
        private string TargetEPC;

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
            AttachCallback(false);
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                Program.ReaderCE.Stop();
            while (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }
        }
        #endregion

        #region Button Handle

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
            {
                Program.ReaderCE.Stop();
                return;
            }
            //Program.ReaderCE.SetPowerLevel((uint)nb_power.Value);
            Program.ReaderCE.RdrOpParms.RunSearchOneTagParms.AveragingRssi = cb_averaging.Checked;
            Program.ReaderCE.RdrOpParms.RunSearchOneTagParms.RunOnce = false;
            Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
            Program.ReaderCE.RdrOpParms.Operation = Operation.SearchOneTag;
            Program.ReaderCE.Start();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stop()
        {
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
            {
                Program.ReaderCE.Stop();
            }
        }

        private void Start()
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                Program.ReaderCE.RdrOpParms.RunSearchOneTagParms.AveragingRssi = cb_averaging.Checked;
                Program.ReaderCE.RdrOpParms.RunSearchOneTagParms.RunOnce = false;
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.SearchOneTag;
                Program.ReaderCE.Start();
            }
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            //Stop current operation
            if (Program.ReaderCE.MyState == ReaderOperationMode.Running)
            {
                Program.ReaderCE.Stop();
            }
            while (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }

            AttachCallback(false);

            using (InventoryForm inv = new InventoryForm(true))
            {
                if (inv.ShowDialog() == DialogResult.OK)
                {
                    TargetEPC = tb_epc.Text = inv.EPC;
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
            /*if (bTone)
            {
                if (rssi > ThresholdArr[3])
                {
                    Device.MelodyPlay(RingMelody[3], Device.BUZZER_SOUND.HIGH);
                }
                else if (rssi <= ThresholdArr[3] && rssi > ThresholdArr[2])
                {
                    Device.MelodyPlay(RingMelody[2], Device.BUZZER_SOUND.HIGH);
                }
                else if (rssi <= ThresholdArr[2] && rssi > ThresholdArr[1])
                {
                    Device.MelodyPlay(RingMelody[1], Device.BUZZER_SOUND.HIGH);
                }
                else if (rssi <= ThresholdArr[1])
                {
                    Device.MelodyPlay(RingMelody[0], Device.BUZZER_SOUND.HIGH);
                }
            }*/
        }

        #endregion

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderCE.MyErrorEvent += new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
                Program.ReaderCE.MyInventoryEvent += new EventHandler<Reader.Events.InventoryEventArgs>(ReaderCE_MyInventoryEvent);
                Program.ReaderCE.MyRunningStateEvent += new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
                //Program.KeyHook.KeyPressEvent += new Reader.Device.KeyboardHook.KeyboardHookEventHandler(KeyHook_KeyPressEvent);
            }
            else
            {
                Program.ReaderCE.MyErrorEvent -= new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
                Program.ReaderCE.MyInventoryEvent -= new EventHandler<Reader.Events.InventoryEventArgs>(ReaderCE_MyInventoryEvent);
                Program.ReaderCE.MyRunningStateEvent -= new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
                //Program.KeyHook.KeyPressEvent -= new Reader.Device.KeyboardHook.KeyboardHookEventHandler(KeyHook_KeyPressEvent);
            }
        }


        void ReaderCE_MyInventoryEvent(object sender, Reader.Events.InventoryEventArgs e)
        {
            /*if (this.InvokeRequired)
            {
                this.Invoke(
                  new EventHandler<Reader.Events.InventoryEventArgs>(ReaderCE_MyInventoryEvent), new object[] { sender, e }
                );
                return;
            }*/
            rssi = (int)e.InventoryInformation.RSSI;

            UpdateRssiLb(rssi.ToString());
            //lb_rssi.Text = rssi.ToString();

            UpdateProgressValue(rssi);

            //Tone
            EnToneTmr(true);

            if (rssi < 0)
                UpdateRssiLb(String.Empty);
            else
                RestartOORDetectTmr();
        }

        void ReaderCE_MyErrorEvent(object sender, Reader.Events.ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Write)
            {
                ShowMsg(e.ErrorCode.ToString());
            }
        }


        void ReaderCE_MyRunningStateEvent(object sender, Reader.Events.ReaderOperationModeEventArgs e)
        {
            switch (e.State)
            {
                case ReaderOperationMode.Idle:
                    //Device.MelodyPlay(Device.RingTone.T1, Device.BUZZER_SOUND.HIGH);
                    UpdateStartButton(true);
                    break;
                case ReaderOperationMode.Running:
                    //Device.MelodyPlay(Device.RingTone.T2, Device.BUZZER_SOUND.HIGH);
                    UpdateStartButton(false);
                    break;
                case ReaderOperationMode.SearchDone:
                    break;
                case ReaderOperationMode.Stopping:
                    break;
                case ReaderOperationMode.WriteDone:

                    break;
                case ReaderOperationMode.DeviceNotFound:
                    break;
            }
        }

        #endregion

        #region Delegate

        private delegate void UpdateStartButtonDeleg(bool start);
        private void UpdateStartButton(bool start)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateStartButtonDeleg(UpdateStartButton), new object[] { start });
                return;
            }
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
        private delegate void RestartOORDetectTmrDeleg();
        void RestartOORDetectTmr()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new RestartOORDetectTmrDeleg(RestartOORDetectTmr), new object[] { });
                return;
            }
            tmr_ZeroDetector.Enabled = false;
            tmr_ZeroDetector.Enabled = true; // OK?
        }
        private delegate void ShowMsgDeleg(string msg);
        private void ShowMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ShowMsgDeleg(ShowMsg), new object[] { msg });
                return;
            }
            MessageBox.Show(msg);
        }
        private delegate void EnToneTmrDeleg(bool en);
        private void EnToneTmr(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnToneTmrDeleg(EnToneTmr), new object[] { en });
                return;
            }
            if (tmr_tone.Enabled != en)
                tmr_tone.Enabled = en;
        }
        private delegate void UpdateRssiLbDeleg(string msg);
        private void UpdateRssiLb(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateRssiLbDeleg(UpdateRssiLb), new object[] { msg });
                return;
            }
            lb_rssi.Text = msg;
        }
        private delegate void UpdateProgressValueDeleg(int value);
        private void UpdateProgressValue(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateProgressValueDeleg(UpdateProgressValue), new object[] { value });
                return;
            }
            if (value > 100)
                pg_rssi.Value = 100;
            else if (value < 0)
                pg_rssi.Value = 0;
            else
                pg_rssi.Value = value;
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