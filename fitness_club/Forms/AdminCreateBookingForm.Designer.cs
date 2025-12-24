namespace fitness_club.Forms
{
    partial class AdminCreateBookingForm
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
            this.lblClientInfo = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.dgvAvailableSessions = new System.Windows.Forms.DataGridView();
            this.cbMemberships = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClientInfo
            // 
            this.lblClientInfo.AutoSize = true;
            this.lblClientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblClientInfo.Location = new System.Drawing.Point(12, 9);
            this.lblClientInfo.Name = "lblClientInfo";
            this.lblClientInfo.Size = new System.Drawing.Size(77, 20);
            this.lblClientInfo.TabIndex = 29;
            this.lblClientInfo.Text = "ClientInfo";
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(748, 12);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(103, 23);
            this.btnBook.TabIndex = 31;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // dgvAvailableSessions
            // 
            this.dgvAvailableSessions.AllowUserToAddRows = false;
            this.dgvAvailableSessions.AllowUserToDeleteRows = false;
            this.dgvAvailableSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAvailableSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableSessions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAvailableSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableSessions.Location = new System.Drawing.Point(16, 69);
            this.dgvAvailableSessions.MultiSelect = false;
            this.dgvAvailableSessions.Name = "dgvAvailableSessions";
            this.dgvAvailableSessions.ReadOnly = true;
            this.dgvAvailableSessions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAvailableSessions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableSessions.Size = new System.Drawing.Size(834, 369);
            this.dgvAvailableSessions.TabIndex = 33;
            // 
            // cbMemberships
            // 
            this.cbMemberships.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMemberships.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbMemberships.FormattingEnabled = true;
            this.cbMemberships.Location = new System.Drawing.Point(16, 39);
            this.cbMemberships.Name = "cbMemberships";
            this.cbMemberships.Size = new System.Drawing.Size(491, 24);
            this.cbMemberships.TabIndex = 34;
            this.cbMemberships.SelectedIndexChanged += new System.EventHandler(this.cbMemberships_SelectedIndexChanged);
            // 
            // AdminCreateBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 450);
            this.Controls.Add(this.cbMemberships);
            this.Controls.Add(this.dgvAvailableSessions);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.lblClientInfo);
            this.Name = "AdminCreateBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create booking";
            this.Load += new System.EventHandler(this.AdminCreateBookingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClientInfo;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.DataGridView dgvAvailableSessions;
        private System.Windows.Forms.ComboBox cbMemberships;
    }
}