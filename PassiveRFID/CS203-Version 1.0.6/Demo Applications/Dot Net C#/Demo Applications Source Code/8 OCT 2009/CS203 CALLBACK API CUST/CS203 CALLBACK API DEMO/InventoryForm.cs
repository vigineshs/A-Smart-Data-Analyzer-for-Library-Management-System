using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Net;

namespace CS203DEMO
{
    using rfid.Constants;
    using rfid.Structures;

    using Reader;
    using Reader.Constants;
    using Reader.Structures;
    using Reader.Utility;

    public partial class InventoryForm : Form
    {
        #region Private Member
        private SQLMethod sqlMethod = null;

        private Thread reset;
        private long totaltags = 0;
        private long totalcrc = 0;
        private Stopwatch watchrate = new Stopwatch();
        private object MyLock = new object();
        private bool selectMode = false;
        public string EPC = "";

        private bool SaveSQL = false;

        public enum ButtonState : int
        {
            Start = 0,
            Stop,
            Select,
            Save,
            Clear,
            Exit,
            ALL,
            Unknow
        }

        private Custom.Control.SortColumnHeader m_colhdrIndex;
        private Custom.Control.SortColumnHeader m_colhdrPc;
        private Custom.Control.SortColumnHeader m_colhdrEpc;
        private Custom.Control.SortColumnHeader m_colhdrRssi;
        private Custom.Control.SortColumnHeader m_colhdrCount;
        private Custom.Control.SortListView m_sortListView;

        private List<Reader.Structures.InventoryDataStruct> InventoryListItems = new List<Reader.Structures.InventoryDataStruct>();

        private List<Reader.Structures.InventoryDataStruct> lock_InvItems
        {
          get { lock (MyLock) { return InventoryListItems;} }
           
            set { lock (MyLock) { InventoryListItems = value; } }
            
        }

        #endregion

        #region Public Member
        public bool SelectMode
        {
            get { return selectMode; }
        }

        public class OnButtonClickEventArgs : EventArgs
        {
            private ButtonState state = ButtonState.Unknow;
            private bool enable = false;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="Stat">Input TagAccess Data</param>
            public OnButtonClickEventArgs(ButtonState Stat, bool Enable)
            {
                state = Stat;
                enable = Enable;
            }
            /// <summary>
            /// State
            /// </summary>
            public ButtonState State
            {
                get { return state; }
                set { state = value; }
            }
            public bool Enable
            {
                get { return enable; }
            }
        }
        public event EventHandler<OnButtonClickEventArgs> OnButtonEnable;

        #endregion

