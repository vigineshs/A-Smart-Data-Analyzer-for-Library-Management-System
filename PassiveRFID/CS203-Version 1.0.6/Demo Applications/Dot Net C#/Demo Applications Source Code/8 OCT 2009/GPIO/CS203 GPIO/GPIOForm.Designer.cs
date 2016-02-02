namespace CS203_GPIO
{
    partial class GPIOForm
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
            this.components = new System.ComponentModel.Container();
            this.lk_gpi0 = new System.Windows.Forms.LinkLabel();
            this.lk_gpi1 = new System.Windows.Forms.LinkLabel();
            this.lk_gpo0 = new System.Windows.Forms.LinkLabel();
            this.lk_gpo1 = new System.Windows.Forms.LinkLabel();
            this.lk_led = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_conn = new System.Windows.Forms.Button();
            this.refresh_tmr = new System.Windows.Forms.Timer(this.components);
            this.lb_status = new System.Windows.Forms.Label();
            this.ipTextBox1 = new CS203_GPIO.IPTextBox();
            this.hl_led = new CS203_GPIO.ONOFF();
            this.hl_gpo1 = new CS203_GPIO.ONOFF();
            this.hl_gpo0 = new CS203_GPIO.ONOFF();
            this.hl_gpi1 = new CS203_GPIO.ONOFF();
            this.hl_gpi0 = new CS203_GPIO.ONOFF();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lk_gpi0
            // 
            this.lk_gpi0.AutoSize = true;
            this.lk_gpi0.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lk_gpi0.Location = new System.Drawing.Point(3, 9);
            this.lk_gpi0.Name = "lk_gpi0";
            this.lk_gpi0.Size = new System.Drawing.Size(51, 19);
            this.lk_gpi0.TabIndex = 1;
            this.lk_gpi0.TabStop = true;
            this.lk_gpi0.Text = "GPI:0";
            // 
            // lk_gpi1
            // 
            this.lk_gpi1.AutoSize = true;
            this.lk_gpi1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lk_gpi1.Location = new System.Drawing.Point(3, 60);
            this.lk_gpi1.Name = "lk_gpi1";
            this.lk_gpi1.Size = new System.Drawing.Size(51, 19);
            this.lk_gpi1.TabIndex = 1;
            this.lk_gpi1.TabStop = true;
            this.lk_gpi1.Text = "GPI:1";
            // 
            // lk_gpo0
            // 
            this.lk_gpo0.AutoSize = true;
            this.lk_gpo0.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lk_gpo0.Location = new System.Drawing.Point(3, 111);
            this.lk_gpo0.Name = "lk_gpo0";
            this.lk_gpo0.Size = new System.Drawing.Size(59, 19);
            this.lk_gpo0.TabIndex = 1;
            this.lk_gpo0.TabStop = true;
            this.lk_gpo0.Text = "GPO:0";
            // 
            // lk_gpo1
            // 
            this.lk_gpo1.AutoSize = true;
            this.lk_gpo1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lk_gpo1.Location = new System.Drawing.Point(3, 162);
            this.lk_gpo1.Name = "lk_gpo1";
            this.lk_gpo1.Size = new System.Drawing.Size(59, 19);
            this.lk_gpo1.TabIndex = 1;
            this.lk_gpo1.TabStop = true;
            this.lk_gpo1.Text = "GPO:1";
            // 
            // lk_led
            // 
            this.lk_led.AutoSize = true;
            this.lk_led.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lk_led.Location = new System.Drawing.Point(3, 213);
            this.lk_led.Name = "lk_led";
            this.lk_led.Size = new System.Drawing.Size(42, 19);
            this.lk_led.TabIndex = 1;
            this.lk_led.TabStop = true;
            this.lk_led.Text = "LED";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.lk_led);
            this.splitContainer1.Panel1.Controls.Add(this.lk_gpi0);
            this.splitContainer1.Panel1.Controls.Add(this.lk_gpo1);
            this.splitContainer1.Panel1.Controls.Add(this.lk_gpi1);
            this.splitContainer1.Panel1.Controls.Add(this.lk_gpo0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.hl_led);
            this.splitContainer1.Panel2.Controls.Add(this.hl_gpo1);
            this.splitContainer1.Panel2.Controls.Add(this.hl_gpo0);
            this.splitContainer1.Panel2.Controls.Add(this.hl_gpi1);
            this.splitContainer1.Panel2.Controls.Add(this.hl_gpi0);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Size = new System.Drawing.Size(308, 242);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.TabIndex = 2;
            // 
            // btn_conn
            // 
            this.btn_conn.BackColor = System.Drawing.Color.Green;
            this.btn_conn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conn.ForeColor = System.Drawing.Color.White;
            this.btn_conn.Location = new System.Drawing.Point(12, 260);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(85, 27);
            this.btn_conn.TabIndex = 3;
            this.btn_conn.Text = "Connect";
            this.btn_conn.UseVisualStyleBackColor = false;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // refresh_tmr
            // 
            this.refresh_tmr.Interval = 500;
            this.refresh_tmr.Tick += new System.EventHandler(this.refresh_tmr_Tick);
            // 
            // lb_status
            // 
            this.lb_status.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.ForeColor = System.Drawing.Color.Red;
            this.lb_status.Location = new System.Drawing.Point(237, 263);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(83, 23);
            this.lb_status.TabIndex = 5;
            // 
            // ipTextBox1
            // 
            this.ipTextBox1.IP = "192.168.25.203";
            this.ipTextBox1.Location = new System.Drawing.Point(103, 263);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.Size = new System.Drawing.Size(128, 18);
            this.ipTextBox1.TabIndex = 4;
            this.ipTextBox1.ToolTipText = "Change IP Here";
            // 
            // hl_led
            // 
            this.hl_led.Location = new System.Drawing.Point(31, 211);
            this.hl_led.Name = "hl_led";
            this.hl_led.ON = false;
            this.hl_led.ReadOnly = false;
            this.hl_led.Size = new System.Drawing.Size(119, 21);
            this.hl_led.TabIndex = 0;
            this.hl_led.OnTriggerEvt += new System.EventHandler(this.hl_led_OnTriggerEvt);
            // 
            // hl_gpo1
            // 
            this.hl_gpo1.Location = new System.Drawing.Point(31, 160);
            this.hl_gpo1.Name = "hl_gpo1";
            this.hl_gpo1.ON = false;
            this.hl_gpo1.ReadOnly = false;
            this.hl_gpo1.Size = new System.Drawing.Size(119, 21);
            this.hl_gpo1.TabIndex = 0;
            this.hl_gpo1.OnTriggerEvt += new System.EventHandler(this.hl_gpo1_OnTriggerEvt);
            // 
            // hl_gpo0
            // 
            this.hl_gpo0.Location = new System.Drawing.Point(31, 109);
            this.hl_gpo0.Name = "hl_gpo0";
            this.hl_gpo0.ON = false;
            this.hl_gpo0.ReadOnly = false;
            this.hl_gpo0.Size = new System.Drawing.Size(119, 21);
            this.hl_gpo0.TabIndex = 0;
            this.hl_gpo0.OnTriggerEvt += new System.EventHandler(this.hl_gpo0_OnTriggerEvt);
            // 
            // hl_gpi1
            // 
            this.hl_gpi1.Location = new System.Drawing.Point(31, 58);
            this.hl_gpi1.Name = "hl_gpi1";
            this.hl_gpi1.ON = false;
            this.hl_gpi1.ReadOnly = true;
            this.hl_gpi1.Size = new System.Drawing.Size(119, 21);
            this.hl_gpi1.TabIndex = 0;
            // 
            // hl_gpi0
            // 
            this.hl_gpi0.Location = new System.Drawing.Point(31, 7);
            this.hl_gpi0.Name = "hl_gpi0";
            this.hl_gpi0.ON = false;
            this.hl_gpi0.ReadOnly = true;
            this.hl_gpi0.Size = new System.Drawing.Size(119, 21);
            this.hl_gpi0.TabIndex = 0;
            // 
            // GPIOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(332, 293);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.ipTextBox1);
            this.Controls.Add(this.btn_conn);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPIOForm";
            this.Text = "GPIO";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ONOFF hl_gpi0;
        private System.Windows.Forms.LinkLabel lk_gpi0;
        private System.Windows.Forms.LinkLabel lk_gpi1;
        private System.Windows.Forms.LinkLabel lk_gpo0;
        private System.Windows.Forms.LinkLabel lk_gpo1;
        private System.Windows.Forms.LinkLabel lk_led;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ONOFF hl_led;
        private ONOFF hl_gpo1;
        private ONOFF hl_gpo0;
        private ONOFF hl_gpi1;
        private System.Windows.Forms.Button btn_conn;
        private IPTextBox ipTextBox1;
        private System.Windows.Forms.Timer refresh_tmr;
        private System.Windows.Forms.Label lb_status;

    }
}

