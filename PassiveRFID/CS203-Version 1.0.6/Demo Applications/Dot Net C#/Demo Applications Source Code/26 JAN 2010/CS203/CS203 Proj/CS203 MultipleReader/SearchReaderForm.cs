using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSLibrary.Net;

namespace CS203_MultipleReader
{
    public partial class SearchReaderForm : Form
    {
        private NetFinder netfinder = new NetFinder();

        public SearchReaderForm()
        {
            InitializeComponent();
        }

        private void SearchReaderForm_Load(object sender, EventArgs e)
        {
            netfinder.OnSearchCompleted += new EventHandler<DeviceFinderArgs>(netfinder_OnSearchCompleted);
        }

        private void SearchReaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            netfinder.OnSearchCompleted -= new EventHandler<DeviceFinderArgs>(netfinder_OnSearchCompleted);
            netfinder.Stop();
        }

        void netfinder_OnSearchCompleted(object sender, DeviceFinderArgs e)
        {
            //update list
            ListViewItem item = new ListViewItem(e.Found.device_name);
            item.SubItems.Add(e.Found.ip.ToString());
            item.SubItems.Add(e.Found.mac.ToString());
            listView1.Items.Add(item);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (netfinder.Operation == RecvOperation.IDLE)
            {
                listView1.Items.Clear();
                netfinder.ClearDeviceList();
                netfinder.SearchDevice();
                btn_search.Text = "Stop";
            }
            else if(netfinder.Operation == RecvOperation.SEARCH)
            {
                netfinder.Stop();
                btn_search.Text = "Search";
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem cb in listView1.CheckedItems)
            {
                Program.ConnectIPList.Add(cb.SubItems[1].Text);
            }
            DialogResult = DialogResult.OK;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btn_connect.Enabled = listView1.CheckedItems.Count != 0;
        }

    }
}