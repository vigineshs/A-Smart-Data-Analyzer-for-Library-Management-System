namespace CS203_MultipleReader
{
    partial class ReadTagForm
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
            this.nTable1 = new CSLibrary.Windows.UI.NTable();
            this.btn_startInventory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btn_stopInventory = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTable1
            // 
            this.nTable1.AllowColumnResize = false;
            this.nTable1.AltBackColor = System.Drawing.Color.Khaki;
            this.nTable1.AltForeColor = System.Drawing.Color.Black;
            this.nTable1.AutoColumnSize = true;
            this.nTable1.AutoMoveRow = true;
            this.nTable1.BackColor = System.Drawing.Color.White;
            this.nTable1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nTable1.ColumnBackColor = System.Drawing.Color.Chocolate;
            this.nTable1.ColumnFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.nTable1.ColumnForeColor = System.Drawing.Color.White;
            this.nTable1.DefaultLineAligment = System.Drawing.StringAlignment.Center;
            this.nTable1.DefaultRowHeight = 20;
            this.nTable1.DefaultTextAligment = System.Drawing.StringAlignment.Center;
            this.nTable1.DrawGridBorder = true;
            this.nTable1.FocusCellBackColor = System.Drawing.Color.Black;
            this.nTable1.FocusCellForeColor = System.Drawing.Color.White;
            this.nTable1.LeftHeader = false;
            this.nTable1.Location = new System.Drawing.Point(12, 12);
            this.nTable1.MultipleSelection = false;
            this.nTable1.Name = "nTable1";
            this.nTable1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.nTable1.SelectionForeColor = System.Drawing.Color.Black;
            this.nTable1.ShowSplitterValue = true;
            this.nTable1.ShowStartSplitter = true;
            this.nTable1.Size = new System.Drawing.Size(463, 427);
            this.nTable1.SplitterColor = System.Drawing.Color.Red;
            this.nTable1.SplitterMode = CSLibrary.Windows.UI.NTableSplitterMode.Default;
            this.nTable1.SplitterStartColor = System.Drawing.Color.Brown;
            this.nTable1.SplitterWidth = 1;
            this.nTable1.TabIndex = 0;
            this.nTable1.Text = "nTable1";
            // 
            // btn_startInventory
            // 
            this.btn_startInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_startInventory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_startInventory.ForeColor = System.Drawing.Color.Black;
            this.btn_startInventory.Location = new System.Drawing.Point(505, 12);
            this.btn_startInventory.Name = "btn_startInventory";
            this.btn_startInventory.Size = new System.Drawing.Size(109, 34);
            this.btn_startInventory.TabIndex = 1;
            this.btn_startInventory.Text = "Start Inventory";
            this.btn_startInventory.UseVisualStyleBackColor = false;
            this.btn_startInventory.Click += new System.EventHandler(this.btn_startInventory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(481, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sorting";
            this.groupBox2.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(8, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(90, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Text = "Highest Count";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "Highest Power";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Alphabetic EPC";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btn_stopInventory
            // 
            this.btn_stopInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_stopInventory.Enabled = false;
            this.btn_stopInventory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stopInventory.ForeColor = System.Drawing.Color.Black;
            this.btn_stopInventory.Location = new System.Drawing.Point(505, 52);
            this.btn_stopInventory.Name = "btn_stopInventory";
            this.btn_stopInventory.Size = new System.Drawing.Size(109, 34);
            this.btn_stopInventory.TabIndex = 1;
            this.btn_stopInventory.Text = "Stop Inventory";
            this.btn_stopInventory.UseVisualStyleBackColor = false;
            this.btn_stopInventory.Click += new System.EventHandler(this.btn_stopInventory_Click);
            // 
            // ReadTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_stopInventory);
            this.Controls.Add(this.btn_startInventory);
            this.Controls.Add(this.nTable1);
            this.Name = "ReadTagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Read Tag";
            this.Load += new System.EventHandler(this.ReadTagForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReadTagForm_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CSLibrary.Windows.UI.NTable nTable1;
        private System.Windows.Forms.Button btn_startInventory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_stopInventory;

    }
}

