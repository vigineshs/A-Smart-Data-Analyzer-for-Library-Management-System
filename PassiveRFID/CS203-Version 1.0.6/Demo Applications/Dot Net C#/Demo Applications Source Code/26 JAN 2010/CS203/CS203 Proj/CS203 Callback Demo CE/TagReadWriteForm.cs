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

using CSLibrary.HotKeys;

namespace CS203_CALLBACK_API_DEMO_CE
{
    enum Opts
    {
        UNKNOWN = -1,
        TAG_SEARCH,
        TAG_READ,
        TAG_WRITE,
        TAG_EXIT
    }


    public partial class TagReadWriteForm : Form
    {
        #region Private Member
        private Opts m_opt = Opts.UNKNOWN;
        private uint m_retry_cnt = 7;
        private bool m_cancel_read_all_bank = false;
        private bool m_read_done = false;
        private bool m_cancel_write_all_bank = false;
        private bool m_stop = false;
        private object m_synclock = new object();
        private TagCallbackInfo m_record = new TagCallbackInfo();
        private TagDataModel m_tagTable = new TagDataModel(SlowFlags.PC | SlowFlags.EPC);
        #endregion

        #region Form
        public TagReadWriteForm()
        {
            InitializeComponent();
        }


        private void NewReadWriteForm_Load(object sender, EventArgs e)
        {
            //Setting Table
            nTable1.SetColumnWidth(0, 50);
            nTable1.BindModel(m_tagTable);

            AttachCallback(true);
        }

