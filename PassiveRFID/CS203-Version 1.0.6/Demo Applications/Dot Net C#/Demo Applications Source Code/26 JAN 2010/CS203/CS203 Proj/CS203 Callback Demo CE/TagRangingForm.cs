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


    public partial class TagRangingForm : Form
    {
        #region Private Member

        private int m_totaltag = 0;

        private int m_tagRate = 0;

        private bool m_stop = false;

        enum ButtonState : int
        {
            Start = 0,
            Stop,
            Select,
            Unknow
        }

        private ThreadSafeList m_epclistItems = new ThreadSafeList();

        #endregion

        #region Form
        public TagRangingForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            //Third Step (Attach to Form)
            AttachCallback(true);
            nTable.BindModel(new TagDataModel(SlowFlags.INDEX | SlowFlags.EPC | SlowFlags.RSSI));
            nTable.SetColumnWidth(0, 50);
            nTable.SetColumnWidth(2, 50);
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
                Program.ReaderCE.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderCE_TagRangingEvent);
            }
            else
            {
                HotKeys.OnKeyEvent -= new HotKeys.HotKeyEventArgs(HotKeys_OnKeyEvent);

                Program.ReaderCE.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderCE_TagRangingEvent);
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

        void ReaderCE_TagRangingEvent(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            //Using asyn delegate to update UI
            if (e.type == CallbackType.TAG_RANGING)
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
                    //Device.MelodyPlay(RingTone.T2, BuzzerVolume.HIGH);
                    startMenu1.ToggleStartButton();
                    EnableUpdate(true);
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
                m_epclistItems.Insert(record);
            }
        }

        private void RefreshListView()
        {
            nTable.BindModel(new TagDataModel(m_epclistItems.GetSortedList(), SlowFlags.INDEX | SlowFlags.EPC | SlowFlags.RSSI));
        }

        private delegate void EnableUpdateDel(bool en);
        private void EnableUpdate(bool en)
        {
            tmr_readrate.Enabled = en;
        }

        private delegate void CloseFormDeleg();
        private void CloseForm()
        {
            this.Close();
        }
        private delegate void EnableFormDeleg(bool en);
        private void EnableForm(bool en)
        {
            this.Enabled = en;
        }
        private void tmr_readrate_Tick(object sender, EventArgs e)
        {
            m_tagRate = m_totaltag;
            startMenu1.UpdateTagCount(m_epclistItems.Items.Count);
            startMenu1.UpdateTagRate(m_tagRate);
            m_totaltag = 0;
            RefreshListView();
        }

        void startMenu1_OnButtonClick(ButtonClickType type)
        {
            switch (type)
            {
                case ButtonClickType.Clear:
                    m_epclistItems.Items.Clear();
                    nTable.BindModel(new TagDataModel(SlowFlags.INDEX | SlowFlags.EPC | SlowFlags.RSSI));
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
                            m_epclistItems.SortMethod = SortIndex.EPC;
                            m_epclistItems.Ascending = true;
                            //m_epclistItems.Sort();
                            break;
                        case Sorting.EPC_Decending:
                            m_epclistItems.SortMethod = SortIndex.EPC;
                            m_epclistItems.Ascending = false;
                            //m_epclistItems.Sort();
                            break;
                        case Sorting.RSSI_Ascending:
                            m_epclistItems.SortMethod = SortIndex.RSSI;
                            m_epclistItems.Ascending = true;
                            //m_epclistItems.Sort();
                            break;
                        case Sorting.RSSI_Decending:
                            m_epclistItems.SortMethod = SortIndex.RSSI;
                            m_epclistItems.Ascending = false;
                            //m_epclistItems.Sort();
                            break;
                    }
                    nTable.BindModel(new TagDataModel(m_epclistItems.GetSortedList(), SlowFlags.INDEX | SlowFlags.EPC | SlowFlags.RSSI));
                    break;
            }
        }

        #endregion

        #region Button Handle

        public void Start()
        {
            if (Program.ReaderCE.State == RFState.IDLE)
            {
                Program.ReaderCE.SetOperationMode(Program.appSetting.Cfg_continuous_mode ? RadioOperationMode.CONTINUOUS : RadioOperationMode.NONCONTINUOUS);
                Program.ReaderCE.SetTagGroup(Program.appSetting.tagGroup);
                Program.ReaderCE.SetSingulationAlgorithmParms(Program.appSetting.Singulation, Program.appSetting.SingulationAlg);
                Program.ReaderCE.Options.TagRanging.flags = SelectFlags.ZERO;
                Program.ReaderCE.StartOperation(Operation.TAG_RANGING, Program.appSetting.Cfg_blocking_mode);
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
                        if (m_epclistItems.Items.Count > 0)
                        {
                            DateTime date = DateTime.Now;
                            foreach (TagCallbackInfo data in m_epclistItems.Items)
                                sw.WriteLine(string.Format("{0},{1},{2},{3}", date, data.pc.ToString(), data.epc.ToString(), data.rssi));
                        }
                        sw.Flush();
                    }
                }
            }
        }

        #endregion

    }
}