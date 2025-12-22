namespace fitness_club.Forms
{
    partial class StatisticsForm
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
            this.btnClientsPerClub = new System.Windows.Forms.Button();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.btnTrainerWorkload = new System.Windows.Forms.Button();
            this.bttnSessionOccupancy = new System.Windows.Forms.Button();
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnActiveMembershipsPdf = new System.Windows.Forms.Button();
            this.btnTrainerWorkloadPdf = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPopularMembership = new System.Windows.Forms.Label();
            this.lblPopularClub = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClientsPerClub
            // 
            this.btnClientsPerClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClientsPerClub.Location = new System.Drawing.Point(12, 50);
            this.btnClientsPerClub.Name = "btnClientsPerClub";
            this.btnClientsPerClub.Size = new System.Drawing.Size(181, 48);
            this.btnClientsPerClub.TabIndex = 3;
            this.btnClientsPerClub.Text = "Active clients per club";
            this.btnClientsPerClub.UseVisualStyleBackColor = true;
            this.btnClientsPerClub.Click += new System.EventHandler(this.btnClientsPerClub_Click);
            // 
            // btnRevenue
            // 
            this.btnRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRevenue.Location = new System.Drawing.Point(12, 212);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(181, 48);
            this.btnRevenue.TabIndex = 4;
            this.btnRevenue.Text = "Revenue Analysis";
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // btnTrainerWorkload
            // 
            this.btnTrainerWorkload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTrainerWorkload.Location = new System.Drawing.Point(12, 104);
            this.btnTrainerWorkload.Name = "btnTrainerWorkload";
            this.btnTrainerWorkload.Size = new System.Drawing.Size(181, 48);
            this.btnTrainerWorkload.TabIndex = 5;
            this.btnTrainerWorkload.Text = "Trainer workload";
            this.btnTrainerWorkload.UseVisualStyleBackColor = true;
            this.btnTrainerWorkload.Click += new System.EventHandler(this.btnTrainerWorkload_Click);
            // 
            // bttnSessionOccupancy
            // 
            this.bttnSessionOccupancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bttnSessionOccupancy.Location = new System.Drawing.Point(12, 158);
            this.bttnSessionOccupancy.Name = "bttnSessionOccupancy";
            this.bttnSessionOccupancy.Size = new System.Drawing.Size(181, 48);
            this.bttnSessionOccupancy.TabIndex = 6;
            this.bttnSessionOccupancy.Text = "Session occupancy";
            this.bttnSessionOccupancy.UseVisualStyleBackColor = true;
            this.bttnSessionOccupancy.Click += new System.EventHandler(this.bttnSessionOccupancy_Click);
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.AllowUserToAddRows = false;
            this.dgvStatistics.AllowUserToDeleteRows = false;
            this.dgvStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatistics.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Location = new System.Drawing.Point(199, 50);
            this.dgvStatistics.MultiSelect = false;
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.ReadOnly = true;
            this.dgvStatistics.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatistics.Size = new System.Drawing.Size(646, 451);
            this.dgvStatistics.TabIndex = 18;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.Location = new System.Drawing.Point(199, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 20);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Statistics (table view)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Reports (export to PDF)";
            // 
            // btnActiveMembershipsPdf
            // 
            this.btnActiveMembershipsPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnActiveMembershipsPdf.Location = new System.Drawing.Point(12, 311);
            this.btnActiveMembershipsPdf.Name = "btnActiveMembershipsPdf";
            this.btnActiveMembershipsPdf.Size = new System.Drawing.Size(181, 48);
            this.btnActiveMembershipsPdf.TabIndex = 22;
            this.btnActiveMembershipsPdf.Text = "Active club memberships (PDF)";
            this.btnActiveMembershipsPdf.UseVisualStyleBackColor = true;
            this.btnActiveMembershipsPdf.Click += new System.EventHandler(this.btnActiveMembershipsPdf_Click);
            // 
            // btnTrainerWorkloadPdf
            // 
            this.btnTrainerWorkloadPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTrainerWorkloadPdf.Location = new System.Drawing.Point(12, 365);
            this.btnTrainerWorkloadPdf.Name = "btnTrainerWorkloadPdf";
            this.btnTrainerWorkloadPdf.Size = new System.Drawing.Size(181, 48);
            this.btnTrainerWorkloadPdf.TabIndex = 23;
            this.btnTrainerWorkloadPdf.Text = "Trainer workload (PDF)";
            this.btnTrainerWorkloadPdf.UseVisualStyleBackColor = true;
            this.btnTrainerWorkloadPdf.Click += new System.EventHandler(this.btnTrainerWorkloadPdf_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(14, 462);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "To (for trainer report):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(14, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "From (for trainer report):";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(18, 481);
            this.dtpTo.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(116, 20);
            this.dtpTo.TabIndex = 25;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(18, 439);
            this.dtpFrom.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(116, 20);
            this.dtpFrom.TabIndex = 24;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // lblPopularMembership
            // 
            this.lblPopularMembership.AutoSize = true;
            this.lblPopularMembership.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPopularMembership.Location = new System.Drawing.Point(19, 533);
            this.lblPopularMembership.Name = "lblPopularMembership";
            this.lblPopularMembership.Size = new System.Drawing.Size(150, 20);
            this.lblPopularMembership.TabIndex = 28;
            this.lblPopularMembership.Text = "PopularMembership";
            // 
            // lblPopularClub
            // 
            this.lblPopularClub.AutoSize = true;
            this.lblPopularClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPopularClub.Location = new System.Drawing.Point(19, 570);
            this.lblPopularClub.Name = "lblPopularClub";
            this.lblPopularClub.Size = new System.Drawing.Size(95, 20);
            this.lblPopularClub.TabIndex = 29;
            this.lblPopularClub.Text = "PopularClub";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 615);
            this.Controls.Add(this.lblPopularClub);
            this.Controls.Add(this.lblPopularMembership);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.btnTrainerWorkloadPdf);
            this.Controls.Add(this.btnActiveMembershipsPdf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvStatistics);
            this.Controls.Add(this.bttnSessionOccupancy);
            this.Controls.Add(this.btnTrainerWorkload);
            this.Controls.Add(this.btnRevenue);
            this.Controls.Add(this.btnClientsPerClub);
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Statistics/Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClientsPerClub;
        private System.Windows.Forms.Button btnRevenue;
        private System.Windows.Forms.Button btnTrainerWorkload;
        private System.Windows.Forms.Button bttnSessionOccupancy;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnActiveMembershipsPdf;
        private System.Windows.Forms.Button btnTrainerWorkloadPdf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPopularMembership;
        private System.Windows.Forms.Label lblPopularClub;
    }
}