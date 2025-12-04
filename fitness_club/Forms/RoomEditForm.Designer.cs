namespace fitness_club.Forms
{
    partial class RoomEditForm
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
            this.txtEquipment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudFloor = new System.Windows.Forms.NumericUpDown();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.nudArea = new System.Windows.Forms.NumericUpDown();
            this.lblClub = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEquipment
            // 
            this.txtEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtEquipment.Location = new System.Drawing.Point(23, 215);
            this.txtEquipment.Multiline = true;
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(180, 73);
            this.txtEquipment.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(19, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 63;
            this.label7.Text = "Equipment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(234, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 59;
            this.label4.Text = "Capacity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(19, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Area (м2)";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(238, 215);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(180, 28);
            this.cbStatus.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(234, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(234, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Floor";
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRoomNumber.Location = new System.Drawing.Point(23, 69);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(180, 26);
            this.txtRoomNumber.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(19, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Room Number";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(321, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 31);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(204, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 31);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudFloor
            // 
            this.nudFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nudFloor.Location = new System.Drawing.Point(238, 69);
            this.nudFloor.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFloor.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.nudFloor.Name = "nudFloor";
            this.nudFloor.Size = new System.Drawing.Size(180, 26);
            this.nudFloor.TabIndex = 68;
            this.nudFloor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudCapacity
            // 
            this.nudCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nudCapacity.Location = new System.Drawing.Point(238, 141);
            this.nudCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(180, 26);
            this.nudCapacity.TabIndex = 69;
            this.nudCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudArea
            // 
            this.nudArea.DecimalPlaces = 2;
            this.nudArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nudArea.Location = new System.Drawing.Point(23, 141);
            this.nudArea.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudArea.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudArea.Name = "nudArea";
            this.nudArea.Size = new System.Drawing.Size(180, 26);
            this.nudArea.TabIndex = 70;
            this.nudArea.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblClub
            // 
            this.lblClub.AutoSize = true;
            this.lblClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblClub.Location = new System.Drawing.Point(19, 9);
            this.lblClub.Name = "lblClub";
            this.lblClub.Size = new System.Drawing.Size(60, 24);
            this.lblClub.TabIndex = 71;
            this.lblClub.Text = "label1";
            // 
            // RoomEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 361);
            this.Controls.Add(this.lblClub);
            this.Controls.Add(this.nudArea);
            this.Controls.Add(this.nudCapacity);
            this.Controls.Add(this.nudFloor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtEquipment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.label3);
            this.Name = "RoomEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit/Add Room";
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEquipment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudFloor;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.NumericUpDown nudArea;
        private System.Windows.Forms.Label lblClub;
    }
}