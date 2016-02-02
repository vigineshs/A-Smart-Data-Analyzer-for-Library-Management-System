namespace CS203DEMO
{
    partial class WriteInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteInputForm));
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nb_offset = new System.Windows.Forms.NumericUpDown();
            this.nb_retry = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nb_count = new System.Windows.Forms.NumericUpDown();
            this.tb_pwd = new CustomTextbox.HexOnlyTextbox();
            this.tb_data = new CustomTextbox.HexOnlyTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.nb_offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_retry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_count)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_ok.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btn_ok.Location = new System.Drawing.Point(12, 158);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(72, 50);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Red;
            this.btn_cancel.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btn_cancel.Location = new System.Drawing.Point(216, 158);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(87, 50);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "PWD";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Offset";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Retry";
            // 
            // nb_offset
            // 
            this.nb_offset.Location = new System.Drawing.Point(62, 70);
            this.nb_offset.Maximum = new decimal(new int[] {
            32128,
            0,
            0,
            0});
            this.nb_offset.Name = "nb_offset";
            this.nb_offset.Size = new System.Drawing.Size(87, 22);
            this.nb_offset.TabIndex = 2;
            // 
            // nb_retry
            // 
            this.nb_retry.Location = new System.Drawing.Point(62, 100);
            this.nb_retry.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nb_retry.Name = "nb_retry";
            this.nb_retry.Size = new System.Drawing.Size(87, 22);
            this.nb_retry.TabIndex = 4;
            this.nb_retry.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(166, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Count";
            // 
            // nb_count
            // 
            this.nb_count.Location = new System.Drawing.Point(216, 70);
            this.nb_count.Maximum = new decimal(new int[] {
            32128,
            0,
            0,
            0});
            this.nb_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nb_count.Name = "nb_count";
            this.nb_count.Size = new System.Drawing.Size(87, 22);
            this.nb_count.TabIndex = 3;
            this.nb_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nb_count.ValueChanged += new System.EventHandler(this.nb_count_ValueChanged);
            // 
            // tb_pwd
            // 
            this.tb_pwd.BackColor = System.Drawing.Color.LightGreen;
            this.tb_pwd.BackgroundText = "0000000";
            this.tb_pwd.ForeColor = System.Drawing.Color.Gray;
            this.tb_pwd.Location = new System.Drawing.Point(62, 42);
            this.tb_pwd.MaxLength = 8;
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.Size = new System.Drawing.Size(241, 22);
            this.tb_pwd.TabIndex = 1;
            this.tb_pwd.Text = "0000000";
            // 
            // tb_data
            // 
            this.tb_data.BackColor = System.Drawing.Color.LightGreen;
            this.tb_data.BackgroundText = "Input Data Here!!!";
            this.tb_data.ForeColor = System.Drawing.Color.Gray;
            this.tb_data.Location = new System.Drawing.Point(62, 12);
            this.tb_data.Name = "tb_data";
            this.tb_data.Size = new System.Drawing.Size(241, 22);
            this.tb_data.TabIndex = 0;
            this.tb_data.Text = "Input Data Here!!!";
            // 
            // WriteInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.nb_retry);
            this.Controls.Add(this.nb_count);
            this.Controls.Add(this.nb_offset);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.tb_data);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WriteInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WriteInputForm";
            this.Load += new System.EventHandler(this.WriteInputForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WriteInputForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.nb_offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_retry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomTextbox.HexOnlyTextbox tb_data;
        private CustomTextbox.HexOnlyTextbox tb_pwd;
        private System.Windows.Forms.NumericUpDown nb_offset;
        private System.Windows.Forms.NumericUpDown nb_retry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nb_count;
    }
}