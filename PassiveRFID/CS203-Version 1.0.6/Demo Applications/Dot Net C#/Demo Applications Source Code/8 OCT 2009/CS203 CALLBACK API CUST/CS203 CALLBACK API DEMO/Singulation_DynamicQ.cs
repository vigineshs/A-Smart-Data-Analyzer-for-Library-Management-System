using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using rfid.Structures;
using rfid.Constants;

namespace CS203DEMO
{
    public partial class Singulation_DynamicQ : UserControl
    {
        private DynamicQAdjustParms dynQAdjust;
        private DynamicQParms dynQ;
        private DynamicQThresholdParms dynQThreshold;

        private SingulationAlgorithm current = SingulationAlgorithm.UNKNOWN;

        public DynamicQAdjustParms DynamicQAdjust
        {
            get { return dynQAdjust; }
            set { dynQAdjust = value; Refresh(); }
        }

        public DynamicQParms DynamicQ
        {
            get { return dynQ; }
            set { dynQ = value; Refresh(); }
        }

        public DynamicQThresholdParms DynamicQThreshold
        {
            get { return dynQThreshold; }
            set { dynQThreshold = value; Refresh(); }
        }

        public Singulation_DynamicQ(SingulationAlgorithmParms parms, SingulationAlgorithm alg)
        {
            InitializeComponent();

            switch (current = alg)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    DynamicQ = parms as DynamicQParms;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    DynamicQAdjust = parms as DynamicQAdjustParms;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    DynamicQThreshold = parms as DynamicQThresholdParms;
                    break;
            }
        }


        public override void Refresh()
        {
            base.Refresh();
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    nb_startqvalue.Value = dynQ.startQValue;
                    nb_retry.Value = dynQ.retryCount;
                    nb_minqvalue.Value = dynQ.minQValue;
                    nb_maxqvalue.Value = dynQ.maxQValue;
                    nb_MaxQueryRep.Value = dynQ.maxQueryRepCount;
                    cb_toggle.Checked = dynQ.toggleTarget != 0;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    nb_startqvalue.Value = dynQAdjust.startQValue;
                    nb_retry.Value = dynQAdjust.retryCount;
                    nb_minqvalue.Value = dynQAdjust.minQValue;
                    nb_maxqvalue.Value = dynQAdjust.maxQValue;
                    nb_MaxQueryRep.Value = dynQAdjust.maxQueryRepCount;
                    cb_toggle.Checked = dynQAdjust.toggleTarget != 0;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    nb_startqvalue.Value = dynQThreshold.startQValue;
                    nb_retry.Value = dynQThreshold.retryCount;
                    nb_minqvalue.Value = dynQThreshold.minQValue;
                    nb_maxqvalue.Value = dynQThreshold.maxQValue;
                    nb_MaxQueryRep.Value = dynQThreshold.thresholdMultiplier;
                    cb_toggle.Checked = dynQThreshold.toggleTarget != 0;
                    label4.Text = "Multiplier";
                    break;
            }
        }

        #region Value Changed
        private void nb_startqvalue_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.startQValue = (uint)nb_startqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.startQValue = (uint)nb_startqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.startQValue = (uint)nb_startqvalue.Value;
                    break;
            }

        }

        private void nb_minqvalue_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.minQValue = (uint)nb_minqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.minQValue = (uint)nb_minqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.minQValue = (uint)nb_minqvalue.Value;
                    break;
            }
        }

        private void nb_retry_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.retryCount = (uint)nb_retry.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.retryCount = (uint)nb_retry.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.retryCount = (uint)nb_retry.Value;
                    break;
            }
        }

        private void nb_maxqvalue_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.maxQValue = (uint)nb_maxqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.maxQValue = (uint)nb_maxqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.maxQValue = (uint)nb_maxqvalue.Value;
                    break;
            }

        }

        private void nb_MaxQueryRep_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.maxQueryRepCount = (uint)nb_MaxQueryRep.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.maxQueryRepCount = (uint)nb_MaxQueryRep.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.thresholdMultiplier = (uint)nb_MaxQueryRep.Value;
                    break;
            }
        }

        private void cb_toggle_CheckedChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.toggleTarget = (uint)(cb_toggle.Checked ? 1 : 0);
                    break;
                case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.toggleTarget = (uint)(cb_toggle.Checked ? 1 : 0);
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.toggleTarget = (uint)(cb_toggle.Checked ? 1 : 0);
                    break;
            }
        }
        #endregion

    }
}
