#define NONBLOCKING
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace CS203_CALLBACK_API_DEMO_CE
{
    using CSLibrary;
    using CSLibrary.Constants;
    using CSLibrary.Structures;
    using CSLibrary.Text;

    using CSLibrary.HotKeys;


    public partial class TagInventoryForm : Form
    {
        #region Private Member

        private int m_totaltag = 0;

        private bool m_stop = false;

        private bool m_selected = false;

        private TagDataModel m_tagTable = new TagDataModel(SlowFlags.INDEX | SlowFlags.PC | SlowFlags.EPC);

        private DateTime timeStarted = DateTime.MinValue;

        enum ButtonState : int
        {
            Start = 0,
            Stop,
            Select,
            Unknow
        }

        #endregion

        #region Form
        public TagInventoryForm()
        {
            InitializeComponent();
        }

        public TagInventoryForm(bool selectable)
        {
            InitializeComponent();

            m_selected = selectable;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            //Third Step (Attach to Form)
            AttachCallback(true);
            nTable.BindModel(m_tagTable);
            nTable.SetColumnWidth(0, 50);
            nTable.SetColumnWidth(1, 50);
         }


        private void SearchForm_Closing(object sender, CancelEventArgs e)
        {
            //Fourth Step (Dettach from Form and Stop)
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

                Program.ReaderCE.OnStateChanged +=new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderCE_StateChangedEvent);
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
                m_totaltag++;

                UpdateRecords(e.info);

                if (Program.appSetting.Cfg_blocking_mode)
                {
                    Application.DoEvents();
                }
            }
        }

        void ReaderCE_StateChangedEvent(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            switch (e.state)
            {
                case RFState.IDLE:
                    EnableUpdate(false);
                    if (!m_stop)
                    {
                        m_totaltag = 0;
                        //Device.MelodyPlay(RingTone.T1, BuzzerVolume.HIGH);
                        startMenu1.ToggleStartButton();
                        EnableForm(true);
                        RefreshListView();
                    }
                    else
                    {
                        CloseForm();
                    }
                    break;
                case RFState.BUSY:
                    EnableUpdate(true);
                    //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);
                    startMenu1.ToggleStartButton();
                    timeStarted = CSLibrary.Tools.DateTimeEx.Now;
                    break;
                case RFState.ABORT:
                    EnableForm(false); ;
                    break;
            }
        }

        #endregion

        #region UI Update

        public class LvEpcSorter : IComparer<TagCallbackInfo>
        {
            public int Compare(TagCallbackInfo obj1, TagCallbackInfo obj2)
            {
                return obj1.epc.ToString().CompareTo(obj2.epc.ToString());
            }
        }
        public class LvCntSorter : IComparer<TagCallbackInfo>
        {
            public int Compare(TagCallbackInfo obj1, TagCallbackInfo obj2)
            {
                if (((TagCallbackInfo)obj2).count > ((TagCallbackInfo)obj1).count)
                {
                    return 1;
                }
                else if (((TagCallbackInfo)obj2).count < ((TagCallbackInfo)obj1).count)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public class LvRssiSorter : IComparer<TagCallbackInfo>
        {
            public int Compare(TagCallbackInfo obj1, TagCallbackInfo obj2)
            {
                if (((TagCallbackInfo)obj2).rssi > ((TagCallbackInfo)obj1).rssi)
                {
                    return 1;
                }
                else if (((TagCallbackInfo)obj2).rssi < ((TagCallbackInfo)obj1).rssi)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public class LvIndexSorter : IComparer<TagCallbackInfo>
        {
            public int Compare(TagCallbackInfo obj1, TagCallbackInfo obj2)
            {
                if (((TagCallbackInfo)obj2).index > ((TagCallbackInfo)obj1).index)
                {
                    return 1;
                }
                else if (((TagCallbackInfo)obj2).index < ((TagCallbackInfo)obj1).index)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        private void UpdateRecords(object data)
        {
            TagCallbackInfo record = (TagCallbackInfo)data;
            if (record != null)
            {
                m_tagTable.Items.Add(record);
                startMenu1.UpdateTagCount(m_totaltag);
                startMenu1.UpdateTimeElapsed(((TimeSpan)CSLibrary.Tools.DateTimeEx.Now.Subtract(timeStarted)).TotalSeconds);
                //Device.BuzzerOn(2000, 40, BuzzerVolume.HIGH);
            }
        }
        private void EnableUpdate(bool en)
        {
            tmr_readrate.Enabled = en;
        }
        private void CloseForm()
        {
            this.Close();
        }
        private void EnableForm(bool en)
        {
            this.Enabled = en;
        }
        private void RefreshListView()
        {
            m_tagTable.RefreshItemList();
        }
        private void nTable_RowChanged(int rowIndex)
        {
            if (m_selected)
            {
                startMenu1.UpdateStartBtn(true);
            }
        }

        private void tmr_readrate_Tick(object sender, EventArgs e)
        {
            RefreshListView();
        }
        #endregion

        #region Button Handle

        public void Start()
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
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

        private void Save()
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(save.FileName, FileMode.OpenOrCreate))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        if (m_tagTable.Items.Count > 0)
                        {
                            DateTime date = DateTime.Now;
                            foreach (TagCallbackInfo data in m_tagTable.Items)
                                sw.WriteLine(string.Format("{0},{1},{2},{3}", date, data.pc.ToString(), data.epc.ToString(), data.rssi));
                        }
                        sw.Flush();
                    }
                }
            }
        }
        void startMenu1_OnButtonClick(ButtonClickType type)
        {
            switch (type)
            {
                case ButtonClickType.Clear:
                    m_tagTable.Clear();
                    break;
                case ButtonClickType.Exit:
                    this.Close();
                    break;
                case ButtonClickType.Hide:
                case ButtonClickType.Unhide:
                    //Resize list
                    nTable.Height = 240 - startMenu1.Height;
                    break;
                case ButtonClickType.Save:
                    Save();
                    break;
                case ButtonClickType.Start:
                    Start();
                    break;
                case ButtonClickType.Stop:
                    Stop();
                    break;
                case ButtonClickType.Sorting:
                    switch (startMenu1.SortingMethod)
                    {
                        case Sorting.EPC_Ascending:
                            m_tagTable.Sort(SortIndex.EPC, true);
                            break;
                        case Sorting.EPC_Decending:
                            m_tagTable.Sort(SortIndex.EPC, false);
                            break;
                    }
                    nTable.BindModel(m_tagTable);
                    break;
            }
        }

        #endregion

    }
}