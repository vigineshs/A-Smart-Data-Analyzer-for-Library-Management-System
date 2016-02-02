using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CS203_GPIO
{
    public partial class ONOFF : UserControl
    {
        public event EventHandler OnTriggerEvt;

        public Boolean ReadOnly
        {
            get { return rb_on.ReadOnly; }
            set { rb_on.ReadOnly = rb_off.ReadOnly = value; }
        }

        public bool ON
        {
            get { return rb_on.Checked; }
            set
            {
                if (value)
                {
                    rb_on.Checked = true;
                }
                else
                {
                    rb_off.Checked = true;
                }
            }

        }

        public ONOFF()
        {
            InitializeComponent();
        }

        private void rb_on_CheckedChanged(object sender, EventArgs e)
        {
            if (OnTriggerEvt != null && !ReadOnly)
                OnTriggerEvt(rb_on.Checked, e);
        }

    }
}
