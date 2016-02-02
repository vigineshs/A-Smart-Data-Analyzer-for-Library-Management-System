namespace CS203_CALLBACK_API_DEMO_CE
{
    partial class MenuForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lb_cslib = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_firmware = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_macaddr = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_rfidlib = new System.Windows.Forms.Label();
            this.lb_freqProfile = new System.Windows.Forms.Label();
            this.lb_freqtype = new System.Windows.Forms.Label();
            this.lb_profile = new System.Windows.Forms.Label();
            this.lb_power = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_software = new System.Windows.Forms.Label();
            this.menuBar1 = new CS203_CALLBACK_API_DEMO_CE.MenuBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(105, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.Text = "CSLibrary Vers";
            // 
            // lb_cslib
            // 
            this.lb_cslib.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_cslib.Location = new System.Drawing.Point(189, 3);
            this.lb_cslib.Name = "lb_cslib";
            this.lb_cslib.Size = new System.Drawing.Size(39, 20);
            this.lb_cslib.Text = "1.0.0";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(105, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.Text = "Firmware Vers";
            // 
            // lb_firmware
            // 
            this.lb_firmware.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_firmware.Location = new System.Drawing.Point(189, 43);
            this.lb_firmware.Name = "lb_firmware";
            this.lb_firmware.Size = new System.Drawing.Size(128, 20);
            this.lb_firmware.Text = "1.0.0";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(105, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.Text = "MAC Address";
            // 
            // lb_macaddr
            // 
            this.lb_macaddr.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_macaddr.Location = new System.Drawing.Point(189, 63);
            this.lb_macaddr.Name = "lb_macaddr";
            this.lb_macaddr.Size = new System.Drawing.Size(128, 20);
            this.lb_macaddr.Text = "xxxx:xxxx:xxxx:xxxx";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(105, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.Text = "RFID Lib Vers";
            // 
            // lb_rfidlib
            // 
            this.lb_rfidlib.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_rfidlib.Location = new System.Drawing.Point(189, 23);
            this.lb_rfidlib.Name = "lb_rfidlib";
            this.lb_rfidlib.Size = new System.Drawing.Size(128, 20);
            this.lb_rfidlib.Text = "1.0.0";
            // 
            // lb_freqProfile
            // 
            this.lb_freqProfile.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_freqProfile.Location = new System.Drawing.Point(105, 83);
            this.lb_freqProfile.Name = "lb_freqProfile";
            this.lb_freqProfile.Size = new System.Drawing.Size(212, 20);
            this.lb_freqProfile.Text = "Frequency Profile : Hong Kong";
            // 
            // lb_freqtype
            // 
            this.lb_freqtype.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_freqtype.Location = new System.Drawing.Point(105, 103);
            this.lb_freqtype.Name = "lb_freqtype";
            this.lb_freqtype.Size = new System.Drawing.Size(212, 20);
            this.lb_freqtype.Text = "Frequency : Hopping";
            // 
            // lb_profile
            // 
            this.lb_profile.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_profile.Location = new System.Drawing.Point(105, 123);
            this.lb_profile.Name = "lb_profile";
            this.lb_profile.Size = new System.Drawing.Size(212, 20);
            this.lb_profile.Text = "Profile : 2";
            // 
            // lb_power
            // 
            this.lb_power.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_power.Location = new System.Drawing.Point(105, 143);
            this.lb_power.Name = "lb_power";
            this.lb_power.Size = new System.Drawing.Size(212, 20);
            this.lb_power.Text = "Power : 30 dBm";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(234, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.Text = "UI Vers";
            // 
            // lb_software
            // 
            this.lb_software.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lb_software.Location = new System.Drawing.Point(278, 3);
            this.lb_software.Name = "lb_software";
            this.lb_software.Size = new System.Drawing.Size(39, 20);
            this.lb_software.Text = "1.0.0";
            // 
            // menuBar1
            // 
            this.menuBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(99, 240);
            this.menuBar1.TabIndex = 15;
            this.menuBar1.ButtonClick += new System.EventHandler(this.menuBar1_ButtonClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(105, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 71);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuBar1);
            this.Controls.Add(this.lb_software);
            this.Controls.Add(this.lb_cslib);
            this.Controls.Add(this.lb_macaddr);
            this.Controls.Add(this.lb_power);
            this.Controls.Add(this.lb_profile);
            this.Controls.Add(this.lb_freqtype);
            this.Controls.Add(this.lb_freqProfile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_firmware);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_rfidlib);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.Activated += new System.EventHandler(this.MenuForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MenuForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_cslib;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_firmware;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_macaddr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_rfidlib;
        private System.Windows.Forms.Label lb_freqProfile;
        private System.Windows.Forms.Label lb_freqtype;
        private System.Windows.Forms.Label lb_profile;
        private System.Windows.Forms.Label lb_power;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_software;
        private MenuBar menuBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}