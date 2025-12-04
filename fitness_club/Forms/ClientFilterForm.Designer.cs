namespace fitness_club.Forms
{
    partial class ClientFilterForm
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
            this.chkMale = new System.Windows.Forms.CheckBox();
            this.chkFemale = new System.Windows.Forms.CheckBox();
            this.chkOther = new System.Windows.Forms.CheckBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dtpRegFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpRegTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkMale
            // 
            this.chkMale.AutoSize = true;
            this.chkMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkMale.Location = new System.Drawing.Point(12, 34);
            this.chkMale.Name = "chkMale";
            this.chkMale.Size = new System.Drawing.Size(57, 21);
            this.chkMale.TabIndex = 0;
            this.chkMale.Text = "Male";
            this.chkMale.UseVisualStyleBackColor = true;
            // 
            // chkFemale
            // 
            this.chkFemale.AutoSize = true;
            this.chkFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkFemale.Location = new System.Drawing.Point(12, 61);
            this.chkFemale.Name = "chkFemale";
            this.chkFemale.Size = new System.Drawing.Size(73, 21);
            this.chkFemale.TabIndex = 1;
            this.chkFemale.Text = "Female";
            this.chkFemale.UseVisualStyleBackColor = true;
            // 
            // chkOther
            // 
            this.chkOther.AutoSize = true;
            this.chkOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkOther.Location = new System.Drawing.Point(12, 88);
            this.chkOther.Name = "chkOther";
            this.chkOther.Size = new System.Drawing.Size(63, 21);
            this.chkOther.TabIndex = 2;
            this.chkOther.Text = "Other";
            this.chkOther.UseVisualStyleBackColor = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLogin.Location = new System.Drawing.Point(8, 11);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(67, 20);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Gender:";
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnApply.Location = new System.Drawing.Point(287, 268);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 31);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(196, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(125, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Status:";
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkInactive.Location = new System.Drawing.Point(129, 64);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(75, 21);
            this.chkInactive.TabIndex = 8;
            this.chkInactive.Text = "Inactive";
            this.chkInactive.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkActive.Location = new System.Drawing.Point(129, 37);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(65, 21);
            this.chkActive.TabIndex = 7;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // dtpRegFrom
            // 
            this.dtpRegFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegFrom.Location = new System.Drawing.Point(12, 148);
            this.dtpRegFrom.Name = "dtpRegFrom";
            this.dtpRegFrom.ShowCheckBox = true;
            this.dtpRegFrom.Size = new System.Drawing.Size(116, 20);
            this.dtpRegFrom.TabIndex = 10;
            this.dtpRegFrom.ValueChanged += new System.EventHandler(this.dtpRegFrom_ValueChanged);
            // 
            // dtpRegTo
            // 
            this.dtpRegTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegTo.Location = new System.Drawing.Point(12, 190);
            this.dtpRegTo.Name = "dtpRegTo";
            this.dtpRegTo.ShowCheckBox = true;
            this.dtpRegTo.Size = new System.Drawing.Size(116, 20);
            this.dtpRegTo.TabIndex = 11;
            this.dtpRegTo.ValueChanged += new System.EventHandler(this.dtpRegTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(8, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Registration from:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(8, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Registration to:";
            // 
            // ClientFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpRegTo);
            this.Controls.Add(this.dtpRegFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkInactive);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.chkOther);
            this.Controls.Add(this.chkFemale);
            this.Controls.Add(this.chkMale);
            this.Name = "ClientFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Filters";
            this.Load += new System.EventHandler(this.ClientFilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMale;
        private System.Windows.Forms.CheckBox chkFemale;
        private System.Windows.Forms.CheckBox chkOther;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DateTimePicker dtpRegFrom;
        private System.Windows.Forms.DateTimePicker dtpRegTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}