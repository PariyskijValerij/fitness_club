namespace fitness_club.Forms
{
    partial class MembershipFilterForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartTo = new System.Windows.Forms.DateTimePicker();
            this.dtpStartFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPaused = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkExpired = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEndFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Start date to:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Start date from:";
            // 
            // dtpStartTo
            // 
            this.dtpStartTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartTo.Location = new System.Drawing.Point(14, 82);
            this.dtpStartTo.Name = "dtpStartTo";
            this.dtpStartTo.ShowCheckBox = true;
            this.dtpStartTo.Size = new System.Drawing.Size(116, 20);
            this.dtpStartTo.TabIndex = 24;
            this.dtpStartTo.ValueChanged += new System.EventHandler(this.dtpStartTo_ValueChanged);
            // 
            // dtpStartFrom
            // 
            this.dtpStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartFrom.Location = new System.Drawing.Point(14, 40);
            this.dtpStartFrom.Name = "dtpStartFrom";
            this.dtpStartFrom.ShowCheckBox = true;
            this.dtpStartFrom.Size = new System.Drawing.Size(116, 20);
            this.dtpStartFrom.TabIndex = 23;
            this.dtpStartFrom.ValueChanged += new System.EventHandler(this.dtpStartFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Status:";
            // 
            // chkPaused
            // 
            this.chkPaused.AutoSize = true;
            this.chkPaused.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkPaused.Location = new System.Drawing.Point(16, 59);
            this.chkPaused.Name = "chkPaused";
            this.chkPaused.Size = new System.Drawing.Size(75, 21);
            this.chkPaused.TabIndex = 21;
            this.chkPaused.Text = "Paused";
            this.chkPaused.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkActive.Location = new System.Drawing.Point(16, 32);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(65, 21);
            this.chkActive.TabIndex = 20;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(242, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnApply.Location = new System.Drawing.Point(333, 265);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 31);
            this.btnApply.TabIndex = 18;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkExpired
            // 
            this.chkExpired.AutoSize = true;
            this.chkExpired.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkExpired.Location = new System.Drawing.Point(16, 86);
            this.chkExpired.Name = "chkExpired";
            this.chkExpired.Size = new System.Drawing.Size(74, 21);
            this.chkExpired.TabIndex = 27;
            this.chkExpired.Text = "Expired";
            this.chkExpired.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpStartFrom);
            this.groupBox1.Controls.Add(this.dtpStartTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 110);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpEndFrom);
            this.groupBox2.Controls.Add(this.dtpEndTo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(218, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 110);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "End Date";
            // 
            // dtpEndFrom
            // 
            this.dtpEndFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndFrom.Location = new System.Drawing.Point(14, 40);
            this.dtpEndFrom.Name = "dtpEndFrom";
            this.dtpEndFrom.ShowCheckBox = true;
            this.dtpEndFrom.Size = new System.Drawing.Size(116, 20);
            this.dtpEndFrom.TabIndex = 23;
            this.dtpEndFrom.ValueChanged += new System.EventHandler(this.dtpEndFrom_ValueChanged);
            // 
            // dtpEndTo
            // 
            this.dtpEndTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndTo.Location = new System.Drawing.Point(14, 82);
            this.dtpEndTo.Name = "dtpEndTo";
            this.dtpEndTo.ShowCheckBox = true;
            this.dtpEndTo.Size = new System.Drawing.Size(116, 20);
            this.dtpEndTo.TabIndex = 24;
            this.dtpEndTo.ValueChanged += new System.EventHandler(this.dtpEndTo_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(10, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "End date to:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(10, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "End date from:";
            // 
            // MembershipFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 308);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkExpired);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPaused);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Name = "MembershipFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MembershipFilterForm";
            this.Load += new System.EventHandler(this.MembershipFilterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartTo;
        private System.Windows.Forms.DateTimePicker dtpStartFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPaused;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkExpired;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpEndFrom;
        private System.Windows.Forms.DateTimePicker dtpEndTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}