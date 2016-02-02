using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CS203_Example_Code
{


    public partial class SelfTestForm : Form
    {
        enum Bank
        {
            ACC,
            KILL,
            PC,
            EPC,
            TID,
            USER
        }

        private enum Status
        {
            NOT_DONE,
            STARTING,
            FINISHED
        }

        private string[] statusArray = new string[] { "Not Done", "Starting", "Finished" };

        private bool bThreadStarted = false;

        private bool bTestAcc = true;
        private bool bTestKill = true;
        private bool bTestPC = true;
        private bool bTestEPC = true;
        private bool bTestTID = true;
        private bool bTestUSER = true;


        public SelfTestForm()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            StartThread();
        }

        private void StartThread()
        {
            if (!bThreadStarted)
            {
                Thread run = new Thread(new ThreadStart(ThreadProc));
                run.Start();
                run.Join(100);
            }
        }

        private void ThreadProc()
        {
            EnableButton(false);
            bThreadStarted = true;

            UpdateStatus(Bank.ACC, Status.NOT_DONE);
            UpdateStatus(Bank.EPC, Status.NOT_DONE);
            UpdateStatus(Bank.KILL, Status.NOT_DONE);
            UpdateStatus(Bank.PC, Status.NOT_DONE);
            UpdateStatus(Bank.TID, Status.NOT_DONE);
            UpdateStatus(Bank.USER, Status.NOT_DONE);

            if (bTestTID)
            {
                UpdateStatus(Bank.TID, Status.STARTING);
                Program.TestReadTid();
                UpdateStatus(Bank.TID, Status.FINISHED);
            }

            if (bTestAcc)
            {
                UpdateStatus(Bank.ACC, Status.STARTING);
                Program.TestWriteAcc();
                UpdateStatus(Bank.ACC, Status.FINISHED);
            }

            if (bTestKill)
            {
                UpdateStatus(Bank.KILL, Status.STARTING);
                Program.TestWriteKill();
                UpdateStatus(Bank.KILL, Status.FINISHED);
            }

            if (bTestUSER)
            {
                UpdateStatus(Bank.USER, Status.STARTING);
                Program.TestWriteUser(1);
                UpdateStatus(Bank.USER, Status.FINISHED);
            }

            if (bTestPC)
            {
                UpdateStatus(Bank.PC, Status.STARTING);
                Program.TestWritePC();
                UpdateStatus(Bank.PC, Status.FINISHED);
            }

            if (bTestEPC)
            {
                UpdateStatus(Bank.EPC, Status.STARTING);
                Program.TestWriteEPC();
                UpdateStatus(Bank.EPC, Status.FINISHED);
            }
            bThreadStarted = false;
            EnableButton(true);
        }

        private delegate void EnableButtonDel(bool en);

        private void EnableButton(bool en)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableButtonDel(EnableButton), new object[] { en });
                return;
            }
            btn_start.Enabled = en;
            cb_acc.Enabled = cb_epc.Enabled = cb_kill.Enabled = cb_pc.Enabled = cb_tid.Enabled = cb_user.Enabled = en;
        }

        private delegate void UpdateStatusDel(Bank bank, Status status);
        private void UpdateStatus(Bank bank, Status status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDel(UpdateStatus), new object[] { bank, status });
                return;
            }
            switch (bank)
            {
                case Bank.ACC:
                    switch(status)
                    {
                        case Status.FINISHED:
                            lb_status_acc.ForeColor = Color.Green;
                            break;
                        case Status.NOT_DONE:
                            lb_status_acc.ForeColor = Color.Red;
                            break;
                        case Status.STARTING:
                            lb_status_acc.ForeColor = Color.Blue;
                            break;
                    }
                    lb_status_acc.Text = statusArray[(int)status];
                    break;
                case Bank.EPC:
                    switch (status)
                    {
                        case Status.FINISHED:
                            lb_status_epc.ForeColor = Color.Green;
                            break;
                        case Status.NOT_DONE:
                            lb_status_epc.ForeColor = Color.Red;
                            break;
                        case Status.STARTING:
                            lb_status_epc.ForeColor = Color.Blue;
                            break;
                    }
                    lb_status_epc.Text = statusArray[(int)status];
                    break;
                case Bank.KILL:
                    switch (status)
                    {
                        case Status.FINISHED:
                            lb_status_kill.ForeColor = Color.Green;
                            break;
                        case Status.NOT_DONE:
                            lb_status_kill.ForeColor = Color.Red;
                            break;
                        case Status.STARTING:
                            lb_status_kill.ForeColor = Color.Blue;
                            break;
                    }
                    lb_status_kill.Text = statusArray[(int)status];
                    break;
                case Bank.PC:
                    switch (status)
                    {
                        case Status.FINISHED:
                            lb_status_pc.ForeColor = Color.Green;
                            break;
                        case Status.NOT_DONE:
                            lb_status_pc.ForeColor = Color.Red;
                            break;
                        case Status.STARTING:
                            lb_status_pc.ForeColor = Color.Blue;
                            break;
                    }
                    lb_status_pc.Text = statusArray[(int)status];
                    break;
                case Bank.TID:
                    switch (status)
                    {
                        case Status.FINISHED:
                            lb_status_tid.ForeColor = Color.Green;
                            break;
                        case Status.NOT_DONE:
                            lb_status_tid.ForeColor = Color.Red;
                            break;
                        case Status.STARTING:
                            lb_status_tid.ForeColor = Color.Blue;
                            break;
                    }
                    lb_status_tid.Text = statusArray[(int)status]; 
                    break;
                case Bank.USER:
                    switch (status)
                    {
                        case Status.FINISHED:
                            lb_status_user.ForeColor = Color.Green;
                            break;
                        case Status.NOT_DONE:
                            lb_status_user.ForeColor = Color.Red;
                            break;
                        case Status.STARTING:
                            lb_status_user.ForeColor = Color.Blue;
                            break;
                    }
                    lb_status_user.Text = statusArray[(int)status]; 
                    break;
            }

        }

        private void cb_acc_CheckStateChanged(object sender, EventArgs e)
        {
            bTestAcc = cb_acc.Checked;
        }

        private void cb_kill_CheckStateChanged(object sender, EventArgs e)
        {
            bTestKill = cb_kill.Checked;
        }

        private void cb_pc_CheckStateChanged(object sender, EventArgs e)
        {
            bTestPC = cb_pc.Checked;
        }

        private void cb_epc_CheckStateChanged(object sender, EventArgs e)
        {
            bTestEPC = cb_epc.Checked;
        }

        private void cb_user_CheckStateChanged(object sender, EventArgs e)
        {
            bTestUSER = cb_user.Checked;
        }

        private void cb_tid_CheckStateChanged(object sender, EventArgs e)
        {
            bTestTID = cb_tid.Checked;
        }

    }
}