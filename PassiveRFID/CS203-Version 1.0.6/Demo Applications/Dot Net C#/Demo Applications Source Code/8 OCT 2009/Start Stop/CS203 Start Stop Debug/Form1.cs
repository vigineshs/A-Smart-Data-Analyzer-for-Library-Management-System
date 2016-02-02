using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Reader.Constants;
using Reader.Structures;

namespace CS203_Start_Stop_Debug
{
    public partial class Form1 : Form
    {
        bool close = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_startup_Click(object sender, EventArgs e)
        {
            try
            {
                btn_start.Enabled = false;
                for (int i = 1; i < 1001; i++)
                {
                    lb_stat.Text = "Starting to initialize";
                    Application.DoEvents();
                    rfid.Constants.Result ret = rfid.Constants.Result.OK;
                    ret = Program.ReaderXP.StartupReader(ipTextBox1.IP, 0);
                    

                    ret = Program.ReaderXP.ShutdownReader();
                    if (ret != rfid.Constants.Result.OK)
                    {
                        throw new Exception(ret.ToString());
                    }
                    lb_count.Text = string.Format("Count : {0}/1000", i);
                    if (close)
                        break;
                }
                btn_start.Enabled = true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                btn_start.Enabled = true;
                lb_stat.Text = "Initial fail!!";
            }
            lb_stat.Text = "Initial done!!";
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if(!btn_start.Enabled)
                e.Cancel = true;
            base.OnClosing(e);
        }
        void ReaderXP_MyRunningStateEvent(object sender, Reader.Events.ReaderOperationModeEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void ReaderXP_MyErrorEvent(object sender, Reader.Events.ErrorEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void ReaderXP_MyInventoryEvent(object sender, Reader.Events.InventoryEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}