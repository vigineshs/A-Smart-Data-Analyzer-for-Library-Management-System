using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary.HotKeys;

namespace CS203_CALLBACK_API_DEMO_CE
{
    public partial class TagSearchForm : Form
    {
        #region Private Variable
        private TagDataModel m_tagTable = new TagDataModel(SlowFlags.INDEX | SlowFlags.PC | SlowFlags.EPC);
        private bool m_toggleStartBtn = false;
        private bool m_stop = false;
        #endregion

        #region Extern Varible
        public string pc
        {
            get
            {
                if (nTable1.CurrentRowIndex != -1)
                {
                    return m_tagTable.Items[nTable1.CurrentRowIndex].pc.ToString();
                }
                return String.Empty;
            }
        }
        public string epc
        {
            get
            {
                if (nTable1.CurrentRowIndex != -1)
                {
                    return m_tagTable.Items[nTable1.CurrentRowIndex].epc.ToString();
                }
                return String.Empty;
            }
        }
        #endregion

        #region Form
        public TagSearchForm()
        {
            InitializeComponent();
        }

        private void TagSearchForm_Load(object sender, EventArgs e)
        {
            //Table setting
            nTable1.BindModel(m_tagTable);//Bind empty table to draw column header
            nTable1.SetColumnWidth(0, 50);//Index column width
            nTable1.SetColumnWidth(1, 50);//Rssi column width
            
            //Attach Callback Event
            AttachCallback(true);
        }

        private void TagSearchForm_Closing(object sender, CancelEventArgs e)
        {
            if (Program.ReaderCE.State != RFState.IDLE)
            {
                m_stop = e.Cancel = true;
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
                Program.ReaderCE.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderCE_TagInventoryEvent);
            }
            else
            {
                HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);

                Program.ReaderCE.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderCE_TagInventoryEvent);
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

        void ReaderCE_TagInventoryEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            //Using asyn delegate to update UI
            if (e.type == CallbackType.TAG_INVENTORY)
            {
                //Device.BuzzerOn(2000, 40, BuzzerVolume.HIGH);

                UpdateRecords(e.info);
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
                        ToggleButton();
                        EnableForm(true);
                    }
                    else
                    {
                        CloseForm();
                    }
                    break;
                case RFState.BUSY:
                    //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);
                    ToggleButton();
                    break;
                case RFState.ABORT:
                    EnableForm(false); ;
                    break;
            }
        }

        #endregion

        #region Delegate
        private delegate void ToggleButtonDel();
        private void ToggleButton()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ToggleButtonDel(ToggleButton), new object[] { });
                return;
            }
            if (m_toggleStartBtn)
            {
                m_toggleStartBtn = false;
                btn_search.Text = "Search";
                btn_search.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                m_toggleStartBtn = true;
                btn_search.Text = "Stop";
                btn_search.BackColor = Color.Red;
            }
        }

        private delegate void UpdateRecordsDel(object data);
        private void UpdateRecords(object data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateRecordsDel(UpdateRecords), new object[] { data });
                return;
            }
            TagCallbackInfo record = (TagCallbackInfo)data;
            if (record != null)
            {
                m_tagTable.AddItem(record);
                lb_tagCount.Text = m_tagTable.Items.Count.ToString();
            }
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

        #region Control Handle
        public void Start()
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                //Clear list
                m_tagTable.Clear();
                Program.ReaderCE.SetOperationMode(Program.appSetting.Cfg_continuous_mode ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
                Program.ReaderCE.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderCE.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);

                Program.ReaderCE.Options.TagInventory.flags = SelectFlags.ZERO;
                Program.ReaderCE.StartOperation(Operation.TAG_INVENTORY, Program.appSetting.Cfg_blocking_mode);
            }
        }

        private void Stop()
        {
            if (Program.ReaderCE.State == RFState.BUSY)
            {
                Program.ReaderCE.StopOperation(true);
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                Start();
            }
            else if (Program.ReaderCE.State == RFState.BUSY)
            {
                Stop();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nTable1_RowChanged(int rowIndex)
        {
            btn_select.Enabled = (rowIndex != -1);
        }
        #endregion
    }
}