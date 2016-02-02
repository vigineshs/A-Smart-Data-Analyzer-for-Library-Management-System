namespace CS203_CALLBACK_API_DEMO
{
    partial class TagSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagSettingForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_gerenal = new System.Windows.Forms.TabPage();
            this.lb_detail = new System.Windows.Forms.LinkLabel();
            this.lk_antenna_port_cfg = new System.Windows.Forms.LinkLabel();
            this.cb_save = new System.Windows.Forms.CheckBox();
            this.cb_debug_log = new System.Windows.Forms.CheckBox();
            this.cb_fixed = new System.Windows.Forms.CheckBox();
            this.cb_lbt = new System.Windows.Forms.CheckBox();
            this.cb_linkprofile = new System.Windows.Forms.ComboBox();
            this.cb_freqlist = new System.Windows.Forms.ComboBox();
            this.cb_country = new System.Windows.Forms.ComboBox();
            this.nb_power = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_POWER = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tp_config = new System.Windows.Forms.TabPage();
            this.cb_custInvtryBlocking = new System.Windows.Forms.CheckBox();
            this.cb_custInvtryCont = new System.Windows.Forms.CheckBox();
            this.cb_target = new System.Windows.Forms.ComboBox();
            this.cb_algorithm = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_session = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_selected = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tp_cwonoff = new System.Windows.Forms.TabPage();
            this.btn_cwon = new System.Windows.Forms.Button();
            this.cb_withData = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cwoff = new System.Windows.Forms.Button();
            this.btn_apply = new System.Windows.Forms.Button();
            this.ts_status = new System.Windows.Forms.StatusBar();
            this.label4 = new System.Windows.Forms.Label();
            this.nb_reconnectTimeout = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tp_gerenal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_power)).BeginInit();
            this.tp_config.SuspendLayout();
            this.tp_cwonoff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_reconnectTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_gerenal);
            this.tabControl1.Controls.Add(this.tp_config);
#if ENGINEERING_MODE
            this.tabControl1.Controls.Add(this.tp_cwonoff);
