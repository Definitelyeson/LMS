namespace LibraryManagementSystem.View
{
    partial class frmBorrowerDetails
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
            this.txtStudentName = new CustomControls.RJControls.RJTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSection = new CustomControls.RJControls.RJComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new CustomControls.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContatNumber = new CustomControls.RJControls.RJTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new CustomControls.RJControls.RJTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpReturnDate = new CustomControls.RJControls.RJDatePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new CustomControls.RJControls.RJButton();
            this.btnSave = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Borrower\'s Information";
            // 
            // txtStudentName
            // 
            this.txtStudentName.BackColor = System.Drawing.SystemColors.Window;
            this.txtStudentName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtStudentName.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtStudentName.BorderRadius = 0;
            this.txtStudentName.BorderSize = 2;
            this.txtStudentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStudentName.Location = new System.Drawing.Point(50, 118);
            this.txtStudentName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentName.Multiline = false;
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtStudentName.PasswordChar = false;
            this.txtStudentName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtStudentName.PlaceholderText = "Enter Student Name";
            this.txtStudentName.Size = new System.Drawing.Size(250, 36);
            this.txtStudentName.TabIndex = 5;
            this.txtStudentName.Texts = "";
            this.txtStudentName.UnderlinedStyle = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Student Name";
            // 
            // cmbSection
            // 
            this.cmbSection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbSection.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmbSection.BorderSize = 1;
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbSection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.ForeColor = System.Drawing.Color.DimGray;
            this.cmbSection.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmbSection.Items.AddRange(new object[] {
            "BSIT",
            "BSCRIM",
            "RADTECH"});
            this.cmbSection.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cmbSection.ListTextColor = System.Drawing.Color.DimGray;
            this.cmbSection.Location = new System.Drawing.Point(50, 194);
            this.cmbSection.MinimumSize = new System.Drawing.Size(200, 30);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Padding = new System.Windows.Forms.Padding(1);
            this.cmbSection.Size = new System.Drawing.Size(248, 30);
            this.cmbSection.TabIndex = 13;
            this.cmbSection.Texts = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Course/Section";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtAddress.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtAddress.BorderRadius = 0;
            this.txtAddress.BorderSize = 2;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddress.Location = new System.Drawing.Point(48, 264);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Multiline = false;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAddress.PasswordChar = false;
            this.txtAddress.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAddress.PlaceholderText = "Enter Address";
            this.txtAddress.Size = new System.Drawing.Size(250, 36);
            this.txtAddress.TabIndex = 15;
            this.txtAddress.Texts = "";
            this.txtAddress.UnderlinedStyle = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Address:";
            // 
            // txtContatNumber
            // 
            this.txtContatNumber.BackColor = System.Drawing.SystemColors.Window;
            this.txtContatNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtContatNumber.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtContatNumber.BorderRadius = 0;
            this.txtContatNumber.BorderSize = 2;
            this.txtContatNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContatNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContatNumber.Location = new System.Drawing.Point(48, 342);
            this.txtContatNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtContatNumber.Multiline = false;
            this.txtContatNumber.Name = "txtContatNumber";
            this.txtContatNumber.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtContatNumber.PasswordChar = false;
            this.txtContatNumber.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtContatNumber.PlaceholderText = "Enter Contact Number";
            this.txtContatNumber.Size = new System.Drawing.Size(250, 36);
            this.txtContatNumber.TabIndex = 17;
            this.txtContatNumber.Texts = "";
            this.txtContatNumber.UnderlinedStyle = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Contact Number:";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmailAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtEmailAddress.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtEmailAddress.BorderRadius = 0;
            this.txtEmailAddress.BorderSize = 2;
            this.txtEmailAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmailAddress.Location = new System.Drawing.Point(48, 419);
            this.txtEmailAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailAddress.Multiline = false;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEmailAddress.PasswordChar = false;
            this.txtEmailAddress.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmailAddress.PlaceholderText = "Enter Email Address";
            this.txtEmailAddress.Size = new System.Drawing.Size(250, 36);
            this.txtEmailAddress.TabIndex = 19;
            this.txtEmailAddress.Texts = "";
            this.txtEmailAddress.UnderlinedStyle = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Email Address:";
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dtpReturnDate.BorderSize = 1;
            this.dtpReturnDate.CustomFormat = "";
            this.dtpReturnDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.Location = new System.Drawing.Point(48, 496);
            this.dtpReturnDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(248, 35);
            this.dtpReturnDate.SkinColor = System.Drawing.Color.Transparent;
            this.dtpReturnDate.TabIndex = 21;
            this.dtpReturnDate.TextColor = System.Drawing.Color.Black;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 472);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 21);
            this.label7.TabIndex = 20;
            this.label7.Text = "Return Date:";
            // 
            // pbCover
            // 
            this.pbCover.Location = new System.Drawing.Point(352, 118);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(231, 337);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 22;
            this.pbCover.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(367, 462);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(29, 13);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "Title";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.BorderColor = System.Drawing.Color.Maroon;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(380, 496);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 40);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.BorderRadius = 10;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(478, 496);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 40);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmBorrowerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 585);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtContatNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBorrowerDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrower Details";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBorrowerDetails_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJTextBox txtStudentName;
        private System.Windows.Forms.Label label3;
        private CustomControls.RJControls.RJComboBox cmbSection;
        private System.Windows.Forms.Label label6;
        private CustomControls.RJControls.RJTextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtContatNumber;
        private System.Windows.Forms.Label label4;
        private CustomControls.RJControls.RJTextBox txtEmailAddress;
        private System.Windows.Forms.Label label5;
        private CustomControls.RJControls.RJDatePicker dtpReturnDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.Label lblTitle;
        private CustomControls.RJControls.RJButton btnCancel;
        private CustomControls.RJControls.RJButton btnSave;
    }
}