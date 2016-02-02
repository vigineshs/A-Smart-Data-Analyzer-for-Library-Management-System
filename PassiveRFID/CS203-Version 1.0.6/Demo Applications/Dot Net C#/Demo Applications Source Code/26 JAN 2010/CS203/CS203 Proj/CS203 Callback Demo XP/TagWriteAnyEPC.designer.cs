namespace CS203_CALLBACK_API_DEMO
{
    partial class TagWriteAnyEPCForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nbCount = new System.Windows.Forms.NumericUpDown();
            this.btnExit = new CSLibrary.Windows.RoundButton();
            this.btnStop = new CSLibrary.Windows.RoundButton();
            this.btnStart = new CSLibrary.Windows.RoundButton();
            this.txtMask = new CSLibrary.Windows.HexOnlyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSuccessTag = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mask";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "num of Tags";
            // 
            // nbCount
            // 
            this.nbCount.Location = new System.Drawing.Point(98, 14);
            this.nbCount.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nbCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbCount.Name = "nbCount";
            this.nbCount.Size = new System.Drawing.Size(217, 22);
            this.nbCount.TabIndex = 3;
            this.nbCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbCount.ValueChanged += new System.EventHandler(this.nbCount_ValueChanged);
            // 
            // btnExit
            // 
            this.btnExit.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.BorderLineColor = System.Drawing.Color.Black;
            this.btnExit.DisableBorderLineColor = System.Drawing.Color.Gray;
            this.btnExit.DisabledBackColor = System.Drawing.Color.Gray;
            this.btnExit.DrawBorderLine = false;
            this.btnExit.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(238, 202);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 35);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExit.TextMargin = 0;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStop
            // 
            this.btnStop.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStop.BorderLineColor = System.Drawing.Color.Black;
            this.btnStop.DisableBorderLineColor = System.Drawing.Color.Gray;
            this.btnStop.DisabledBackColor = System.Drawing.Color.Gray;
            this.btnStop.DrawBorderLine = false;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(86, 202);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 35);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStop.TextMargin = 0;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.ActiveBackColor = System.Drawing.Color.LightGreen;
            this.btnStart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStart.BorderLineColor = System.Drawing.Color.Black;
            this.btnStart.DisableBorderLineColor = System.Drawing.Color.Gray;
            this.btnStart.DisabledBackColor = System.Drawing.Color.Gray;
            this.btnStart.DrawBorderLine = false;
            this.btnStart.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(3, 202);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(77, 35);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStart.TextMargin = 0;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtMask
            // 
            this.txtMask.BackgroundText = null;
            this.txtMask.FontColor = System.Drawing.Color.Black;
            this.txtMask.ForeColor = System.Drawing.Color.Gray;
            this.txtMask.Location = new System.Drawing.Point(98, 55);
            this.txtMask.MaxLength = 23;
            this.txtMask.Name = "txtMask";
            this.txtMask.PaddingZero = true;
            this.txtMask.Size = new System.Drawing.Size(217, 22);
            this.txtMask.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.Location = new System.Drawing.Point(5, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Successful Written Tag";
            // 
            // txtSuccessTag
            // 
            this.txtSuccessTag.Font = new System.Drawing.Font("Tahoma", 24F);
            this.txtSuccessTag.ForeColor = System.Drawing.Color.Red;
            this.txtSuccessTag.Location = new System.Drawing.Point(98, 92);
            this.txtSuccessTag.Name = "txtSuccessTag";
            this.txtSuccessTag.Size = new System.Drawing.Size(187, 39);
            this.txtSuccessTag.TabIndex = 0;
            this.txtSuccessTag.Text = "0";
            this.txtSuccessTag.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TagWriteAnyEPCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.txtSuccessTag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtMask);
            this.Controls.Add(this.nbCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagWriteAnyEPCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CS10 WriteAny Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.nbCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nbCount;
        private CSLibrary.Windows.HexOnlyTextBox txtMask;
        private CSLibrary.Windows.RoundButton btnStart;
        private CSLibrary.Windows.RoundButton btnStop;
        private CSLibrary.Windows.RoundButton btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtSuccessTag;
    }
}

