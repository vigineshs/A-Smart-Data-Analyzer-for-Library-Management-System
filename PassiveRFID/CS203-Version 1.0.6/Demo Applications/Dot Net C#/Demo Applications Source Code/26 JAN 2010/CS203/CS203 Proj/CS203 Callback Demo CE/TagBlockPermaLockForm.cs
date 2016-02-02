using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.Text;

namespace CS203_CALLBACK_API_DEMO_CE
{
    public partial class TagBlockPermaLockForm : Form
    {
        #region Private Member
        enum LockState
        {
            Unknown,
            Locked,
            Unlocked,
        }

        private bool m_stop = false;
        private string TargetEPC = String.Empty;
        #endregion

        #region Form
        public TagBlockPermaLockForm()
        {
            InitializeComponent();
        }

        private void TagBlockPermaLockForm_Load(object sender, EventArgs e)
        {
            AttachCallback(true);
        }

        void TagBlockPermaLockForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderCE.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
                Program.ReaderCE.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
            }
            else
            {
                Program.ReaderCE.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_OnAccessCompleted);
                Program.ReaderCE.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
            }
        }

        void ReaderCE_OnAccessCompleted(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
#if NETCF3_5
            Trace.WriteLine(string.Format("Bank {0}, Access {1}, Result {2}, Data {3}", e.bank, e.access,e.success, e.data == null ? null : e.data.ToString()));
#endif
         }

        void ReaderCE_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            switch (e.state)
            {
                case RFState.IDLE:
                    if (!m_stop)
                    {
                        EnableButton(true);
                        EnableForm(true);
                    }
                    else
                    {
                        CloseForm();
                    }
                    break;
                case RFState.BUSY:
                    EnableButton(false);
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
        private delegate void EnableButtonDeleg(bool en);
        private void EnableButton(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableButtonDeleg(EnableButton), new object[] { en });
                return;
            }
            btn_exit.Enabled = btn_lock.Enabled = btn_read.Enabled = en;
        }
        #endregion

        #region Control Handle
        void lb_epc_Click(object sender, System.EventArgs e)
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
                    TargetEPC = lb_epc.Text = inv.epc;
                }
            }
            AttachCallback(true);
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderCE.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderCE.Options.TagSelected.epcMaskOffset = 0;
            Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true);

            Program.ReaderCE.Options.TagBlockLock.accessPassword = tb_password.ToUInt32;
            Program.ReaderCE.Options.TagBlockLock.count = 1; // Read at least 64 block, only vaild for higgs 3 tag
            Program.ReaderCE.Options.TagBlockLock.offset = 0;
            Program.ReaderCE.Options.TagBlockLock.setPermalock = false;
            Program.ReaderCE.Options.TagBlockLock.retryCount = 7;
            Program.ReaderCE.Options.TagBlockLock.flags = SelectFlags.SELECT;
            if (Program.ReaderCE.StartOperation(Operation.TAG_BLOCK_PERMALOCK, true) == Result.OK)
            {
                //Read Permalock success
                SetPermalock(Program.ReaderCE.Options.TagBlockLock.mask);
            }
        }

        private void btn_lock_Click(object sender, EventArgs e)
        {
            Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
            Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(TargetEPC);
            Program.ReaderCE.Options.TagSelected.epcMaskLength = Hex.GetBitCount(TargetEPC);
            Program.ReaderCE.Options.TagSelected.epcMaskOffset = 0;
            Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true);

            Program.ReaderCE.Options.TagBlockLock.accessPassword = tb_password.ToUInt32;
            Program.ReaderCE.Options.TagBlockLock.count = 1;//Set at least 64 block, only vaild for higgs 3 tag
            Program.ReaderCE.Options.TagBlockLock.offset = 0;
            Program.ReaderCE.Options.TagBlockLock.setPermalock = true;
            Program.ReaderCE.Options.TagBlockLock.retryCount = 7;
            Program.ReaderCE.Options.TagBlockLock.mask = GetPermalock();
            Program.ReaderCE.Options.TagBlockLock.flags = SelectFlags.SELECT;
            Program.ReaderCE.StartOperation(Operation.TAG_BLOCK_PERMALOCK, false);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lv_lock_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                lv_lock.Items[e.Index].Tag = LockState.Locked;
                lv_lock.Items[e.Index].SubItems[1].Text = "Locked";
            }
            else
            {
                lv_lock.Items[e.Index].Tag = LockState.Unlocked;
                lv_lock.Items[e.Index].SubItems[1].Text = "Unlocked";
            }
        }

        private ushort[] GetPermalock()
        {
            List<ushort> tmpList = new List<ushort>();
            ushort utmp = 0x0;
            int countdown = 15;
            int left = lv_lock.Items.Count % 16;
            foreach (ListViewItem item in lv_lock.Items)
            {
                switch((LockState)item.Tag)
                {
                    case LockState.Locked:
                        utmp |= (ushort)(0x1 << countdown);
                        break;
                    case LockState.Unknown:
                    case LockState.Unlocked:
                        utmp |= (ushort)(0x0 << countdown);
                        break;
                }
                countdown--;
                if (countdown < 0)
                {
                    countdown = 15;
                    tmpList.Add(utmp);
                    utmp = 0;
                }
            }
            if (left != 0)
            {
                tmpList.Add(utmp);
            }
            return tmpList.ToArray();
        }
        /// <summary>
        /// We only care about first byte for Higgs 3
        /// </summary>
        /// <param name="locked"></param>
        private void SetPermalock(ushort[] locked)
        {
            int index = 0;
            lv_lock.BeginUpdate();
            lv_lock.Items.Clear();
            foreach (ushort s in locked)
            {
                for (int i = 15; i >= 8; i--)
                {
                    ListViewItem item = new ListViewItem(index.ToString());
                    if (((s >> i) & 0x1) == 1)
                    {
                        item.Tag = LockState.Locked;
                        item.SubItems.Add("Locked");
                        item.Checked = true;
                    }
                    else
                    {
                        item.Tag = LockState.Unlocked;
                        item.SubItems.Add("Unlocked");
                        item.Checked = false;
                    }
                    lv_lock.Items.Add(item);
                    index++;
                }
            }
            lv_lock.EndUpdate();
        }
        #endregion

    }
}