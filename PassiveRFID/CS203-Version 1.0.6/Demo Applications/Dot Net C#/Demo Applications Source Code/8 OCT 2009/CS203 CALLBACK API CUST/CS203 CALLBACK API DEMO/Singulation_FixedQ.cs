using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using rfid.Structures;

namespace CS203DEMO
{
    public partial class Singulation_FixedQ : UserControl
    {
        FixedQParms m_fixedQ = new FixedQParms();

        public FixedQParms FixedQ
        {
            get { return m_fixedQ; }
            set { m_fixedQ = value; Refresh(); }
        }

        public Singulation_FixedQ(FixedQParms fixedQ)
        {
            InitializeComponent();

            FixedQ = fixedQ;
        }

        public override void Refresh()
        {
            base.Refresh();
            nb_qvalue.Value = m_fixedQ.qValue;
            cb_repeat.Checked = m_fixedQ.repeatUntilNoTags == 0 ? false : true;
            nb_retry.Value = m_fixedQ.retryCount;
            cb_toggle.Checked = m_fixedQ.toggleTarget == 0 ? false : true;
        }

        private void nb_qvalue_ValueChanged(object sender, EventArgs e)
        {
            m_fixedQ.qValue = (uint)nb_qvalue.Value;
        }

        private void nb_retry_ValueChanged(object sender, EventArgs e)
        {
            m_fixedQ.retryCount = (uint)nb_retry.Value;
        }

        private void cb_toggle_CheckedChanged(object sender, EventArgs e)
        {
            m_fixedQ.toggleTarget = (uint)(cb_toggle.Checked ? 1 : 0);
        }

        private void cb_repeat_CheckedChanged(object sender, EventArgs e)
        {
            m_fixedQ.repeatUntilNoTags = (uint)(cb_repeat.Checked ? 1 : 0);
        }

    }
}
