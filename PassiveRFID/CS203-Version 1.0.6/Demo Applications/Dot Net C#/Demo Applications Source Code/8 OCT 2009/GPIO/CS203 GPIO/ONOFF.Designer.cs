namespace CS203_GPIO
{
    partial class ONOFF
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rb_on = new CS203_GPIO.RadioButtonEx();
            this.rb_off = new CS203_GPIO.RadioButtonEx();
            this.SuspendLayout();
            // 
            // rb_on
            // 
            this.rb_on.AutoSize = true;
            this.rb_on.Location = new System.Drawing.Point(3, 2);
            this.rb_on.Name = "rb_on";
            this.rb_on.ReadOnly = false;
            this.rb_on.Size = new System.Drawing.Size(51, 16);
            this.rb_on.TabIndex = 2;
            this.rb_on.Text = "HIGH";
            this.rb_on.UseVisualStyleBackColor = true;
            this.rb_on.CheckedChanged += new System.EventHandler(this.rb_on_CheckedChanged);
            // 
            // rb_off
            // 
            this.rb_off.AutoSize = true;
            this.rb_off.Checked = true;
            this.rb_off.Location = new System.Drawing.Point(70, 2);
            this.rb_off.Name = "rb_off";
            this.rb_off.ReadOnly = false;
            this.rb_off.Size = new System.Drawing.Size(49, 16);
            this.rb_off.TabIndex = 3;
            this.rb_off.TabStop = true;
            this.rb_off.Text = "LOW";
            this.rb_off.UseVisualStyleBackColor = true;
            // 
            // ONOFF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rb_off);
            this.Controls.Add(this.rb_on);
            this.Name = "ONOFF";
            this.Size = new System.Drawing.Size(122, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButtonEx rb_on;
        private RadioButtonEx rb_off;

    }
}