        private void NewReadWriteForm_Closing(object sender, CancelEventArgs e)
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
                HotKeys.OnKeyEvent += new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
                Program.ReaderCE.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
                Program.ReaderCE.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderCE_TagSearchAllEvent);
                Program.ReaderCE.OnAccessCompleted += new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_TagCompletedEvent);
            }
            else
            {
                HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);
                Program.ReaderCE.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
                Program.ReaderCE.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderCE_TagSearchAllEvent);
                Program.ReaderCE.OnAccessCompleted -= new EventHandler<CSLibrary.Events.OnAccessCompletedEventArgs>(ReaderCE_TagCompletedEvent);
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
                        if (tc_readAndWrite.SelectedIndex == 0 && KeyDown)
                        {
                            Start();
                        }
                        break;
                }
            }
            else
            {
                if (KeyCode == Key.F11 && tc_readAndWrite.SelectedIndex == 0)
                {
                    Stop();
                }
            }
        }

        void ReaderCE_TagCompletedEvent(object sender, CSLibrary.Events.OnAccessCompletedEventArgs e)
        {
            if (e.access == TagAccess.READ)
            {
                switch (e.bank)
                {
                    case Bank.ACC_PWD:
                        if (e.success)
                        {
                            UpdateBankInfo(e.bank, Program.ReaderCE.Options.TagReadAccPwd.password.ToString());
                        }
                        break;
                    case Bank.EPC:
                        if (e.success)
                        {
                            UpdateBankInfo(e.bank, Program.ReaderCE.Options.TagReadEPC.epc.ToString());
                        }
                        break;
                    case Bank.KILL_PWD:
                        if (e.success)
                        {
                            UpdateBankInfo(e.bank, Program.ReaderCE.Options.TagReadKillPwd.password.ToString());
                        }
                        break;
                    case Bank.PC:
                        if (e.success)
                        {
                            UpdateBankInfo(e.bank, Program.ReaderCE.Options.TagReadPC.pc.ToString());
                        }
                        break;
                    case Bank.TID:
                        if (e.success)
                        {
                            UpdateBankInfo(e.bank, Program.ReaderCE.Options.TagReadTid.tid.ToString());
                        }
                        break;
                    case Bank.USER:
                        if (e.success)
                        {
                            UpdateBankInfo(e.bank, Program.ReaderCE.Options.TagReadUser.pData.ToString());
                        }
                        break;
                }
            }
        }

        void ReaderCE_TagSearchAllEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            if (e.type == CallbackType.TAG_INVENTORY)
            {
                AddItem(e.info);
            }
        }

        void ReaderCE_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            switch (e.state)
            {
                case RFState.IDLE:
                    EnableForm(true);
                    if (!m_stop)
                    {
                        switch (m_opt)
                        {
                            case Opts.TAG_SEARCH:
                                //Device.MelodyPlay(RingTone.T1, BuzzerVolume.HIGH);
                                ChangeBtnState(false);
                                break;
                        }
                    }
                    else
                    {
                        CloseForm();
                    }
                    break;
                case RFState.BUSY:
                    switch (m_opt)
                    {
                        case Opts.TAG_SEARCH:
                            //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);
                            ChangeBtnState(true);
                            break;
                    }
                    break;
                case RFState.ABORT:
                    EnableForm(false);
                    break;
            }
        }
        #endregion

        #region UI Update
        private void ChangeBtnState(bool searching)
        {
            if (searching)
            {
                btn_search.Text = "Stop";
                btn_search.BackColor = Color.Red;
            }
            else
            {
                btn_search.Text = "Search";
                btn_search.BackColor = Color.FromArgb(0, 192, 0);
            }
        }

        private void UpdateBankInfo(Bank bank,  string info)
        {

            switch (bank)
            {
                case Bank.ACC_PWD:
                    m_readAllBank.UpdateAccPwd(info);
                    break;
                case Bank.KILL_PWD:
                    m_readAllBank.UpdateKillPwd(info);
                    break;
                case Bank.TID:
                    m_readAllBank.UpdateTid(info);
                    break;
                case Bank.USER:
                    m_readAllBank.UpdateUserBank(info);
                    break;
                case Bank.PC:
                    m_readAllBank.UpdatePC(info);
                    break;
                case Bank.EPC:
                    m_readAllBank.UpdateEPC(info);
                    break;
            }
        }
        #endregion

        #region Other Handle

        private void Start()
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                Clear();
                m_opt = Opts.TAG_SEARCH;

                Program.ReaderCE.SetOperationMode(Program.appSetting.Cfg_continuous_mode ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
                Program.ReaderCE.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderCE.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);

                Program.ReaderCE.StartOperation(Operation.TAG_INVENTORY, false);
            }
        }
        private void Stop()
        {
            if (Program.ReaderCE.State == RFState.BUSY)
            {
                Program.ReaderCE.StopOperation(true);
            }
        }

        private void Clear()
        {
            m_tagTable.Clear();
            tb_entertag.Text = "";
        }

        private void tb_entertag_TextChanged(object sender, EventArgs e)
        {
            m_record.epc = new S_EPC(tb_entertag.Text);
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void lb_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void nTable1_RowChanged(int rowIndex)
        {
            m_readAllBank.Clear();
            m_writeAllBank.Clear();
            m_read_done = false;
            m_record.epc = m_tagTable.Items[rowIndex].epc;
            m_record.pc = m_tagTable.Items[rowIndex].pc;
            tb_entertag.Text = m_record.epc.ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                Program.ReaderCE.StopOperation(true);
            }

            m_opt = (Opts)tc_readAndWrite.SelectedIndex;

            switch ((Opts)tc_readAndWrite.SelectedIndex)
            {
                case Opts.TAG_SEARCH:
                    ChangeBtnState(false);
                    break;
                case Opts.TAG_READ:

                    if (nTable1.CurrentRowIndex == -1)
                    {
                        MessageBox.Show("Please choose a tag first or input a tag ID");
                        tc_readAndWrite.SelectedIndex = 0;
                    }
                    else
                    {
                        m_readAllBank.pc = m_record.pc.ToString();
                        m_readAllBank.epc = m_record.epc.ToString();
                    }
                    break;
                case Opts.TAG_WRITE:
                    if (nTable1.CurrentRowIndex == -1)
                    {
                        MessageBox.Show("Please choose a tag first or input a tag ID");
                        tc_readAndWrite.SelectedIndex = 0;
                    }
                    else if (!m_read_done)
                    {
                        MessageBox.Show("Please read a tag first");
                        tc_readAndWrite.SelectedIndex = 1;
                    }
                    else
                    {
                        m_writeAllBank.pc = m_record.pc.ToString();
                        m_writeAllBank.epc = m_record.epc.ToString();
                        m_writeAllBank.UpdateAccPwd(m_readAllBank.AccPwd);
                        m_writeAllBank.UpdateKillPwd(m_readAllBank.KillPwd);
                        m_writeAllBank.UpdateUserBank(m_readAllBank.UserMem);
                        m_writeAllBank.OffsetUser = m_readAllBank.OffsetUser;
                        m_writeAllBank.WordUser = m_readAllBank.WordUser;
                    }
                    break;
                case Opts.TAG_EXIT:
                    this.Close();
                    break;
            }
        }
        #endregion

        #region Read
        private void btn_readallbank_Click(object sender, EventArgs e)
        {

            if (Program.ReaderCE.State == RFState.IDLE)
            {
                m_readAllBank.Clear();

                m_opt = Opts.TAG_READ;

                m_cancel_read_all_bank = false;

                btn_readallbank.Text = "Stop";
                btn_readallbank.BackColor = Color.Red;

                //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);

                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, read will fail
                Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(/*m_record.pc.ToString() + */m_record.epc.ToString());
                Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;
                if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed");
                    return;
                }
                if (m_readAllBank.ReadPc && !m_cancel_read_all_bank)
                {
                    lb_ReadInfo.Text = "Start reading PC";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagReadPC.accessPassword = m_readAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagReadPC.retryCount = m_retry_cnt;

                    if (Program.ReaderCE.StartOperation(Operation.TAG_READ_PC, true) == Result.OK)
                    {
                        m_readAllBank.IconPc = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        m_readAllBank.IconPc = ReadAllBank.ReadState.FAILED;
                    }

                }
                if (m_readAllBank.ReadEpc && !m_cancel_read_all_bank)
                {
                    lb_ReadInfo.Text = "Start reading EPC";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagReadEPC.accessPassword = m_readAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagReadEPC.retryCount = m_retry_cnt;
                    Program.ReaderCE.Options.TagReadEPC.count = 6;

                    if (Program.ReaderCE.StartOperation(Operation.TAG_READ_EPC, true) == Result.OK)
                    {
                        m_readAllBank.IconEpc = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        m_readAllBank.IconEpc = ReadAllBank.ReadState.FAILED;
                    }

                }

                //if access bank is checked, read it.
                if (m_readAllBank.ReadAccPwd && !m_cancel_read_all_bank)
                {
                    lb_ReadInfo.Text = "Start reading access pwd";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagReadAccPwd.accessPassword = m_readAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagReadAccPwd.retryCount = m_retry_cnt;

                    if (Program.ReaderCE.StartOperation(Operation.TAG_READ_ACC_PWD, true) == Result.OK)
                    {
                        m_readAllBank.IconAcc = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        m_readAllBank.IconAcc = ReadAllBank.ReadState.FAILED;
                    }
                    
                }
                //if kill bank is checked, read it.
                if (m_readAllBank.ReadKillPwd && !m_cancel_read_all_bank)
                {
                    lb_ReadInfo.Text = "Start reading kill pwd";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagReadKillPwd.accessPassword = m_readAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagReadKillPwd.retryCount = m_retry_cnt;

                    if (Program.ReaderCE.StartOperation(Operation.TAG_READ_KILL_PWD, true) == Result.OK)
                    {
                        m_readAllBank.IconKill = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        m_readAllBank.IconKill = ReadAllBank.ReadState.FAILED;
                    }
                }
                //if tid bank is checked, read it.
                if (m_readAllBank.ReadTid && !m_cancel_read_all_bank)
                {
                    lb_ReadInfo.Text = "Start reading TID";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagReadTid.accessPassword = m_readAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagReadTid.retryCount = m_retry_cnt;
                    Program.ReaderCE.Options.TagReadTid.offset = m_readAllBank.OffsetTid;
                    Program.ReaderCE.Options.TagReadTid.count = m_readAllBank.WordTid;

                    if (Program.ReaderCE.StartOperation(Operation.TAG_READ_TID, true) == Result.OK)
                    {
                        m_readAllBank.IconTid = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        m_readAllBank.IconTid = ReadAllBank.ReadState.FAILED;
                    }
                }
                //if user bank is checked, read it.
                if (m_readAllBank.ReadUserBank && !m_cancel_read_all_bank)
                {
                    lb_ReadInfo.Text = "Start reading user memory";
                    Application.DoEvents();
    
                    Program.ReaderCE.Options.TagReadUser.accessPassword = m_readAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagReadUser.retryCount = m_retry_cnt;
                    Program.ReaderCE.Options.TagReadUser.offset = m_readAllBank.OffsetUser;
                    Program.ReaderCE.Options.TagReadUser.count = m_readAllBank.WordUser;

                    if (Program.ReaderCE.StartOperation(Operation.TAG_READ_USER, true) == Result.OK)
                    {
                        m_readAllBank.IconUser = ReadAllBank.ReadState.OK;
                    }
                    else
                    {
                        //Read failed
                        m_readAllBank.IconUser = ReadAllBank.ReadState.FAILED;
                    }
                }

                lb_ReadInfo.Text = "Read done!!!";
                //Device.MelodyPlay(RingTone.T1, BuzzerVolume.HIGH);
                btn_readallbank.Text = "Read";
                btn_readallbank.BackColor = Color.FromArgb(0, 192, 0);
                Application.DoEvents();
                m_read_done = true;
            }
            else
            {
                MessageBox.Show("Reader is busy now, please try later.");
            }
        }
        #endregion

        #region Write
        private void btn_writeAllbank_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                if (!(m_writeAllBank.WriteAccPwd |
                    m_writeAllBank.WriteEPC |
                    m_writeAllBank.WriteKillPwd |
                    m_writeAllBank.WritePC |
                    m_writeAllBank.WriteUser))
                {
                    //All unchecked
                    MessageBox.Show("Please check at least one item to write", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                    return;
                }

                m_opt = Opts.TAG_WRITE;

                m_cancel_write_all_bank = false;

                btn_writeallbank.Enabled = false;

                //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);

                Program.ReaderCE.Options.TagSelected.flags = SelectMaskFlags.DISABLE_ALL;
                //Comment:If enable PC lock, please make sure you are not using Higgs3 Tag. Otherwise, write will fail
                Program.ReaderCE.Options.TagSelected.epcMask = new S_MASK(/*m_record.pc.ToString() +*/ m_record.epc.ToString());
                Program.ReaderCE.Options.TagSelected.epcMaskLength = (uint)Program.ReaderCE.Options.TagSelected.epcMask.Length * 8;

                if (Program.ReaderCE.StartOperation(Operation.TAG_SELECTED, true) != Result.OK)
                {
                    MessageBox.Show("Selected tag failed");
                    return;
                }


                //if access bank is checked, read it.
                if (!m_cancel_write_all_bank && m_writeAllBank.WriteAccPwd)
                {
                    lb_WriteInfo.Text = "Start writing access pwd";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagWriteAccPwd.retryCount = m_retry_cnt;
                    Program.ReaderCE.Options.TagWriteAccPwd.accessPassword = m_writeAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagWriteAccPwd.password = m_writeAllBank.AccPwd;

                    if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_ACC_PWD, true) == Result.OK)
                    {
                        m_writeAllBank.IconAcc = WriteAllBank.WriteState.OK;
                    }
                    else
                    {
                        //Write failed
                        m_writeAllBank.IconAcc = WriteAllBank.WriteState.FAILED;
                    }

                }
                //if kill bank is checked, read it.
                if (!m_cancel_write_all_bank && m_writeAllBank.WriteKillPwd)
                {
                    lb_WriteInfo.Text = "Start writing kill pwd";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagWriteKillPwd.retryCount = m_retry_cnt;
                    Program.ReaderCE.Options.TagWriteKillPwd.accessPassword = m_writeAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagWriteKillPwd.password = m_writeAllBank.KillPwd;

                    if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_KILL_PWD, true) == Result.OK)
                    {
                        m_writeAllBank.IconKill = WriteAllBank.WriteState.OK;
                    }
                    else
                    {
                        //Write failed
                        m_writeAllBank.IconKill = WriteAllBank.WriteState.FAILED;
                    }
                }

                //if user bank is checked, read it.
                if (!m_cancel_write_all_bank && m_writeAllBank.WriteUser)
                {
                    lb_WriteInfo.Text = "Start writing user memory";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagWriteUser.retryCount = m_retry_cnt;
                    Program.ReaderCE.Options.TagWriteUser.accessPassword = m_writeAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagWriteUser.offset = m_writeAllBank.OffsetUser;
                    Program.ReaderCE.Options.TagWriteUser.count = m_writeAllBank.WordUser;
                    Program.ReaderCE.Options.TagWriteUser.pData = Hex.ToUshorts(m_writeAllBank.User);

                    if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_USER, true) == Result.OK)
                    {
                        m_writeAllBank.IconUser = WriteAllBank.WriteState.OK;
                    }
                    else
                    {
                        //Write failed
                        m_writeAllBank.IconUser = WriteAllBank.WriteState.FAILED;
                    }

                }

                if (!m_cancel_write_all_bank && m_writeAllBank.WritePC)
                {
                    lb_WriteInfo.Text = "Start writing PC";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagWritePC.retryCount = m_retry_cnt;
                    Program.ReaderCE.Options.TagWritePC.accessPassword = m_writeAllBank.AccessPwd;
                    
                    Program.ReaderCE.Options.TagWritePC.pc = Hex.ToUshort(m_writeAllBank.pc);

                    if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_PC, true) == Result.OK)
                    {
                        m_writeAllBank.IconPc = WriteAllBank.WriteState.OK;
                        m_tagTable.Items[nTable1.CurrentRowIndex].pc = m_record.pc = new S_PC(m_writeAllBank.pc);
                    }
                    else
                    {
                        //Write failed
                        m_writeAllBank.IconPc = WriteAllBank.WriteState.FAILED;
                    }
                }
                //Write EPC must put in last order to prevent it get lost
                if (!m_cancel_write_all_bank && m_writeAllBank.WriteEPC)
                {
                    lb_WriteInfo.Text = "Start writing EPC";
                    Application.DoEvents();

                    Program.ReaderCE.Options.TagWriteEPC.retryCount = m_retry_cnt;
                    Program.ReaderCE.Options.TagWriteEPC.accessPassword = m_writeAllBank.AccessPwd;
                    Program.ReaderCE.Options.TagWriteEPC.offset = 0;
                    Program.ReaderCE.Options.TagWriteEPC.count = Hex.GetWordCount(m_writeAllBank.epc);
                    Program.ReaderCE.Options.TagWriteEPC.epc = new S_EPC(m_writeAllBank.epc);

                    if (Program.ReaderCE.StartOperation(Operation.TAG_WRITE_EPC, true) == Result.OK)
                    {
                        //EPC Changed 
                        m_writeAllBank.IconEpc = WriteAllBank.WriteState.OK;
                        m_tagTable.Items[nTable1.CurrentRowIndex].epc = m_record.epc = new S_EPC(m_writeAllBank.epc);
                    }
                    else
                    {
                        //Write failed
                        m_writeAllBank.IconEpc = WriteAllBank.WriteState.FAILED;
                    }
                }
                lb_WriteInfo.Text = "Write done!!!";
                //Device.MelodyPlay(RingTone.T1, BuzzerVolume.HIGH);
                Application.DoEvents();
                btn_writeallbank.Enabled = true;
            }
            else
            {
                MessageBox.Show("Reader is busy now, please try later.");
            }
        }
        #endregion

        #region Delegate
        private delegate void AddItemDeleg(TagCallbackInfo info);
        private void AddItem(TagCallbackInfo info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AddItemDeleg(AddItem), new object[] { info });
                return;
            }
            m_tagTable.AddItem(info);
            //Device.BuzzerOn(2000, 40, BuzzerVolume.HIGH);
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

    }
}