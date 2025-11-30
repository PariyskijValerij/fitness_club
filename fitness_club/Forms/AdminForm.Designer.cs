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
            this.button1 = new System.Windows.Forms.Button();
            this.btnManageMemberships = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenClients
            // 
            this.btnOpenClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOpenClients.Location = new System.Drawing.Point(24, 22);
            this.btnOpenClients.Name = "btnOpenClients";
            this.btnOpenClients.Size = new System.Drawing.Size(145, 42);
            this.btnOpenClients.TabIndex = 0;
            this.btnOpenClients.Text = "Manage Clients";
            this.btnOpenClients.UseVisualStyleBackColor = true;
            this.btnOpenClients.Click += new System.EventHandler(this.btnOpenClients_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(326, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Manage Clubs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManageMemberships
            // 
            this.btnManageMemberships.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnManageMemberships.Location = new System.Drawing.Point(175, 22);
            this.btnManageMemberships.Name = "btnManageMemberships";
            this.btnManageMemberships.Size = new System.Drawing.Size(145, 59);
            this.btnManageMemberships.TabIndex = 3;
            this.btnManageMemberships.Text = "Memberships (TODO)";
            this.btnManageMemberships.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageMemberships);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOpenClients);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AdminForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenClients;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnManageMemberships;
    }
}