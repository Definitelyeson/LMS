using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.CustomControl;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Utilities;

namespace LibraryManagementSystem.View
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve user input from textboxes
            string username = txtUsername.Texts;
            string password = txtPassword.Texts;

            // Attempt to log in using the ViewModel
            Users loggedInUser = _usersViewModel.Login(username, password);

            if (loggedInUser != null)
            {
                _notifier.Alert("Logged in successfully!", frmAlert.enmType.Success);
                Session.Login(loggedInUser);

                // Redirect to a unified dashboard form
                frmAdminDashboard dashboard = new frmAdminDashboard(loggedInUser);
                dashboard.Show();

                this.Hide(); // Optionally hide the login form
            }
            else
            {
                _notifier.Alert("Login failed. Incorrect username or password.", frmAlert.enmType.Error);
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
