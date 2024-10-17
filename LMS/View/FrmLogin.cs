using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS.CustomControls;
using LMS.Model;
using LMS.ViewModel;
using LMS.Utilities;

namespace LMS.View
{
    public partial class FrmLogin : Form
    {
        // ViewModel to interact with the user data and handle business logic
        private UsersViewModel _usersViewModel;
        private readonly ToastNotifier _notifier = new ToastNotifier();

        public FrmLogin()
        {
            InitializeComponent();
            _usersViewModel = new UsersViewModel(); // Initialize the ViewModel

        }

        private void CheckBoxShowPass_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (e.Checked)
            {
                // If checked, show the password regardless of text
                TxtPassword.PasswordChar = '\0';
            }
            else
            {
                // If unchecked, mask the password input (but only if there is text)
                if (!string.IsNullOrEmpty(TxtPassword.Text))
                {
                    TxtPassword.PasswordChar = '*';
                }
            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                // If the text is empty, we show the placeholder and remove masking
                TxtPassword.PasswordChar = '\0';
            }
            else
            {
                // If there's text, mask the password input
                TxtPassword.PasswordChar = '*';
            }
        }
       
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve user input from textboxes
            string username = TxtUsername.Text;
            string password = TxtPassword.Text; // Use TxtPassword, not TxtUsername

            // Attempt to log in using the ViewModel
            Users loggedInUser = _usersViewModel.Login(username, password);

            if (loggedInUser != null)
            {
                _notifier.Alert("Logged in successfully!", customToast.enmType.Success);
                Session.Login(loggedInUser);

                // Redirect based on the user's position
                if (loggedInUser.Position == "Student")
                {
                    FrmStudentDashboard studentDashboard = new FrmStudentDashboard(loggedInUser);
                    studentDashboard.Show();
                }
                else
                {
                    FrmAdminDashboard dashboard = new FrmAdminDashboard(loggedInUser);
                    dashboard.Show();
                }

                this.Hide(); // Optionally hide the login form
            }
            else
            {
                _notifier.Alert("Login failed. Incorrect username or password.", customToast.enmType.Error);
            }
        }
    }
 }

