namespace CS203_CALLBACK_API_DEMO_CE
{
    partial class NetFinderForm
    {
        private bool disposed = false;
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
            disposed = disposing;
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
            this.lv_device = new CSLibrary.Windows.UI.NTable();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_start.Location = new System.Drawing.Point(7, 195);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(95, 18);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Search";
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.Cyan;
            this.btn_connect.Enabled = false;
            this.btn_connect.Location = new System.Drawing.Point(108, 195);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(101, 18);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_clear.Location = new System.Drawing.Point(215, 195);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(98, 18);
            this.btn_clear.TabIndex = 0;
            this.btn_clear.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_assign
            // 
            this.btn_assign.BackColor = System.Drawing.Color.Blue;
            this.btn_assign.Enabled = false;
            this.btn_assign.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold);
            this.btn_assign.ForeColor = System.Drawing.Color.White;
            this.btn_assign.Location = new System.Drawing.Point(7, 171);
            this.btn_assign.Name = "btn_assign";
            this.btn_assign.Size = new System.Drawing.Size(95, 18);
            this.btn_assign.TabIndex = 2;
            this.btn_assign.Text = "Assignment";
            this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
            // 
            // btn_image
            // 
            this.btn_image.BackColor = System.Drawing.Color.Blue;
            this.btn_image.Enabled = false;
            this.btn_image.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold);
            this.btn_image.ForeColor = System.Drawing.Color.White;
            this.btn_image.Location = new System.Drawing.Point(108, 171);
            this.btn_image.Name = "btn_image";
            this.btn_image.Size = new System.Drawing.Size(101, 18);
            this.btn_image.TabIndex = 2;
            this.btn_image.Text = "Image";
            this.btn_image.Click += new System.EventHandler(this.btn_image_Click);
            // 
            // btn_bootloader
            // 
            this.btn_bootloader.BackColor = System.Drawing.Color.Blue;
            this.btn_bootloader.Enabled = false;
            this.btn_bootloader.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold);
            this.btn_bootloader.ForeColor = System.Drawing.Color.White;
            this.btn_bootloader.Location = new System.Drawing.Point(215, 171);
            this.btn_bootloader.Name = "btn_bootloader";
            this.btn_bootloader.Size = new System.Drawing.Size(98, 18);
            this.btn_bootloader.TabIndex = 2;
            this.btn_bootloader.Text = "Bootloader";
            this.btn_bootloader.Click += new System.EventHandler(this.btn_bootloader_Click);
            // 
            // lb_info
            // 
            this.lb_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_info.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.lb_info.ForeColor = System.Drawing.Color.Blue;
            this.lb_info.Location = new System.Drawing.Point(7, 145);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(306, 23);
            // 
            // lv_device
            // 
            this.lv_device.AllowColumnResize = false;
            this.lv_device.AltBackColor = System.Drawing.Color.Khaki;
            this.lv_device.AltForeColor = System.Drawing.Color.Black;
            this.lv_device.AutoColumnSize = false;
            this.lv_device.AutoMoveRow = true;
            this.lv_device.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lv_device.ColumnBackColor = System.Drawing.Color.Chocolate;
            this.lv_device.ColumnFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lv_device.ColumnForeColor = System.Drawing.Color.White;
            this.lv_device.DefaultLineAligment = System.Drawing.StringAlignment.Center;
            this.lv_device.DefaultRowHeight = 20;
            this.lv_device.DefaultTextAligment = System.Drawing.StringAlignment.Center;
            this.lv_device.DrawGridBorder = true;
            this.lv_device.FocusCellBackColor = System.Drawing.Color.Black;
            this.lv_device.FocusCellForeColor = System.Drawing.Color.White;
            this.lv_device.LeftHeader = false;
            this.lv_device.Location = new System.Drawing.Point(7, 3);
            this.lv_device.MultipleSelection = false;
            this.lv_device.Name = "lv_device";
            this.lv_device.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.lv_device.SelectionForeColor = System.Drawing.Color.Black;
            this.lv_device.ShowSplitterValue = true;
            this.lv_device.ShowStartSplitter = true;
            this.lv_device.Size = new System.Drawing.Size(306, 139);
            this.lv_device.SplitterColor = System.Drawing.Color.Red;
            this.lv_device.SplitterMode = CSLibrary.Windows.UI.NTableSplitterMode.Default;
            this.lv_device.SplitterStartColor = System.Drawing.Color.Brown;
            this.lv_device.SplitterWidth = 1;
            this.lv_device.TabIndex = 3;
            this.lv_device.Text = "nTable1";
            this.lv_device.SelectionChanged += new CSLibrary.Windows.UI.NTableSelectionHandler(this.lv_device_SelectionChanged);
            this.lv_device.RowChanged += new CSLibrary.Windows.UI.NTableRowHandler(this.lv_device_RowChanged);
            // 
            // NetFinderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(318, 215);
            this.Controls.Add(this.lv_device);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.btn_bootloader);
            this.Controls.Add(this.btn_image);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NetFinderForm";
            this.Text = "Search Device";
            this.Load += new System.EventHandler(this.NetFinderForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NetFinderForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_assign;
        private System.Windows.Forms.Button btn_image;
        private System.Windows.Forms.Button btn_bootloader;
        private System.Windows.Forms.Label lb_info;
        private CSLibrary.Windows.UI.NTable lv_device;
    }
}