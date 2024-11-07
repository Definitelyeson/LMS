namespace LibraryManagementSystem.View
{
    partial class frmAdminDashboard
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCloseChildForm = new CustomControls.RJControls.RJButton();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.profileBox = new CustomControls.RJControls.RJCircularPictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new CustomControls.RJControls.RJButton();
            this.btnBookArchives = new CustomControls.RJControls.RJButton();
            this.btnManageUsers = new CustomControls.RJControls.RJButton();
            this.btnTransactions = new CustomControls.RJControls.RJButton();
            this.btnReturnBooks = new CustomControls.RJControls.RJButton();
            this.btnBorrowBooks = new CustomControls.RJControls.RJButton();
            this.btnBookDetails = new CustomControls.RJControls.RJButton();
            this.btnSearchBooks = new CustomControls.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LabelTotalUsers = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LabelTotalBorrowed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelTotalArchived = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelTotalBooks = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileBox)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(9)))));
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Controls.Add(this.btnCloseChildForm);
            this.panelTitle.Controls.Add(this.lblPosition);
            this.panelTitle.Controls.Add(this.lblName);
            this.panelTitle.Controls.Add(this.profileBox);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1370, 54);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(658, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 37);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "DASHBOARD";
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseChildForm.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCloseChildForm.BorderColor = System.Drawing.Color.Transparent;
            this.btnCloseChildForm.BorderRadius = 0;
            this.btnCloseChildForm.BorderSize = 0;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseChildForm.Image = global::LibraryManagementSystem.Properties.Resources.Back;
            this.btnCloseChildForm.Location = new System.Drawing.Point(202, 3);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(44, 45);
            this.btnCloseChildForm.TabIndex = 3;
            this.btnCloseChildForm.TextColor = System.Drawing.Color.White;
            this.btnCloseChildForm.UseVisualStyleBackColor = false;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(62, 25);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(37, 15);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "ESON";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(62, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "ESON";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // profileBox
            // 
            this.profileBox.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.profileBox.BorderColor = System.Drawing.Color.Red;
            this.profileBox.BorderColor2 = System.Drawing.Color.Transparent;
            this.profileBox.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.profileBox.BorderSize = 2;
            this.profileBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.profileBox.GradientAngle = 50F;
            this.profileBox.Location = new System.Drawing.Point(0, 0);
            this.profileBox.Name = "profileBox";
            this.profileBox.Size = new System.Drawing.Size(53, 53);
            this.profileBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profileBox.TabIndex = 0;
            this.profileBox.TabStop = false;
            this.profileBox.Click += new System.EventHandler(this.profileBox_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnBookArchives);
            this.panelMenu.Controls.Add(this.btnManageUsers);
            this.panelMenu.Controls.Add(this.btnTransactions);
            this.panelMenu.Controls.Add(this.btnReturnBooks);
            this.panelMenu.Controls.Add(this.btnBorrowBooks);
            this.panelMenu.Controls.Add(this.btnBookDetails);
            this.panelMenu.Controls.Add(this.btnSearchBooks);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 54);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(156, 695);
            this.panelMenu.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.BackgroundColor = System.Drawing.Color.White;
            this.btnLogout.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogout.BorderRadius = 0;
            this.btnLogout.BorderSize = 0;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.Image = global::LibraryManagementSystem.Properties.Resources.image_11;
            this.btnLogout.Location = new System.Drawing.Point(0, 655);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(156, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = " LOGOUT";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.TextColor = System.Drawing.Color.Red;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnBookArchives
            // 
            this.btnBookArchives.BackColor = System.Drawing.Color.White;
            this.btnBookArchives.BackgroundColor = System.Drawing.Color.White;
            this.btnBookArchives.BorderColor = System.Drawing.Color.Transparent;
            this.btnBookArchives.BorderRadius = 0;
            this.btnBookArchives.BorderSize = 0;
            this.btnBookArchives.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBookArchives.FlatAppearance.BorderSize = 0;
            this.btnBookArchives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookArchives.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookArchives.ForeColor = System.Drawing.Color.Black;
            this.btnBookArchives.Image = global::LibraryManagementSystem.Properties.Resources.image_14;
            this.btnBookArchives.Location = new System.Drawing.Point(0, 342);
            this.btnBookArchives.Name = "btnBookArchives";
            this.btnBookArchives.Size = new System.Drawing.Size(156, 40);
            this.btnBookArchives.TabIndex = 7;
            this.btnBookArchives.Text = " Book Archives";
            this.btnBookArchives.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookArchives.TextColor = System.Drawing.Color.Black;
            this.btnBookArchives.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBookArchives.UseVisualStyleBackColor = false;
            this.btnBookArchives.Click += new System.EventHandler(this.btnBookArchives_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.BackColor = System.Drawing.Color.White;
            this.btnManageUsers.BackgroundColor = System.Drawing.Color.White;
            this.btnManageUsers.BorderColor = System.Drawing.Color.Transparent;
            this.btnManageUsers.BorderRadius = 0;
            this.btnManageUsers.BorderSize = 0;
            this.btnManageUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageUsers.FlatAppearance.BorderSize = 0;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUsers.ForeColor = System.Drawing.Color.Black;
            this.btnManageUsers.Image = global::LibraryManagementSystem.Properties.Resources.image_7;
            this.btnManageUsers.Location = new System.Drawing.Point(0, 302);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(156, 40);
            this.btnManageUsers.TabIndex = 6;
            this.btnManageUsers.Text = " Manage Users";
            this.btnManageUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageUsers.TextColor = System.Drawing.Color.Black;
            this.btnManageUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageUsers.UseVisualStyleBackColor = false;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.BackColor = System.Drawing.Color.White;
            this.btnTransactions.BackgroundColor = System.Drawing.Color.White;
            this.btnTransactions.BorderColor = System.Drawing.Color.Transparent;
            this.btnTransactions.BorderRadius = 0;
            this.btnTransactions.BorderSize = 0;
            this.btnTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactions.ForeColor = System.Drawing.Color.Black;
            this.btnTransactions.Image = global::LibraryManagementSystem.Properties.Resources.image_10;
            this.btnTransactions.Location = new System.Drawing.Point(0, 262);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(156, 40);
            this.btnTransactions.TabIndex = 5;
            this.btnTransactions.Text = " Book Transactions";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTransactions.TextColor = System.Drawing.Color.Black;
            this.btnTransactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransactions.UseVisualStyleBackColor = false;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnReturnBooks
            // 
            this.btnReturnBooks.BackColor = System.Drawing.Color.White;
            this.btnReturnBooks.BackgroundColor = System.Drawing.Color.White;
            this.btnReturnBooks.BorderColor = System.Drawing.Color.Transparent;
            this.btnReturnBooks.BorderRadius = 0;
            this.btnReturnBooks.BorderSize = 0;
            this.btnReturnBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReturnBooks.FlatAppearance.BorderSize = 0;
            this.btnReturnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBooks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnBooks.ForeColor = System.Drawing.Color.Black;
            this.btnReturnBooks.Image = global::LibraryManagementSystem.Properties.Resources.image_9;
            this.btnReturnBooks.Location = new System.Drawing.Point(0, 222);
            this.btnReturnBooks.Name = "btnReturnBooks";
            this.btnReturnBooks.Size = new System.Drawing.Size(156, 40);
            this.btnReturnBooks.TabIndex = 4;
            this.btnReturnBooks.Text = " Return Books";
            this.btnReturnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturnBooks.TextColor = System.Drawing.Color.Black;
            this.btnReturnBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnBooks.UseVisualStyleBackColor = false;
            this.btnReturnBooks.Click += new System.EventHandler(this.btnReturnBooks_Click);
            // 
            // btnBorrowBooks
            // 
            this.btnBorrowBooks.BackColor = System.Drawing.Color.White;
            this.btnBorrowBooks.BackgroundColor = System.Drawing.Color.White;
            this.btnBorrowBooks.BorderColor = System.Drawing.Color.Transparent;
            this.btnBorrowBooks.BorderRadius = 0;
            this.btnBorrowBooks.BorderSize = 0;
            this.btnBorrowBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBorrowBooks.FlatAppearance.BorderSize = 0;
            this.btnBorrowBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowBooks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowBooks.ForeColor = System.Drawing.Color.Black;
            this.btnBorrowBooks.Image = global::LibraryManagementSystem.Properties.Resources.image_8;
            this.btnBorrowBooks.Location = new System.Drawing.Point(0, 182);
            this.btnBorrowBooks.Name = "btnBorrowBooks";
            this.btnBorrowBooks.Size = new System.Drawing.Size(156, 40);
            this.btnBorrowBooks.TabIndex = 3;
            this.btnBorrowBooks.Text = " Borrow Books";
            this.btnBorrowBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrowBooks.TextColor = System.Drawing.Color.Black;
            this.btnBorrowBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrowBooks.UseVisualStyleBackColor = false;
            this.btnBorrowBooks.Click += new System.EventHandler(this.btnBorrowBooks_Click);
            // 
            // btnBookDetails
            // 
            this.btnBookDetails.BackColor = System.Drawing.Color.White;
            this.btnBookDetails.BackgroundColor = System.Drawing.Color.White;
            this.btnBookDetails.BorderColor = System.Drawing.Color.Transparent;
            this.btnBookDetails.BorderRadius = 0;
            this.btnBookDetails.BorderSize = 0;
            this.btnBookDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBookDetails.FlatAppearance.BorderSize = 0;
            this.btnBookDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookDetails.ForeColor = System.Drawing.Color.Black;
            this.btnBookDetails.Image = global::LibraryManagementSystem.Properties.Resources.image_5__1_;
            this.btnBookDetails.Location = new System.Drawing.Point(0, 142);
            this.btnBookDetails.Name = "btnBookDetails";
            this.btnBookDetails.Size = new System.Drawing.Size(156, 40);
            this.btnBookDetails.TabIndex = 2;
            this.btnBookDetails.Text = " Book Details";
            this.btnBookDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookDetails.TextColor = System.Drawing.Color.Black;
            this.btnBookDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBookDetails.UseVisualStyleBackColor = false;
            this.btnBookDetails.Click += new System.EventHandler(this.btnBookDetails_Click);
            // 
            // btnSearchBooks
            // 
            this.btnSearchBooks.BackColor = System.Drawing.Color.White;
            this.btnSearchBooks.BackgroundColor = System.Drawing.Color.White;
            this.btnSearchBooks.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearchBooks.BorderRadius = 0;
            this.btnSearchBooks.BorderSize = 0;
            this.btnSearchBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearchBooks.FlatAppearance.BorderSize = 0;
            this.btnSearchBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBooks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBooks.ForeColor = System.Drawing.Color.Black;
            this.btnSearchBooks.Image = global::LibraryManagementSystem.Properties.Resources.image_4;
            this.btnSearchBooks.Location = new System.Drawing.Point(0, 102);
            this.btnSearchBooks.Name = "btnSearchBooks";
            this.btnSearchBooks.Size = new System.Drawing.Size(156, 40);
            this.btnSearchBooks.TabIndex = 1;
            this.btnSearchBooks.Text = " Search Books";
            this.btnSearchBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchBooks.TextColor = System.Drawing.Color.Black;
            this.btnSearchBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchBooks.UseVisualStyleBackColor = false;
            this.btnSearchBooks.Click += new System.EventHandler(this.btnSearchBooks_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::LibraryManagementSystem.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.tableLayoutPanel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(156, 54);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1214, 695);
            this.panelMain.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1214, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.LabelTotalUsers);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.pictureBox5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(912, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(299, 94);
            this.panel4.TabIndex = 3;
            // 
            // LabelTotalUsers
            // 
            this.LabelTotalUsers.AutoSize = true;
            this.LabelTotalUsers.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalUsers.Location = new System.Drawing.Point(135, 29);
            this.LabelTotalUsers.Name = "LabelTotalUsers";
            this.LabelTotalUsers.Size = new System.Drawing.Size(84, 65);
            this.LabelTotalUsers.TabIndex = 2;
            this.LabelTotalUsers.Text = "22";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(131, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "Total User";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox5.Image = global::LibraryManagementSystem.Properties.Resources.users;
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(108, 90);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.LabelTotalBorrowed);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(609, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 94);
            this.panel3.TabIndex = 2;
            // 
            // LabelTotalBorrowed
            // 
            this.LabelTotalBorrowed.AutoSize = true;
            this.LabelTotalBorrowed.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalBorrowed.Location = new System.Drawing.Point(135, 29);
            this.LabelTotalBorrowed.Name = "LabelTotalBorrowed";
            this.LabelTotalBorrowed.Size = new System.Drawing.Size(84, 65);
            this.LabelTotalBorrowed.TabIndex = 2;
            this.LabelTotalBorrowed.Text = "22";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(113, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Borrowed Books";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox4.Image = global::LibraryManagementSystem.Properties.Resources.borrow;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(108, 90);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.LabelTotalArchived);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(306, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 94);
            this.panel2.TabIndex = 1;
            // 
            // LabelTotalArchived
            // 
            this.LabelTotalArchived.AutoSize = true;
            this.LabelTotalArchived.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalArchived.Location = new System.Drawing.Point(135, 29);
            this.LabelTotalArchived.Name = "LabelTotalArchived";
            this.LabelTotalArchived.Size = new System.Drawing.Size(84, 65);
            this.LabelTotalArchived.TabIndex = 2;
            this.LabelTotalArchived.Text = "22";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(120, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Archived Books";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = global::LibraryManagementSystem.Properties.Resources.Archives;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(108, 90);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.LabelTotalBooks);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 94);
            this.panel1.TabIndex = 0;
            // 
            // LabelTotalBooks
            // 
            this.LabelTotalBooks.AutoSize = true;
            this.LabelTotalBooks.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalBooks.Location = new System.Drawing.Point(133, 20);
            this.LabelTotalBooks.Name = "LabelTotalBooks";
            this.LabelTotalBooks.Size = new System.Drawing.Size(84, 65);
            this.LabelTotalBooks.TabIndex = 2;
            this.LabelTotalBooks.Text = "22";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Books";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::LibraryManagementSystem.Properties.Resources.Books1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileBox)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private CustomControls.RJControls.RJCircularPictureBox profileBox;
        private System.Windows.Forms.Panel panelMenu;
        private CustomControls.RJControls.RJButton btnSearchBooks;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJButton btnBookArchives;
        private CustomControls.RJControls.RJButton btnManageUsers;
        private CustomControls.RJControls.RJButton btnTransactions;
        private CustomControls.RJControls.RJButton btnReturnBooks;
        private CustomControls.RJControls.RJButton btnBorrowBooks;
        private CustomControls.RJControls.RJButton btnBookDetails;
        private CustomControls.RJControls.RJButton btnLogout;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblName;
        private CustomControls.RJControls.RJButton btnCloseChildForm;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LabelTotalUsers;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LabelTotalBorrowed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LabelTotalArchived;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LabelTotalBooks;
        private System.Windows.Forms.Label label3;
    }
}