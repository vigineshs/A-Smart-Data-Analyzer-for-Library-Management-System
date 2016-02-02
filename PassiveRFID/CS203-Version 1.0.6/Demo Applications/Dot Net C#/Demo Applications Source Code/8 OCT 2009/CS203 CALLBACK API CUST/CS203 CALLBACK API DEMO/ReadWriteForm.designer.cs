namespace CS203DEMO
{
    partial class ReadWriteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadWriteForm));
            this.btn_readkill = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.pn_custread = new System.Windows.Forms.Panel();
            this.btn_readuser = new System.Windows.Forms.Button();
            this.btn_readtid = new System.Windows.Forms.Button();
            this.btn_readepc = new System.Windows.Forms.Button();
            this.btn_readpc = new System.Windows.Forms.Button();
            this.btn_readacc = new System.Windows.Forms.Button();
            this.pn_basicread = new System.Windows.Forms.Panel();
            this.rb_write = new System.Windows.Forms.RadioButton();
            this.rb_read = new System.Windows.Forms.RadioButton();
            this.cb_memBank = new System.Windows.Forms.ComboBox();
            this.nb_count = new System.Windows.Forms.NumericUpDown();
            this.nb_offset = new System.Windows.Forms.NumericUpDown();
            this.btn_read = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_epc = new System.Windows.Forms.LinkLabel();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_cread = new System.Windows.Forms.Button();
            this.pn_custread.SuspendLayout();
            this.pn_basicread.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_offset)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_readkill
            // 
            this.btn_readkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_readkill.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readkill.Location = new System.Drawing.Point(3, 7);
            this.btn_readkill.Name = "btn_readkill";
            this.btn_readkill.Size = new System.Drawing.Size(60, 20);
            this.btn_readkill.TabIndex = 0;
            this.btn_readkill.Text = "KILL";
            this.btn_readkill.UseVisualStyleBackColor = false;
            this.btn_readkill.Click += new System.EventHandler(this.btn_readkill_Click);
            // 
            // tb_log
            // 
            this.tb_log.BackColor = System.Drawing.SystemColors.Info;
            this.tb_log.Location = new System.Drawing.Point(0, 0);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(320, 123);
            this.tb_log.TabIndex = 1;
            // 
            // pn_custread
            // 
            this.pn_custread.BackColor = System.Drawing.SystemColors.Info;
            this.pn_custread.Controls.Add(this.btn_readuser);
            this.pn_custread.Controls.Add(this.btn_readtid);
            this.pn_custread.Controls.Add(this.btn_readepc);
            this.pn_custread.Controls.Add(this.btn_readpc);
            this.pn_custread.Controls.Add(this.btn_readacc);
            this.pn_custread.Controls.Add(this.btn_readkill);
            this.pn_custread.Location = new System.Drawing.Point(0, 152);
            this.pn_custread.Name = "pn_custread";
            this.pn_custread.Size = new System.Drawing.Size(134, 88);
            this.pn_custread.TabIndex = 9;
            // 
            // btn_readuser
            // 
            this.btn_readuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_readuser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readuser.Location = new System.Drawing.Point(69, 59);
            this.btn_readuser.Name = "btn_readuser";
            this.btn_readuser.Size = new System.Drawing.Size(60, 20);
            this.btn_readuser.TabIndex = 0;
            this.btn_readuser.Text = "USER";
            this.btn_readuser.UseVisualStyleBackColor = false;
            this.btn_readuser.Click += new System.EventHandler(this.btn_readuser_Click);
            // 
            // btn_readtid
            // 
            this.btn_readtid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_readtid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readtid.Location = new System.Drawing.Point(69, 33);
            this.btn_readtid.Name = "btn_readtid";
            this.btn_readtid.Size = new System.Drawing.Size(60, 20);
            this.btn_readtid.TabIndex = 0;
            this.btn_readtid.Text = "TID";
            this.btn_readtid.UseVisualStyleBackColor = false;
            this.btn_readtid.Click += new System.EventHandler(this.btn_readtid_Click);
            // 
            // btn_readepc
            // 
            this.btn_readepc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_readepc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readepc.Location = new System.Drawing.Point(69, 7);
            this.btn_readepc.Name = "btn_readepc";
            this.btn_readepc.Size = new System.Drawing.Size(60, 20);
            this.btn_readepc.TabIndex = 0;
            this.btn_readepc.Text = "EPC";
            this.btn_readepc.UseVisualStyleBackColor = false;
            this.btn_readepc.Click += new System.EventHandler(this.btn_readepc_Click);
            // 
            // btn_readpc
            // 
            this.btn_readpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_readpc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readpc.Location = new System.Drawing.Point(3, 59);
            this.btn_readpc.Name = "btn_readpc";
            this.btn_readpc.Size = new System.Drawing.Size(60, 20);
            this.btn_readpc.TabIndex = 0;
            this.btn_readpc.Text = "PC";
            this.btn_readpc.UseVisualStyleBackColor = false;
            this.btn_readpc.Click += new System.EventHandler(this.btn_readpc_Click);
            // 
            // btn_readacc
            // 
            this.btn_readacc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_readacc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readacc.Location = new System.Drawing.Point(3, 33);
            this.btn_readacc.Name = "btn_readacc";
            this.btn_readacc.Size = new System.Drawing.Size(60, 20);
            this.btn_readacc.TabIndex = 0;
            this.btn_readacc.Text = "ACC";
            this.btn_readacc.UseVisualStyleBackColor = false;
            this.btn_readacc.Click += new System.EventHandler(this.btn_readacc_Click);
            // 
            // pn_basicread
            // 
            this.pn_basicread.BackColor = System.Drawing.SystemColors.Info;
            this.pn_basicread.Controls.Add(this.rb_write);
            this.pn_basicread.Controls.Add(this.rb_read);
            this.pn_basicread.Controls.Add(this.cb_memBank);
            this.pn_basicread.Controls.Add(this.nb_count);
            this.pn_basicread.Controls.Add(this.nb_offset);
            this.pn_basicread.Controls.Add(this.btn_read);
            this.pn_basicread.Controls.Add(this.label1);
            this.pn_basicread.Controls.Add(this.label2);
            this.pn_basicread.Location = new System.Drawing.Point(135, 152);
            this.pn_basicread.Name = "pn_basicread";
            this.pn_basicread.Size = new System.Drawing.Size(185, 88);
            this.pn_basicread.TabIndex = 8;
            // 
            // rb_write
            // 
            this.rb_write.Font = new System.Drawing.Font("Tahoma", 8F);
            this.rb_write.Location = new System.Drawing.Point(133, 62);
            this.rb_write.Name = "rb_write";
            this.rb_write.Size = new System.Drawing.Size(49, 20);
            this.rb_write.TabIndex = 7;
            this.rb_write.Text = "Write";
            this.rb_write.Click += new System.EventHandler(this.rb_write_Click);
            // 
            // rb_read
            // 
            this.rb_read.Checked = true;
            this.rb_read.Font = new System.Drawing.Font("Tahoma", 8F);
            this.rb_read.Location = new System.Drawing.Point(86, 62);
            this.rb_read.Name = "rb_read";
            this.rb_read.Size = new System.Drawing.Size(49, 20);
            this.rb_read.TabIndex = 7;
            this.rb_read.TabStop = true;
            this.rb_read.Text = "Read";
            this.rb_read.Click += new System.EventHandler(this.rb_read_Click);
            // 
            // cb_memBank
            // 
            this.cb_memBank.Items.AddRange(new object[] {
            "PWD",
            "PC-EPC",
            "TID",
            "USER"});
            this.cb_memBank.Location = new System.Drawing.Point(5, 59);
            this.cb_memBank.Name = "cb_memBank";
            this.cb_memBank.Size = new System.Drawing.Size(69, 20);
            this.cb_memBank.TabIndex = 4;
            // 
            // nb_count
            // 
            this.nb_count.Location = new System.Drawing.Point(5, 33);
            this.nb_count.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.nb_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nb_count.Name = "nb_count";
            this.nb_count.Size = new System.Drawing.Size(69, 22);
            this.nb_count.TabIndex = 1;
            this.nb_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nb_offset
            // 
            this.nb_offset.Location = new System.Drawing.Point(5, 7);
            this.nb_offset.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.nb_offset.Name = "nb_offset";
            this.nb_offset.Size = new System.Drawing.Size(69, 22);
            this.nb_offset.TabIndex = 1;
            // 
            // btn_read
            // 
            this.btn_read.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_read.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_read.Location = new System.Drawing.Point(122, 3);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(60, 54);
            this.btn_read.TabIndex = 0;
            this.btn_read.Text = "Read";
            this.btn_read.UseVisualStyleBackColor = false;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.Location = new System.Drawing.Point(80, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Offset";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.Location = new System.Drawing.Point(80, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Count";
            // 
            // lb_epc
            // 
            this.lb_epc.Location = new System.Drawing.Point(59, 129);
            this.lb_epc.Name = "lb_epc";
            this.lb_epc.Size = new System.Drawing.Size(211, 20);
            this.lb_epc.TabIndex = 4;
            this.lb_epc.TabStop = true;
            this.lb_epc.Text = "Click Here to select a tag";
            this.lb_epc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lb_epc.Click += new System.EventHandler(this.lb_epc_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_clear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(3, 126);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(60, 23);
            this.btn_clear.TabIndex = 0;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_cread
            // 
            this.btn_cread.BackColor = System.Drawing.Color.Red;
            this.btn_cread.Location = new System.Drawing.Point(257, 104);
            this.btn_cread.Name = "btn_cread";
            this.btn_cread.Size = new System.Drawing.Size(46, 19);
            this.btn_cread.TabIndex = 7;
            this.btn_cread.Text = "CRead";
            this.btn_cread.UseVisualStyleBackColor = false;
            this.btn_cread.Visible = false;
            this.btn_cread.Click += new System.EventHandler(this.btn_cread_Click);
            // 
            // ReadWriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.btn_cread);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lb_epc);
            this.Controls.Add(this.pn_basicread);
            this.Controls.Add(this.pn_custread);
            this.Controls.Add(this.tb_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadWriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Read and Write";
            this.Load += new System.EventHandler(this.ReadForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ReadForm_Closing);
            this.pn_custread.ResumeLayout(false);
            this.pn_basicread.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nb_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_offset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_readkill;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Panel pn_custread;
        private System.Windows.Forms.Button btn_readuser;
        private System.Windows.Forms.Button btn_readtid;
        private System.Windows.Forms.Button btn_readepc;
        private System.Windows.Forms.Button btn_readpc;
        private System.Windows.Forms.Button btn_readacc;
        private System.Windows.Forms.Panel pn_basicread;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nb_count;
        private System.Windows.Forms.NumericUpDown nb_offset;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.LinkLabel lb_epc;
        private System.Windows.Forms.ComboBox cb_memBank;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.RadioButton rb_write;
        private System.Windows.Forms.RadioButton rb_read;
        private System.Windows.Forms.Button btn_cread;
    }
}

