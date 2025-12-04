namespace fitness_club.Forms
{
    partial class MembershipTypeManagementForm
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
            this.btnRooms = new System.Windows.Forms.Button();
            this.btnDeleteMembershipType = new System.Windows.Forms.Button();
            this.btnEditMembershipType = new System.Windows.Forms.Button();
            this.btnAddMembershipType = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnClubClearSearch = new System.Windows.Forms.Button();
            this.btnClubSearch = new System.Windows.Forms.Button();
            this.txtClubSearch = new System.Windows.Forms.TextBox();
            this.dgvMembershipTypes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembershipTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRooms
            // 
            this.btnRooms.Location = new System.Drawing.Point(266, 0);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(145, 23);
            this.btnRooms.TabIndex = 26;
            this.btnRooms.Text = "Memberships//TODO";
            this.btnRooms.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMembershipType
            // 
            this.btnDeleteMembershipType.Location = new System.Drawing.Point(128, 0);
            this.btnDeleteMembershipType.Name = "btnDeleteMembershipType";
            this.btnDeleteMembershipType.Size = new System.Drawing.Size(61, 23);
            this.btnDeleteMembershipType.TabIndex = 25;
            this.btnDeleteMembershipType.Text = "Delete";
            this.btnDeleteMembershipType.UseVisualStyleBackColor = true;
            this.btnDeleteMembershipType.Click += new System.EventHandler(this.btnDeleteMembershipType_Click);
            // 
            // btnEditMembershipType
            // 
            this.btnEditMembershipType.Location = new System.Drawing.Point(71, 0);
            this.btnEditMembershipType.Name = "btnEditMembershipType";
            this.btnEditMembershipType.Size = new System.Drawing.Size(61, 23);
            this.btnEditMembershipType.TabIndex = 24;
            this.btnEditMembershipType.Text = "Edit";
            this.btnEditMembershipType.UseVisualStyleBackColor = true;
            this.btnEditMembershipType.Click += new System.EventHandler(this.btnEditMembershipType_Click);
            // 
            // btnAddMembershipType
            // 
            this.btnAddMembershipType.Location = new System.Drawing.Point(13, 0);
            this.btnAddMembershipType.Name = "btnAddMembershipType";
            this.btnAddMembershipType.Size = new System.Drawing.Size(61, 23);
            this.btnAddMembershipType.TabIndex = 23;
            this.btnAddMembershipType.Text = "Add";
            this.btnAddMembershipType.UseVisualStyleBackColor = true;
            this.btnAddMembershipType.Click += new System.EventHandler(this.btnAddMembershipType_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFilter.Location = new System.Drawing.Point(693, 48);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(116, 29);
            this.btnFilter.TabIndex = 22;
            this.btnFilter.Text = "FilterTODO";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClearFilter.Location = new System.Drawing.Point(815, 48);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(116, 29);
            this.btnClearFilter.TabIndex = 21;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            // 
            // btnClubClearSearch
            // 
            this.btnClubClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClubClearSearch.Location = new System.Drawing.Point(473, 48);
            this.btnClubClearSearch.Name = "btnClubClearSearch";
            this.btnClubClearSearch.Size = new System.Drawing.Size(116, 29);
            this.btnClubClearSearch.TabIndex = 20;
            this.btnClubClearSearch.Text = "ClearTODO";
            this.btnClubClearSearch.UseVisualStyleBackColor = true;
            // 
            // btnClubSearch
            // 
            this.btnClubSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClubSearch.Location = new System.Drawing.Point(351, 48);
            this.btnClubSearch.Name = "btnClubSearch";
            this.btnClubSearch.Size = new System.Drawing.Size(116, 29);
            this.btnClubSearch.TabIndex = 19;
            this.btnClubSearch.Text = "SearchTODO";
            this.btnClubSearch.UseVisualStyleBackColor = true;
            // 
            // txtClubSearch
            // 
            this.txtClubSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtClubSearch.Location = new System.Drawing.Point(12, 48);
            this.txtClubSearch.Name = "txtClubSearch";
            this.txtClubSearch.Size = new System.Drawing.Size(333, 29);
            this.txtClubSearch.TabIndex = 18;
            // 
            // dgvMembershipTypes
            // 
            this.dgvMembershipTypes.AllowUserToAddRows = false;
            this.dgvMembershipTypes.AllowUserToDeleteRows = false;
            this.dgvMembershipTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembershipTypes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMembershipTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembershipTypes.Location = new System.Drawing.Point(13, 83);
            this.dgvMembershipTypes.MultiSelect = false;
            this.dgvMembershipTypes.Name = "dgvMembershipTypes";
            this.dgvMembershipTypes.ReadOnly = true;
            this.dgvMembershipTypes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvMembershipTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembershipTypes.Size = new System.Drawing.Size(919, 426);
            this.dgvMembershipTypes.TabIndex = 17;
            // 
            // MembershipTypeManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 521);
            this.Controls.Add(this.btnRooms);
            this.Controls.Add(this.btnDeleteMembershipType);
            this.Controls.Add(this.btnEditMembershipType);
            this.Controls.Add(this.btnAddMembershipType);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnClubClearSearch);
            this.Controls.Add(this.btnClubSearch);
            this.Controls.Add(this.txtClubSearch);
            this.Controls.Add(this.dgvMembershipTypes);
            this.Name = "MembershipTypeManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Membership Types Management";
            this.Load += new System.EventHandler(this.MembershipTypeManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembershipTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnDeleteMembershipType;
        private System.Windows.Forms.Button btnEditMembershipType;
        private System.Windows.Forms.Button btnAddMembershipType;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnClubClearSearch;
        private System.Windows.Forms.Button btnClubSearch;
        private System.Windows.Forms.TextBox txtClubSearch;
        private System.Windows.Forms.DataGridView dgvMembershipTypes;
    }
}