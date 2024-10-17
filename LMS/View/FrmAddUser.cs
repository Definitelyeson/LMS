using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS.Model;
using System.Xml.Linq;
using LMS.ViewModel;
using System.Text.RegularExpressions;

namespace LMS.View
{
    public partial class FrmAddUser : Form
    {
        private UsersViewModel usersViewModel;
        private string selectedImagePath = ""; // To store the selected image path
        private ErrorProvider errorProvider;   // ErrorProvider for real-time validation
                                               // Declare an event to notify when a user is added
        public event EventHandler UserAdded;

        public FrmAddUser(UsersViewModel usersViewModel)
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
            TxtName.TextChanged += ValidateName;
            TxtEmailAddress.TextChanged += ValidateEmail;
            TxtContactNo.TextChanged += ValidateContactNumber;
            CmbPosition.SelectedIndexChanged += ValidatePosition;
            TxtUsername.TextChanged += ValidateUsername;
            TxtPassword.TextChanged += ValidatePassword;
            TxtConfirmPassword.TextChanged += ValidateConfirmPassword;
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
            BtnSave.Enabled = ValidateForm();
        }



        // Real-time validation for Name
        private void ValidateName(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                errorProvider.SetError(TxtName, "Name is required.");
            }
            else
            {
                errorProvider.SetError(TxtName, "");
            }
        }

        // Real-time validation for Email
        private void ValidateEmail(object sender, EventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple email validation pattern
            if (string.IsNullOrWhiteSpace(TxtEmailAddress.Text))
            {
                errorProvider.SetError(TxtEmailAddress, "Email address is required.");
            }
            else if (!Regex.IsMatch(TxtEmailAddress.Text, emailPattern))
            {
                errorProvider.SetError(TxtEmailAddress, "Please enter a valid email address.");
            }
            else
            {
                errorProvider.SetError(TxtEmailAddress, "");
            }
        }


        // Real-time validation for Contact Number
        private void ValidateContactNumber(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtContactNo.Text))
            {
                errorProvider.SetError(TxtContactNo, "Contact number is required.");
            }
            else
            {
                errorProvider.SetError(TxtContactNo, "");
            }
        }


        // Real-time validation for Position
        private void ValidatePosition(object sender, EventArgs e)
        {
            if (CmbPosition.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbPosition, "Please select a position.");
            }
            else
            {
                errorProvider.SetError(CmbPosition, "");
            }
        }

        // Real-time validation for Username
        private void ValidateUsername(object sender, EventArgs e)
        {
            string usernamePattern = @"^[a-zA-Z0-9]{6,16}$"; // Only alphanumeric, 6 to 16 characters
            if (string.IsNullOrWhiteSpace(TxtUsername.Text))
            {
                errorProvider.SetError(TxtUsername, "Username is required.");
            }
            else if (!Regex.IsMatch(TxtUsername.Text, usernamePattern))
            {
                errorProvider.SetError(TxtUsername, "Username must be 6-16 characters, alphanumeric only.");
            }
            else
            {
                errorProvider.SetError(TxtUsername, "");
            }
        }

        // Real-time validation for Password
        private void ValidatePassword(object sender, EventArgs e)
        {
            string passwordPattern = @"^[a-zA-Z0-9]{6,16}$"; // Only alphanumeric, 6 to 16 characters
            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                errorProvider.SetError(TxtPassword, "Password is required.");
            }
            else if (!Regex.IsMatch(TxtPassword.Text, passwordPattern))
            {
                errorProvider.SetError(TxtPassword, "Password must be 6-16 characters, alphanumeric only.");
            }
            else
            {
                errorProvider.SetError(TxtPassword, "");
            }
        }


        // Real-time validation for Confirm Password
        private void ValidateConfirmPassword(object sender, EventArgs e)
        {
            if (TxtPassword.Text != TxtConfirmPassword.Text)
            {
                errorProvider.SetError(TxtConfirmPassword, "Passwords do not match.");
            }
            else
            {
                errorProvider.SetError(TxtConfirmPassword, "");
            }
        }


        // Set a default image when the form loads
        private void SetDefaultImage()
        {
            PbProfile.Image = Properties.Resources.placeholder; // Load a default image from resources
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
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(TxtPassword.Text);

                // Use default image if no image was selected
                string photoPath = GetPhotoPath();

                // Create a new user object
                Users newUser = new Users
                {
                    Name = TxtName.Text,
                    BirthDate = DtpBirthday.Value, // Assuming you have a DateTimePicker for birthdate
                    Address = TxtAddress.Text,
                    ContactNo = TxtContactNo.Text,
                    EmailAddress = TxtEmailAddress.Text,
                    Position = CmbPosition.SelectedItem.ToString(),
                    Username = TxtUsername.Text,
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
            TxtName.Clear();
            DtpBirthday.Value = DateTime.Now;
            TxtAddress.Clear();
            TxtContactNo.Clear();
            TxtEmailAddress.Clear();
            CmbPosition.SelectedIndex = -1;
            TxtUsername.Clear();
            TxtPassword.Clear();
            TxtConfirmPassword.Clear();
            PbProfile.Image = Properties.Resources.placeholder;
            selectedImagePath = "";

            errorProvider.Clear();
          
        }

        private void PbProfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Profile Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Image file types

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName; // Store the selected image path
                    PbProfile.Image = Image.FromFile(selectedImagePath); // Display the selected image
                }
            }
        }
       

       
    }
}
