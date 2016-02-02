namespace CS203DEMO
{
    partial class TagSecurityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagSecurityForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cb_kill = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_acc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_epc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_tid = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_user = new System.Windows.Forms.ComboBox();
            this.btn_kill = new System.Windows.Forms.Button();
            this.btn_setkill = new System.Windows.Forms.Button();
            this.btn_setacc = new System.Windows.Forms.Button();
            this.btn_setepc = new System.Windows.Forms.Button();
            this.btn_settid = new System.Windows.Forms.Button();
            this.btn_setuser = new System.Windows.Forms.Button();
            this.rb_target = new System.Windows.Forms.RadioButton();
            this.rb_any = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.lk_epc = new System.Windows.Forms.LinkLabel();
            this.tb_pwd = new CustomTextbox.HexOnlyTextbox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Kill Pwd";
            // 
            // cb_kill
            // 
            this.cb_kill.Items.AddRange(new object[] {
            "ACCESSIBLE",
            "ALWAYS_ACCESSIBLE",
            "SECURED_ACCESSIBLE",
            "ALWAYS_NOT_ACCESSIBLE",
            "NO_CHANGE"});
            this.cb_kill.Location = new System.Drawing.Point(66, 59);
            this.cb_kill.Name = "cb_kill";
            this.cb_kill.Size = new System.Drawing.Size(173, 20);
            this.cb_kill.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Acc Pwd";
            // 
            // cb_acc
            // 
            this.cb_acc.Items.AddRange(new object[] {
            "ACCESSIBLE",
            "ALWAYS_ACCESSIBLE",
            "SECURED_ACCESSIBLE",
            "ALWAYS_NOT_ACCESSIBLE",
            "NO_CHANGE"});
            this.cb_acc.Location = new System.Drawing.Point(66, 88);
            this.cb_acc.Name = "cb_acc";
            this.cb_acc.Size = new System.Drawing.Size(173, 20);
            this.cb_acc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "EPC";
            // 
            // cb_epc
            // 
            this.cb_epc.Items.AddRange(new object[] {
            "WRITEABLE",
            "ALWAYS_WRITEABLE",
            "SECURED_WRITEABLE",
            "ALWAYS_NOT_WRITEABLE",
            "NO_CHANGE"});
            this.cb_epc.Location = new System.Drawing.Point(66, 117);
            this.cb_epc.Name = "cb_epc";
            this.cb_epc.Size = new System.Drawing.Size(173, 20);
            this.cb_epc.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "TID";
            // 
            // cb_tid
            // 
            this.cb_tid.Items.AddRange(new object[] {
            "WRITEABLE",
            "ALWAYS_WRITEABLE",
            "SECURED_WRITEABLE",
            "ALWAYS_NOT_WRITEABLE",
            "NO_CHANGE"});
            this.cb_tid.Location = new System.Drawing.Point(66, 146);
            this.cb_tid.Name = "cb_tid";
            this.cb_tid.Size = new System.Drawing.Size(173, 20);
            this.cb_tid.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "USER";
            // 
            // cb_user
            // 
            this.cb_user.Items.AddRange(new object[] {
            "WRITEABLE",
            "ALWAYS_WRITEABLE",
            "SECURED_WRITEABLE",
            "ALWAYS_NOT_WRITEABLE",
            "NO_CHANGE"});
            this.cb_user.Location = new System.Drawing.Point(66, 175);
            this.cb_user.Name = "cb_user";
            this.cb_user.Size = new System.Drawing.Size(173, 20);
            this.cb_user.TabIndex = 3;
            // 
            // btn_kill
            // 
            this.btn_kill.BackColor = System.Drawing.Color.Red;
            this.btn_kill.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btn_kill.ForeColor = System.Drawing.Color.White;
            this.btn_kill.Location = new System.Drawing.Point(3, 204);
            this.btn_kill.Name = "btn_kill";
            this.btn_kill.Size = new System.Drawing.Size(100, 33);
            this.btn_kill.TabIndex = 8;
            this.btn_kill.Text = "Kill Tag";
            this.btn_kill.UseVisualStyleBackColor = false;
            this.btn_kill.Click += new System.EventHandler(this.btn_kill_Click);
            // 
            // btn_setkill
            // 
            this.btn_setkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btn_setkill.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_setkill.Location = new System.Drawing.Point(245, 59);
            this.btn_setkill.Name = "btn_setkill";
            this.btn_setkill.Size = new System.Drawing.Size(72, 23);
            this.btn_setkill.TabIndex = 11;
            this.btn_setkill.Text = "Set";
            this.btn_setkill.UseVisualStyleBackColor = false;
            this.btn_setkill.Click += new System.EventHandler(this.btn_setkill_Click);
            // 
            // btn_setacc
            // 
            this.btn_setacc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btn_setacc.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_setacc.Location = new System.Drawing.Point(245, 88);
            this.btn_setacc.Name = "btn_setacc";
            this.btn_setacc.Size = new System.Drawing.Size(72, 23);
            this.btn_setacc.TabIndex = 11;
            this.btn_setacc.Text = "Set";
            this.btn_setacc.UseVisualStyleBackColor = false;
            this.btn_setacc.Click += new System.EventHandler(this.btn_setacc_Click);
            // 
            // btn_setepc
            // 
            this.btn_setepc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btn_setepc.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_setepc.Location = new System.Drawing.Point(245, 117);
            this.btn_setepc.Name = "btn_setepc";
            this.btn_setepc.Size = new System.Drawing.Size(72, 23);
            this.btn_setepc.TabIndex = 11;
            this.btn_setepc.Text = "Set";
            this.btn_setepc.UseVisualStyleBackColor = false;
            this.btn_setepc.Click += new System.EventHandler(this.btn_setepc_Click);
            // 
            // btn_settid
            // 
            this.btn_settid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btn_settid.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_settid.Location = new System.Drawing.Point(245, 146);
            this.btn_settid.Name = "btn_settid";
            this.btn_settid.Size = new System.Drawing.Size(72, 23);
            this.btn_settid.TabIndex = 11;
            this.btn_settid.Text = "Set";
            this.btn_settid.UseVisualStyleBackColor = false;
            this.btn_settid.Click += new System.EventHandler(this.btn_settid_Click);
            // 
            // btn_setuser
            // 
            this.btn_setuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btn_setuser.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_setuser.Location = new System.Drawing.Point(245, 175);
            this.btn_setuser.Name = "btn_setuser";
            this.btn_setuser.Size = new System.Drawing.Size(72, 23);
            this.btn_setuser.TabIndex = 11;
            this.btn_setuser.Text = "Set";
            this.btn_setuser.UseVisualStyleBackColor = false;
            this.btn_setuser.Click += new System.EventHandler(this.btn_setuser_Click);
            // 
            // rb_target
            // 
            this.rb_target.Checked = true;
            this.rb_target.Location = new System.Drawing.Point(3, 35);
            this.rb_target.Name = "rb_target";
            this.rb_target.Size = new System.Drawing.Size(100, 20);
            this.rb_target.TabIndex = 12;
            this.rb_target.TabStop = true;
            this.rb_target.Text = "Target EPC";
            this.rb_target.Click += new System.EventHandler(this.rb_target_Click);
            // 
            // rb_any
            // 
            this.rb_any.Location = new System.Drawing.Point(91, 34);
            this.rb_any.Name = "rb_any";
            this.rb_any.Size = new System.Drawing.Size(78, 20);
            this.rb_any.TabIndex = 12;
            this.rb_any.Text = "Any EPC";
            this.rb_any.Visible = false;
            this.rb_any.Click += new System.EventHandler(this.rb_any_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(175, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "PWD";
            // 
            // lk_epc
            // 
            this.lk_epc.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Underline);
            this.lk_epc.Location = new System.Drawing.Point(3, 0);
            this.lk_epc.Name = "lk_epc";
            this.lk_epc.Size = new System.Drawing.Size(314, 32);
            this.lk_epc.TabIndex = 24;
            this.lk_epc.TabStop = true;
            this.lk_epc.Text = "Please Click Here To Select A Tag";
            this.lk_epc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lk_epc.Click += new System.EventHandler(this.lk_epc_Click);
            // 
            // tb_pwd
            // 
            this.tb_pwd.BackColor = System.Drawing.Color.White;
            this.tb_pwd.BackgroundText = null;
            this.tb_pwd.ForeColor = System.Drawing.Color.Gray;
            this.tb_pwd.Location = new System.Drawing.Point(217, 35);
            this.tb_pwd.MaxLength = 8;
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.Size = new System.Drawing.Size(100, 22);
            this.tb_pwd.TabIndex = 18;
            // 
            // TagSecurityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.lk_epc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.rb_any);
            this.Controls.Add(this.rb_target);
            this.Controls.Add(this.btn_setuser);
            this.Controls.Add(this.btn_settid);
            this.Controls.Add(this.btn_setepc);
            this.Controls.Add(this.btn_setacc);
            this.Controls.Add(this.btn_setkill);
            this.Controls.Add(this.btn_kill);
            this.Controls.Add(this.cb_user);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_tid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_epc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_acc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_kill);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagSecurityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tag Security";
            this.Load += new System.EventHandler(this.TagSecurityForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TagSecurityForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_kill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_acc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_epc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_tid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_user;
        private System.Windows.Forms.Button btn_kill;
        private System.Windows.Forms.Button btn_setkill;
        private System.Windows.Forms.Button btn_setacc;
        private System.Windows.Forms.Button btn_setepc;
        private System.Windows.Forms.Button btn_settid;
        private System.Windows.Forms.Button btn_setuser;
        private System.Windows.Forms.RadioButton rb_target;
        private System.Windows.Forms.RadioButton rb_any;
        private CustomTextbox.HexOnlyTextbox tb_pwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lk_epc;
    }
}