        #region Form
        public InventoryForm(bool SelectMode)
        {
            InitializeComponent();
            InitListView();
            selectMode = SelectMode;
            try
            {
                sqlMethod = new SQLMethod();
            }
            catch
            {
                MessageBox.Show("SQL start error");
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            //Show MAC and IP
            Text = String.Format("IP = {0}, MAC = {1}", Program.IP, Program.MAC);

            //Third Step (Attach to Form)
            AttachCallback(true);

            ControlPanelForm.LaunchControlPanel(this);

        }


        private void InventoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fourth Step (Dettach from Form and Stop)
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

        #region Event Callback
        void ReaderCE_MyRunningStateEvent(object sender, Reader.Events.ReaderOperationModeEventArgs e)
        {
            switch (e.State)
            {
                case ReaderOperationMode.Idle:
                    watchrate.Stop();
                    EnableButton(ButtonState.Start, true);
                    EnableButton(ButtonState.Stop, false);
                    EnableTimer(false);
                    //Check whether fail
                    if (Program.ReaderCE.LastResultCode == Result.NET_RESET)
                    {
                        //Use other thread to create progress
                        reset = new Thread(new ThreadStart(Reset));
                        reset.Start();
                    }
                    break;
                case ReaderOperationMode.Running:
                    watchrate.Reset();
                    watchrate.Start();
                    totaltags = 0;
                    totalcrc = 0;
                    EnableButton(ButtonState.Start, false);
                    EnableButton(ButtonState.Stop, true);
                    EnableTimer(true);
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

        private delegate void ResetDeleg();
        private void Reset()
        {
            Result rc = Result.OK;
            MessageForm.LaunchForm(this);
            {
                EnableButton(ButtonState.ALL, false);
                Application.DoEvents();
                //Reset Reader first, it will shutdown current reader and restart reader
                //It will also reconfig back previous operation
                DateTime now = DateTime.Now;

                while(true)
                {

                    if ((rc = Program.ReaderCE.ResetReader(Operation.Inventory)) == Result.OK)
                    {
                        //Got error and stop here
                        //ShowMsg(String.Format("ResetReader fail rc = {0}", rc));
                        break;
                    }
                    if (Program.hours != 0)
                    {
                        TimeSpan time = now.Subtract(DateTime.Now);
                        if (Math.Abs(time.TotalMinutes) > Program.hours * 60)
                            break;
                    }
                }
                if (rc == Result.OK)
                {
                    //Start inventory
                    Program.ReaderCE.Start();
                }
                else
                {
                    ShowMsg(String.Format("ResetReader fail rc = {0}", rc));
                }
                EnableButton(ButtonState.ALL, true);
            }
            MessageForm.msgform.CloseForm();
        }
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

        public void AbortReset()
        {
            if (reset != null && reset.IsAlive)
            {
                reset.Abort();
            }
        }

        void ReaderCE_MyInventoryEvent(object sender, Reader.Events.InventoryEventArgs e)
        {
            // Do your work here
            // UI refresh and data processing on other Thread
            // Notes :  blocking here will cause problem
            //          Please use asyn call or separate thread to refresh UI
            Interlocked.Increment(ref totaltags);

            InventoryDataStruct data = e.InventoryInformation;
            UpdateInvUI(data);
        }

        private delegate void UpdateInvUIDeleg(InventoryDataStruct InventoryInformation);
        private void UpdateInvUI(InventoryDataStruct InventoryInformation)
        {
            Reader.Structures.InventoryDataStruct FoundData = lock_InvItems.Find(delegate(Reader.Structures.InventoryDataStruct iepc) { return iepc.EPC.ToString() == InventoryInformation.EPC.ToString(); });
            {
                if (FoundData != null && FoundData.Index > -1)
                {
                    //found a record
                    lock_InvItems[(int)FoundData.Index].Count++;
                    lock_InvItems[(int)FoundData.Index].RSSI = InventoryInformation.RSSI;
                    //UI update in separate thread
                    UpdateListView(
                        lock_InvItems[(int)FoundData.Index].Index.ToString(),
                        lock_InvItems[(int)FoundData.Index].RSSI.ToString("F1"), 
                        lock_InvItems[(int)FoundData.Index].Count.ToString());
                    Save();
                }
                else
                {
                    Reader.Utility.Sound.Beep(2000, 10);
                    //record no exist
                    //add a record to item list
                    InventoryInformation.Index = lock_InvItems.Count;
                    lock_InvItems.Add(InventoryInformation);
                    //UI update in separate thread
                    LVAddItem(
                        InventoryInformation.Index.ToString(),
                        InventoryInformation.PC.ToString(),
                        InventoryInformation.EPC.ToString(),
                        InventoryInformation.RSSI.ToString(),
                        InventoryInformation.Count.ToString());
                   // Save();
                    
                    if (SaveSQL)
                    {
                        sqlMethod.AddData(InventoryInformation.EPC.ToString());
                    }
                }
            }
        }

        private void AttachCallback(bool en)
        {
            if (en)
            {
                Program.ReaderCE.MyInventoryEvent += new EventHandler<Reader.Events.InventoryEventArgs>(ReaderCE_MyInventoryEvent);
                Program.ReaderCE.MyRunningStateEvent += new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
                Program.ReaderCE.MyErrorEvent += new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
            }
            else
            {
                Program.ReaderCE.MyInventoryEvent -= new EventHandler<Reader.Events.InventoryEventArgs>(ReaderCE_MyInventoryEvent);
                Program.ReaderCE.MyRunningStateEvent -= new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
                Program.ReaderCE.MyErrorEvent -= new EventHandler<Reader.Events.ErrorEventArgs>(ReaderCE_MyErrorEvent);
            }
        }

        void ReaderCE_MyErrorEvent(object sender, Reader.Events.ErrorEventArgs e)
        {
            Interlocked.Increment(ref totalcrc);
        }

       

        #endregion

        #region Delegate

        private delegate void LVAddItemDeleg(string index, string pc, string epc, string rssi, string count);
        private void LVAddItem(string index, string pc, string epc, string rssi, string count)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new LVAddItemDeleg(LVAddItem), new object[] { index, pc, epc, rssi, count });
                return;
            }
            lock (MyLock)
            {
                ListViewItem item = new ListViewItem(index);
                item.Font = new Font("Courier New", 12, FontStyle.Regular);
                item.SubItems.Add(pc);
                item.SubItems.Add(epc);
                item.SubItems.Add(rssi);
                item.SubItems.Add(count);
                m_sortListView.Items.Add(item);
            }
        }

