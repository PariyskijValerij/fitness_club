namespace fitness_club.Forms
{
    partial class ClubFilterForm
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
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.chkKiev = new System.Windows.Forms.CheckBox();
            this.chkKharkiv = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(128, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Status:";
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkInactive.Location = new System.Drawing.Point(131, 64);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(75, 21);
            this.chkInactive.TabIndex = 17;
            this.chkInactive.Text = "Inactive";
            this.chkInactive.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkActive.Location = new System.Drawing.Point(131, 37);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(65, 21);
            this.chkActive.TabIndex = 16;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(198, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 15;
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
            this.btnApply.TabIndex = 14;
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
            this.lblLogin.Size = new System.Drawing.Size(39, 20);
            this.lblLogin.TabIndex = 13;
            this.lblLogin.Text = "City:";
            // 
            // chkKiev
            // 
            this.chkKiev.AutoSize = true;
            this.chkKiev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkKiev.Location = new System.Drawing.Point(14, 61);
            this.chkKiev.Name = "chkKiev";
            this.chkKiev.Size = new System.Drawing.Size(53, 21);
            this.chkKiev.TabIndex = 11;
            this.chkKiev.Text = "Kyiv";
            this.chkKiev.UseVisualStyleBackColor = true;
            // 
            // chkKharkiv
            // 
            this.chkKharkiv.AutoSize = true;
            this.chkKharkiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkKharkiv.Location = new System.Drawing.Point(14, 34);
            this.chkKharkiv.Name = "chkKharkiv";
            this.chkKharkiv.Size = new System.Drawing.Size(74, 21);
            this.chkKharkiv.TabIndex = 10;
            this.chkKharkiv.Text = "Kharkiv";
            this.chkKharkiv.UseVisualStyleBackColor = true;
            // 
            // ClubFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkInactive);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.chkKiev);
            this.Controls.Add(this.chkKharkiv);
            this.Name = "ClubFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Club Filters";
            this.Load += new System.EventHandler(this.ClubFilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.CheckBox chkKiev;
        private System.Windows.Forms.CheckBox chkKharkiv;
    }
}