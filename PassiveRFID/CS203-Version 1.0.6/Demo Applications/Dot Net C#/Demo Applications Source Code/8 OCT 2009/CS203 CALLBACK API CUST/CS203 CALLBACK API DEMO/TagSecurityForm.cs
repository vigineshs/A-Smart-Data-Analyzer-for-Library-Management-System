using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203DEMO
{
    using rfid.Structures;
    using rfid.Constants;
    using Reader;
    using Reader.Constants;
    using Reader.Structures;

    public partial class TagSecurityForm : Form
    {
        #region Member
        public string TargetEPC = "";
        private ResultForm result = new ResultForm();
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
            tb_pwd.Text = "00000000";
        }

        private void TagSecurityForm_Closing(object sender, CancelEventArgs e)
        {
            /*if (result != null)
            {
                result.Close();
                //result.Dispose();
                result = null;
            }*/
            AttachCallback(false);
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                Program.ReaderCE.Stop();
            while (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
            {
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
            }
        }

        #endregion

        #region Button Handle
        private void lk_epc_Click(object sender, EventArgs e)
        {
            //Stop current process
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                Program.ReaderCE.Stop();
            while (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
            {
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
            }
            AttachCallback(false);
            using (InventoryForm InvForm = new InventoryForm(true))
            {
                if (InvForm.ShowDialog() == DialogResult.OK)
                {
                    lk_epc.Text = TargetEPC = InvForm.EPC;
                }
            }
            AttachCallback(true);
        }

        private void rb_target_Click(object sender, EventArgs e)
        {
            rb_any.Checked = false;
            rb_target.Checked = true;
        }

        private void rb_any_Click(object sender, EventArgs e)
        {
            rb_any.Checked = true;
            rb_target.Checked = false;
        }

        private void btn_setkill_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                Program.ReaderCE.RdrOpParms.RunLockKillParms.Permissions = (PasswordPermission)cb_kill.SelectedIndex;
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = uint.Parse(tb_pwd.Text, System.Globalization.NumberStyles.HexNumber);
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.LockKill;
                Program.ReaderCE.Start();
            }
        }

        private void btn_setacc_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                Program.ReaderCE.RdrOpParms.RunLockAccParms.Permissions = (PasswordPermission)cb_acc.SelectedIndex;
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = uint.Parse(tb_pwd.Text, System.Globalization.NumberStyles.HexNumber);
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.LockAcc;
                Program.ReaderCE.Start();
            }
        }

        private void btn_setepc_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                Program.ReaderCE.RdrOpParms.RunLockEPCParms.Permissions = (MemoryPermission)cb_epc.SelectedIndex;
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = uint.Parse(tb_pwd.Text, System.Globalization.NumberStyles.HexNumber);
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.LockEPC;
                Program.ReaderCE.Start();
            }
        }

        private void btn_settid_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                Program.ReaderCE.RdrOpParms.RunLockTIDParms.Permissions = (MemoryPermission)cb_tid.SelectedIndex;
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = uint.Parse(tb_pwd.Text, System.Globalization.NumberStyles.HexNumber);
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.LockTID;
                Program.ReaderCE.Start();
            }
        }

        private void btn_setuser_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                Program.ReaderCE.RdrOpParms.RunLockUSERParms.Permissions = (MemoryPermission)cb_user.SelectedIndex;
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = uint.Parse(tb_pwd.Text, System.Globalization.NumberStyles.HexNumber);
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.LockUser;
                Program.ReaderCE.Start();
            }
        }

        private void btn_kill_Click(object sender, EventArgs e)
        {
            using (KillPWD kill = new KillPWD())
            {
                AttachCallback(false);
                kill.TargetEPC = TargetEPC;
                kill.AccPassword = uint.Parse(tb_pwd.Text, System.Globalization.NumberStyles.HexNumber);
                kill.ShowDialog();
                AttachCallback(true);
                /*if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
                {
                    //Program.ReaderCE.RdrOpParms.RunBasicKillParms.Flags = ReaderFlag.SELECT;
                    Program.ReaderCE.RdrOpParms.TargetAccessPassword = uint.Parse(tb_pwd.Text, System.Globalization.NumberStyles.HexNumber);
                    Program.ReaderCE.RdrOpParms.TargetKillPassword = kill.KillPassword;
                    Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                    Program.ReaderCE.RdrOpParms.Operation = Operation.Kill;
                    Program.ReaderCE.Start();
                }*/
            }

        }

        private void btn_applysec_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Event Callback
        void ReaderCE_MyRunningStateEvent(object sender, Reader.Events.ReaderOperationModeEventArgs e)
        {
            switch (e.State)
            {
                case ReaderOperationMode.Idle:
                    //Device.MelodyPlay(Device.RingTone.T1, Device.BUZZER_SOUND.HIGH);
                    break;
                case ReaderOperationMode.Running:
                    //Device.MelodyPlay(Device.RingTone.T2, Device.BUZZER_SOUND.HIGH);
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

        void ReaderCE_MyInventoryEvent(object sender, Reader.Events.InventoryEventArgs e)
        {
            // do your work here
            // UI refresh and data processing
        }


        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderCE.MyTagAccessEvent += new EventHandler<Reader.Events.TagAccessEventArgs>(ReaderCE_MyTagAccessEvent);
                Program.ReaderCE.MyRunningStateEvent += new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
                Program.ReaderCE.MyErrorEvent += new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
                //Program.KeyHook.KeyPressEvent += new Reader.Device.KeyboardHook.KeyboardHookEventHandler(KeyHook_KeyPressEvent);
            }
            else
            {
                Program.ReaderCE.MyTagAccessEvent -= new EventHandler<Reader.Events.TagAccessEventArgs>(ReaderCE_MyTagAccessEvent);
                Program.ReaderCE.MyRunningStateEvent -= new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
                Program.ReaderCE.MyErrorEvent -= new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
                //Program.KeyHook.KeyPressEvent -= new Reader.Device.KeyboardHook.KeyboardHookEventHandler(KeyHook_KeyPressEvent);
            }
        }

        
        void ReaderCE_MyErrorEvent(object sender, Reader.Events.ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Lock)
            {
                ShowMsg(e.ErrorCode.ToString());
            }
        }

        void ReaderCE_MyTagAccessEvent(object sender, Reader.Events.TagAccessEventArgs e)
        {
            result.UpdateResult(e.TagAccessInformation.resultType == TagAccResult.OK ? true : false);
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
            //Text = String.Format("Kill Result = {0}", msg);
        }
        #endregion

        /*#region Other Handle
        private void tb_epc_TextChanged(object sender, EventArgs e)
        {
            TargetEPC = tb_epc.Text;
        }
        #endregion*/

        
    }
}