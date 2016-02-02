using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO_CE
{
    public partial class ReaderInfomation : Form
    {
        public ReaderInfomation()
        {
            InitializeComponent();
        }

        private void ReaderInfomation_Load(object sender, EventArgs e)
        {
            if (Program.ReaderCE.State == CSLibrary.Constants.RFState.IDLE)
            {
                tb_cslVer.Text = Program.cslibraryVersion.ToString();
                tb_dirVer.Text = Program.driverVersion.ToString();
                tb_fwVer.Text = Program.firmwareVersion.ToString();
                tb_libver.Text = Program.rfidLibraryVersion.ToString();
                tb_deviceName.Text = Program.deviceName;
                tb_sn.Text = Program.serialNumber;
                tb_pcbaCode.Text = Program.pcbAssemblyCode;
                tb_manufactureDate.Text = Program.manufactureDate;
                tb_hwVer.Text = Program.hardwareVersion.ToString();
            }
        }

        private void ReaderInfomation_Closing(object sender, CancelEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}