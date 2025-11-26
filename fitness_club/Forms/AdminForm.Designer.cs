namespace fitness_club.Forms
{
    partial class AdminForm
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
            this.btnOpenClients = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenClients
            // 
            this.btnOpenClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOpenClients.Location = new System.Drawing.Point(23, 74);
            this.btnOpenClients.Name = "btnOpenClients";
            this.btnOpenClients.Size = new System.Drawing.Size(145, 42);
            this.btnOpenClients.TabIndex = 0;
            this.btnOpenClients.Text = "Manage Clients";
            this.btnOpenClients.UseVisualStyleBackColor = true;
            this.btnOpenClients.Click += new System.EventHandler(this.btnOpenClients_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLogin.Location = new System.Drawing.Point(19, 41);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(140, 20);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Users managment";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.btnOpenClients);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenClients;
        private System.Windows.Forms.Label lblLogin;
    }
}