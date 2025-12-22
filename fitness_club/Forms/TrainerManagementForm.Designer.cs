namespace fitness_club.Forms
{
    partial class TrainerManagementForm
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
            this.btnSessions = new System.Windows.Forms.Button();
            this.btnDeleteTrainer = new System.Windows.Forms.Button();
            this.btnEditTrainer = new System.Windows.Forms.Button();
            this.btnAddTrainer = new System.Windows.Forms.Button();
            this.btnTrainerClearSearch = new System.Windows.Forms.Button();
            this.btnTrainerSearch = new System.Windows.Forms.Button();
            this.txtTrainerSearch = new System.Windows.Forms.TextBox();
            this.dgvTrainers = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSessions
            // 
            this.btnSessions.Location = new System.Drawing.Point(267, 0);
            this.btnSessions.Name = "btnSessions";
            this.btnSessions.Size = new System.Drawing.Size(79, 23);
            this.btnSessions.TabIndex = 26;
            this.btnSessions.Text = "Sessions";
            this.btnSessions.UseVisualStyleBackColor = true;
            this.btnSessions.Click += new System.EventHandler(this.btnSessions_Click);
            // 
            // btnDeleteTrainer
            // 
            this.btnDeleteTrainer.Location = new System.Drawing.Point(129, 0);
            this.btnDeleteTrainer.Name = "btnDeleteTrainer";
            this.btnDeleteTrainer.Size = new System.Drawing.Size(61, 23);
            this.btnDeleteTrainer.TabIndex = 25;
            this.btnDeleteTrainer.Text = "Delete";
            this.btnDeleteTrainer.UseVisualStyleBackColor = true;
            this.btnDeleteTrainer.Click += new System.EventHandler(this.btnDeleteTrainer_Click);
            // 
            // btnEditTrainer
            // 
            this.btnEditTrainer.Location = new System.Drawing.Point(72, 0);
            this.btnEditTrainer.Name = "btnEditTrainer";
            this.btnEditTrainer.Size = new System.Drawing.Size(61, 23);
            this.btnEditTrainer.TabIndex = 24;
            this.btnEditTrainer.Text = "Edit";
            this.btnEditTrainer.UseVisualStyleBackColor = true;
            this.btnEditTrainer.Click += new System.EventHandler(this.btnEditTrainer_Click);
            // 
            // btnAddTrainer
            // 
            this.btnAddTrainer.Location = new System.Drawing.Point(13, 0);
            this.btnAddTrainer.Name = "btnAddTrainer";
            this.btnAddTrainer.Size = new System.Drawing.Size(61, 23);
            this.btnAddTrainer.TabIndex = 23;
            this.btnAddTrainer.Text = "Add";
            this.btnAddTrainer.UseVisualStyleBackColor = true;
            this.btnAddTrainer.Click += new System.EventHandler(this.btnAddTrainer_Click);
            // 
            // btnTrainerClearSearch
            // 
            this.btnTrainerClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTrainerClearSearch.Location = new System.Drawing.Point(474, 48);
            this.btnTrainerClearSearch.Name = "btnTrainerClearSearch";
            this.btnTrainerClearSearch.Size = new System.Drawing.Size(116, 29);
            this.btnTrainerClearSearch.TabIndex = 20;
            this.btnTrainerClearSearch.Text = "Clear";
            this.btnTrainerClearSearch.UseVisualStyleBackColor = true;
            this.btnTrainerClearSearch.Click += new System.EventHandler(this.btnTrainerClearSearch_Click);
            // 
            // btnTrainerSearch
            // 
            this.btnTrainerSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTrainerSearch.Location = new System.Drawing.Point(352, 48);
            this.btnTrainerSearch.Name = "btnTrainerSearch";
            this.btnTrainerSearch.Size = new System.Drawing.Size(116, 29);
            this.btnTrainerSearch.TabIndex = 19;
            this.btnTrainerSearch.Text = "Search";
            this.btnTrainerSearch.UseVisualStyleBackColor = true;
            this.btnTrainerSearch.Click += new System.EventHandler(this.btnTrainerSearch_Click);
            // 
            // txtTrainerSearch
            // 
            this.txtTrainerSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtTrainerSearch.Location = new System.Drawing.Point(13, 48);
            this.txtTrainerSearch.Name = "txtTrainerSearch";
            this.txtTrainerSearch.Size = new System.Drawing.Size(333, 29);
            this.txtTrainerSearch.TabIndex = 18;
            // 
            // dgvTrainers
            // 
            this.dgvTrainers.AllowUserToAddRows = false;
            this.dgvTrainers.AllowUserToDeleteRows = false;
            this.dgvTrainers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrainers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainers.Location = new System.Drawing.Point(13, 83);
            this.dgvTrainers.MultiSelect = false;
            this.dgvTrainers.Name = "dgvTrainers";
            this.dgvTrainers.ReadOnly = true;
            this.dgvTrainers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvTrainers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrainers.Size = new System.Drawing.Size(919, 426);
            this.dgvTrainers.TabIndex = 17;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRefresh.Location = new System.Drawing.Point(596, 48);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(31, 29);
            this.btnRefresh.TabIndex = 37;
            this.btnRefresh.Text = "⟳";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // TrainerManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 521);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSessions);
            this.Controls.Add(this.btnDeleteTrainer);
            this.Controls.Add(this.btnEditTrainer);
            this.Controls.Add(this.btnAddTrainer);
            this.Controls.Add(this.btnTrainerClearSearch);
            this.Controls.Add(this.btnTrainerSearch);
            this.Controls.Add(this.txtTrainerSearch);
            this.Controls.Add(this.dgvTrainers);
            this.Name = "TrainerManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trainers Management";
            this.Load += new System.EventHandler(this.TrainerManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSessions;
        private System.Windows.Forms.Button btnDeleteTrainer;
        private System.Windows.Forms.Button btnEditTrainer;
        private System.Windows.Forms.Button btnAddTrainer;
        private System.Windows.Forms.Button btnTrainerClearSearch;
        private System.Windows.Forms.Button btnTrainerSearch;
        private System.Windows.Forms.TextBox txtTrainerSearch;
        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.Button btnRefresh;
    }
}