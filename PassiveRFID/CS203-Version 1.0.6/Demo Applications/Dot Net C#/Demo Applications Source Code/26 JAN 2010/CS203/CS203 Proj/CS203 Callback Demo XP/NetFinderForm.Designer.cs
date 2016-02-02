namespace CS203_CALLBACK_API_DEMO
{
    partial class NetFinderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetFinderForm));
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_assign = new System.Windows.Forms.Button();
            this.btn_image = new System.Windows.Forms.Button();
            this.btn_bootloader = new System.Windows.Forms.Button();
            this.lb_info = new System.Windows.Forms.Label();
            this.lv_device = new CS203_CALLBACK_API_DEMO.ListBoxEx.ListBoxEx();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.AccessibleDescription = "Start Button";
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(12, 408);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(98, 30);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Search";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.Cyan;
            this.btn_connect.Enabled = false;
            this.btn_connect.Location = new System.Drawing.Point(116, 408);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 30);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_clear.Location = new System.Drawing.Point(528, 408);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 30);
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_assign
            // 
            this.btn_assign.BackColor = System.Drawing.Color.Blue;
            this.btn_assign.Enabled = false;
            this.btn_assign.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_assign.ForeColor = System.Drawing.Color.White;
            this.btn_assign.Location = new System.Drawing.Point(222, 408);
            this.btn_assign.Name = "btn_assign";
            this.btn_assign.Size = new System.Drawing.Size(83, 30);
            this.btn_assign.TabIndex = 2;
            this.btn_assign.Text = "Assignment";
            this.btn_assign.UseVisualStyleBackColor = false;
            this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
            // 
            // btn_image
            // 
            this.btn_image.BackColor = System.Drawing.Color.Blue;
            this.btn_image.Enabled = false;
            this.btn_image.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_image.ForeColor = System.Drawing.Color.White;
            this.btn_image.Location = new System.Drawing.Point(311, 408);
            this.btn_image.Name = "btn_image";
            this.btn_image.Size = new System.Drawing.Size(83, 30);
            this.btn_image.TabIndex = 3;
            this.btn_image.Text = "Image";
            this.btn_image.UseVisualStyleBackColor = false;
            this.btn_image.Click += new System.EventHandler(this.btn_image_Click);
            // 
            // btn_bootloader
            // 
            this.btn_bootloader.BackColor = System.Drawing.Color.Blue;
            this.btn_bootloader.Enabled = false;
            this.btn_bootloader.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_bootloader.ForeColor = System.Drawing.Color.White;
            this.btn_bootloader.Location = new System.Drawing.Point(400, 408);
            this.btn_bootloader.Name = "btn_bootloader";
            this.btn_bootloader.Size = new System.Drawing.Size(83, 30);
            this.btn_bootloader.TabIndex = 4;
            this.btn_bootloader.Text = "Bootloader";
            this.btn_bootloader.UseVisualStyleBackColor = false;
            this.btn_bootloader.Click += new System.EventHandler(this.btn_bootloader_Click);
            // 
            // lb_info
            // 
            this.lb_info.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_info.ForeColor = System.Drawing.Color.Blue;
            this.lb_info.Location = new System.Drawing.Point(12, 382);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(590, 23);
            this.lb_info.TabIndex = 5;
            this.lb_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lv_device
            // 
            this.lv_device.BackColor = System.Drawing.SystemColors.Info;
            this.lv_device.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_device.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lv_device.FormattingEnabled = true;
            this.lv_device.ItemHeight = 65;
            this.lv_device.Location = new System.Drawing.Point(12, 12);
            this.lv_device.Name = "lv_device";
            this.lv_device.Size = new System.Drawing.Size(591, 367);
            this.lv_device.TabIndex = 4;
            this.lv_device.SelectedIndexChanged += new System.EventHandler(this.lv_device_SelectedIndexChanged);
            // 
            // NetFinderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(614, 443);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.lv_device);
            this.Controls.Add(this.btn_bootloader);
            this.Controls.Add(this.btn_image);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NetFinderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Device";
            this.Load += new System.EventHandler(this.NetFinderForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetFinderForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_assign;
        private CS203_CALLBACK_API_DEMO.ListBoxEx.ListBoxEx lv_device;
        private System.Windows.Forms.Button btn_image;
        private System.Windows.Forms.Button btn_bootloader;
        private System.Windows.Forms.Label lb_info;
    }
}