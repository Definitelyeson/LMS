    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Utilities;

namespace LibraryManagementSystem.View
{
    public partial class frmAddUser : Form
    {
        private UsersViewModel usersViewModel;
        private string selectedImagePath = ""; // To store the selected image path
        private ErrorProvider errorProvider;   // ErrorProvider for real-time validation
                                               // Declare an event to notify when a user is added
        public event EventHandler UserAdded;
        public frmAddUser(UsersViewModel usersViewModel)
        {
            InitializeComponent();

            this.usersViewModel = usersViewModel;
            SetDefaultImage(); // Set the default image for the PictureBox


            // Initialize ErrorProvider
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink; // Prevent blinking

            // Attach event handlers for real-time validation
            AttachValidationEvents();
        }

        // Attach validation events for real-time validation
        private void AttachValidationEvents()
        {
            txtName.TextChanged += ValidateName;
            txtEmailAddress.TextChanged += ValidateEmail;
            txtContactNumber.TextChanged += ValidateContactNumber;
            cmbPosition.OnSelectedIndexChanged += ValidatePosition;
            txtUsername.TextChanged += ValidateUsername;
            txtPassword.TextChanged += ValidatePassword;
            txtConfirmPassword.TextChanged += ValidateConfirmPassword;
        }
        // Validate all fields on form
        private bool ValidateForm()
        {
            bool isValid = true;

            // Trigger validations for each field
            ValidateName(null, null);
            ValidateEmail(null, null);
            ValidateContactNumber(null, null);
            ValidatePosition(null, null);
            ValidateUsername(null, null);
            ValidatePassword(null, null);
            ValidateConfirmPassword(null, null);

            foreach (Control control in this.Controls)
            {
                if (errorProvider.GetError(control) != "")
                {
                    control.Focus();
                    return false;
                }
            }

            return isValid;
        }
        private void ToggleSaveButton()
        {
            btnSave.Enabled = ValidateForm();
        }



        // Real-time validation for Name
        private void ValidateName(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Texts))
            {
                errorProvider.SetError(txtName, "Name is required.");
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }

        // Real-time validation for Email
        private void ValidateEmail(object sender, EventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple email validation pattern
            if (string.IsNullOrWhiteSpace(txtEmailAddress.Texts))
            {
                errorProvider.SetError(txtEmailAddress, "Email address is required.");
            }
            else if (!Regex.IsMatch(txtEmailAddress.Texts, emailPattern))
            {
                errorProvider.SetError(txtEmailAddress, "Please enter a valid email address.");
            }
            else
            {
                errorProvider.SetError(txtEmailAddress, "");
            }
        }


