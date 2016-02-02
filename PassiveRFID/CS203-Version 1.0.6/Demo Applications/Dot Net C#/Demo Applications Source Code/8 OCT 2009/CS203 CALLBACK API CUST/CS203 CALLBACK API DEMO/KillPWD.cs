using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Reader.Utility;

namespace CS203DEMO
{
    using rfid.Structures;
    using rfid.Constants;
    using Reader;
    using Reader.Constants;
    using Reader.Structures;
    //using Reader.Device;

    public partial class KillPWD : Form
    {
        private uint accpwd = 0;
        private uint killpwd = 0;
        public string TargetEPC = "";
        public uint KillPassword
        {
            get { return killpwd; }
        }

        public uint AccPassword
        {
            get { return accpwd; }
            set { accpwd = value; }
        }


        #region Form
        public KillPWD()
        {
            InitializeComponent();
        }
        private void KillPWD_Load(object sender, EventArgs e)
        {
            AttachCallback(true);
        }

        private void KillPWD_Closing(object sender, CancelEventArgs e)
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
        private void btn_ok_Click(object sender, EventArgs e)
        {
            killpwd = uint.Parse(tb_killpwd.Text, System.Globalization.NumberStyles.HexNumber);
            if (Program.ReaderCE.MyState == ReaderOperationMode.Idle)
            {
                //Program.ReaderCE.RdrOpParms.RunBasicKillParms.Flags = ReaderFlag.SELECT;
                Program.ReaderCE.RdrOpParms.RunBasicKillParms.TargetKillPassword = KillPassword;
                Program.ReaderCE.RdrOpParms.RunBasicKillParms.SelectCriteria = HighLevelInterface.CreateSelectCriteria(32, 96, MemoryBank.EPC, Action.ASLINVA_DSLINVB, Target.SELECTED, false, HexEncoding.GetBytes(TargetEPC));
                Program.ReaderCE.RdrOpParms.RunBasicKillParms.TagGroup = HighLevelInterface.CreateTagGroup(Selected.ON, Session.S0, SessionTarget.A);
                Program.ReaderCE.RdrOpParms.RunBasicKillParms.Singulation = SingulationAlgorithm.FIXEDQ;
                Program.ReaderCE.RdrOpParms.RunBasicKillParms.SingulationParms = HighLevelInterface.CreateFixedQParms(0, 10, 0, 0);
                Program.ReaderCE.RdrOpParms.RunBasicKillParms.Flags = ReaderFlag.SELECT;
                Program.ReaderCE.RdrOpParms.TargetAccessPassword = AccPassword;
                Program.ReaderCE.RdrOpParms.Operation = Operation.Kill;
                Program.ReaderCE.Setup(Operation.Kill);
                Program.ReaderCE.Start();
            }
        }

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
            }
            else
            {
                Program.ReaderCE.MyTagAccessEvent -= new EventHandler<Reader.Events.TagAccessEventArgs>(ReaderCE_MyTagAccessEvent);
                Program.ReaderCE.MyRunningStateEvent -= new EventHandler<Reader.Events.ReaderOperationModeEventArgs>(ReaderCE_MyRunningStateEvent);
            }
        }

        void ReaderCE_MyTagAccessEvent(object sender, Reader.Events.TagAccessEventArgs e)
        {
            ShowMsg(e.TagAccessInformation.resultType.ToString());
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
            lb_result.Text = msg;
        }
        #endregion



    }
}