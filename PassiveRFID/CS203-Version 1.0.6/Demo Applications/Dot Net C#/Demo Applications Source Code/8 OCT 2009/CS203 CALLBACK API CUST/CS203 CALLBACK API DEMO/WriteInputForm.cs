using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203DEMO
{
    public partial class WriteInputForm : Form
    {
        #region Pravite Member
        //private string data = "";
        public bool EnableOffset = false;
        public bool EnableCount = false;
        public uint DataLength = 0;
        public string Data
        {
            get { return tb_data.Text; }
        }
        public uint PWD
        {
            get { return uint.Parse(tb_pwd.Text, System.Globalization.NumberStyles.HexNumber); }
        }
        public uint RetryCnt
        {
            get { return (uint)nb_retry.Value; }
        }
        public ushort Offset
        {
            get { return (ushort)nb_offset.Value; }
        }
        public ushort Count
        {
            get { return (ushort)nb_count.Value; }
        }
        
        #endregion

        #region Form
        public WriteInputForm()
        {
            InitializeComponent();
        }

        private void WriteInputForm_Load(object sender, EventArgs e)
        {
            nb_offset.Enabled = EnableOffset;
            nb_count.Enabled = EnableCount;
            if(EnableCount)
                tb_data.MaxLength = (int)nb_count.Value * 4;
            else
                tb_data.MaxLength = (int)DataLength * 4;
        }

        private void WriteInputForm_Closing(object sender, CancelEventArgs e)
        {

        }
        #endregion

        #region Button
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (tb_data.Text.Length != tb_data.MaxLength)
            {
                MessageBox.Show("Please input data");
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nb_count_ValueChanged(object sender, EventArgs e)
        {
            tb_data.MaxLength = (int)nb_count.Value * 4;
        }
        #endregion
    }
}