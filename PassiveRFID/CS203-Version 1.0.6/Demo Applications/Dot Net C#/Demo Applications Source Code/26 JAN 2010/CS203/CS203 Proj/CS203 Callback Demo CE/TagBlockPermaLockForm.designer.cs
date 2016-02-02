namespace CS203_CALLBACK_API_DEMO_CE
{
    partial class TagBlockPermaLockForm
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
            this.lb_epc = new System.Windows.Forms.LinkLabel();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_lock = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lv_lock = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_password = new Custom.Control.HexOnlyTextbox();
            this.SuspendLayout();
            // 
            // lb_epc
            // 
            this.lb_epc.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular);
            this.lb_epc.Location = new System.Drawing.Point(12, 9);
            this.lb_epc.Name = "lb_epc";
            this.lb_epc.Size = new System.Drawing.Size(294, 23);
            this.lb_epc.TabIndex = 0;
            this.lb_epc.Text = "Please click here to select a tag";
            this.lb_epc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lb_epc.Click += new System.EventHandler(this.lb_epc_Click);
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(12, 160);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(75, 23);
            this.btn_read.TabIndex = 4;
            this.btn_read.Text = "Read";
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_lock
            // 
            this.btn_lock.Location = new System.Drawing.Point(12, 203);
            this.btn_lock.Name = "btn_lock";
            this.btn_lock.Size = new System.Drawing.Size(75, 23);
            this.btn_lock.TabIndex = 4;
            this.btn_lock.Text = "Lock";
            this.btn_lock.Click += new System.EventHandler(this.btn_lock_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(93, 203);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Exit";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 23);
            this.label4.Text = "Access Password";
            // 
            // lv_lock
            // 
            this.lv_lock.CheckBoxes = true;
            this.lv_lock.Columns.Add(this.columnHeader1);
            this.lv_lock.Columns.Add(this.columnHeader2);
            this.lv_lock.FullRowSelect = true;
            this.lv_lock.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_lock.Location = new System.Drawing.Point(174, 35);
            this.lv_lock.Name = "lv_lock";
            this.lv_lock.Size = new System.Drawing.Size(143, 191);
            this.lv_lock.TabIndex = 9;
            this.lv_lock.View = System.Windows.Forms.View.Details;
            this.lv_lock.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lv_lock_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Block";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Locked";
            this.columnHeader2.Width = 80;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 62);
            this.label1.Text = "512 bit User memory Permalock, with 64 bit block-size";
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.LightPink;
            this.tb_password.BackgroundText = null;
            this.tb_password.FontColor = System.Drawing.Color.Black;
            this.tb_password.ForeColor = System.Drawing.Color.Black;
            this.tb_password.Location = new System.Drawing.Point(12, 123);
            this.tb_password.MaxLength = 8;
            this.tb_password.Name = "tb_password";
            this.tb_password.PaddingZero = true;
            this.tb_password.Size = new System.Drawing.Size(141, 23);
            this.tb_password.TabIndex = 6;
            this.tb_password.Text = "00000000";
            // 
            // TagBlockPermaLockForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_lock);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_lock);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.lb_epc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TagBlockPermaLockForm";
            this.Text = "TagBlockPermaLockForm";
            this.Load += new System.EventHandler(this.TagBlockPermaLockForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TagBlockPermaLockForm_Closing);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.LinkLabel lb_epc;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_lock;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label4;
        private Custom.Control.HexOnlyTextbox tb_password;
        private System.Windows.Forms.ListView lv_lock;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
    }
}