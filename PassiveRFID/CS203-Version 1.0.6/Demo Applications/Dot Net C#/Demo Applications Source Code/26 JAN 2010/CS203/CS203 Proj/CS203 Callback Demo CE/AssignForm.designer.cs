namespace CS203_CALLBACK_API_DEMO_CE
{
    partial class AssignForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_assign = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nb_timeout = new System.Windows.Forms.NumericUpDown();
            this.ipTextBox1 = new CS203_CALLBACK_API_DEMO_CE.IPTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_devicename = new System.Windows.Forms.TextBox();
            this.cb_dhcp = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nb_timeout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.Text = "CS203 IP";
            // 
            // btn_assign
            // 
            this.btn_assign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_assign.Location = new System.Drawing.Point(223, 68);
            this.btn_assign.Name = "btn_assign";
            this.btn_assign.Size = new System.Drawing.Size(83, 28);
            this.btn_assign.TabIndex = 2;
            this.btn_assign.Text = "Assign";
            this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(-2, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.Text = "Timeout";
            // 
            // nb_timeout
            // 
            this.nb_timeout.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular);
            this.nb_timeout.Location = new System.Drawing.Point(68, 71);
            this.nb_timeout.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nb_timeout.Name = "nb_timeout";
            this.nb_timeout.Size = new System.Drawing.Size(52, 25);
            this.nb_timeout.TabIndex = 3;
            // 
            // ipTextBox1
            // 
            this.ipTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ipTextBox1.IP = "192.168.25.203";
            this.ipTextBox1.Location = new System.Drawing.Point(80, 6);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.Size = new System.Drawing.Size(226, 25);
            this.ipTextBox1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(-2, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.Text = "Device Name";
            // 
            // tb_devicename
            // 
            this.tb_devicename.Location = new System.Drawing.Point(107, 42);
            this.tb_devicename.MaxLength = 31;
            this.tb_devicename.Name = "tb_devicename";
            this.tb_devicename.Size = new System.Drawing.Size(199, 22);
            this.tb_devicename.TabIndex = 4;
            // 
            // cb_dhcp
            // 
            this.cb_dhcp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.cb_dhcp.Location = new System.Drawing.Point(144, 72);
            this.cb_dhcp.Name = "cb_dhcp";
            this.cb_dhcp.Size = new System.Drawing.Size(73, 22);
            this.cb_dhcp.TabIndex = 5;
            this.cb_dhcp.Text = "DHCP";
            this.cb_dhcp.CheckStateChanged += new System.EventHandler(this.cb_dhcp_CheckedChanged);
            // 
            // AssignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(310, 108);
            this.Controls.Add(this.cb_dhcp);
            this.Controls.Add(this.tb_devicename);
            this.Controls.Add(this.nb_timeout);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignForm";
            this.Text = "Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.nb_timeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IPTextBox ipTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_assign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nb_timeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_devicename;
        private System.Windows.Forms.CheckBox cb_dhcp;
    }
}