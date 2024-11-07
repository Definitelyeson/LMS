using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.ViewModel;
using CustomControls.RJControls;
using LibraryManagementSystem.Utilities;

namespace LibraryManagementSystem.View
{
    public partial class frmAdminDashboard : Form
    {

        private RJButton currentButton;
        private Form activeForm;
        private List<Control> initialControls;
        private Users currentUser;
        private BooksViewModel _booksViewModel;
        private BorrowerViewModel _borrowerViewModel;
        private UsersViewModel _usersViewModel;

        public frmAdminDashboard(Users user)
        {
            InitializeComponent();

            currentUser = user; // Store the logged-in user information
                                // Initialize ViewModels
            _booksViewModel = new BooksViewModel();
            _borrowerViewModel = new BorrowerViewModel();
            _usersViewModel = new UsersViewModel();

            DisplayUserInfo();
            LoadDashboardData(); // Load dashboard data on form load

            // Save initial controls
            initialControls = new List<Control>();
            foreach (Control ctrl in panelMain.Controls)
            {
                initialControls.Add(ctrl);
            }

            // Hide/Disable buttons based on role
            if (currentUser.Position == "Student Assistant")
            {
                RestrictToStudentAssistant();
            }

            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            DisplayUserInfo();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void DisplayUserInfo()
        {
            lblName.Text = currentUser.Name; // Display name
            lblPosition.Text = currentUser.Position; // Display position
                                                       // Load user profile image
            if (File.Exists(currentUser.PhotoPath))
            {
                profileBox.Image = Image.FromFile(currentUser.PhotoPath); // Display profile photo
            }
        }
        private async void LoadDashboardData()
        {
            try
            {
                // Load books data
                await _booksViewModel.LoadBooksAsync();
                int totalBooks = _booksViewModel.BooksList.Count;

                // Count archived books
                await _booksViewModel.LoadArchivesAsync();
                int totalArchivedBooks = _booksViewModel.BooksList.Count;

                // Load borrowers data (to count borrowed books)
                var unreturnedBooks = await _borrowerViewModel.LoadAllUnreturnedBooksAsync("All"); // Pass "All" as filter
                int totalBorrowedBooks = unreturnedBooks.Count;

                // Set values on the dashboard panels
                LabelTotalBooks.Text = totalBooks.ToString();
                LabelTotalArchived.Text = totalArchivedBooks.ToString();
                LabelTotalBorrowed.Text = totalBorrowedBooks.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}");
            }
        }

        private void RestrictToStudentAssistant()
        {
            // Hide or disable buttons that are not relevant to the student role
            btnManageUsers.Visible = false;
            btnBookDetails.Visible = false;
            btnTransactions.Visible = false;
            btnBookArchives.Visible = false;

            // Optionally, disable instead of hiding
            // btnManageUsers.Enabled = false;
            // btnBookDetails.Enabled = false;

            // You can change the title or some other information to make it clear it's the student dashboard
            //lblTitle.Text = "Student Assistant Dashboard";
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (RJButton)btnSender)
                {
                    DisableButton();
                    currentButton = (RJButton)btnSender;
                    currentButton.BackColor = Color.FromArgb(0, 64, 0);
                    currentButton.ForeColor = Color.White;
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(RJButton))
                {
                    previousBtn.BackColor = Color.White;
                    previousBtn.ForeColor = Color.Black;

                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            // Clear existing controls
            panelMain.Controls.Clear();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(childForm);
            this.panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        //resetting childform back to dashboard
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "DASHBOARD";
            currentButton = null;
            btnCloseChildForm.Visible = false;

            // Clear current controls
            panelMain.Controls.Clear();

            // Restore initial controls
            foreach (Control ctrl in initialControls)
            {
                panelMain.Controls.Add(ctrl);
            }
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            LoadDashboardData();
        }

        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSearchBooks(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Logout(); // Clear the session
            MessageBox.Show("You have logged out successfully!");

            // Redirect to login form
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
            this.Hide(); // Close the dashboard
        }

        private void btnBookDetails_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBookDetails(), sender);
        }

        private void btnBorrowBooks_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("User is not logged in.");
                return;
            }
            OpenChildForm(new View.frmBookBorrowing(currentUser), sender);
        }

        private void btnReturnBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReturnBooks(currentUser), sender);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBookTransactions(), sender);
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmUsers(), sender);
        }

        private void btnBookArchives_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBookArchives(), sender);
        }

        private void profileBox_Click(object sender, EventArgs e)
        {

            OpenChildForm(new frmProfile(currentUser), null);
        }
    }
}
