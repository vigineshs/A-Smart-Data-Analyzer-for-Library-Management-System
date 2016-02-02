using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CSLibrary.Text;
using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary;

using CSLibrary.HotKeys;

namespace CS203_CALLBACK_API_DEMO_CE
{
    public partial class TagKillForm : Form
    {
        #region private member
        private const string m_epc_info = "Click here to select a tag to destroy.";
        
        private bool m_stop = false;
        #endregion

        #region Form
        public TagKillForm()
        {
            InitializeComponent();
        }

        private void TagKillForm_Load(object sender, EventArgs e)
        {
            AttachCallback(true);
        }

        private void TagKillForm_Closing(object sender, CancelEventArgs e)
        {
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
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_kill_Click(object sender, EventArgs e)
        {
            if (/*tb_access_password.ToUInt32 == 0 ||*/tb_kill_password.ToUInt32 == 0 || lk_epc.Text == m_epc_info)
            {
                MessageBox.Show("kill password must be non-zero, please change it and do it again.", "Warning!");
                return;
            }
            if (Program.ReaderCE.State == CSLibrary.Constants.RFState.IDLE)
            {
                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(lk_epc.Text);
                Program.ReaderCE.Options.TagSelected.epcMaskLength = Hex.GetBitCount(lk_epc.Text);

                if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected a tag failed");
                    return;
                }
                Program.ReaderCE.Options.TagKill.retryCount = 7;
                Program.ReaderCE.Options.TagKill.killPassword = tb_kill_password.ToUInt32;
                Program.ReaderCE.Options.TagKill.flags = SelectFlags.SELECT;

                if (Program.ReaderCE.StartOperation(Operation.TAG_KILL, false) != Result.OK)
                {
                    MessageBox.Show("StartOperation failed");
                    return;
                }
            }
        }
        private void lk_epc_Click(object sender, EventArgs e)
        {
            //Stop current process
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                Program.ReaderCE.StopOperation(true);
            }
            AttachCallback(false);
            using (TagSearchForm InvForm = new TagSearchForm())
            {
                if (InvForm.ShowDialog() == DialogResult.OK)
                {
                    lk_epc.Text = InvForm.epc;
                }
            }
            AttachCallback(true);
        }
        #endregion

        #region Event callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                HotKeys.OnKeyEvent += new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
                Program.ReaderCE.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnCompleted);
                Program.ReaderCE.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
            }
            else
            {
                HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
                Program.ReaderCE.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnCompleted);
                Program.ReaderCE.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
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
                        Program.Power.PowerUp();
                        break;
                    case Key.F5:
                        Program.Power.PowerDown();
                        break;
                }
            }
        }

        void ReaderCE_OnCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            if (e.access == TagAccess.KILL)
            {
                resultForm1.UpdateResult(e.success);
            }
        }

        void ReaderCE_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            switch (e.state)
            {
                case RFState.IDLE:
                    if (!m_stop)
                    {
                        //Device.MelodyPlay(CSLibrary.Device.RingTone.T1, BuzzerVolume.HIGH);
                    }
                    else
                    {
                        CloseForm();
                    }
                    EnableForm(true);
                    break;
                case RFState.BUSY:
                    //Device.MelodyPlay(CSLibrary.Device.RingTone.T2, BuzzerVolume.HIGH);
                    break;
                case RFState.ABORT:
                    EnableForm(false);
                    break;
            }
        }

        #endregion

        #region Delegate
        private delegate void CloseFormDeleg();
        private void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CloseFormDeleg(CloseForm), new object[] { });
                return;
            }
            this.Close();
        }
        private delegate void EnableFormDeleg(bool en);
        private void EnableForm(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableFormDeleg(EnableForm), new object[] { en });
                return;
            }
            this.Enabled = en;
        }
        #endregion
    }
}