        private delegate void UpdateListViewDeleg(string index, string rssi, string count);
        private void UpdateListView(string index, string rssi, string count)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateListViewDeleg(UpdateListView), new object[] { index, rssi, count });
                return;
            }
            lock (MyLock)
            {
                for (int i = 0; i < m_sortListView.Items.Count; i++)
                {
                    if (m_sortListView.Items[i].SubItems[0].Text == index)
                    {
                        m_sortListView.Items[i].SubItems[3].Text = rssi;
                        m_sortListView.Items[i].SubItems[4].Text = count;
                        break;
                    }
                }
            }
        }

        private delegate void EnableTimerDeleg(bool en);
        private void EnableTimer(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableTimerDeleg(EnableTimer), new object[] { en });
                return;
            }
            tmr_updatelist.Enabled = en;
        }

        #endregion

        #region ListView Handle
        private void InitListView()
        {
            this.m_sortListView = new Custom.Control.SortListView();
            // 
            // m_sortListView
            // 
            this.m_sortListView.FullRowSelect = true;
            this.m_sortListView.GridLines = true;
            this.m_sortListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.m_sortListView.Location = new System.Drawing.Point(3, 3);
            this.m_sortListView.Name = "m_sortListView";
            this.m_sortListView.Size = new System.Drawing.Size(380, 400);
            this.m_sortListView.TabIndex = 0;
            this.m_sortListView.UseCompatibleStateImageBehavior = false;
            this.m_sortListView.View = System.Windows.Forms.View.Details;
            this.m_sortListView.Font = new Font(FontFamily.GenericSerif, 12);
            this.m_sortListView.SelectedIndexChanged += new System.EventHandler(this.m_sortListView_SelectedIndexChanged);
            m_colhdrIndex = new Custom.Control.SortColumnHeader();
            m_colhdrPc = new Custom.Control.SortColumnHeader();
            m_colhdrEpc = new Custom.Control.SortColumnHeader();
            m_colhdrRssi = new Custom.Control.SortColumnHeader();
            m_colhdrCount = new Custom.Control.SortColumnHeader();
            m_sortListView.Columns.AddRange(new ColumnHeader[] { m_colhdrIndex, m_colhdrPc, m_colhdrEpc, m_colhdrRssi, m_colhdrCount });
            m_colhdrIndex.Text = "Index";
            m_colhdrIndex.Width = 80;
            m_colhdrPc.Text = "PC";
            m_colhdrPc.Width = 80;
            m_colhdrEpc.Text = "EPC";
            m_colhdrEpc.Width = 260;
            m_colhdrRssi.Text = "RSSI";
            m_colhdrRssi.Width = 80;
            m_colhdrCount.Text = "Count";
            m_colhdrCount.Width = 100;
            m_sortListView.SortColumn = 0;
            //Controls.Add(m_sortListView);
            m_sortListView.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(m_sortListView);
            // Assign specific comparers to each column header.
            m_colhdrIndex.ColumnHeaderSorter = new Custom.Control.ComparerStringAsInt();
            m_colhdrPc.ColumnHeaderSorter = new Custom.Control.ComparerString();
            m_colhdrEpc.ColumnHeaderSorter = new Custom.Control.ComparerString();
            m_colhdrRssi.ColumnHeaderSorter = new Custom.Control.ComparerStringAsDouble();
            m_colhdrCount.ColumnHeaderSorter = new Custom.Control.ComparerStringAsInt();
            this.m_sortListView.Sorting = Custom.Control.SortOrder.Ascending;
        }

        private void m_sortListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!selectMode)
                return;
            if (m_sortListView.SelectedIndices != null && m_sortListView.SelectedIndices.Count > 0 && m_sortListView.SelectedIndices[0] >= 0)
            {
                EnableButton(ButtonState.Select, true);
            }
            else
            {
                EnableButton(ButtonState.Select, false);
                if (Program.ReaderCE.MyState == ReaderOperationMode.Running)
                {
                    EnableButton(ButtonState.Start, false);
                    EnableButton(ButtonState.Stop, true);
                }
                else if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
                {
                    EnableButton(ButtonState.Start, true);
                    EnableButton(ButtonState.Stop, false);
                }
            }
        }
        #endregion

        #region Button Handle
        
        public void Start()
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                //Do Setup on SettingForm
                Program.ReaderCE.RdrOpParms.RunBasicSearchParms.OperationMode = RadioOperationMode.CONTINUOUS;
                Program.ReaderCE.RdrOpParms.Operation = Reader.Constants.Operation.Inventory;
                Program.ReaderCE.RunCycle = -1; //set it to -1, otherwise it will stop inventory after some error, eg, network broke and reconnect
                Program.ReaderCE.Setup(Operation.Inventory);
                Program.ReaderCE.Start();
                WebClient client = new WebClient();
                ShowMsg(String.Format("hello out"));

                try
                {
                    ShowMsg(String.Format("hello"));

                    foreach (InventoryDataStruct data in InventoryListItems)
                    {
                        //creating namevalue collections for the post paramters
                        
                        ShowMsg(String.Format(data.Count.ToString()));
                        
                        int i = Int32.Parse(data.Count.ToString());
                       
                        if (i < 10)
                        {
                            ShowMsg(String.Format("hello"));

                            String response = client.DownloadString("http://localhost:8080/librarymgmt/Attendance?btag=" + data.EPC.ToString());
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                    
           
            }
              
            
        }
        public void StartOnce()
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                //Do Setup on SettingForm
                Program.ReaderCE.RdrOpParms.RunBasicSearchParms.OperationMode = RadioOperationMode.NONCONTINUOUS;
                Program.ReaderCE.RdrOpParms.Operation = Reader.Constants.Operation.Inventory;
                Program.ReaderCE.RunCycle = 0; //set it to -1, otherwise it will stop inventory after some error, eg, network broke and reconnect
                Program.ReaderCE.Setup(Operation.Inventory);
                Program.ReaderCE.Start();
            }
        }

        public void Stop()
        {
            if (Program.ReaderCE.MyState == ReaderOperationMode.Running)
            {
                Program.ReaderCE.Stop();
            }
        }

        public void Clear()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(Clear));
                return;
            }
            InventoryListItems.Clear();
            m_sortListView.Items.Clear();
        }

        public void SelectTag()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(SelectTag));
                return;
            }
            if (selectMode && m_sortListView.SelectedIndices.Count > 0)
            {
                EPC = m_sortListView.Items[m_sortListView.SelectedIndices[0]].SubItems[2].Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(CloseForm));
                return;
            }
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void Save()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(Save));
                return;
            }
            if (InventoryListItems.Count == 0)
                return;

            WebClient client = new WebClient();
            
            try
            {
                
                foreach (InventoryDataStruct data in InventoryListItems)
                {
                    //creating namevalue collections for the post paramters
                    //ShowMsg(String.Format(data.Count.ToString()));
                    int i = Int32.Parse(data.Count.ToString());

                    

                    if (i == 2)
                    {
                        String response = client.DownloadString("http://localhost:8080/librarymgmt/Attendance?btag=" + data.EPC.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Save2SQL()
        {
            if (!sqlMethod.Prepare())
            {
                MessageBox.Show("Connect to Server error! Please check connection.");
            }
            else
            {
                SaveSQL = true;
            }
        }

        private delegate void EnableButtonDeleg(ButtonState state, bool en);
        private void EnableButton(ButtonState state, bool en)
        {
            RaiseEvent<OnButtonClickEventArgs>(OnButtonEnable, this, new OnButtonClickEventArgs(state, en));
        }


        #endregion

        #region Timer
        private void tmr_updatelist_Tick(object sender, EventArgs e)
        {
            tsl_uid.Text = "Tag read = " + lock_InvItems.Count;
          //  tsl_rate.Text = string.Format("Rate = {0:F1} Tag/s", totaltags / watchrate.Elapsed.TotalSeconds);

            tsl_crc.Text = string.Format("CRC = {0:F1} Tag/s", totalcrc / watchrate.Elapsed.TotalSeconds);
            if (watchrate.Elapsed.TotalSeconds > 10)
            {
                watchrate.Reset();
                watchrate.Start();
                Interlocked.Exchange(ref totaltags, 0);
                Interlocked.Exchange(ref totalcrc, 0);
            }
        }
        #endregion

        #region Protected
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void RaiseEvent<T>(EventHandler<T> eventHandler, object sender, T e)
            where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ControlPanelForm.CloseControlPanel();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            ControlPanelForm.SetTopMost(true);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            ControlPanelForm.SetTopMost(false);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            ControlPanelForm.SetResize(new Point(this.Location.X+ this.Width, this.Location.Y), this.Height);
        }

        public override Size MaximumSize
        {
            get
            {
                if (ControlPanelForm._controlPanel != null)
                {
                    Rectangle rc = Screen.GetWorkingArea(this.DesktopBounds);
                    return new Size(rc.Width - ControlPanelForm._controlPanel.Width, rc.Height);
                }
                else
                    return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
            }
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            ControlPanelForm.SetResize(new Point(this.Location.X + this.Width, this.Location.Y), this.Height);
        }
        #endregion

        
    }
}