namespace CS203DEMO
{
    partial class KillPWD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KillPWD));
            this.btn_ok = new System.Windows.Forms.Button();
            this.tb_killpwd = new CustomTextbox.HexOnlyTextbox();
            this.lb_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_ok.Location = new System.Drawing.Point(119, 36);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(72, 28);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "KILL";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tb_killpwd
            // 
            this.tb_killpwd.BackColor = System.Drawing.Color.White;
            this.tb_killpwd.BackgroundText = null;
            this.tb_killpwd.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.tb_killpwd.ForeColor = System.Drawing.Color.Gray;
            this.tb_killpwd.Location = new System.Drawing.Point(3, 3);
            this.tb_killpwd.MaxLength = 8;
            this.tb_killpwd.Name = "tb_killpwd";
            this.tb_killpwd.Size = new System.Drawing.Size(188, 30);
            this.tb_killpwd.TabIndex = 2;
            // 
            // lb_result
            // 
            this.lb_result.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lb_result.Location = new System.Drawing.Point(0, 36);
            this.lb_result.Name = "lb_result";
            this.lb_result.Size = new System.Drawing.Size(113, 28);
            this.lb_result.TabIndex = 0;
            this.lb_result.Text = "<Result>";
            // 
            // KillPWD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(195, 69);
            this.Controls.Add(this.lb_result);
            this.Controls.Add(this.tb_killpwd);
            this.Controls.Add(this.btn_ok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KillPWD";
            this.Text = "Please Enter kill password";
            this.Load += new System.EventHandler(this.KillPWD_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.KillPWD_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private CustomTextbox.HexOnlyTextbox tb_killpwd;
        private System.Windows.Forms.Label lb_result;

    }
}