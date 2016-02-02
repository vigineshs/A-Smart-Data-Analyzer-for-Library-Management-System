using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace CS203_GPIO
{
    public partial class GPIOForm : Form
    {


        enum ReadIO
        {
            GPI0,
            GPI1,
            GPO0,
            GPO1,
            LED
        }

        enum WriteIO
        {
            GPO0,
            GPO1,
            LED
        }

        bool m_connect = false;
        TcpClient client;
        TcpClient client2;

        public GPIOForm()
        {
            InitializeComponent();
        }
        private void btn_conn_Click(object sender, EventArgs e)
        {
            if (!m_connect)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(ipTextBox1.IP, 1516);
                }
                catch (Exception ex)
                {
                    m_connect = false;
                    lb_status.Text = "FAIL";
                    return;
                }
                m_connect = true;
                btn_conn.BackColor = Color.Red;
                btn_conn.Text = "Disconnect";
                splitContainer1.Panel2.Enabled = true;
                refresh_tmr.Enabled = true;
                lb_status.Text = "OK";
            }
            else
            {
                client.Close();
                m_connect = false;
                btn_conn.BackColor = Color.Green;
                btn_conn.Text = "Connect";
                splitContainer1.Panel2.Enabled = false;
                refresh_tmr.Enabled = false;
                lb_status.Text = "Disconnected";
            }
        }

        private int SendCmd(ReadIO io)
        {
            try
            {
                byte[] buf = new byte[5];
                int command = 0;
                NetworkStream stream = client.GetStream();
                {
                    switch(io)
                    {
                        case ReadIO.GPI0:
                            command = 0x0C;
                            break;
                        case ReadIO.GPI1:
                            command = 0x0D;
                            break;
                        case ReadIO.GPO0:
                            command = 0x0A;
                            break;
                        case ReadIO.GPO1:
                            command = 0x0B;
                            break;
                        case ReadIO.LED:
                            command = 0x10;
                            break;
                    }
                    buf[0] = 0x80;
                    buf[1] = 0x00;
                    buf[2] = 0x00;
                    buf[3] = (byte)command;
                    stream.Write(buf, 0, 4);

                    for (int i = 0; i < 20000; i++) ;

                    stream.Read(buf, 0, 5);

                    if (buf[0] == 0x81 && buf[1] == 0x01)
                    {
                        return buf[4];
                    }
                    return -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }

        private int SendCmd(WriteIO io, Boolean On)
        {
            try
            {
                byte[] buf = new byte[5];
                int command = 0;
                NetworkStream stream = client.GetStream();
                {
                    switch (io)
                    {
                        case WriteIO.GPO0:
                            command = On ? 0x04 : 0x05;
                            break;
                        case WriteIO.GPO1:
                            command = On ? 0x06 : 0x07;
                            break;
                        case WriteIO.LED:
                            command = On ? 0x08 : 0x09;
                            break;
                    }
                    buf[0] = 0x80;
                    buf[1] = 0x00;
                    buf[2] = 0x00;
                    buf[3] = (byte)command;
                    stream.Write(buf, 0, 4);

                    for (int i = 0; i < 20000; i++) ;

                    stream.Read(buf, 0, 5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }

        private void hl_gpo0_OnTriggerEvt(object sender, EventArgs e)
        {
            SendCmd(WriteIO.GPO0, (bool)sender);
        }

        private void hl_gpo1_OnTriggerEvt(object sender, EventArgs e)
        {
            SendCmd(WriteIO.GPO1, (bool)sender);
        }

        private void hl_led_OnTriggerEvt(object sender, EventArgs e)
        {
            SendCmd(WriteIO.LED, (bool)sender);
        }

        private void refresh_tmr_Tick(object sender, EventArgs e)
        {
            refresh_tmr.Stop();
            lb_status.Text = Refresh() ? "OK" : "FAIL";
            refresh_tmr.Start();
        }

        private bool Refresh()
        {
            try
            {
                hl_gpo0.ON = SendCmd(ReadIO.GPO0) == 1 ? true : false;
                hl_gpo1.ON = SendCmd(ReadIO.GPO1) == 1 ? true : false;
                hl_gpi0.ON = SendCmd(ReadIO.GPI0) == 1 ? true : false;
                hl_gpi1.ON = SendCmd(ReadIO.GPI1) == 1 ? true : false;
                hl_led.ON = SendCmd(ReadIO.LED) == 1 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private bool BootLoader()
        {
            try
            {
                byte[] buf = new byte[5];
                int command = 0;
                NetworkStream stream = client.GetStream();
                buf[0] = 0x80;
                buf[1] = 0x00;
                buf[2] = 0x00;
                buf[3] = 0x03;
                stream.Write(buf, 0, 4);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}