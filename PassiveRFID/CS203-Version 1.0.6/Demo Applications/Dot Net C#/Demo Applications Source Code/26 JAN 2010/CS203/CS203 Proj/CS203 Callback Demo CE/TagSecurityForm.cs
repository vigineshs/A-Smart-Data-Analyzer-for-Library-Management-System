using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO_CE
{
    using CSLibrary.Structures;
    using CSLibrary.Constants;
    using CSLibrary.Text;
    using CSLibrary;

    using CSLibrary.HotKeys;

    public partial class TagSecurityForm : Form
    {
        #region Public and Private Member
        public string TargetEPC = "";
        private ResultForm result = new ResultForm();
        private bool m_stop = false;
        #endregion

        #region Form
        public TagSecurityForm()
        {
            InitializeComponent();
        }

        private void TagSecurityForm_Load(object sender, EventArgs e)
        {
            //tb_epc.Text = TargetEPC;
            cb_acc.SelectedIndex = cb_epc.SelectedIndex = cb_kill.SelectedIndex = cb_tid.SelectedIndex = cb_user.SelectedIndex = 4;
            AttachCallback(true);
        }

        private void TagSecurityForm_Closing(object sender, CancelEventArgs e)
        {

            if (Program.ReaderCE.State != RFState.IDLE)
            {
                e.Cancel = m_stop = true;
                Program.ReaderCE.TurnCarrierWaveOff();
            }
            else
            {
                AttachCallback(false);
            }
        }

        #endregion

        #region Button Handle
        private void lk_epc_Click(object sender, EventArgs e)
        {
            //Stop current process
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                return;
            }

            AttachCallback(false);
            using (TagSearchForm InvForm = new TagSearchForm())
            {
                if (InvForm.ShowDialog() == DialogResult.OK)
                {
                    lk_epc.Text = TargetEPC = InvForm.epc;
                }
            }
            AttachCallback(true);
        }

        private void btn_kill_Click(object sender, EventArgs e)
        {
            AttachCallback(false);
            using (TagKillForm kill = new TagKillForm())
            {
                kill.ShowDialog();
            }
            AttachCallback(true);
        }

        private void btn_applysec_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                //Select a tag first
                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
                Program.ReaderCE.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
                if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected a tag failed");
                    return;
                }

                Program.ReaderCE.Options.TagLock.retryCount = 7;
                Program.ReaderCE.Options.TagLock.accessPassword = tb_pwd.ToUInt32;
                Program.ReaderCE.Options.TagLock.flags = SelectFlags.SELECT;
                Program.ReaderCE.StartOperation(Operation.TAG_LOCK, false);
            }
        }
        void btn_permlock_Click(object sender, System.EventArgs e)
        {
            AttachCallback(false);
            using (TagBlockPermaLockForm block = new TagBlockPermaLockForm())
            {
                block.ShowDialog();
            }
            AttachCallback(true);
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Event Callback
        void ReaderCE_MyRunningStateEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
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


        private void AttachCallback(bool en)
        {
            if (en)
            {
                HotKeys.OnKeyEvent += new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
                Program.ReaderCE.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnCompleted);
                Program.ReaderCE.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_MyRunningStateEvent);
            }
            else
            {
                HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
                Program.ReaderCE.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnCompleted);
                Program.ReaderCE.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_MyRunningStateEvent);
            }
        }

        void ReaderCE_OnCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            if (e.access == TagAccess.LOCK)
            {
                resultForm1.UpdateResult(e.success);
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

        #endregion

        #region Delegate
        private delegate void ShowMsgDeleg(string msg);
        private void ShowMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ShowMsgDeleg(ShowMsg), new object[] { msg });
                return;
            }
            MessageBox.Show(msg);
        }
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

        #region combox Handle
        private void cb_kill_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ReaderCE.Options.TagLock.killPasswordPermissions = (Permission)cb_kill.SelectedIndex;
        }

        private void cb_acc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ReaderCE.Options.TagLock.accessPasswordPermissions = (Permission)cb_acc.SelectedIndex;
        }

        private void cb_epc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ReaderCE.Options.TagLock.epcMemoryBankPermissions = (Permission)cb_epc.SelectedIndex;
        }

        private void cb_tid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ReaderCE.Options.TagLock.tidMemoryBankPermissions = (Permission)cb_tid.SelectedIndex;
        }

        private void cb_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ReaderCE.Options.TagLock.userMemoryBankPermissions = (Permission)cb_user.SelectedIndex;
        }
        #endregion

    }
}