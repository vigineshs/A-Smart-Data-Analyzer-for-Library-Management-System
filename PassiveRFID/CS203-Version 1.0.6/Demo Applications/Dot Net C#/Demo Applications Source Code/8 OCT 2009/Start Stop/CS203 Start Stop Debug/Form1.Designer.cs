namespace CS203_Start_Stop_Debug
{
    partial class Form1
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
            this.lb_stat = new System.Windows.Forms.Label();
            this.lb_count = new System.Windows.Forms.Label();
            this.ipTextBox1 = new CS203_Start_Stop_Debug.IPTextBox();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(12, 41);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(228, 33);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_startup_Click);
            // 
            // lb_stat
            // 
            this.lb_stat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_stat.Location = new System.Drawing.Point(12, 77);
            this.lb_stat.Name = "lb_stat";
            this.lb_stat.Size = new System.Drawing.Size(228, 23);
            this.lb_stat.TabIndex = 1;
            this.lb_stat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_count
            // 
            this.lb_count.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_count.ForeColor = System.Drawing.Color.Red;
            this.lb_count.Location = new System.Drawing.Point(12, 100);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(230, 23);
            this.lb_count.TabIndex = 2;
            this.lb_count.Text = "Count : 0/1000";
            this.lb_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipTextBox1
            // 
            this.ipTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ipTextBox1.IP = "192.168.25.203";
            this.ipTextBox1.Location = new System.Drawing.Point(15, 10);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.Size = new System.Drawing.Size(226, 25);
            this.ipTextBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 126);
            this.Controls.Add(this.ipTextBox1);
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.lb_stat);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debug";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_stat;
        private System.Windows.Forms.Label lb_count;
        private IPTextBox ipTextBox1;
    }
}