#endif
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(318, 193);
            this.tabControl1.TabIndex = 2;
            // 
            // tp_gerenal
            // 
            this.tp_gerenal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tp_gerenal.Controls.Add(this.lb_detail);
            this.tp_gerenal.Controls.Add(this.lk_antenna_port_cfg);
            this.tp_gerenal.Controls.Add(this.cb_save);
            this.tp_gerenal.Controls.Add(this.cb_debug_log);
            this.tp_gerenal.Controls.Add(this.cb_fixed);
            this.tp_gerenal.Controls.Add(this.cb_lbt);
            this.tp_gerenal.Controls.Add(this.cb_linkprofile);
            this.tp_gerenal.Controls.Add(this.cb_freqlist);
            this.tp_gerenal.Controls.Add(this.cb_country);
            this.tp_gerenal.Controls.Add(this.nb_reconnectTimeout);
            this.tp_gerenal.Controls.Add(this.nb_power);
            this.tp_gerenal.Controls.Add(this.label4);
            this.tp_gerenal.Controls.Add(this.label10);
            this.tp_gerenal.Controls.Add(this.label2);
            this.tp_gerenal.Controls.Add(this.lb_POWER);
            this.tp_gerenal.Controls.Add(this.label3);
            this.tp_gerenal.Location = new System.Drawing.Point(4, 21);
            this.tp_gerenal.Name = "tp_gerenal";
            this.tp_gerenal.Size = new System.Drawing.Size(310, 168);
            this.tp_gerenal.TabIndex = 0;
            this.tp_gerenal.Text = "Gerenal Options";
            // 
            // lb_detail
            // 
            this.lb_detail.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.lb_detail.Location = new System.Drawing.Point(188, 10);
            this.lb_detail.Name = "lb_detail";
            this.lb_detail.Size = new System.Drawing.Size(100, 23);
            this.lb_detail.TabIndex = 85;
            this.lb_detail.TabStop = true;
            this.lb_detail.Text = "Detail";
            this.lb_detail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_detail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_detail_LinkClicked);
            // 
            // lk_antenna_port_cfg
            // 
            this.lk_antenna_port_cfg.AutoSize = true;
            this.lk_antenna_port_cfg.Enabled = false;
            this.lk_antenna_port_cfg.Location = new System.Drawing.Point(189, 72);
            this.lk_antenna_port_cfg.Name = "lk_antenna_port_cfg";
            this.lk_antenna_port_cfg.Size = new System.Drawing.Size(102, 12);
            this.lk_antenna_port_cfg.TabIndex = 84;
            this.lk_antenna_port_cfg.TabStop = true;
            this.lk_antenna_port_cfg.Text = "Antenna Port Config";
            this.lk_antenna_port_cfg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_antenna_port_cfg_LinkClicked);
            // 
            // cb_save
            // 
            this.cb_save.Checked = true;
            this.cb_save.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_save.Location = new System.Drawing.Point(191, 144);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(119, 16);
            this.cb_save.TabIndex = 79;
            this.cb_save.Text = "Save settings";
            this.cb_save.CheckStateChanged += new System.EventHandler(this.cb_fixed_CheckedChanged);
            // 
            // cb_debug_log
            // 
            this.cb_debug_log.Location = new System.Drawing.Point(191, 99);
            this.cb_debug_log.Name = "cb_debug_log";
            this.cb_debug_log.Size = new System.Drawing.Size(119, 16);
            this.cb_debug_log.TabIndex = 79;
            this.cb_debug_log.Text = "Debug Log";
            // 
            // cb_fixed
            // 
            this.cb_fixed.Location = new System.Drawing.Point(191, 45);
            this.cb_fixed.Name = "cb_fixed";
            this.cb_fixed.Size = new System.Drawing.Size(119, 16);
            this.cb_fixed.TabIndex = 79;
            this.cb_fixed.Text = "Fixed Channel";
            this.cb_fixed.CheckStateChanged += new System.EventHandler(this.cb_fixed_CheckedChanged);
            // 
            // cb_lbt
            // 
            this.cb_lbt.Location = new System.Drawing.Point(191, 122);
            this.cb_lbt.Name = "cb_lbt";
            this.cb_lbt.Size = new System.Drawing.Size(116, 16);
            this.cb_lbt.TabIndex = 73;
            this.cb_lbt.Text = "Enable LBT";
            // 
            // cb_linkprofile
            // 
            this.cb_linkprofile.Location = new System.Drawing.Point(72, 10);
            this.cb_linkprofile.Name = "cb_linkprofile";
            this.cb_linkprofile.Size = new System.Drawing.Size(97, 20);
            this.cb_linkprofile.TabIndex = 71;
            // 
            // cb_freqlist
            // 
            this.cb_freqlist.Location = new System.Drawing.Point(72, 114);
            this.cb_freqlist.Name = "cb_freqlist";
            this.cb_freqlist.Size = new System.Drawing.Size(97, 20);
            this.cb_freqlist.TabIndex = 64;
            this.cb_freqlist.SelectedIndexChanged += new System.EventHandler(this.cb_country_SelectedIndexChanged);
            // 
            // cb_country
            // 
            this.cb_country.Location = new System.Drawing.Point(72, 69);
            this.cb_country.Name = "cb_country";
            this.cb_country.Size = new System.Drawing.Size(97, 20);
            this.cb_country.TabIndex = 64;
            this.cb_country.SelectedIndexChanged += new System.EventHandler(this.cb_country_SelectedIndexChanged);
            // 
            // nb_power
            // 
            this.nb_power.Location = new System.Drawing.Point(72, 39);
            this.nb_power.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nb_power.Name = "nb_power";
            this.nb_power.Size = new System.Drawing.Size(97, 22);
            this.nb_power.TabIndex = 61;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(11, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 80;
            this.label10.Text = "Frequencies(MHz)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 81;
            this.label2.Text = "Country";
            // 
            // lb_POWER
            // 
            this.lb_POWER.Location = new System.Drawing.Point(11, 43);
            this.lb_POWER.Name = "lb_POWER";
            this.lb_POWER.Size = new System.Drawing.Size(56, 20);
            this.lb_POWER.TabIndex = 82;
            this.lb_POWER.Text = "Power";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 83;
            this.label3.Text = "Profile";
            // 
            // tp_config
            // 
            this.tp_config.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tp_config.Controls.Add(this.cb_custInvtryBlocking);
            this.tp_config.Controls.Add(this.cb_custInvtryCont);
            this.tp_config.Controls.Add(this.cb_target);
            this.tp_config.Controls.Add(this.cb_algorithm);
            this.tp_config.Controls.Add(this.label6);
            this.tp_config.Controls.Add(this.label5);
            this.tp_config.Controls.Add(this.cb_session);
            this.tp_config.Controls.Add(this.label7);
            this.tp_config.Controls.Add(this.label9);
            this.tp_config.Controls.Add(this.cb_selected);
            this.tp_config.Controls.Add(this.label8);
            this.tp_config.Location = new System.Drawing.Point(4, 21);
            this.tp_config.Name = "tp_config";
            this.tp_config.Size = new System.Drawing.Size(310, 168);
            this.tp_config.TabIndex = 1;
            this.tp_config.Text = "Inventory Config";
            // 
            // cb_custInvtryBlocking
            // 
            this.cb_custInvtryBlocking.Location = new System.Drawing.Point(183, 3);
            this.cb_custInvtryBlocking.Name = "cb_custInvtryBlocking";
            this.cb_custInvtryBlocking.Size = new System.Drawing.Size(121, 20);
            this.cb_custInvtryBlocking.TabIndex = 12;
            this.cb_custInvtryBlocking.Text = "Blocking mode";
            // 
            // cb_custInvtryCont
            // 
            this.cb_custInvtryCont.Checked = true;
            this.cb_custInvtryCont.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_custInvtryCont.Location = new System.Drawing.Point(88, 3);
            this.cb_custInvtryCont.Name = "cb_custInvtryCont";
            this.cb_custInvtryCont.Size = new System.Drawing.Size(105, 20);
            this.cb_custInvtryCont.TabIndex = 12;
            this.cb_custInvtryCont.Text = "Continuous";
            // 
            // cb_target
            // 
            this.cb_target.Location = new System.Drawing.Point(88, 96);
            this.cb_target.Name = "cb_target";
            this.cb_target.Size = new System.Drawing.Size(132, 20);
            this.cb_target.TabIndex = 1;
            // 
            // cb_algorithm
            // 
            this.cb_algorithm.Location = new System.Drawing.Point(88, 127);
            this.cb_algorithm.Name = "cb_algorithm";
            this.cb_algorithm.Size = new System.Drawing.Size(132, 20);
            this.cb_algorithm.TabIndex = 6;
            this.cb_algorithm.SelectedIndexChanged += new System.EventHandler(this.cb_algorithm_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(1, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Target";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Algorithm";
            // 
            // cb_session
            // 
            this.cb_session.Location = new System.Drawing.Point(88, 65);
            this.cb_session.Name = "cb_session";
            this.cb_session.Size = new System.Drawing.Size(132, 20);
            this.cb_session.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(1, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Session";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(1, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "Operation";
            // 
            // cb_selected
            // 
            this.cb_selected.Location = new System.Drawing.Point(88, 34);
            this.cb_selected.Name = "cb_selected";
            this.cb_selected.Size = new System.Drawing.Size(132, 20);
            this.cb_selected.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(1, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Selected";
            // 
            // tp_cwonoff
            // 
            this.tp_cwonoff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.tp_cwonoff.Controls.Add(this.btn_cwon);
            this.tp_cwonoff.Controls.Add(this.cb_withData);
            this.tp_cwonoff.Controls.Add(this.label1);
            this.tp_cwonoff.Controls.Add(this.btn_cwoff);
            this.tp_cwonoff.Location = new System.Drawing.Point(4, 21);
            this.tp_cwonoff.Name = "tp_cwonoff";
            this.tp_cwonoff.Size = new System.Drawing.Size(310, 168);
            this.tp_cwonoff.TabIndex = 3;
            this.tp_cwonoff.Text = "Carrier Wave";
            // 
            // btn_cwon
            // 
            this.btn_cwon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_cwon.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btn_cwon.ForeColor = System.Drawing.Color.White;
            this.btn_cwon.Location = new System.Drawing.Point(74, 42);
            this.btn_cwon.Name = "btn_cwon";
            this.btn_cwon.Size = new System.Drawing.Size(157, 46);
            this.btn_cwon.TabIndex = 0;
            this.btn_cwon.Text = "CW ON";
            this.btn_cwon.UseVisualStyleBackColor = false;
            this.btn_cwon.Click += new System.EventHandler(this.btn_cwon_Click);
            // 
            // cb_withData
            // 
            this.cb_withData.AutoSize = true;
            this.cb_withData.Location = new System.Drawing.Point(95, 97);
            this.cb_withData.Name = "cb_withData";
            this.cb_withData.Size = new System.Drawing.Size(119, 16);
            this.cb_withData.TabIndex = 1;
            this.cb_withData.Text = "Transmit Data Mode";
            this.cb_withData.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Engineering Test Mode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_cwoff
            // 
            this.btn_cwoff.BackColor = System.Drawing.Color.Red;
            this.btn_cwoff.Enabled = false;
            this.btn_cwoff.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btn_cwoff.ForeColor = System.Drawing.Color.White;
            this.btn_cwoff.Location = new System.Drawing.Point(74, 119);
            this.btn_cwoff.Name = "btn_cwoff";
            this.btn_cwoff.Size = new System.Drawing.Size(157, 46);
            this.btn_cwoff.TabIndex = 0;
            this.btn_cwoff.Text = "CW OFF";
            this.btn_cwoff.UseVisualStyleBackColor = false;
            this.btn_cwoff.Click += new System.EventHandler(this.btn_cwoff_Click);
            // 
            // btn_apply
            // 
            this.btn_apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_apply.Location = new System.Drawing.Point(243, 191);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 24);
            this.btn_apply.TabIndex = 3;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = false;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // ts_status
            // 
            this.ts_status.Location = new System.Drawing.Point(0, 191);
            this.ts_status.Name = "ts_status";
            this.ts_status.Size = new System.Drawing.Size(318, 24);
            this.ts_status.TabIndex = 4;
            this.ts_status.Text = "Status";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 81;
            this.label4.Text = "Reconnect Timeout";
            // 
            // nb_reconnectTimeout
            // 
            this.nb_reconnectTimeout.Location = new System.Drawing.Point(72, 144);
            this.nb_reconnectTimeout.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nb_reconnectTimeout.Name = "nb_reconnectTimeout";
            this.nb_reconnectTimeout.Size = new System.Drawing.Size(97, 22);
            this.nb_reconnectTimeout.TabIndex = 61;
            // 
            // TagSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(318, 215);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.ts_status);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagSettingForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tp_gerenal.ResumeLayout(false);
            this.tp_gerenal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_power)).EndInit();
            this.tp_config.ResumeLayout(false);
            this.tp_cwonoff.ResumeLayout(false);
            this.tp_cwonoff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_reconnectTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_gerenal;
        private System.Windows.Forms.TabPage tp_config;
        private System.Windows.Forms.ComboBox cb_linkprofile;
        private System.Windows.Forms.ComboBox cb_country;
        private System.Windows.Forms.NumericUpDown nb_power;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_POWER;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_target;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_session;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_selected;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.CheckBox cb_lbt;
        private System.Windows.Forms.CheckBox cb_fixed;
        private System.Windows.Forms.ComboBox cb_algorithm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusBar ts_status;
        private System.Windows.Forms.CheckBox cb_custInvtryCont;
        private System.Windows.Forms.ComboBox cb_freqlist;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cb_save;
        private System.Windows.Forms.CheckBox cb_custInvtryBlocking;
        private System.Windows.Forms.CheckBox cb_debug_log;
        private System.Windows.Forms.TabPage tp_cwonoff;
        private System.Windows.Forms.Button btn_cwon;
        private System.Windows.Forms.Button btn_cwoff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lk_antenna_port_cfg;
        private System.Windows.Forms.CheckBox cb_withData;
        private System.Windows.Forms.LinkLabel lb_detail;
        private System.Windows.Forms.NumericUpDown nb_reconnectTimeout;
        private System.Windows.Forms.Label label4;



    }
}

