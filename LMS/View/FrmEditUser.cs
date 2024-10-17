using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LMS.Model;
using LMS.ViewModel;

namespace LMS.View
{
    public partial class FrmEditUser : Form
    {
        private Users user; // User to edit
        private UsersViewModel viewModel;
       
        public FrmEditUser(Users userToEdit, UsersViewModel viewModel)
        {
            InitializeComponent();

            user = userToEdit;
            this.viewModel = viewModel;

            // Fill form fields with user details
            TxtName.Text = user.Name;
            TxtContactNo.Text = user.ContactNo;
            TxtEmailAddress.Text = user.EmailAddress;
            TxtAddress.Text = user.Address;
            CmbPosition.Text = user.Position;
            TxtUsername.Text = user.Username;
            DtpBirthday.Value = user.BirthDate.HasValue ? user.BirthDate.Value : DateTime.Now;

            // Load current photo
            LoadUserPhoto();

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Update user object with form data
            user.Name = TxtName.Text;
            user.ContactNo = TxtContactNo.Text;
            user.EmailAddress = TxtEmailAddress.Text;
            user.Position = CmbPosition.Text;
            user.Username = TxtUsername.Text;
            user.BirthDate = DtpBirthday.Value;

            // Handle password update
            if (!string.IsNullOrEmpty(TxtPassword.Text))
            {
                if (TxtPassword.Text == TxtConfirmPassword.Text)
                {
                    // Hash the new password before updating
                    user.Password = BCrypt.Net.BCrypt.HashPassword(TxtPassword.Text);
                }
                else
                {
                    MessageBox.Show("New passwords do not match!");
                    return; // Prevent saving if passwords don't match
                }
            }

            // Update the user in the database
            viewModel.UpdateUser(user);

            // Close form
            this.Close();
        }
        private void LoadUserPhoto()
        {
            if (!string.IsNullOrEmpty(user.PhotoPath) && File.Exists(user.PhotoPath))
            {
                PbProfile.Image = Image.FromFile(user.PhotoPath);
            }
            else
            {
                PbProfile.Image = Properties.Resources.default_image; // Placeholder
            }
        }

        private void PbProfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    user.PhotoPath = openFileDialog.FileName; // Store the new photo path
                    PbProfile.Image = Image.FromFile(user.PhotoPath); // Display the new photo
                }
            }
        }
    }
}
