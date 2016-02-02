using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;

using CSLibrary.Net;

namespace CS203_CALLBACK_API_DEMO_CE
{
    public partial class NetFinderForm : Form
    {
        #region Member variable

        private string Info_Search = "Press \"Search\" button to search all CS203 in the same subnet.";
        private string Info_Connect = "Press \"Connect\" or \"Assignment\" or other buttons.";
        private string Info_Select = "Select any CS203 device on the list.";

        private bool m_start = false;

        private NetFinder netfinder = new NetFinder();
        private UpdateProgressForm progressform = null;
        private DeviceFinderList deviceList = new DeviceFinderList();
        public string ConnectIP;

        public string MAC;

        #endregion

        #region Form
        public NetFinderForm()
        {
            InitializeComponent();
        }

        private void NetFinderForm_Load(object sender, EventArgs e)
        {
            progressform = new UpdateProgressForm();
            progressform.Disposed += new EventHandler(progressform_Disposed);

            netfinder.OnSearchCompleted += new EventHandler<DeviceFinderArgs>(netfinder_OnSearchCompleted);
            netfinder.OnAssignCompleted += new EventHandler<ResultArgs>(netfinder_OnAssignCompleted);
            netfinder.OnUpdateCompleted += new EventHandler<UpdateResultArgs>(netfinder_OnUpdateCompleted);
            netfinder.OnUpdatePercent += new EventHandler<UpdatePercentArgs>(netfinder_OnUpdatePercent);

            lb_info.Text = Info_Search;
            lv_device.BindModel(deviceList);
            lv_device.SetColumnWidth(0, 100);
            lv_device.SetColumnWidth(1, 100);
            lv_device.SetColumnWidth(2, 100);
            lv_device.SetColumnWidth(3, 100);

        }

        private void NetFinderForm_Closing(object sender, CancelEventArgs e)
        {
            netfinder.OnSearchCompleted -= new EventHandler<DeviceFinderArgs>(netfinder_OnSearchCompleted);
            netfinder.OnAssignCompleted -= new EventHandler<ResultArgs>(netfinder_OnAssignCompleted);
            netfinder.OnUpdateCompleted -= new EventHandler<UpdateResultArgs>(netfinder_OnUpdateCompleted);
            netfinder.OnUpdatePercent -= new EventHandler<UpdatePercentArgs>(netfinder_OnUpdatePercent);
            netfinder.Stop();
            netfinder.Dispose();
        }

        #endregion

