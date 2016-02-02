using System;
using System.Collections.Generic;
using System.Text;

namespace CS203_GPIO
{
    class RadioButtonEx : System.Windows.Forms.RadioButton
    {
        public Boolean readOnly = false;

        public Boolean ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        public RadioButtonEx() { }

        protected override void OnCheckedChanged(EventArgs e)
        {
            if (!ReadOnly)
                base.OnCheckedChanged(e);
        }
        protected override void OnClick(EventArgs e)
        {
            if (!ReadOnly)
                base.OnClick(e);
        }
    }
}
