namespace CS203_Example_Code
{
    partial class SelfTestForm
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
            this.btn_start = new System.Windows.Forms.Button();
            this.cb_acc = new System.Windows.Forms.CheckBox();
            this.cb_kill = new System.Windows.Forms.CheckBox();
            this.cb_pc = new System.Windows.Forms.CheckBox();
            this.cb_epc = new System.Windows.Forms.CheckBox();
            this.cb_tid = new System.Windows.Forms.CheckBox();
            this.cb_user = new System.Windows.Forms.CheckBox();
            this.lb_status_acc = new System.Windows.Forms.Label();
            this.lb_status_kill = new System.Windows.Forms.Label();
            this.lb_status_pc = new System.Windows.Forms.Label();
            this.lb_status_epc = new System.Windows.Forms.Label();
            this.lb_status_tid = new System.Windows.Forms.Label();
            this.lb_status_user = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Green;
            this.btn_start.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(157, 159);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(158, 33);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start Test";
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cb_acc
            // 
            this.cb_acc.Checked = true;
            this.cb_acc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_acc.Location = new System.Drawing.Point(13, 3);
            this.cb_acc.Name = "cb_acc";
            this.cb_acc.Size = new System.Drawing.Size(211, 20);
            this.cb_acc.TabIndex = 1;
            this.cb_acc.Text = "Read Write Access Password";
            this.cb_acc.CheckStateChanged += new System.EventHandler(this.cb_acc_CheckStateChanged);
            // 
            // cb_kill
            // 
            this.cb_kill.Checked = true;
            this.cb_kill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_kill.Location = new System.Drawing.Point(13, 29);
            this.cb_kill.Name = "cb_kill";
            this.cb_kill.Size = new System.Drawing.Size(185, 20);
            this.cb_kill.TabIndex = 1;
            this.cb_kill.Text = "Read Write Kill Password";
            this.cb_kill.CheckStateChanged += new System.EventHandler(this.cb_kill_CheckStateChanged);
            // 
            // cb_pc
            // 
            this.cb_pc.Checked = true;
            this.cb_pc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_pc.Location = new System.Drawing.Point(13, 55);
            this.cb_pc.Name = "cb_pc";
            this.cb_pc.Size = new System.Drawing.Size(159, 20);
            this.cb_pc.TabIndex = 1;
            this.cb_pc.Text = "Read Write PC";
            this.cb_pc.CheckStateChanged += new System.EventHandler(this.cb_pc_CheckStateChanged);
            // 
            // cb_epc
            // 
            this.cb_epc.Checked = true;
            this.cb_epc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_epc.Location = new System.Drawing.Point(13, 81);
            this.cb_epc.Name = "cb_epc";
            this.cb_epc.Size = new System.Drawing.Size(174, 20);
            this.cb_epc.TabIndex = 1;
            this.cb_epc.Text = "Read Write EPC";
            this.cb_epc.CheckStateChanged += new System.EventHandler(this.cb_epc_CheckStateChanged);
            // 
            // cb_tid
            // 
            this.cb_tid.Checked = true;
            this.cb_tid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_tid.Location = new System.Drawing.Point(13, 107);
            this.cb_tid.Name = "cb_tid";
            this.cb_tid.Size = new System.Drawing.Size(100, 20);
            this.cb_tid.TabIndex = 1;
            this.cb_tid.Text = "Read Tid";
            this.cb_tid.CheckStateChanged += new System.EventHandler(this.cb_tid_CheckStateChanged);
            // 
            // cb_user
            // 
            this.cb_user.Checked = true;
            this.cb_user.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_user.Location = new System.Drawing.Point(13, 133);
            this.cb_user.Name = "cb_user";
            this.cb_user.Size = new System.Drawing.Size(185, 20);
            this.cb_user.TabIndex = 1;
            this.cb_user.Text = "Read Write User Memory";
            this.cb_user.CheckStateChanged += new System.EventHandler(this.cb_user_CheckStateChanged);
            // 
            // lb_status_acc
            // 
            this.lb_status_acc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_status_acc.ForeColor = System.Drawing.Color.Red;
            this.lb_status_acc.Location = new System.Drawing.Point(230, 3);
            this.lb_status_acc.Name = "lb_status_acc";
            this.lb_status_acc.Size = new System.Drawing.Size(85, 20);
            this.lb_status_acc.Text = "Not Done";
            // 
            // lb_status_kill
            // 
            this.lb_status_kill.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_status_kill.ForeColor = System.Drawing.Color.Red;
            this.lb_status_kill.Location = new System.Drawing.Point(230, 29);
            this.lb_status_kill.Name = "lb_status_kill";
            this.lb_status_kill.Size = new System.Drawing.Size(85, 20);
            this.lb_status_kill.Text = "Not Done";
            // 
            // lb_status_pc
            // 
            this.lb_status_pc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_status_pc.ForeColor = System.Drawing.Color.Red;
            this.lb_status_pc.Location = new System.Drawing.Point(230, 55);
            this.lb_status_pc.Name = "lb_status_pc";
            this.lb_status_pc.Size = new System.Drawing.Size(85, 20);
            this.lb_status_pc.Text = "Not Done";
            // 
            // lb_status_epc
            // 
            this.lb_status_epc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_status_epc.ForeColor = System.Drawing.Color.Red;
            this.lb_status_epc.Location = new System.Drawing.Point(230, 81);
            this.lb_status_epc.Name = "lb_status_epc";
            this.lb_status_epc.Size = new System.Drawing.Size(85, 20);
            this.lb_status_epc.Text = "Not Done";
            // 
            // lb_status_tid
            // 
            this.lb_status_tid.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_status_tid.ForeColor = System.Drawing.Color.Red;
            this.lb_status_tid.Location = new System.Drawing.Point(230, 107);
            this.lb_status_tid.Name = "lb_status_tid";
            this.lb_status_tid.Size = new System.Drawing.Size(85, 20);
            this.lb_status_tid.Text = "Not Done";
            // 
            // lb_status_user
            // 
            this.lb_status_user.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_status_user.ForeColor = System.Drawing.Color.Red;
            this.lb_status_user.Location = new System.Drawing.Point(230, 133);
            this.lb_status_user.Name = "lb_status_user";
            this.lb_status_user.Size = new System.Drawing.Size(85, 20);
            this.lb_status_user.Text = "Not Done";
            // 
            // SelfTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(318, 195);
            this.Controls.Add(this.lb_status_user);
            this.Controls.Add(this.lb_status_tid);
            this.Controls.Add(this.lb_status_epc);
            this.Controls.Add(this.lb_status_pc);
            this.Controls.Add(this.lb_status_kill);
            this.Controls.Add(this.lb_status_acc);
            this.Controls.Add(this.cb_user);
            this.Controls.Add(this.cb_tid);
            this.Controls.Add(this.cb_epc);
            this.Controls.Add(this.cb_pc);
            this.Controls.Add(this.cb_kill);
            this.Controls.Add(this.cb_acc);
            this.Controls.Add(this.btn_start);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelfTestForm";
            this.Text = "SelfTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.CheckBox cb_acc;
        private System.Windows.Forms.CheckBox cb_kill;
        private System.Windows.Forms.CheckBox cb_pc;
        private System.Windows.Forms.CheckBox cb_epc;
        private System.Windows.Forms.CheckBox cb_tid;
        private System.Windows.Forms.CheckBox cb_user;
        private System.Windows.Forms.Label lb_status_acc;
        private System.Windows.Forms.Label lb_status_kill;
        private System.Windows.Forms.Label lb_status_pc;
        private System.Windows.Forms.Label lb_status_epc;
        private System.Windows.Forms.Label lb_status_tid;
        private System.Windows.Forms.Label lb_status_user;
    }
}