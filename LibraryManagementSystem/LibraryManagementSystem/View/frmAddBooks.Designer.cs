namespace LibraryManagementSystem.View
{
    partial class frmAddBooks
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtBookTitle = new CustomControls.RJControls.RJTextBox();
            this.txtAuthor = new CustomControls.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPublisher = new CustomControls.RJControls.RJTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPublishedYear = new CustomControls.RJControls.RJDatePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCategory = new CustomControls.RJControls.RJComboBox();
            this.cmbBookType = new CustomControls.RJControls.RJComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.txtQuantity = new CustomControls.RJControls.RJTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSummary = new CustomControls.RJControls.RJTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new CustomControls.RJControls.RJButton();
            this.btnSave = new CustomControls.RJControls.RJButton();
            this.btnUpdate = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(116, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Book Title:";
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.BackColor = System.Drawing.SystemColors.Window;
            this.txtBookTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtBookTitle.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtBookTitle.BorderRadius = 0;
            this.txtBookTitle.BorderSize = 2;
            this.txtBookTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBookTitle.Location = new System.Drawing.Point(120, 98);
            this.txtBookTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtBookTitle.Multiline = false;
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBookTitle.PasswordChar = false;
            this.txtBookTitle.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtBookTitle.PlaceholderText = "Enter Book Title";
            this.txtBookTitle.Size = new System.Drawing.Size(250, 36);
            this.txtBookTitle.TabIndex = 3;
            this.txtBookTitle.Texts = "";
            this.txtBookTitle.UnderlinedStyle = true;
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuthor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtAuthor.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtAuthor.BorderRadius = 0;
            this.txtAuthor.BorderSize = 2;
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAuthor.Location = new System.Drawing.Point(120, 173);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuthor.Multiline = false;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAuthor.PasswordChar = false;
            this.txtAuthor.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAuthor.PlaceholderText = "Enter Book Author";
            this.txtAuthor.Size = new System.Drawing.Size(250, 36);
            this.txtAuthor.TabIndex = 5;
            this.txtAuthor.Texts = "";
            this.txtAuthor.UnderlinedStyle = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Author:";
            // 
            // txtPublisher
            // 
            this.txtPublisher.BackColor = System.Drawing.SystemColors.Window;
            this.txtPublisher.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtPublisher.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtPublisher.BorderRadius = 0;
            this.txtPublisher.BorderSize = 2;
            this.txtPublisher.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublisher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPublisher.Location = new System.Drawing.Point(120, 251);
            this.txtPublisher.Margin = new System.Windows.Forms.Padding(4);
            this.txtPublisher.Multiline = false;
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPublisher.PasswordChar = false;
            this.txtPublisher.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPublisher.PlaceholderText = "Enter Book Publisher";
            this.txtPublisher.Size = new System.Drawing.Size(250, 36);
            this.txtPublisher.TabIndex = 7;
            this.txtPublisher.Texts = "";
            this.txtPublisher.UnderlinedStyle = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Book Publisher";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(118, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Year Published";
            // 
            // dtpPublishedYear
            // 
            this.dtpPublishedYear.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dtpPublishedYear.BorderSize = 1;
            this.dtpPublishedYear.CustomFormat = "yyyy";
            this.dtpPublishedYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPublishedYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPublishedYear.Location = new System.Drawing.Point(122, 328);
            this.dtpPublishedYear.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpPublishedYear.Name = "dtpPublishedYear";
            this.dtpPublishedYear.ShowUpDown = true;
            this.dtpPublishedYear.Size = new System.Drawing.Size(248, 35);
            this.dtpPublishedYear.SkinColor = System.Drawing.Color.Transparent;
            this.dtpPublishedYear.TabIndex = 9;
            this.dtpPublishedYear.TextColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(118, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmbCategory.BorderSize = 1;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbCategory.ForeColor = System.Drawing.Color.DimGray;
            this.cmbCategory.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmbCategory.Items.AddRange(new object[] {
            "Circulation",
            "",
            "Filipiniana",
            "",
            "Multimedia",
            "",
            "Newly Acquired Book",
            "",
            "Periodical",
            "",
            "Reference",
            "",
            "Reserved",
            "",
            "Supplementary",
            "",
            "Thesis"});
            this.cmbCategory.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cmbCategory.ListTextColor = System.Drawing.Color.DimGray;
            this.cmbCategory.Location = new System.Drawing.Point(122, 403);
            this.cmbCategory.MinimumSize = new System.Drawing.Size(200, 30);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Padding = new System.Windows.Forms.Padding(1);
            this.cmbCategory.Size = new System.Drawing.Size(248, 30);
            this.cmbCategory.TabIndex = 11;
            this.cmbCategory.Texts = "";
            // 
            // cmbBookType
            // 
            this.cmbBookType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbBookType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmbBookType.BorderSize = 1;
            this.cmbBookType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbBookType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbBookType.ForeColor = System.Drawing.Color.DimGray;
            this.cmbBookType.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmbBookType.Items.AddRange(new object[] {
            "Teacher Material Manual",
            "Fiction/Nonfiction",
            "Journal/Magazine "});
            this.cmbBookType.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cmbBookType.ListTextColor = System.Drawing.Color.DimGray;
            this.cmbBookType.Location = new System.Drawing.Point(122, 469);
            this.cmbBookType.MinimumSize = new System.Drawing.Size(200, 30);
            this.cmbBookType.Name = "cmbBookType";
            this.cmbBookType.Padding = new System.Windows.Forms.Padding(1);
            this.cmbBookType.Size = new System.Drawing.Size(248, 30);
            this.cmbBookType.TabIndex = 13;
            this.cmbBookType.Texts = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(118, 445);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Book Type:";
            // 
            // pbCover
            // 
            this.pbCover.Location = new System.Drawing.Point(438, 98);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(277, 189);
            this.pbCover.TabIndex = 14;
            this.pbCover.TabStop = false;
            this.pbCover.Click += new System.EventHandler(this.pbCover_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.txtQuantity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtQuantity.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtQuantity.BorderRadius = 0;
            this.txtQuantity.BorderSize = 2;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQuantity.Location = new System.Drawing.Point(438, 328);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Multiline = false;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtQuantity.PasswordChar = false;
            this.txtQuantity.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtQuantity.PlaceholderText = "Enter Book Quantity";
            this.txtQuantity.Size = new System.Drawing.Size(250, 36);
            this.txtQuantity.TabIndex = 16;
            this.txtQuantity.Texts = "";
            this.txtQuantity.UnderlinedStyle = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(434, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Quatity:";
            // 
            // txtSummary
            // 
            this.txtSummary.BackColor = System.Drawing.SystemColors.Window;
            this.txtSummary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtSummary.BorderFocusColor = System.Drawing.Color.Lime;
            this.txtSummary.BorderRadius = 0;
            this.txtSummary.BorderSize = 2;
            this.txtSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSummary.Location = new System.Drawing.Point(438, 403);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(4);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSummary.PasswordChar = false;
            this.txtSummary.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSummary.PlaceholderText = "Enter Book Publisher";
            this.txtSummary.Size = new System.Drawing.Size(250, 36);
            this.txtSummary.TabIndex = 18;
            this.txtSummary.Texts = "";
            this.txtSummary.UnderlinedStyle = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(434, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 21);
            this.label9.TabIndex = 17;
            this.label9.Text = "Book Summary";
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
            this.btnCancel.Location = new System.Drawing.Point(438, 459);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 40);
            this.btnCancel.TabIndex = 19;
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
            this.btnSave.Location = new System.Drawing.Point(538, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 40);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUpdate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUpdate.BorderRadius = 10;
            this.btnUpdate.BorderSize = 0;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(639, 459);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(76, 40);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextColor = System.Drawing.Color.White;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmAddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.cmbBookType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpPublishedYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBookTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddBooks";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmAddBooks_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private CustomControls.RJControls.RJTextBox txtBookTitle;
        private CustomControls.RJControls.RJTextBox txtAuthor;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtPublisher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomControls.RJControls.RJDatePicker dtpPublishedYear;
        private System.Windows.Forms.Label label6;
        private CustomControls.RJControls.RJComboBox cmbCategory;
        private CustomControls.RJControls.RJComboBox cmbBookType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbCover;
        private CustomControls.RJControls.RJTextBox txtQuantity;
        private System.Windows.Forms.Label label8;
        private CustomControls.RJControls.RJTextBox txtSummary;
        private System.Windows.Forms.Label label9;
        private CustomControls.RJControls.RJButton btnCancel;
        private CustomControls.RJControls.RJButton btnSave;
        private CustomControls.RJControls.RJButton btnUpdate;
    }
}