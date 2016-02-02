using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using CSLibrary.Constants;
using CSLibrary.Structures;
using CSLibrary;

namespace CS203_MultipleReader
{
    public partial class ReadTagForm : Form
    {
        private bool m_stop = false;
        private int m_totaltag = 0;
        private ThreadSafeList m_epclistItems = new ThreadSafeList();
        private TagDataModel m_tagList = new TagDataModel(SlowFlags.ALL);
        public ReadTagForm()
        {
            InitializeComponent();
        }

        private void ReadTagForm_Load(object sender, EventArgs e)
        {
            CSLibrary.Windows.UI.SplashScreen.Stop();
            //this.Text = Program.appSetting.AppTitle;
            AttachCallback(true);
            nTable1.BindModel(m_tagList);
            nTable1.SetColumnWidth(0, 50);
            nTable1.SetColumnWidth(2, 100);
            nTable1.SetColumnWidth(3, 50);
            nTable1.SetColumnWidth(4, 50);
        }

        private void ReadTagForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fourth Step (Dettach from Form and Stop)
            foreach (HighLevelInterface reader in Program.ReaderList)
            {
                if (reader.State != RFState.IDLE)
                {
                    m_stop = e.Cancel = true;
                    reader.StopOperation(true);
                }
                else
                {
                    reader.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_OnAsyncCallback);
                    reader.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);
                }
            }
        }

        private void AttachCallback(bool en)
        {
            foreach (HighLevelInterface reader in Program.ReaderList)
            {
                if (en)
                {
                    reader.OnStateChanged += new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);
                    reader.OnAsyncCallback += new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_OnAsyncCallback);
                }
                else
                {
                    reader.OnAsyncCallback -= new EventHandler<CSLibrary.Events.OnAsyncCallbackEventArgs>(ReaderXP_OnAsyncCallback);
                    reader.OnStateChanged -= new EventHandler<CSLibrary.Events.OnStateChangedEventArgs>(ReaderXP_OnStateChanged);
                }
            }
        }

        void ReaderXP_OnAsyncCallback(object sender, CSLibrary.Events.OnAsyncCallbackEventArgs e)
        {
            //Using asyn delegate to update UI
            if (e.type == CallbackType.TAG_RANGING)
            {
                m_totaltag++;

                UpdateRecords(e.info);
                //20090219,18:00:44,1000-0000-0000-0000-0000-0688 
                //YYYYMMDD,HH:MM:SS,Tag ID(24byte)

                //Program.tagDataLogSw.WriteLine(string.Format("{0},{1}", DateTime.Now.ToString("yyyymmdd,hh:MM:ss"), BitConverter.ToString(e.info.epc.ToBytes())));
                //SaveTagData(string.Format("{0},{1}", DateTime.Now.ToString("yyyyMMdd,hh:mm:ss"), BitConverter.ToString(e.info.epc.ToBytes())));
            }
        }

        void ReaderXP_OnStateChanged(object sender, CSLibrary.Events.OnStateChangedEventArgs e)
        {
            switch (e.state)
            {
                case RFState.BUSY:
                    btn_startInventory.Enabled = false;
                    btn_stopInventory.Enabled = true;
                    break;
                case RFState.IDLE:
                    bool someReaderReset = false;
                    foreach (HighLevelInterface reader in Program.ReaderList)
                    {
                        if (reader.LastResultCode == Result.NETWORK_RESET)
                        {
                            someReaderReset = true;
                            new Thread(new ThreadStart(Reset)).Start();
                        }
                    }
                    if (someReaderReset)
                    {
                        btn_startInventory.Enabled = false;
                        btn_stopInventory.Enabled = true;
                    }
                    else
                    {
                        btn_startInventory.Enabled = true;
                        btn_stopInventory.Enabled = false;
                    }
                    break;
                case RFState.RESET:
                    break;
                case RFState.ABORT:
                    break;
            }
        }

        private void UpdateRecords(object data)
        {
            TagCallbackInfo record = (TagCallbackInfo)data;
            if (record != null)
            {
                m_tagList.Insert(record);
            }
        }

        private void btn_stopInventory_Click(object sender, EventArgs e)
        {
            foreach (HighLevelInterface reader in Program.ReaderList)
            {
                if (reader.State == RFState.BUSY)
                {
                    reader.StopOperation(true);
                }
            }
        }

        private void btn_startInventory_Click(object sender, EventArgs e)
        {
            foreach (HighLevelInterface reader in Program.ReaderList)
            {
                if (reader.State == RFState.IDLE)
                {
                    reader.SetOperationMode(RadioOperationMode.CONTINUOUS);
                    reader.Options.TagRanging.flags = SelectFlags.ZERO;
                    reader.StartOperation(Operation.TAG_RANGING, false);
                }
            }
        }

        /*private void SaveTagData(string data)
        {
            try
            {
                String dataPath = Path.Combine(Program.appSetting.DataPath, string.Format("{0}{1}.txt", Program.appSetting.DeviceName, DateTime.Now.ToString("yyMM")));
                if (File.Exists(dataPath))
                {
                    using (StreamWriter sw = File.AppendText(dataPath))
                    {
                        sw.WriteLine(data);
                        sw.Flush();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(dataPath))
                    {
                        sw.WriteLine(data);
                        sw.Flush();
                    }
                }
            }
            catch
            {

            }

        }*/

        private void Reset()
        {
            Result rc = Result.OK;
            WaitingDialog.Show();
            {
                EnableForm(false);
                Application.DoEvents();
                foreach (HighLevelInterface reader in Program.ReaderList)
                {
                    //Reset Reader first, it will shutdown current reader and restart reader
                    //It will also reconfig back previous operation
                    if (reader.LastResultCode == Result.NETWORK_RESET)
                    {
                        if ((rc = reader.Reconnect(10)) == Result.OK)
                        {
                            //Start inventory
                            reader.StartOperation(Operation.TAG_RANGING, false);
                        }
                        else
                        {
                            ShowMsg(String.Format("ResetReader fail rc = {0}", rc));
                        }
                    }
                }
                EnableForm(true);
            }
            WaitingDialog.Stop();
        }


        private delegate void EnableFormDel(bool enable);
        private void EnableForm(bool enable)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EnableFormDel(EnableForm), new object[] { enable });
                return;
            }
            this.Enabled = enable;
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
    }
}