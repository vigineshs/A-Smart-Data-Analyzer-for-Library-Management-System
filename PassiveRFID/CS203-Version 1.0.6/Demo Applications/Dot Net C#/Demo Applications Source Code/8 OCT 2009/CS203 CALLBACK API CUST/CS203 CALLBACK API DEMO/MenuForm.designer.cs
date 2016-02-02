namespace CS203DEMO
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
            this.btn_rw = new System.Windows.Forms.Button();
            this.btn_geiger = new System.Windows.Forms.Button();
            this.btn_security = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_setup = new System.Windows.Forms.Button();
            this.btn_inv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_software = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_firmware = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_cslib = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_rfidlib = new System.Windows.Forms.Label();
            this.lb_freqProfile = new System.Windows.Forms.Label();
            this.lb_freqtype = new System.Windows.Forms.Label();
            this.lb_profile = new System.Windows.Forms.Label();
            this.lb_power = new System.Windows.Forms.Label();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_c51bldr = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_c51App = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_rw
            // 
            this.btn_rw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_rw.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_rw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_rw.Location = new System.Drawing.Point(3, 36);
            this.btn_rw.Name = "btn_rw";
            this.btn_rw.Size = new System.Drawing.Size(96, 27);
            this.btn_rw.TabIndex = 0;
            this.btn_rw.Text = "ReadWrite";
            this.btn_rw.UseVisualStyleBackColor = false;
            this.btn_rw.Click += new System.EventHandler(this.btn_rw_Click);
            // 
            // btn_geiger
            // 
            this.btn_geiger.BackColor = System.Drawing.Color.Lime;
            this.btn_geiger.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_geiger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_geiger.Location = new System.Drawing.Point(3, 69);
            this.btn_geiger.Name = "btn_geiger";
            this.btn_geiger.Size = new System.Drawing.Size(96, 27);
            this.btn_geiger.TabIndex = 0;
            this.btn_geiger.Text = "Geiger";
            this.btn_geiger.UseVisualStyleBackColor = false;
            this.btn_geiger.Click += new System.EventHandler(this.btn_geiger_Click);
            // 
            // btn_security
            // 
            this.btn_security.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_security.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_security.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_security.Location = new System.Drawing.Point(3, 102);
            this.btn_security.Name = "btn_security";
            this.btn_security.Size = new System.Drawing.Size(96, 27);
            this.btn_security.TabIndex = 0;
            this.btn_security.Text = "Security";
            this.btn_security.UseVisualStyleBackColor = false;
            this.btn_security.Click += new System.EventHandler(this.btn_security_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_back.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_back.Location = new System.Drawing.Point(6, 249);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(96, 27);
            this.btn_back.TabIndex = 0;
            this.btn_back.Text = "Exit";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_setup
            // 
            this.btn_setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_setup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_setup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_setup.Location = new System.Drawing.Point(3, 135);
            this.btn_setup.Name = "btn_setup";
            this.btn_setup.Size = new System.Drawing.Size(96, 27);
            this.btn_setup.TabIndex = 0;
            this.btn_setup.Text = "Setup";
            this.btn_setup.UseVisualStyleBackColor = false;
            this.btn_setup.Click += new System.EventHandler(this.btn_setup_Click);
            // 
            // btn_inv
            // 
            this.btn_inv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_inv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_inv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_inv.Location = new System.Drawing.Point(3, 3);
            this.btn_inv.Name = "btn_inv";
            this.btn_inv.Size = new System.Drawing.Size(96, 27);
            this.btn_inv.TabIndex = 0;
            this.btn_inv.Text = "Inventory";
            this.btn_inv.UseVisualStyleBackColor = false;
            this.btn_inv.Click += new System.EventHandler(this.btn_inv_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.Location = new System.Drawing.Point(105, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Demo App Vers";
            // 
            // lb_software
            // 
            this.lb_software.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_software.Location = new System.Drawing.Point(189, 3);
            this.lb_software.Name = "lb_software";
            this.lb_software.Size = new System.Drawing.Size(128, 20);
            this.lb_software.TabIndex = 10;
            this.lb_software.Text = "1.0.0";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.Location = new System.Drawing.Point(105, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Firmware Vers";
            // 
            // lb_firmware
            // 
            this.lb_firmware.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_firmware.Location = new System.Drawing.Point(189, 43);
            this.lb_firmware.Name = "lb_firmware";
            this.lb_firmware.Size = new System.Drawing.Size(128, 20);
            this.lb_firmware.TabIndex = 6;
            this.lb_firmware.Text = "1.0.0";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.Location = new System.Drawing.Point(105, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "CSLib Vers";
            // 
            // lb_cslib
            // 
            this.lb_cslib.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_cslib.Location = new System.Drawing.Point(189, 63);
            this.lb_cslib.Name = "lb_cslib";
            this.lb_cslib.Size = new System.Drawing.Size(128, 20);
            this.lb_cslib.TabIndex = 0;
            this.lb_cslib.Text = "1.0.0";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.Location = new System.Drawing.Point(105, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "RFID Lib Vers";
            // 
            // lb_rfidlib
            // 
            this.lb_rfidlib.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_rfidlib.Location = new System.Drawing.Point(189, 23);
            this.lb_rfidlib.Name = "lb_rfidlib";
            this.lb_rfidlib.Size = new System.Drawing.Size(128, 20);
            this.lb_rfidlib.TabIndex = 8;
            this.lb_rfidlib.Text = "1.0.0";
            // 
            // lb_freqProfile
            // 
            this.lb_freqProfile.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_freqProfile.Location = new System.Drawing.Point(105, 122);
            this.lb_freqProfile.Name = "lb_freqProfile";
            this.lb_freqProfile.Size = new System.Drawing.Size(212, 20);
            this.lb_freqProfile.TabIndex = 4;
            this.lb_freqProfile.Text = "Frequency Profile : Hong Kong";
            // 
            // lb_freqtype
            // 
            this.lb_freqtype.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_freqtype.Location = new System.Drawing.Point(105, 142);
            this.lb_freqtype.Name = "lb_freqtype";
            this.lb_freqtype.Size = new System.Drawing.Size(212, 20);
            this.lb_freqtype.TabIndex = 3;
            this.lb_freqtype.Text = "Frequency : Hopping";
            // 
            // lb_profile
            // 
            this.lb_profile.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_profile.Location = new System.Drawing.Point(105, 162);
            this.lb_profile.Name = "lb_profile";
            this.lb_profile.Size = new System.Drawing.Size(212, 20);
            this.lb_profile.TabIndex = 2;
            this.lb_profile.Text = "Profile : 2";
            // 
            // lb_power
            // 
            this.lb_power.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_power.Location = new System.Drawing.Point(105, 182);
            this.lb_power.Name = "lb_power";
            this.lb_power.Size = new System.Drawing.Size(212, 20);
            this.lb_power.TabIndex = 1;
            this.lb_power.Text = "Power : 30 dBm";
            // 
            // pb_logo
            // 
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(108, 205);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(209, 71);
            this.pb_logo.TabIndex = 12;
            this.pb_logo.TabStop = false;
            this.pb_logo.MouseLeave += new System.EventHandler(this.pb_logo_MouseLeave);
            this.pb_logo.Click += new System.EventHandler(this.pb_logo_Click);
            this.pb_logo.MouseEnter += new System.EventHandler(this.pb_logo_MouseEnter);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.Location = new System.Drawing.Point(105, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "BootLoader";
            // 
            // lb_c51bldr
            // 
            this.lb_c51bldr.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_c51bldr.Location = new System.Drawing.Point(189, 83);
            this.lb_c51bldr.Name = "lb_c51bldr";
            this.lb_c51bldr.Size = new System.Drawing.Size(128, 20);
            this.lb_c51bldr.TabIndex = 0;
            this.lb_c51bldr.Text = "1.0.0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.Location = new System.Drawing.Point(105, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "8051 App";
            // 
            // lb_c51App
            // 
            this.lb_c51App.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lb_c51App.Location = new System.Drawing.Point(189, 102);
            this.lb_c51App.Name = "lb_c51App";
            this.lb_c51App.Size = new System.Drawing.Size(128, 20);
            this.lb_c51App.TabIndex = 0;
            this.lb_c51App.Text = "1.0.0";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(327, 280);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.lb_c51App);
            this.Controls.Add(this.lb_c51bldr);
            this.Controls.Add(this.lb_cslib);
            this.Controls.Add(this.lb_power);
            this.Controls.Add(this.lb_profile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_freqtype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_freqProfile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_firmware);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_rfidlib);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_software);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_setup);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_security);
            this.Controls.Add(this.btn_geiger);
            this.Controls.Add(this.btn_inv);
            this.Controls.Add(this.btn_rw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo Application";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_rw;
        private System.Windows.Forms.Button btn_geiger;
        private System.Windows.Forms.Button btn_security;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_setup;
        private System.Windows.Forms.Button btn_inv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_software;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_firmware;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_cslib;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_rfidlib;
        private System.Windows.Forms.Label lb_freqProfile;
        private System.Windows.Forms.Label lb_freqtype;
        private System.Windows.Forms.Label lb_profile;
        private System.Windows.Forms.Label lb_power;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_c51bldr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_c51App;
    }
}