        // Real-time validation for Contact Number
        private void ValidateContactNumber(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContactNumber.Texts))
            {
                errorProvider.SetError(txtContactNumber, "Contact number is required.");
            }
            else
            {
                errorProvider.SetError(txtContactNumber, "");
            }
        }


        // Real-time validation for Position
        private void ValidatePosition(object sender, EventArgs e)
        {
            if (cmbPosition.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbPosition, "Please select a position.");
            }
            else
            {
                errorProvider.SetError(cmbPosition, "");
            }
        }

        // Real-time validation for Username
        private void ValidateUsername(object sender, EventArgs e)
        {
            string usernamePattern = @"^[a-zA-Z0-9]{6,16}$"; // Only alphanumeric, 6 to 16 characters
            if (string.IsNullOrWhiteSpace(txtUsername.Texts))
            {
                errorProvider.SetError(txtUsername, "Username is required.");
            }
            else if (!Regex.IsMatch(txtUsername.Texts, usernamePattern))
            {
                errorProvider.SetError(txtUsername, "Username must be 6-16 characters, alphanumeric only.");
            }
            else
            {
                errorProvider.SetError(txtUsername, "");
            }
        }

        // Real-time validation for Password
        private void ValidatePassword(object sender, EventArgs e)
        {
            string passwordPattern = @"^[a-zA-Z0-9]{6,16}$"; // Only alphanumeric, 6 to 16 characters
            if (string.IsNullOrWhiteSpace(txtPassword.Texts))
            {
                errorProvider.SetError(txtPassword, "Password is required.");
            }
            else if (!Regex.IsMatch(txtPassword.Texts, passwordPattern))
            {
                errorProvider.SetError(txtPassword, "Password must be 6-16 characters, alphanumeric only.");
            }
            else
            {
                errorProvider.SetError(txtPassword, "");
            }
        }


        // Real-time validation for Confirm Password
        private void ValidateConfirmPassword(object sender, EventArgs e)
        {
            if (txtPassword.Texts != txtConfirmPassword.Texts)
            {
                errorProvider.SetError(txtConfirmPassword, "Passwords do not match.");
            }
            else
            {
                errorProvider.SetError(txtConfirmPassword, "");
            }
        }


        // Set a default image when the form loads
        private void SetDefaultImage()
        {
            pbProfile.Image = Properties.Resources.placeholder; // Load a default image from resources
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate the form before proceeding
            if (!ValidateForm()) // Ensure ValidateForm checks all fields
            {
                MessageBox.Show("Please correct the errors in the form before saving.");
                return;
            }

            try
            {
                // Hash the password using bcrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Texts);

                // Use default image if no image was selected
                string photoPath = GetPhotoPath();

                // Create a new user object
                Users newUser = new Users
                {
                    Name = txtName.Texts,
                    BirthDate = dtpBirthdate.Value, // Assuming you have a DateTimePicker for birthdate
                    Address = txtAddress.Texts,
                    ContactNo = txtContactNumber.Texts,
                    EmailAddress = txtEmailAddress.Texts,
                    Position = cmbPosition.SelectedItem.ToString(),
                    Username = txtUsername.Texts,
                    Password = hashedPassword, // Store the hashed password
                    PhotoPath = photoPath,     // Store the selected image or default image path
                    CreatedAt = DateTime.Now
                };

                // Add the new user to the ViewModel
                usersViewModel.AddUser(newUser);

                MessageBox.Show("User added successfully!");

                // Raise the UserAdded event to notify FrmUsers
                UserAdded?.Invoke(this, EventArgs.Empty);

                // Optionally, clear the form after adding the user
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        // Method to handle getting the photo path, either from user selection or default
        private string GetPhotoPath()
        {
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                // If the user selected an image, return that path
                return selectedImagePath;
            }
            else
            {
                // Otherwise, use the default image from resources
                string imagesFolderPath = Path.Combine(Application.StartupPath, "Images");
                string defaultImagePath = Path.Combine(imagesFolderPath, "default_image.png");

                // Create the Images folder if it doesn't exist
                if (!Directory.Exists(imagesFolderPath))
                {
                    Directory.CreateDirectory(imagesFolderPath);
                }

                // Save the default image to the folder if it hasn't been saved yet
                if (!File.Exists(defaultImagePath))
                {
                    Properties.Resources.default_image.Save(defaultImagePath); // Save the image from resources
                }

                // Return the path to the default image
                return defaultImagePath;
            }
        }


        private void ClearForm()
        {
            txtName.Texts = "";
            dtpBirthdate.Value = DateTime.Now;
            txtAddress.Texts = "";
            txtContactNumber.Texts = "";
            txtEmailAddress.Texts = "";
            cmbPosition.SelectedIndex = -1;
            txtUsername.Texts = "";
            txtPassword.Texts = "";
            txtConfirmPassword.Texts = "";
            pbProfile.Image = Properties.Resources.placeholder;
            selectedImagePath = "";

            errorProvider.Clear();

        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Profile Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Image file types

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName; // Store the selected image path
                    pbProfile.Image = Image.FromFile(selectedImagePath); // Display the selected image
                }
            }
        }

        private void frmAddUser_MouseDown(object sender, MouseEventArgs e)
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