        #region Button Event
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!m_start)
            {
                m_start = true;
                netfinder.SearchDevice();
                btn_start.BackColor = Color.Red;
                btn_start.Text = "Stop";
            }
            else
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }
            btn_connect.Enabled = false;
            btn_assign.Enabled = false;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (m_start)
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }

            if (netfinder.Operation != RecvOperation.IDLE)
            {
                MessageBox.Show("Please stop searching device first.");
                return;
            }
            if (lv_device.CurrentRowIndex >= 0 && lv_device.CurrentRowIndex < deviceList.Items.Count)
            {
                //Get local ip address
                string ip = LocalIPAddress();
   
                //Directly connect to tcp
                byte[] ipb = deviceList.Items[lv_device.CurrentRowIndex].ip.Address;
                byte[] mac = deviceList.Items[lv_device.CurrentRowIndex].mac.Address;

                String[] localIP = ip.Split('.');

                bool sameSubnet = true;
                for (int i = 0; i < 3; i++)
                {
                    if (ipb[i] != byte.Parse(localIP[i]))
                    {
                        sameSubnet = false;
                        break;
                    }
                }
                if (sameSubnet)
                {
                    ConnectIP = deviceList.Items[lv_device.CurrentRowIndex].ip.ToString();
                    MAC = deviceList.Items[lv_device.CurrentRowIndex].mac.ToString();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (MessageBox.Show("Warning! You are going to connect a device in other subnet.", "Contine?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        ConnectIP = deviceList.Items[lv_device.CurrentRowIndex].ip.ToString();
                        MAC = deviceList.Items[lv_device.CurrentRowIndex].mac.ToString();
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {
            if (m_start)
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }

            if (netfinder.Operation != RecvOperation.IDLE)
            {
                MessageBox.Show("Please stop searching device first.");
                return;
            }

            using (AssignForm assign = new AssignForm())
            {
                //assign.CS203IP = lv_device.Items[lv_device.SelectedIndices[0]].SubItems[2].Text;
                assign.CS203IP = deviceList.Items[lv_device.CurrentRowIndex].ip.ToString();
                assign.DeviceName = deviceList.Items[lv_device.CurrentRowIndex].device_name;
                assign.Timeout = deviceList.Items[lv_device.CurrentRowIndex].tcptimeout;
                assign.DHCP = deviceList.Items[lv_device.CurrentRowIndex].DHCP;
                if (assign.ShowDialog() == DialogResult.OK)
                {
                    string[] ip = assign.CS203IP.Split(new char[] { '.' });
                    if (ip != null && ip.Length == 4)
                    {
                        netfinder.AssignDevice(
                            deviceList.Items[lv_device.CurrentRowIndex].mac.Address, 
                            new byte[] { byte.Parse(ip[0]), byte.Parse(ip[1]), byte.Parse(ip[2]), byte.Parse(ip[3]) },
                            assign.DeviceName, 
                            assign.Timeout,
                            assign.DHCP);
                    }
                }
            }
        }
        private void btn_image_Click(object sender, EventArgs e)
        {
            //tftp -i %d.%d.%d.%d PUT \"%s\" boot.img
            if (m_start)
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }
            try
            {
                using (OpenFileDialog ofile = new OpenFileDialog())
                {
                    //ofile.Title = "Please choose Image update file";
                    ofile.Filter = "IMG files (*.img)|*.img|All files (*.*)|*.*";//"IMG Files\0*.img;\0All Files\0*.*\0";
                    if (ofile.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ipb = deviceList.Items[lv_device.CurrentRowIndex].ip.Address;
                        string ip = String.Format("{0}.{1}.{2}.{3}", ipb[0], ipb[1], ipb[2], ipb[3]);

                        netfinder.AsyncUpdateImage(ip, ofile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_bootloader_Click(object sender, EventArgs e)
        {
            if (m_start)
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }
            try
            {
                using (OpenFileDialog ofile = new OpenFileDialog())
                {
                    //ofile.Title = "Please choose Eboot update file";
                    ofile.Filter = "BIN files (*.bin)|*.bin|All files (*.*)|*.*";//"BIN Files\0*.bin;\0All Files\0*.*\0";
                    if (ofile.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ipb = deviceList.Items[lv_device.CurrentRowIndex].ip.Address;
                        string ip = String.Format("{0}.{1}.{2}.{3}", ipb[0], ipb[1], ipb[2], ipb[3]);
                        int port = (int)deviceList.Items[lv_device.CurrentRowIndex].port;
                        
                        netfinder.AsyncUpdateEboot(ip, ofile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            UpdateInfo(Info_Search);
            btn_connect.Enabled = false;
            btn_assign.Enabled = false;
            btn_image.Enabled = false;
            btn_bootloader.Enabled = false;
            netfinder.ClearDeviceList();
            deviceList.Clear();
            netfinder.ResearchDevice();
        }
        #endregion

        #region Callback and delegete
        void netfinder_OnUpdatePercent(object sender, UpdatePercentArgs e)
        {
            if (progressform.bClosed)
            {
                progressform = new UpdateProgressForm();
                progressform.Disposed += new EventHandler(progressform_Disposed);
            }
            progressform.Show();
            progressform.Percent = e.Percent;
        }

        void progressform_Disposed(object sender, EventArgs e)
        {
            if (!disposed)
            {
                btn_clear_Click(null, EventArgs.Empty);
                btn_start_Click(null, EventArgs.Empty);
            }
        }

        void netfinder_OnUpdateCompleted(object sender, UpdateResultArgs e)
        {
            progressform.MessageTxt = String.Format("FW Update {0}", e.Result);
        }

        void netfinder_OnSearchCompleted(object sender, DeviceFinderArgs e)
        {
            UpdateInfo(Info_Select);
            UpdateUI(e.Found);
        }
        void netfinder_OnAssignCompleted(object sender, ResultArgs e)
        {
            ShowMsg(e.Result);
        }


        private delegate void UpdateEbootResultDeleg(UpdateResult result);
        private void UpdateEbootResult(UpdateResult result)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new UpdateEbootResultDeleg(UpdateEbootResult), new object[] { result });
                return;
            }
            //add to list
            Debug.WriteLine(String.Format("Update eboot {0}", result));
            MessageBox.Show(String.Format("Update eboot {0}", result));
        }

        private delegate void UpdateInfoDeleg(String info);

        private void UpdateInfo(String info)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new UpdateInfoDeleg(UpdateInfo), new object[] { info });
                return;
            }
            //add to list
            lb_info.Text = info;

        }

        private delegate void UpdateUIDeleg(DeviceInfomation data);

        private void UpdateUI(DeviceInfomation data)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new UpdateUIDeleg(UpdateUI), new object[] { data });
                return;
            }
            //add to list
            Debug.WriteLine(String.Format("UI List add {0}", data.device_name));
            deviceList.AddItem(data);

        }

        private delegate void ShowMsgDeleg(Result e);
        private void ShowMsg(Result e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ShowMsgDeleg(ShowMsg), new object[] { e });
                return;
            }

            switch (e)
            {
                case Result.ACCEPTED:
                    MessageBox.Show("Assign completed");
                    btn_clear_Click(null, null);
                    btn_start_Click(null, null);
                    break;
                case Result.REJECTED:
                    MessageBox.Show("Assign rejected");
                    break;
                case Result.UNKNOWN:
                    MessageBox.Show("Assign fail");
                    break;
                case Result.TIMEOUT:
                    MessageBox.Show("Assign timeout");
                    break;
            }

        }

        private delegate void ConnectResultDeleg(Result e);
        private void ConnectResult(Result e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ConnectResultDeleg(ConnectResult), new object[] { e });
                return;
            }

            switch (e)
            {
                case Result.ACCEPTED:
                    //MessageBox.Show("Connect success");
                    DialogResult = DialogResult.OK;
                    ConnectIP = deviceList.Items[lv_device.CurrentRowIndex].ip.ToString();
                    MAC = deviceList.Items[lv_device.CurrentRowIndex].mac.ToString();
                    this.Close();
                    break;
                case Result.REJECTED:
                    MessageBox.Show("Connect rejected");
                    break;
                case Result.UNKNOWN:
                    MessageBox.Show("Connect fail");
                    break;
                case Result.TIMEOUT:
                    MessageBox.Show("Connect timeout");
                    break;
            }
        }

        #endregion

        #region Listview Event
        private void lv_device_SelectionChanged()
        {
            
        }
        private void lv_device_RowChanged(int rowIndex)
        {
            if (lv_device.CurrentRowIndex >= 0 && lv_device.CurrentRowIndex < deviceList.Items.Count)
            {
                switch (deviceList.Items[lv_device.CurrentRowIndex].mode)
                {
                    case Mode.Bootloader:
                        btn_connect.Enabled = false;
                        btn_assign.Enabled = false;
                        btn_image.Enabled = true;
                        btn_bootloader.Enabled = false;
                        break;
                    case Mode.Normal:
                        btn_connect.Enabled = true;
                        btn_assign.Enabled = true;
                        btn_image.Enabled = false;
                        btn_bootloader.Enabled = true;
                        break;
                }
                UpdateInfo(Info_Connect);
            }
            else
            {
                btn_connect.Enabled = false;
                btn_assign.Enabled = false;
                btn_bootloader.Enabled = false;
                btn_image.Enabled = false;
            }
        }

        #endregion
    }
}