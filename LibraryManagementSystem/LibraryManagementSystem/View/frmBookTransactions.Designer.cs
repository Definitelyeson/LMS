namespace LibraryManagementSystem.View
{
    partial class frmBookTransactions
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOkay = new CustomControls.RJControls.RJButton();
            this.btnPdf = new CustomControls.RJControls.RJButton();
            this.btnExcel = new CustomControls.RJControls.RJButton();
            this.btnCustom = new CustomControls.RJControls.RJButton();
            this.btnThisMonth = new CustomControls.RJControls.RJButton();
            this.btnLast3Days = new CustomControls.RJControls.RJButton();
            this.btnThisWeek = new CustomControls.RJControls.RJButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new CustomControls.RJControls.RJDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDate = new CustomControls.RJControls.RJDatePicker();
            this.rjComboBox1 = new CustomControls.RJControls.RJComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNext = new CustomControls.RJControls.RJButton();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPrev = new CustomControls.RJControls.RJButton();
            this.panelTransactions = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnOkay);
            this.panel1.Controls.Add(this.btnPdf);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnCustom);
            this.panel1.Controls.Add(this.btnThisMonth);
            this.panel1.Controls.Add(this.btnLast3Days);
            this.panel1.Controls.Add(this.btnThisWeek);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.rjComboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 132);
            this.panel1.TabIndex = 0;
            // 
            // btnOkay
            // 
            this.btnOkay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOkay.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOkay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOkay.BorderRadius = 0;
            this.btnOkay.BorderSize = 0;
            this.btnOkay.FlatAppearance.BorderSize = 0;
            this.btnOkay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkay.ForeColor = System.Drawing.Color.White;
            this.btnOkay.Location = new System.Drawing.Point(748, 12);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(102, 29);
            this.btnOkay.TabIndex = 11;
            this.btnOkay.Text = "Okay";
            this.btnOkay.TextColor = System.Drawing.Color.White;
            this.btnOkay.UseVisualStyleBackColor = false;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPdf.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPdf.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPdf.BorderRadius = 0;
            this.btnPdf.BorderSize = 0;
            this.btnPdf.FlatAppearance.BorderSize = 0;
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.ForeColor = System.Drawing.Color.White;
            this.btnPdf.Location = new System.Drawing.Point(748, 82);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(102, 35);
            this.btnPdf.TabIndex = 10;
            this.btnPdf.Text = "PDF";
            this.btnPdf.TextColor = System.Drawing.Color.White;
            this.btnPdf.UseVisualStyleBackColor = false;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExcel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExcel.BorderRadius = 0;
            this.btnExcel.BorderSize = 0;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(630, 82);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(102, 35);
            this.btnExcel.TabIndex = 9;
            this.btnExcel.Text = "Excel";
            this.btnExcel.TextColor = System.Drawing.Color.White;
            this.btnExcel.UseVisualStyleBackColor = false;
            // 
            // btnCustom
            // 
            this.btnCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCustom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCustom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCustom.BorderRadius = 0;
            this.btnCustom.BorderSize = 0;
            this.btnCustom.FlatAppearance.BorderSize = 0;
            this.btnCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustom.ForeColor = System.Drawing.Color.White;
            this.btnCustom.Location = new System.Drawing.Point(630, 12);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(102, 29);
            this.btnCustom.TabIndex = 8;
            this.btnCustom.Text = "Custom";
            this.btnCustom.TextColor = System.Drawing.Color.White;
            this.btnCustom.UseVisualStyleBackColor = false;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThisMonth.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThisMonth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThisMonth.BorderRadius = 0;
            this.btnThisMonth.BorderSize = 0;
            this.btnThisMonth.FlatAppearance.BorderSize = 0;
            this.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisMonth.ForeColor = System.Drawing.Color.White;
            this.btnThisMonth.Location = new System.Drawing.Point(507, 12);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(102, 29);
            this.btnThisMonth.TabIndex = 7;
            this.btnThisMonth.Text = "This Month";
            this.btnThisMonth.TextColor = System.Drawing.Color.White;
            this.btnThisMonth.UseVisualStyleBackColor = false;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // btnLast3Days
            // 
            this.btnLast3Days.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLast3Days.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLast3Days.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLast3Days.BorderRadius = 0;
            this.btnLast3Days.BorderSize = 0;
            this.btnLast3Days.FlatAppearance.BorderSize = 0;
            this.btnLast3Days.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast3Days.ForeColor = System.Drawing.Color.White;
            this.btnLast3Days.Location = new System.Drawing.Point(389, 13);
            this.btnLast3Days.Name = "btnLast3Days";
            this.btnLast3Days.Size = new System.Drawing.Size(102, 29);
            this.btnLast3Days.TabIndex = 6;
            this.btnLast3Days.Text = "Last 3 Days";
            this.btnLast3Days.TextColor = System.Drawing.Color.White;
            this.btnLast3Days.UseVisualStyleBackColor = false;
            this.btnLast3Days.Click += new System.EventHandler(this.btnLast3Days_Click);
            // 
            // btnThisWeek
            // 
            this.btnThisWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThisWeek.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThisWeek.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThisWeek.BorderRadius = 0;
            this.btnThisWeek.BorderSize = 0;
            this.btnThisWeek.FlatAppearance.BorderSize = 0;
            this.btnThisWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisWeek.ForeColor = System.Drawing.Color.White;
            this.btnThisWeek.Location = new System.Drawing.Point(268, 13);
            this.btnThisWeek.Name = "btnThisWeek";
            this.btnThisWeek.Size = new System.Drawing.Size(102, 29);
            this.btnThisWeek.TabIndex = 5;
            this.btnThisWeek.Text = "This Week";
            this.btnThisWeek.TextColor = System.Drawing.Color.White;
            this.btnThisWeek.UseVisualStyleBackColor = false;
            this.btnThisWeek.Click += new System.EventHandler(this.btnThisWeek_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From Date:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dtpEndDate.BorderSize = 1;
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpEndDate.Location = new System.Drawing.Point(268, 82);
            this.dtpEndDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(341, 35);
            this.dtpEndDate.SkinColor = System.Drawing.Color.Transparent;
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.TextColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dtpStartDate.BorderSize = 1;
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpStartDate.Location = new System.Drawing.Point(21, 82);
            this.dtpStartDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 35);
            this.dtpStartDate.SkinColor = System.Drawing.Color.Transparent;
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.TextColor = System.Drawing.Color.Black;
            // 
            // rjComboBox1
            // 
            this.rjComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rjComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rjComboBox1.BorderSize = 1;
            this.rjComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.rjComboBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.rjComboBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rjComboBox1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.rjComboBox1.ListTextColor = System.Drawing.Color.DimGray;
            this.rjComboBox1.Location = new System.Drawing.Point(21, 12);
            this.rjComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.rjComboBox1.Name = "rjComboBox1";
            this.rjComboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.rjComboBox1.Size = new System.Drawing.Size(200, 30);
            this.rjComboBox1.TabIndex = 0;
            this.rjComboBox1.Texts = "Sort";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.lblPage);
            this.panel2.Controls.Add(this.btnPrev);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 454);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(908, 42);
            this.panel2.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNext.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNext.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNext.BorderRadius = 10;
            this.btnNext.BorderSize = 0;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(491, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(91, 27);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.TextColor = System.Drawing.Color.White;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(423, 12);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(32, 13);
            this.lblPage.TabIndex = 4;
            this.lblPage.Text = "Page";
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPrev.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPrev.BorderColor = System.Drawing.Color.PaleGreen;
            this.btnPrev.BorderRadius = 10;
            this.btnPrev.BorderSize = 0;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(326, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(91, 27);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "Previous";
            this.btnPrev.TextColor = System.Drawing.Color.White;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // panelTransactions
            // 
            this.panelTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTransactions.Location = new System.Drawing.Point(0, 132);
            this.panelTransactions.Name = "panelTransactions";
            this.panelTransactions.Size = new System.Drawing.Size(908, 322);
            this.panelTransactions.TabIndex = 2;
            // 
            // frmBookTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 496);
            this.Controls.Add(this.panelTransactions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBookTransactions";
            this.Text = "Transanctions";
            this.Load += new System.EventHandler(this.frmBookTransactions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJDatePicker dtpStartDate;
        private CustomControls.RJControls.RJComboBox rjComboBox1;
        private CustomControls.RJControls.RJButton btnPdf;
        private CustomControls.RJControls.RJButton btnExcel;
        private CustomControls.RJControls.RJButton btnCustom;
        private CustomControls.RJControls.RJButton btnThisMonth;
        private CustomControls.RJControls.RJButton btnLast3Days;
        private CustomControls.RJControls.RJButton btnThisWeek;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJDatePicker dtpEndDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTransactions;
        private CustomControls.RJControls.RJButton btnNext;
        private System.Windows.Forms.Label lblPage;
        private CustomControls.RJControls.RJButton btnPrev;
        private CustomControls.RJControls.RJButton btnOkay;
    }
}