using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
using LMS.Model;
using System.IO;
using LMS.Utilities;
using static System.Collections.Specialized.BitVector32;
using LMS.ViewModel;

namespace LMS.View
{
    public partial class FrmAdminDashboard : Form
    {
        //Fields
        private BunifuButton currentButton;
        private Form activeForm;
        private List<Control> initialControls;
        private Users currentUser;
        private BooksViewModel _booksViewModel;
        private BorrowerViewModel _borrowerViewModel;
        private UsersViewModel _usersViewModel;



        public FrmAdminDashboard(Users user)
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
            foreach (Control ctrl in PanelMain.Controls)
            {
                initialControls.Add(ctrl);
            }

            BtnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            DisplayUserInfo();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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
                var unreturnedBooks = await _borrowerViewModel.LoadAllUnreturnedBooksAsync();
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

        private void BtnSearchBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSearchBooks(), sender);
        }

        private void BtnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            LoadDashboardData();
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (BunifuButton)btnSender)
                {
                    DisableButton();
                    currentButton = (BunifuButton)btnSender;
                    //currentButton.BackColor = Color.FromArgb(0, 64, 0);
                    //currentButton.ForeColor = Color.White;
                    BtnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in PanelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(BunifuButton))
                {
                    //previousBtn.BackColor = Color.White;
                    //previousBtn.ForeColor = Color.Black;

                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            // Clear existing controls
            PanelMain.Controls.Clear();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelMain.Controls.Add(childForm);
            this.PanelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            LabelTitle.Text = childForm.Text;
        }
        //resetting childform back to dashboard
        private void Reset()
        {
            DisableButton();
            LabelTitle.Text = "DASHBOARD";
            currentButton = null;
            BtnCloseChildForm.Visible = false;

            // Clear current controls
            PanelMain.Controls.Clear();

            // Restore initial controls
            foreach (Control ctrl in initialControls)
            {
                PanelMain.Controls.Add(ctrl);
            }
        }

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void DisplayUserInfo()
        {
            LabelName.Text = currentUser.Name; // Display name
            LabelPosition.Text = currentUser.Position; // Display position
                                                 // Load user profile image
            if (File.Exists(currentUser.PhotoPath))
            {
                profileBox.Image = Image.FromFile(currentUser.PhotoPath); // Display profile photo
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Logout(); // Clear the session
            MessageBox.Show("You have logged out successfully!");

            // Redirect to login form
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
            this.Hide(); // Close the dashboard
        }

        private void BtnBookDetails_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBookDetails(), sender);
        }

        private void BtnTransactions_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTransactions(), sender);
        }

        private void BtnReturnBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmReturnBooks(currentUser), sender);

        }

        private void BtnBorrowBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.FrmBookBorrowing(currentUser), sender);
        }

        private void BtnManageUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmUsers(), sender);
        }

        private void BtnBookArchives_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBookArchives(), sender);
        }
    }
}
