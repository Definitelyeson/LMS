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
using ClosedXML.Excel;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Utilities;

namespace LibraryManagementSystem.View
{
    public partial class frmEditUser : Form
    {
        private Users user; // User to edit
        private UsersViewModel viewModel;
       
        public frmEditUser(Users userToEdit, UsersViewModel viewModel)
        {
            InitializeComponent();

            user = userToEdit;
            this.viewModel = viewModel;

            // Fill form fields with user details
            txtName.Texts = user.Name;
            txtContactNumber.Texts = user.ContactNo;
            txtEmailAddress.Texts = user.EmailAddress;
            txtAddress.Texts = user.Address;
            cmbPosition.Texts = user.Position;
            txtUsername.Texts = user.Username;
            dtpBirthdate.Value = user.BirthDate.HasValue ? user.BirthDate.Value : DateTime.Now;

            // Load current photo
            LoadUserPhoto();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Update user object with form data
            user.Name = txtName.Texts;
            user.ContactNo = txtContactNumber.Texts;
            user.EmailAddress = txtEmailAddress.Texts;
            user.Position = cmbPosition.Texts;
            user.Username = txtUsername.Texts;
            user.BirthDate = dtpBirthdate.Value;

            // Handle password update
            if (!string.IsNullOrEmpty(txtPassword.Texts))
            {
                if (txtPassword.Texts == txtConfirmPassword.Texts)
                {
                    // Hash the new password before updating
                    user.Password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Texts);
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
                pbProfile.Image = Image.FromFile(user.PhotoPath);
            }
            else
            {
                pbProfile.Image = Properties.Resources.default_image; // Placeholder
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
                    pbProfile.Image = Image.FromFile(user.PhotoPath); // Display the new photo
                }
            }
        }

        private void frmEditUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormDragHandler.DragForm(this); // Call the helper class to handle dragging
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

