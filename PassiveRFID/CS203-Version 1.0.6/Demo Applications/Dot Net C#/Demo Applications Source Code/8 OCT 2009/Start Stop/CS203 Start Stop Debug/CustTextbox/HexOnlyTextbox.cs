using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CS203_Start_Stop_Debug
{
    public class HexOnlyTextbox : System.Windows.Forms.TextBox
    {
        private string _bgText;

        public string BackgroundText
        {
            get { return _bgText; }
            set { _bgText = this.Text = value; }
        }

        public HexOnlyTextbox() { }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (IsHex(e.KeyChar) || (e.KeyChar == '\b' || e.KeyChar == 0x16 || e.KeyChar == 0x3))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        private bool IsHex(char hex)
        {
            if ((hex >= '0' && hex <= '9') || (hex >= 'a' && hex <= 'f') || (hex >= 'A' && hex <= 'F'))
                return true;
            return false;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Text = BackgroundText;
            this.ForeColor = Color.Gray;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (this.Text == _bgText)
            {
                this.Text = "";
                this.ForeColor = Color.Black;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (this.Text.Length == 0)
            {
                this.ForeColor = Color.Gray;
                this.Text = _bgText;
            }
            else
            {
                //add zero at the end of the string
                int count = MaxLength - Text.Length;
                for (int i = 0; i < count; i++)
                {
                    this.Text += "0";
                }
                this.ForeColor = Color.Black;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (this.Text != _bgText)
            {
                this.ForeColor = Color.Black;
                if (this.Text.Length > 0)
                {
                    this.BackColor = Color.LightGreen;
                }
                else
                {
                    this.BackColor = Color.White;
                }
                if (this.Text.Length == this.MaxLength)
                {
                    this.BackColor = Color.LightPink;
                }
            }
            else
                this.ForeColor = Color.Gray;

        }

        public int IntValue
        {
            get
            {
                return Int32.Parse(this.Text);
            }
        }
    }
}
