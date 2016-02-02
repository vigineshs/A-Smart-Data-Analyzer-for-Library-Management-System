namespace CS203DEMO
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cb_fixed = new System.Windows.Forms.CheckBox();
            this.cb_lbt = new System.Windows.Forms.CheckBox();
            this.cb_linkprofile = new System.Windows.Forms.ComboBox();
            this.lv_frequ = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.cb_country = new System.Windows.Forms.ComboBox();
            this.nb_hour = new System.Windows.Forms.NumericUpDown();
            this.nb_cycle = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nb_dwell = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nb_power = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_POWER = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gb_singulation = new System.Windows.Forms.GroupBox();
            this.cb_algorithm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_taggroup = new System.Windows.Forms.GroupBox();
            this.cb_target = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_session = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_selected = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_operation = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_userID = new System.Windows.Forms.TextBox();
            this.tb_dbName = new System.Windows.Forms.TextBox();
            this.tb_serverName = new System.Windows.Forms.TextBox();
            this.tb_serverIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_apply = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_cycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_dwell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_power)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gb_singulation.SuspendLayout();
            this.gb_taggroup.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(474, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts_status
            // 
            this.ts_status.BackColor = System.Drawing.SystemColors.Control;
            this.ts_status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_status.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_status.ForeColor = System.Drawing.Color.Red;
            this.ts_status.Name = "ts_status";
            this.ts_status.Size = new System.Drawing.Size(58, 19);
            this.ts_status.Text = "Status";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(474, 364);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cb_fixed);
            this.tabPage1.Controls.Add(this.cb_lbt);
            this.tabPage1.Controls.Add(this.cb_linkprofile);
            this.tabPage1.Controls.Add(this.lv_frequ);
            this.tabPage1.Controls.Add(this.cb_country);
            this.tabPage1.Controls.Add(this.nb_hour);
            this.tabPage1.Controls.Add(this.nb_cycle);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.nb_dwell);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.nb_power);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lb_POWER);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(466, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gerenal Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cb_fixed
            // 
            this.cb_fixed.AutoSize = true;
            this.cb_fixed.Location = new System.Drawing.Point(258, 44);
            this.cb_fixed.Name = "cb_fixed";
            this.cb_fixed.Size = new System.Drawing.Size(92, 16);
            this.cb_fixed.TabIndex = 73;
            this.cb_fixed.Text = "Fixed Channel";
            this.cb_fixed.UseVisualStyleBackColor = true;
            this.cb_fixed.CheckedChanged += new System.EventHandler(this.cb_fixed_CheckedChanged);
            // 
            // cb_lbt
            // 
            this.cb_lbt.AutoSize = true;
            this.cb_lbt.Location = new System.Drawing.Point(258, 14);
            this.cb_lbt.Name = "cb_lbt";
            this.cb_lbt.Size = new System.Drawing.Size(46, 16);
            this.cb_lbt.TabIndex = 73;
            this.cb_lbt.Text = "LBT";
            this.cb_lbt.UseVisualStyleBackColor = true;
            // 
            // cb_linkprofile
            // 
            this.cb_linkprofile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_linkprofile.FormattingEnabled = true;
            this.cb_linkprofile.Location = new System.Drawing.Point(72, 10);
            this.cb_linkprofile.Name = "cb_linkprofile";
            this.cb_linkprofile.Size = new System.Drawing.Size(97, 20);
            this.cb_linkprofile.TabIndex = 71;
            // 
            // lv_frequ
            // 
            this.lv_frequ.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_frequ.FullRowSelect = true;
            this.lv_frequ.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_frequ.HideSelection = false;
            this.lv_frequ.Location = new System.Drawing.Point(8, 194);
            this.lv_frequ.Name = "lv_frequ";
            this.lv_frequ.Size = new System.Drawing.Size(224, 139);
            this.lv_frequ.TabIndex = 65;
            this.lv_frequ.UseCompatibleStateImageBehavior = false;
            this.lv_frequ.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Channel";
            this.columnHeader1.Width = 77;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Frequency";
            this.columnHeader2.Width = 142;
            // 
            // cb_country
            // 
            this.cb_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_country.Location = new System.Drawing.Point(72, 70);
            this.cb_country.Name = "cb_country";
            this.cb_country.Size = new System.Drawing.Size(97, 20);
            this.cb_country.TabIndex = 64;
            this.cb_country.SelectedIndexChanged += new System.EventHandler(this.cb_country_SelectedIndexChanged);
            // 
            // nb_hour
            // 
            this.nb_hour.Location = new System.Drawing.Point(258, 138);
            this.nb_hour.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nb_hour.Name = "nb_hour";
            this.nb_hour.Size = new System.Drawing.Size(97, 22);
            this.nb_hour.TabIndex = 63;
            // 
            // nb_cycle
            // 
            this.nb_cycle.Enabled = false;
            this.nb_cycle.Location = new System.Drawing.Point(72, 138);
            this.nb_cycle.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nb_cycle.Name = "nb_cycle";
            this.nb_cycle.Size = new System.Drawing.Size(97, 22);
            this.nb_cycle.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(256, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 20);
            this.label10.TabIndex = 70;
            this.label10.Text = "Auto Reset trial time(hour)";
            // 
            // nb_dwell
            // 
            this.nb_dwell.Enabled = false;
            this.nb_dwell.Location = new System.Drawing.Point(72, 102);
            this.nb_dwell.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nb_dwell.Name = "nb_dwell";
            this.nb_dwell.Size = new System.Drawing.Size(97, 22);
            this.nb_dwell.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 70;
            this.label4.Text = "Cycle";
            // 
            // nb_power
            // 
            this.nb_power.Location = new System.Drawing.Point(72, 42);
            this.nb_power.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nb_power.Name = "nb_power";
            this.nb_power.Size = new System.Drawing.Size(97, 22);
            this.nb_power.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Dwell";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "Country";
            // 
            // lb_POWER
            // 
            this.lb_POWER.Location = new System.Drawing.Point(11, 44);
            this.lb_POWER.Name = "lb_POWER";
            this.lb_POWER.Size = new System.Drawing.Size(56, 20);
            this.lb_POWER.TabIndex = 67;
            this.lb_POWER.Text = "Power";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 69;
            this.label3.Text = "Profile";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gb_singulation);
            this.tabPage2.Controls.Add(this.gb_taggroup);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cb_operation);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(466, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inventory";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gb_singulation
            // 
            this.gb_singulation.Controls.Add(this.cb_algorithm);
            this.gb_singulation.Controls.Add(this.label5);
            this.gb_singulation.Location = new System.Drawing.Point(8, 141);
            this.gb_singulation.Name = "gb_singulation";
            this.gb_singulation.Size = new System.Drawing.Size(344, 187);
            this.gb_singulation.TabIndex = 7;
            this.gb_singulation.TabStop = false;
            this.gb_singulation.Text = "Singulation";
            // 
            // cb_algorithm
            // 
            this.cb_algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_algorithm.FormattingEnabled = true;
            this.cb_algorithm.Location = new System.Drawing.Point(93, 21);
            this.cb_algorithm.Name = "cb_algorithm";
            this.cb_algorithm.Size = new System.Drawing.Size(132, 20);
            this.cb_algorithm.TabIndex = 1;
            this.cb_algorithm.SelectedIndexChanged += new System.EventHandler(this.cb_algorithm_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Algorithm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_taggroup
            // 
            this.gb_taggroup.Controls.Add(this.cb_target);
            this.gb_taggroup.Controls.Add(this.label6);
            this.gb_taggroup.Controls.Add(this.cb_session);
            this.gb_taggroup.Controls.Add(this.label7);
            this.gb_taggroup.Controls.Add(this.cb_selected);
            this.gb_taggroup.Controls.Add(this.label8);
            this.gb_taggroup.Location = new System.Drawing.Point(8, 32);
            this.gb_taggroup.Name = "gb_taggroup";
            this.gb_taggroup.Size = new System.Drawing.Size(344, 103);
            this.gb_taggroup.TabIndex = 6;
            this.gb_taggroup.TabStop = false;
            this.gb_taggroup.Text = "TagGroup";
            // 
            // cb_target
            // 
            this.cb_target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_target.FormattingEnabled = true;
            this.cb_target.Location = new System.Drawing.Point(93, 70);
            this.cb_target.Name = "cb_target";
            this.cb_target.Size = new System.Drawing.Size(132, 20);
            this.cb_target.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Target";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_session
            // 
            this.cb_session.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_session.FormattingEnabled = true;
            this.cb_session.Location = new System.Drawing.Point(93, 44);
            this.cb_session.Name = "cb_session";
            this.cb_session.Size = new System.Drawing.Size(132, 20);
            this.cb_session.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Session";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_selected
            // 
            this.cb_selected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_selected.FormattingEnabled = true;
            this.cb_selected.Location = new System.Drawing.Point(93, 18);
            this.cb_selected.Name = "cb_selected";
            this.cb_selected.Size = new System.Drawing.Size(132, 20);
            this.cb_selected.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Selected";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(14, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 23);
            this.label9.TabIndex = 5;
            this.label9.Text = "Operation";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_operation
            // 
            this.cb_operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_operation.FormattingEnabled = true;
            this.cb_operation.Location = new System.Drawing.Point(101, 9);
            this.cb_operation.Name = "cb_operation";
            this.cb_operation.Size = new System.Drawing.Size(132, 20);
            this.cb_operation.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tb_password);
            this.tabPage3.Controls.Add(this.tb_userID);
            this.tabPage3.Controls.Add(this.tb_dbName);
            this.tabPage3.Controls.Add(this.tb_serverName);
            this.tabPage3.Controls.Add(this.tb_serverIP);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(466, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SQL database";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(122, 125);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(212, 22);
            this.tb_password.TabIndex = 80;
            // 
            // tb_userID
            // 
            this.tb_userID.Location = new System.Drawing.Point(122, 97);
            this.tb_userID.Name = "tb_userID";
            this.tb_userID.Size = new System.Drawing.Size(212, 22);
            this.tb_userID.TabIndex = 79;
            // 
            // tb_dbName
            // 
            this.tb_dbName.Location = new System.Drawing.Point(122, 69);
            this.tb_dbName.Name = "tb_dbName";
            this.tb_dbName.Size = new System.Drawing.Size(212, 22);
            this.tb_dbName.TabIndex = 78;
            // 
            // tb_serverName
            // 
            this.tb_serverName.Location = new System.Drawing.Point(122, 41);
            this.tb_serverName.Name = "tb_serverName";
            this.tb_serverName.Size = new System.Drawing.Size(212, 22);
            this.tb_serverName.TabIndex = 77;
            // 
            // tb_serverIP
            // 
            this.tb_serverIP.Location = new System.Drawing.Point(122, 10);
            this.tb_serverIP.Name = "tb_serverIP";
            this.tb_serverIP.Size = new System.Drawing.Size(212, 22);
            this.tb_serverIP.TabIndex = 76;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(14, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 20);
            this.label11.TabIndex = 75;
            this.label11.Text = "Password";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(14, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 20);
            this.label12.TabIndex = 73;
            this.label12.Text = "User ID";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(14, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 20);
            this.label13.TabIndex = 71;
            this.label13.Text = "Database Name";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(14, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 20);
            this.label14.TabIndex = 72;
            this.label14.Text = "Server Name";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(14, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 20);
            this.label15.TabIndex = 74;
            this.label15.Text = "Server IP";
            // 
            // btn_apply
            // 
            this.btn_apply.BackColor = System.Drawing.Color.Transparent;
            this.btn_apply.Location = new System.Drawing.Point(399, 364);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_apply.TabIndex = 3;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = false;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(474, 388);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_cycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_dwell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_power)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.gb_singulation.ResumeLayout(false);
            this.gb_taggroup.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ts_status;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cb_linkprofile;
        private System.Windows.Forms.ListView lv_frequ;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox cb_country;
        private System.Windows.Forms.NumericUpDown nb_cycle;
        private System.Windows.Forms.NumericUpDown nb_dwell;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nb_power;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_POWER;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gb_singulation;
        private System.Windows.Forms.ComboBox cb_algorithm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gb_taggroup;
        private System.Windows.Forms.ComboBox cb_target;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_session;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_selected;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_operation;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.CheckBox cb_lbt;
        private System.Windows.Forms.CheckBox cb_fixed;
        private System.Windows.Forms.NumericUpDown nb_hour;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_userID;
        private System.Windows.Forms.TextBox tb_dbName;
        private System.Windows.Forms.TextBox tb_serverName;
        private System.Windows.Forms.TextBox tb_serverIP;



    }
}

