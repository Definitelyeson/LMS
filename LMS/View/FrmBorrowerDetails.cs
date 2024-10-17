using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS.Model;
using LMS.ViewModel;

namespace LMS.View
{
    public partial class FrmBorrowerDetails : Form
    {
        private Books selectedBook;
        private BooksViewModel booksViewModel;
        private BorrowerViewModel borrowerViewModel;
        private int processedBy; // Add this field

        public FrmBorrowerDetails(Books book, BooksViewModel viewModel, int processedBy)
        {
            InitializeComponent();

            // Set the selected book first, then call LoadBookDetails
            selectedBook = book; // Set the selected book
            booksViewModel = viewModel;
            borrowerViewModel = new BorrowerViewModel();

            this.processedBy = processedBy; // Assign the processedBy value (current user's ID)

            LoadBookDetails(); // Now call this after setting the selectedBoo
        }

        private void LoadBookDetails()
        {
            // Assuming you have a PictureBox named 'pictureBoxBookCover' and a Label named 'lblBookTitle' on the form
            LabelTitle.Text = selectedBook.BookTitle;

            // Load book image if available
            if (!string.IsNullOrEmpty(selectedBook.ImagePath) && File.Exists(selectedBook.ImagePath))
            {
                pbCover.Image = Image.FromFile(selectedBook.ImagePath);
            }
            else
            {
                // Fallback to a placeholder if the image is not found
                pbCover.Image = Properties.Resources.placeholder;
            }
        }
        // Validate all input fields
        private bool ValidateInputs()
        {
            // Check if name is provided
            if (string.IsNullOrWhiteSpace(TxtStudentName.Text))
            {
                MessageBox.Show("Student name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtStudentName.Focus();
                return false;
            }

            // Check if course is selected
            if (string.IsNullOrWhiteSpace(DropDownCourse.Text))
            {
                MessageBox.Show("Please select a course.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DropDownCourse.Focus();
                return false;
            }

            // Check if address is provided
            if (string.IsNullOrWhiteSpace(TxtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtAddress.Focus();
                return false;
            }

            // Check if contact number is provided and valid
            if (string.IsNullOrWhiteSpace(TxtContactNo.Text))
            {
                MessageBox.Show("Contact number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtContactNo.Focus();
                return false;
            }

            if (!Regex.IsMatch(TxtContactNo.Text, @"^\d+$")) // Check if contact number is numeric
            {
                MessageBox.Show("Contact number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtContactNo.Focus();
                return false;
            }

            // Check if email is provided and valid
            if (string.IsNullOrWhiteSpace(TxtEmailAddress.Text))
            {
                MessageBox.Show("Email address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtEmailAddress.Focus();
                return false;
            }

            if (!IsValidEmail(TxtEmailAddress.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtEmailAddress.Focus();
                return false;
            }

            // Check if the return date is in the future
            if (DtpReturnDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Return date must be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DtpReturnDate.Focus();
                return false;
            }

            return true; // All validations passed
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (!ValidateInputs())
            {
                return; // Stop if validation fails
            }

            // Check if the selected book is available
            if (!selectedBook.IsAvailable)
            {
                MessageBox.Show("This book is currently unavailable for borrowing.", "Availability Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop if the book is not available
            }

            // Get borrower details from input fields
            string name = TxtStudentName.Text;
            string sectionCourse = DropDownCourse.Text;
            string address = TxtAddress.Text;
            string contactNumber = TxtContactNo.Text;
            string email = TxtEmailAddress.Text;
            DateTime returnDate = DtpReturnDate.Value;

            // Set borrower details in the ViewModel
            borrowerViewModel.SetBorrowerDetails(name, sectionCourse, address, contactNumber, email, returnDate);

            try
            {
                // Attempt to save to the database
                bool isSaved = await borrowerViewModel.SaveBorrowerAsync(borrowerViewModel.CurrentBorrower, selectedBook.book_id, processedBy);

                if (isSaved)
                {
                    MessageBox.Show("Borrower details saved successfully!");
                    this.Close(); // Close the form after saving
                }
                else
                {
                    MessageBox.Show("Failed to save borrower details.");
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions and show an error message
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
