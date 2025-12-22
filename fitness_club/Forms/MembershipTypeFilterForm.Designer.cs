namespace fitness_club.Forms
{
    partial class MembershipTypeFilterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.chkFreezeAllowed = new System.Windows.Forms.CheckBox();
            this.nudPriceFrom = new System.Windows.Forms.NumericUpDown();
            this.nudPriceTo = new System.Windows.Forms.NumericUpDown();
            this.nudDurationTo = new System.Windows.Forms.NumericUpDown();
            this.nudDurationFrom = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnablePrice = new System.Windows.Forms.CheckBox();
            this.chkEnableDuration = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Price to:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Price from:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(185, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Status:";
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkInactive.Location = new System.Drawing.Point(189, 61);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(75, 21);
            this.chkInactive.TabIndex = 21;
            this.chkInactive.Text = "Inactive";
            this.chkInactive.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkActive.Location = new System.Drawing.Point(189, 34);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(65, 21);
            this.chkActive.TabIndex = 20;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(198, 268);
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
            this.btnApply.Location = new System.Drawing.Point(289, 268);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 31);
            this.btnApply.TabIndex = 18;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLogin.Location = new System.Drawing.Point(10, 11);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(120, 20);
            this.lblLogin.TabIndex = 17;
            this.lblLogin.Text = "Freeze allowed:";
            // 
            // chkFreezeAllowed
            // 
            this.chkFreezeAllowed.AutoSize = true;
            this.chkFreezeAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkFreezeAllowed.Location = new System.Drawing.Point(14, 34);
            this.chkFreezeAllowed.Name = "chkFreezeAllowed";
            this.chkFreezeAllowed.Size = new System.Drawing.Size(51, 21);
            this.chkFreezeAllowed.TabIndex = 14;
            this.chkFreezeAllowed.Text = "Yes";
            this.chkFreezeAllowed.UseVisualStyleBackColor = true;
            // 
            // nudPriceFrom
            // 
            this.nudPriceFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nudPriceFrom.Location = new System.Drawing.Point(15, 147);
            this.nudPriceFrom.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPriceFrom.Name = "nudPriceFrom";
            this.nudPriceFrom.Size = new System.Drawing.Size(133, 23);
            this.nudPriceFrom.TabIndex = 70;
            this.nudPriceFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPriceFrom.ValueChanged += new System.EventHandler(this.nudPriceFrom_ValueChanged);
            // 
            // nudPriceTo
            // 
            this.nudPriceTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nudPriceTo.Location = new System.Drawing.Point(15, 194);
            this.nudPriceTo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPriceTo.Name = "nudPriceTo";
            this.nudPriceTo.Size = new System.Drawing.Size(133, 23);
            this.nudPriceTo.TabIndex = 71;
            this.nudPriceTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPriceTo.ValueChanged += new System.EventHandler(this.nudPriceTo_ValueChanged);
            // 
            // nudDurationTo
            // 
            this.nudDurationTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nudDurationTo.Location = new System.Drawing.Point(188, 194);
            this.nudDurationTo.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.nudDurationTo.Name = "nudDurationTo";
            this.nudDurationTo.Size = new System.Drawing.Size(133, 23);
            this.nudDurationTo.TabIndex = 75;
            this.nudDurationTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDurationTo.ValueChanged += new System.EventHandler(this.nudDurationTo_ValueChanged);
            // 
            // nudDurationFrom
            // 
            this.nudDurationFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nudDurationFrom.Location = new System.Drawing.Point(188, 147);
            this.nudDurationFrom.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.nudDurationFrom.Name = "nudDurationFrom";
            this.nudDurationFrom.Size = new System.Drawing.Size(133, 23);
            this.nudDurationFrom.TabIndex = 74;
            this.nudDurationFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDurationFrom.ValueChanged += new System.EventHandler(this.nudDurationFrom_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(185, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "Duration to:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(185, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 72;
            this.label5.Text = "Duration from:";
            // 
            // chkEnablePrice
            // 
            this.chkEnablePrice.AutoSize = true;
            this.chkEnablePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEnablePrice.Location = new System.Drawing.Point(15, 107);
            this.chkEnablePrice.Name = "chkEnablePrice";
            this.chkEnablePrice.Size = new System.Drawing.Size(113, 21);
            this.chkEnablePrice.TabIndex = 76;
            this.chkEnablePrice.Text = "Filter by Price";
            this.chkEnablePrice.UseVisualStyleBackColor = true;
            this.chkEnablePrice.CheckedChanged += new System.EventHandler(this.chkEnablePrice_CheckedChanged);
            // 
            // chkEnableDuration
            // 
            this.chkEnableDuration.AutoSize = true;
            this.chkEnableDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEnableDuration.Location = new System.Drawing.Point(184, 107);
            this.chkEnableDuration.Name = "chkEnableDuration";
            this.chkEnableDuration.Size = new System.Drawing.Size(135, 21);
            this.chkEnableDuration.TabIndex = 77;
            this.chkEnableDuration.Text = "Filter by Duration";
            this.chkEnableDuration.UseVisualStyleBackColor = true;
            this.chkEnableDuration.CheckedChanged += new System.EventHandler(this.chkEnableDuration_CheckedChanged);
            // 
            // MembershipTypeFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.chkEnableDuration);
            this.Controls.Add(this.chkEnablePrice);
            this.Controls.Add(this.nudDurationTo);
            this.Controls.Add(this.nudDurationFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudPriceTo);
            this.Controls.Add(this.nudPriceFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkInactive);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.chkFreezeAllowed);
            this.Name = "MembershipTypeFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MembershipTypeFilterForm";
            this.Load += new System.EventHandler(this.MembershipTypeFilterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.CheckBox chkFreezeAllowed;
        private System.Windows.Forms.NumericUpDown nudPriceFrom;
        private System.Windows.Forms.NumericUpDown nudPriceTo;
        private System.Windows.Forms.NumericUpDown nudDurationTo;
        private System.Windows.Forms.NumericUpDown nudDurationFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEnablePrice;
        private System.Windows.Forms.CheckBox chkEnableDuration;
    }
}