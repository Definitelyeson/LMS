using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.View
{
    public partial class frmProfile : Form
    {
        private Users currentUser; // Store the current logged-in user
        public frmProfile(Users user)
        {
            InitializeComponent();

            currentUser = user; // Initialize with the logged-in user
            DisplayUserInfo();
        }

        private void DisplayUserInfo()
        {
            if (currentUser.BirthDate.HasValue)
            {
                lblBirthdate.Text = currentUser.BirthDate.Value.ToString("MMMM dd, yyyy");
            }
            else
            {
                lblBirthdate.Text = "N/A";  // Or some placeholder if the birthdate is not available
            }

            lblName.Text = currentUser.Name;
            lblContactNumber.Text = currentUser.ContactNo;
            lblEmailAddress.Text = currentUser.EmailAddress;
            //lblBirthdate.Text = currentUser.BirthDate.ToString("MMMM dd, yyyy");
            lblAddress.Text = currentUser.Address;
            lblPosition.Text = currentUser.Position;
            lblUsername.Text = currentUser.Username;

            // Assuming the profile image is stored in a path within the user model
            if (!string.IsNullOrEmpty(currentUser.PhotoPath) && System.IO.File.Exists(currentUser.PhotoPath))
            {
                pbProfile.Image = Image.FromFile(currentUser.PhotoPath);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
