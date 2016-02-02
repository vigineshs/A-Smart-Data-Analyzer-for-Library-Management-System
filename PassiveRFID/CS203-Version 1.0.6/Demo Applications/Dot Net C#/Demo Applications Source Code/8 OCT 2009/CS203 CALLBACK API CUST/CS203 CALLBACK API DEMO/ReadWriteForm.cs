using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203DEMO
{
    using rfid.Constants;
    using rfid.Structures;

    using Reader.Constants;
    using Reader.Structures;
    using Reader.Utility;

    public partial class ReadWriteForm : Form
    {
        #region Private Member
        enum State : int
        {
            WriteEPC,
            Other,
        }
        private State CurState = State.Other;
        private StringBuilder LogBuilder = new StringBuilder();
        private string targetEpc = "";

        public string TargetEPC
        {
            get { return targetEpc; }
            set { targetEpc = value; }
        }
        #endregion

        #region Form
        public ReadWriteForm()
        {
            InitializeComponent();
        }
        private void ReadForm_Load(object sender, EventArgs e)
        {
            //lb_epc.Text = EpcAddDashLine(TargetEPC);
            cb_memBank.SelectedIndex = 0;
            AttachCallback(true);
        }

        private void ReadForm_Closing(object sender, CancelEventArgs e)
        {
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
        private void btn_cread_Click(object sender, EventArgs e)
        {
            /*AttachCallback(false);
            using (CustomReadForm read = new CustomReadForm())
            {
                read.TargetEPC = TargetEPC;
                read.ShowDialog();
            }
            AttachCallback(true);*/
        }
        private void rb_read_Click(object sender, EventArgs e)
        {
            rb_read.Checked = true;
            rb_write.Checked = false;
            btn_readtid.Enabled = true;
            nb_count.Enabled = nb_offset.Enabled = true;
            btn_read.Text = "Read";
            btn_read.BackColor = Color.FromArgb(0, 192, 0);
            btn_read.ForeColor = Color.Black;
        }

        private void rb_write_Click(object sender, EventArgs e)
        {
            rb_read.Checked = false;
            rb_write.Checked = true;
            btn_readtid.Enabled = false;
            nb_count.Enabled = nb_offset.Enabled = false;
            btn_read.Text = "Write";
            btn_read.BackColor = Color.FromArgb(0, 128, 255);
            btn_read.ForeColor = Color.White;
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            ClearLog();
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                return;
            if (rb_read.Checked)
            {
                //Do reader config
                Program.ReaderCE.RdrOpParms.RunBasicReadParms.Singulation = SingulationAlgorithm.FIXEDQ;
                Program.ReaderCE.RdrOpParms.RunBasicReadParms.SingulationParms = Reader.HighLevelInterface.CreateFixedQParms(0, 5, 0, 0); ;
                Program.ReaderCE.RdrOpParms.RunBasicReadParms.TagGroup = Reader.HighLevelInterface.CreateTagGroup(Selected.ON, Session.S0, SessionTarget.A);
                Program.ReaderCE.RdrOpParms.RunBasicReadParms.SelectCriteria = Reader.HighLevelInterface.CreateSelectCriteria(32, 96, MemoryBank.EPC, Action.ASLINVA_DSLINVB, Target.SELECTED, false, HexEncoding.GetBytes(TargetEPC));

                Program.ReaderCE.RdrOpParms.RunBasicReadParms.Flags = Reader.Constants.ReaderFlag.SELECT;
                Program.ReaderCE.RdrOpParms.RunBasicReadParms.TargetOffset = (ushort)nb_offset.Value;
                Program.ReaderCE.RdrOpParms.RunBasicReadParms.TargetCount = (ushort)nb_count.Value;
                Program.ReaderCE.RdrOpParms.RunBasicReadParms.TargetMemoryBank = (MemoryBank)cb_memBank.SelectedIndex;
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = 0x0;
                Program.ReaderCE.RdrOpParms.Operation = Operation.Read;
                Program.ReaderCE.RunCycle = 1;
                Program.ReaderCE.Setup(Operation.Read);
                Program.ReaderCE.Start();
            }
            else
            {
                using (WriteInputForm input = new WriteInputForm())
                {
                    input.DataLength = 1;
                    input.EnableOffset = true;
                    input.EnableCount = true;
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        //Do reader config
                        //If start from PC+EPC then use zero offset otherwise use 16
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.Singulation = SingulationAlgorithm.FIXEDQ;
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.SingulationParms = Reader.HighLevelInterface.CreateFixedQParms(0, 5, 0, 0); ;
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.TagGroup = Reader.HighLevelInterface.CreateTagGroup(Selected.ON, Session.S0, SessionTarget.A);
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.SelectCriteria = Reader.HighLevelInterface.CreateSelectCriteria(32, 96, MemoryBank.EPC, Action.ASLINVA_DSLINVB, Target.SELECTED, false, HexEncoding.GetBytes(TargetEPC));
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.Flags = ReaderFlag.SELECT;
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.TargetCount = input.Count;
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.TargetOffset = input.Offset;
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.Buffer = HexEncoding.GetUshort(input.Data);
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.TargetMemoryBank = (MemoryBank)cb_memBank.SelectedIndex;
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.Verify = 1;
                        Program.ReaderCE.RdrOpParms.RunBasicWriteParms.VerifyRetryCount = 7;
                        Program.ReaderCE.RdrOpParms.TargetAccessPassword = input.PWD;
                        Program.ReaderCE.RdrOpParms.Operation = Operation.Write;
                        Program.ReaderCE.RunCycle = 1;
                        Program.ReaderCE.Setup(Operation.Write);
                        Program.ReaderCE.Start();
                    }
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearLog()
        {
            LogBuilder.Remove(0, LogBuilder.Length);
            tb_log.Text = "";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void btn_readkill_Click(object sender, EventArgs e)
        {
            ClearLog();
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                return;
            if (rb_read.Checked)
            {
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = 0x0;
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.TargetPC = null;    // No PC
                Program.ReaderCE.RdrOpParms.Operation = Operation.ReadKillPwd;
                Program.ReaderCE.Start();
            }
            else
            {
                using (WriteInputForm input = new WriteInputForm())
                {
                    CurState = State.Other;
                    input.DataLength = 2;
                    input.EnableOffset = false;
                    input.EnableCount = false;
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        //Do something
                        Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                        Program.ReaderCE.RdrOpParms.TargetPC = null;    // No PC
                        Program.ReaderCE.RdrOpParms.TargetAccessPassword = input.PWD;
                        Program.ReaderCE.RdrOpParms.RunWriteKillPwdParms.pData = uint.Parse(input.Data, System.Globalization.NumberStyles.HexNumber);
                        Program.ReaderCE.RdrOpParms.WriteRetryCount = input.RetryCnt;
                        Program.ReaderCE.RdrOpParms.Operation = Operation.WriteKillPwd;
                        Program.ReaderCE.Start();
                    }
                }
            }
        }

        private void btn_readacc_Click(object sender, EventArgs e)
        {
            ClearLog();
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                return;
            if (rb_read.Checked)
            {
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = 0x0;
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.ReadAccPwd;
                Program.ReaderCE.Start();
            }
            else
            {
                using (WriteInputForm input = new WriteInputForm())
                {
                    CurState = State.Other;
                    input.DataLength = 2;
                    input.EnableOffset = false;
                    input.EnableCount = false;
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        //Do something
                        Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                        Program.ReaderCE.RdrOpParms.TargetAccessPassword = input.PWD;
                        Program.ReaderCE.RdrOpParms.RunWriteAccPwdParms.pData = uint.Parse(input.Data, System.Globalization.NumberStyles.HexNumber);
                        Program.ReaderCE.RdrOpParms.WriteRetryCount = input.RetryCnt;
                        Program.ReaderCE.RdrOpParms.Operation = Operation.WriteAccPwd;
                        Program.ReaderCE.Start();
                    }
                }
            }
        }

        private void btn_readpc_Click(object sender, EventArgs e)
        {
            ClearLog();
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                return;
            if (rb_read.Checked)
            {
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = 0x0;
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.ReadPC;
                Program.ReaderCE.Start();
            }
            else
            {
                using (WriteInputForm input = new WriteInputForm())
                {
                    CurState = State.Other;
                    input.DataLength = 1;
                    input.EnableOffset = false;
                    input.EnableCount = false;
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        //Do something
                        Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                        Program.ReaderCE.RdrOpParms.TargetAccessPassword = input.PWD;
                        Program.ReaderCE.RdrOpParms.RunWritePCParms.pData = ushort.Parse(input.Data, System.Globalization.NumberStyles.HexNumber);
                        Program.ReaderCE.RdrOpParms.WriteRetryCount = input.RetryCnt;
                        Program.ReaderCE.RdrOpParms.Operation = Operation.WritePC;
                        Program.ReaderCE.Start();
                    }
                }
            }

        }

        private void btn_readepc_Click(object sender, EventArgs e)
        {
            ClearLog();
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                return;
            if (rb_read.Checked)
            {
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = 0x0;
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.ReadEPC;
                Program.ReaderCE.Start();
            }
            else
            {
                using (WriteInputForm input = new WriteInputForm())
                {
                    CurState = State.WriteEPC;
                    input.DataLength = (uint)TargetEPC.Length >> 2; // 96 bit
                    input.EnableOffset = false;
                    input.EnableCount = false;
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        //Do something
                        Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                        Program.ReaderCE.RdrOpParms.TargetAccessPassword = input.PWD;
                        Program.ReaderCE.RdrOpParms.RunWriteEPCParms.BitNum = TargetEPC.Length == 24 ? EPCBitNumber.e96Bit : EPCBitNumber.e240Bit;
                        Program.ReaderCE.RdrOpParms.RunWriteEPCParms.pData = input.Data;
                        Program.ReaderCE.RdrOpParms.WriteRetryCount = input.RetryCnt;
                        Program.ReaderCE.RdrOpParms.Operation = Operation.WriteEPC;
                        Program.ReaderCE.Start();
                    }
                }
            }
        }

        private void btn_readtid_Click(object sender, EventArgs e)
        {
            ClearLog();
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                return;
            if (rb_read.Checked)
            {
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = 0x0;
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.Operation = Operation.ReadTID;
                Program.ReaderCE.Start();
            }
            else
            {

            }
        }

        private void btn_readuser_Click(object sender, EventArgs e)
        {
            ClearLog();
            if (Program.ReaderCE.MyState != ReaderOperationMode.Idle)
                return;
            if (rb_read.Checked)
            {
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = 0x0;
                Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                Program.ReaderCE.RdrOpParms.RunReadUserParms.Offset = (ushort)nb_offset.Value;
                Program.ReaderCE.RdrOpParms.RunReadUserParms.Count = (ushort)nb_count.Value;
                Program.ReaderCE.RdrOpParms.Operation = Operation.ReadUser;
                Program.ReaderCE.Start();
            }
            else
            {
                using (WriteInputForm input = new WriteInputForm())
                {
                    CurState = State.Other;
                    input.DataLength = 0;
                    input.EnableOffset = true;
                    input.EnableCount = true;
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        //Do something
                        Program.ReaderCE.RdrOpParms.TargetEPC = TargetEPC;
                        Program.ReaderCE.RdrOpParms.TargetAccessPassword = input.PWD;
                        Program.ReaderCE.RdrOpParms.RunWriteUserParms.Offset = input.Offset;
                        Program.ReaderCE.RdrOpParms.RunWriteUserParms.Count = (uint)input.Count;
                        Program.ReaderCE.RdrOpParms.RunWriteUserParms.pData = HexEncoding.GetUshort(input.Data);
                        Program.ReaderCE.RdrOpParms.WriteRetryCount = input.RetryCnt;
                        Program.ReaderCE.RdrOpParms.Operation = Operation.WriteUser;
                        Program.ReaderCE.Start();
                    }
                }
            }
        }
        private void lb_epc_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                AttachCallback(false);
                using (InventoryForm InvForm = new InventoryForm(true))
                {
                    if (InvForm.ShowDialog() == DialogResult.OK)
                    {
                        TargetEPC = InvForm.EPC;
                        lb_epc.Text = EpcAddDashLine(InvForm.EPC);
                    }
                }
                AttachCallback(true);
            }
            else
            {
                MessageBox.Show("Please wait, Reader is busy");
            }
        }

        #endregion

        #region Event Callback
        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderCE.MyErrorEvent += new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
                Program.ReaderCE.MyTagAccessEvent += new EventHandler<Reader.Events.TagAccessEventArgs>(ReaderCE_MyTagAccessEvent);
                Program.ReaderCE.MyRunningStateEvent += new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
                //Program.KeyHook.KeyPressEvent += new Reader.Device.KeyboardHook.KeyboardHookEventHandler(KeyHook_KeyPressEvent);
            }
            else
            {
                Program.ReaderCE.MyErrorEvent -= new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
                Program.ReaderCE.MyTagAccessEvent -= new EventHandler<Reader.Events.TagAccessEventArgs>(ReaderCE_MyTagAccessEvent);
                Program.ReaderCE.MyRunningStateEvent -= new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
                //Program.KeyHook.KeyPressEvent -= new Reader.Device.KeyboardHook.KeyboardHookEventHandler(KeyHook_KeyPressEvent);
            }
        }

        void ReaderCE_MyErrorEvent(object sender, Reader.Events.ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Write)
            {
                ShowMsg(e.ErrorCode.ToString());
            }
        }

        void ReaderCE_MyTagAccessEvent(object sender, Reader.Events.TagAccessEventArgs e)
        {
            TagAccessDataStruct data = (TagAccessDataStruct)e.TagAccessInformation;

            LogBuilder.Insert(0, "Time = " + data.ms_ctr.ToString() + "\r\n");
            LogBuilder.Insert(0, "Data = " + Reader.Utility.HexEncoding.ToString(data.data) + "\r\n");
            LogBuilder.Insert(0, "ErrorCode = " + data.errorCode.ToString() + "\r\n");
            LogBuilder.Insert(0, "Operation Type = " + data.accessType.ToString() + "   Result = " + data.resultType + "\r\n");
            UpdateLogTb(LogBuilder.ToString());
        }

        void ReaderCE_MyRunningStateEvent(object sender, Reader.Events.ReaderOperationModeEventArgs e)
        {
            switch (e.State)
            {
                case ReaderOperationMode.Idle:
                    //Device.MelodyPlay(Device.RingTone.T1, Device.BUZZER_SOUND.HIGH);
                    EnablePanel1(true);
                    break;
                case ReaderOperationMode.Running:
                    //Device.MelodyPlay(Device.RingTone.T2, Device.BUZZER_SOUND.HIGH);
                    EnablePanel1(false);
                    break;
                case ReaderOperationMode.SearchDone:
                    break;
                case ReaderOperationMode.Stopping:
                    break;
                case ReaderOperationMode.WriteDone:
                    if (CurState == State.WriteEPC)
                    {
                        TargetEPC = Program.ReaderCE.RdrOpParms.RunWriteEPCParms.pData;
                        //update UI
                        UpdateEPCLb(TargetEPC);
                    }
                    break;
                case ReaderOperationMode.DeviceNotFound:
                    break;
            }
        }

        #endregion

        #region Delegate

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

        private delegate void UpdateLogTbDeleg(string msg);
        private void UpdateLogTb(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateLogTbDeleg(UpdateLogTb), new object[] { msg });
                return;
            }
            tb_log.Text = msg;
        }
        private delegate void UUpdateEPCLbDeleg(string msg);
        private void UpdateEPCLb(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UUpdateEPCLbDeleg(UpdateEPCLb), new object[] { msg });
                return;
            }
            lb_epc.Text = EpcAddDashLine(msg);
        }
        private string EpcAddDashLine(string msg)
        {
            if (msg == null || msg.Length == 0)
                return "";
            int count = msg.Length / 4 + msg.Length % 4;
            string tmp = "";
            for (int i = 0; i < count; i++)
            {
                tmp += String.Format("{0}-", msg.Substring(i*4, 4));
            }
            return tmp.Remove(tmp.Length - 1, 1);
        }
        private delegate void EnablePanel1Deleg(bool en);
        private void EnablePanel1(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnablePanel1Deleg(EnablePanel1), new object[] { en });
                return;
            }
            pn_custread.Enabled = en;
        }

        #endregion


    }
}