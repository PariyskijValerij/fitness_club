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
            this.btnManageClubs = new System.Windows.Forms.Button();
            this.btnManageMembershipTypes = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnManageTrainers = new System.Windows.Forms.Button();
            this.lblPopularClub = new System.Windows.Forms.Label();
            this.lblPopularMembership = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenClients
            // 
            this.btnOpenClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOpenClients.Location = new System.Drawing.Point(24, 22);
            this.btnOpenClients.Name = "btnOpenClients";
            this.btnOpenClients.Size = new System.Drawing.Size(145, 59);
            this.btnOpenClients.TabIndex = 0;
            this.btnOpenClients.Text = "Manage Clients";
            this.btnOpenClients.UseVisualStyleBackColor = true;
            this.btnOpenClients.Click += new System.EventHandler(this.btnOpenClients_Click);
            // 
            // btnManageClubs
            // 
            this.btnManageClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnManageClubs.Location = new System.Drawing.Point(326, 22);
            this.btnManageClubs.Name = "btnManageClubs";
            this.btnManageClubs.Size = new System.Drawing.Size(145, 59);
            this.btnManageClubs.TabIndex = 2;
            this.btnManageClubs.Text = "Manage Clubs";
            this.btnManageClubs.UseVisualStyleBackColor = true;
            this.btnManageClubs.Click += new System.EventHandler(this.btnManageClubs_Click);
            // 
            // btnManageMembershipTypes
            // 
            this.btnManageMembershipTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnManageMembershipTypes.Location = new System.Drawing.Point(175, 22);
            this.btnManageMembershipTypes.Name = "btnManageMembershipTypes";
            this.btnManageMembershipTypes.Size = new System.Drawing.Size(145, 59);
            this.btnManageMembershipTypes.TabIndex = 3;
            this.btnManageMembershipTypes.Text = "Memberships Types";
            this.btnManageMembershipTypes.UseVisualStyleBackColor = true;
            this.btnManageMembershipTypes.Click += new System.EventHandler(this.btnManageMembershipTypes_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStatistics.Location = new System.Drawing.Point(643, 22);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(145, 59);
            this.btnStatistics.TabIndex = 4;
            this.btnStatistics.Text = "Statistics and Reports";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnManageTrainers
            // 
            this.btnManageTrainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnManageTrainers.Location = new System.Drawing.Point(24, 87);
            this.btnManageTrainers.Name = "btnManageTrainers";
            this.btnManageTrainers.Size = new System.Drawing.Size(145, 59);
            this.btnManageTrainers.TabIndex = 5;
            this.btnManageTrainers.Text = "Manage Trainers";
            this.btnManageTrainers.UseVisualStyleBackColor = true;
            this.btnManageTrainers.Click += new System.EventHandler(this.btnManageTrainers_Click);
            // 
            // lblPopularClub
            // 
            this.lblPopularClub.AutoSize = true;
            this.lblPopularClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPopularClub.Location = new System.Drawing.Point(32, 404);
            this.lblPopularClub.Name = "lblPopularClub";
            this.lblPopularClub.Size = new System.Drawing.Size(95, 20);
            this.lblPopularClub.TabIndex = 31;
            this.lblPopularClub.Text = "PopularClub";
            // 
            // lblPopularMembership
            // 
            this.lblPopularMembership.AutoSize = true;
            this.lblPopularMembership.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPopularMembership.Location = new System.Drawing.Point(32, 367);
            this.lblPopularMembership.Name = "lblPopularMembership";
            this.lblPopularMembership.Size = new System.Drawing.Size(150, 20);
            this.lblPopularMembership.TabIndex = 30;
            this.lblPopularMembership.Text = "PopularMembership";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPopularClub);
            this.Controls.Add(this.lblPopularMembership);
            this.Controls.Add(this.btnManageTrainers);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnManageMembershipTypes);
            this.Controls.Add(this.btnManageClubs);
            this.Controls.Add(this.btnOpenClients);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenClients;
        private System.Windows.Forms.Button btnManageClubs;
        private System.Windows.Forms.Button btnManageMembershipTypes;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnManageTrainers;
        private System.Windows.Forms.Label lblPopularClub;
        private System.Windows.Forms.Label lblPopularMembership;
    }
}