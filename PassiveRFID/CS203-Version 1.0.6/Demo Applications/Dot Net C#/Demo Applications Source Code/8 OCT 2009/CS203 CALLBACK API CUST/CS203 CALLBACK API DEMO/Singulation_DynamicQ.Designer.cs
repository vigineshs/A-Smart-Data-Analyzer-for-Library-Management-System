namespace CS203DEMO
{
    partial class Singulation_DynamicQ
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_toggle = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nb_retry = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nb_startqvalue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nb_minqvalue = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nb_maxqvalue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nb_MaxQueryRep = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nb_retry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_startqvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_minqvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_maxqvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_MaxQueryRep)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_toggle
            // 
            this.cb_toggle.AutoSize = true;
            this.cb_toggle.Checked = true;
            this.cb_toggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_toggle.Location = new System.Drawing.Point(90, 96);
            this.cb_toggle.Name = "cb_toggle";
            this.cb_toggle.Size = new System.Drawing.Size(15, 14);
            this.cb_toggle.TabIndex = 10;
            this.cb_toggle.UseVisualStyleBackColor = true;
            this.cb_toggle.CheckedChanged += new System.EventHandler(this.cb_toggle_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Toggle";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nb_retry
            // 
            this.nb_retry.Location = new System.Drawing.Point(255, 3);
            this.nb_retry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nb_retry.Name = "nb_retry";
            this.nb_retry.Size = new System.Drawing.Size(77, 22);
            this.nb_retry.TabIndex = 8;
            this.nb_retry.ValueChanged += new System.EventHandler(this.nb_retry_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(171, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Retry";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nb_startqvalue
            // 
            this.nb_startqvalue.Location = new System.Drawing.Point(90, 3);
            this.nb_startqvalue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nb_startqvalue.Name = "nb_startqvalue";
            this.nb_startqvalue.Size = new System.Drawing.Size(77, 22);
            this.nb_startqvalue.TabIndex = 7;
            this.nb_startqvalue.ValueChanged += new System.EventHandler(this.nb_startqvalue_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "StartQValue";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "MinQValue";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nb_minqvalue
            // 
            this.nb_minqvalue.Location = new System.Drawing.Point(90, 31);
            this.nb_minqvalue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nb_minqvalue.Name = "nb_minqvalue";
            this.nb_minqvalue.Size = new System.Drawing.Size(77, 22);
            this.nb_minqvalue.TabIndex = 7;
            this.nb_minqvalue.ValueChanged += new System.EventHandler(this.nb_minqvalue_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(171, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "MaxQValue";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nb_maxqvalue
            // 
            this.nb_maxqvalue.Location = new System.Drawing.Point(255, 31);
            this.nb_maxqvalue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nb_maxqvalue.Name = "nb_maxqvalue";
            this.nb_maxqvalue.Size = new System.Drawing.Size(77, 22);
            this.nb_maxqvalue.TabIndex = 7;
            this.nb_maxqvalue.ValueChanged += new System.EventHandler(this.nb_maxqvalue_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "MaxQueryRep";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nb_MaxQueryRep
            // 
            this.nb_MaxQueryRep.Location = new System.Drawing.Point(90, 59);
            this.nb_MaxQueryRep.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nb_MaxQueryRep.Name = "nb_MaxQueryRep";
            this.nb_MaxQueryRep.Size = new System.Drawing.Size(77, 22);
            this.nb_MaxQueryRep.TabIndex = 7;
            this.nb_MaxQueryRep.ValueChanged += new System.EventHandler(this.nb_MaxQueryRep_ValueChanged);
            // 
            // Singulation_DynamicQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_toggle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nb_retry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nb_maxqvalue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nb_MaxQueryRep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nb_minqvalue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nb_startqvalue);
            this.Controls.Add(this.label1);
            this.Name = "Singulation_DynamicQ";
            this.Size = new System.Drawing.Size(332, 131);
            ((System.ComponentModel.ISupportInitialize)(this.nb_retry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_startqvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_minqvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_maxqvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_MaxQueryRep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_toggle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nb_retry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nb_startqvalue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nb_minqvalue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nb_maxqvalue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nb_MaxQueryRep;
    }
}
