namespace fitness_club.Forms
{
    partial class ClubManagementForm
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
            this.dgvClubs = new System.Windows.Forms.DataGridView();
            this.btnClubClearSearch = new System.Windows.Forms.Button();
            this.btnClubSearch = new System.Windows.Forms.Button();
            this.txtClubSearch = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnDeleteClub = new System.Windows.Forms.Button();
            this.btnEditClub = new System.Windows.Forms.Button();
            this.btnAddClub = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClubs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClubs
            // 
            this.dgvClubs.AllowUserToAddRows = false;
            this.dgvClubs.AllowUserToDeleteRows = false;
            this.dgvClubs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClubs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClubs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvClubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClubs.Location = new System.Drawing.Point(12, 83);
            this.dgvClubs.MultiSelect = false;
            this.dgvClubs.Name = "dgvClubs";
            this.dgvClubs.ReadOnly = true;
            this.dgvClubs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvClubs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClubs.Size = new System.Drawing.Size(919, 426);
            this.dgvClubs.TabIndex = 1;
            // 
            // btnClubClearSearch
            // 
            this.btnClubClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClubClearSearch.Location = new System.Drawing.Point(473, 48);
            this.btnClubClearSearch.Name = "btnClubClearSearch";
            this.btnClubClearSearch.Size = new System.Drawing.Size(116, 29);
            this.btnClubClearSearch.TabIndex = 10;
            this.btnClubClearSearch.Text = "Clear";
            this.btnClubClearSearch.UseVisualStyleBackColor = true;
            this.btnClubClearSearch.Click += new System.EventHandler(this.btnClubClearSearch_Click);
            // 
            // btnClubSearch
            // 
            this.btnClubSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClubSearch.Location = new System.Drawing.Point(351, 48);
            this.btnClubSearch.Name = "btnClubSearch";
            this.btnClubSearch.Size = new System.Drawing.Size(116, 29);
            this.btnClubSearch.TabIndex = 9;
            this.btnClubSearch.Text = "Search";
            this.btnClubSearch.UseVisualStyleBackColor = true;
            this.btnClubSearch.Click += new System.EventHandler(this.btnClubSearch_Click);
            // 
            // txtClubSearch
            // 
            this.txtClubSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtClubSearch.Location = new System.Drawing.Point(12, 48);
            this.txtClubSearch.Name = "txtClubSearch";
            this.txtClubSearch.Size = new System.Drawing.Size(333, 29);
            this.txtClubSearch.TabIndex = 8;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFilter.Location = new System.Drawing.Point(693, 48);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(116, 29);
            this.btnFilter.TabIndex = 12;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClearFilter.Location = new System.Drawing.Point(815, 48);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(116, 29);
            this.btnClearFilter.TabIndex = 11;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnDeleteClub
            // 
            this.btnDeleteClub.Location = new System.Drawing.Point(128, 0);
            this.btnDeleteClub.Name = "btnDeleteClub";
            this.btnDeleteClub.Size = new System.Drawing.Size(61, 23);
            this.btnDeleteClub.TabIndex = 15;
            this.btnDeleteClub.Text = "Delete";
            this.btnDeleteClub.UseVisualStyleBackColor = true;
            this.btnDeleteClub.Click += new System.EventHandler(this.btnDeleteClub_Click);
            // 
            // btnEditClub
            // 
            this.btnEditClub.Location = new System.Drawing.Point(71, 0);
            this.btnEditClub.Name = "btnEditClub";
            this.btnEditClub.Size = new System.Drawing.Size(61, 23);
            this.btnEditClub.TabIndex = 14;
            this.btnEditClub.Text = "Edit";
            this.btnEditClub.UseVisualStyleBackColor = true;
            this.btnEditClub.Click += new System.EventHandler(this.btnEditClub_Click);
            // 
            // btnAddClub
            // 
            this.btnAddClub.Location = new System.Drawing.Point(13, 0);
            this.btnAddClub.Name = "btnAddClub";
            this.btnAddClub.Size = new System.Drawing.Size(61, 23);
            this.btnAddClub.TabIndex = 13;
            this.btnAddClub.Text = "Add";
            this.btnAddClub.UseVisualStyleBackColor = true;
            this.btnAddClub.Click += new System.EventHandler(this.btnAddClub_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.Location = new System.Drawing.Point(266, 0);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(79, 23);
            this.btnRooms.TabIndex = 16;
            this.btnRooms.Text = "Rooms";
            this.btnRooms.UseVisualStyleBackColor = true;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // ClubManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 521);
            this.Controls.Add(this.btnRooms);
            this.Controls.Add(this.btnDeleteClub);
            this.Controls.Add(this.btnEditClub);
            this.Controls.Add(this.btnAddClub);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnClubClearSearch);
            this.Controls.Add(this.btnClubSearch);
            this.Controls.Add(this.txtClubSearch);
            this.Controls.Add(this.dgvClubs);
            this.Name = "ClubManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clubs Management";
            this.Load += new System.EventHandler(this.ClubManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClubs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClubs;
        private System.Windows.Forms.Button btnClubClearSearch;
        private System.Windows.Forms.Button btnClubSearch;
        private System.Windows.Forms.TextBox txtClubSearch;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnDeleteClub;
        private System.Windows.Forms.Button btnEditClub;
        private System.Windows.Forms.Button btnAddClub;
        private System.Windows.Forms.Button btnRooms;
    }
}