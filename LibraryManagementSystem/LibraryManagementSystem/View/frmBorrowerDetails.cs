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
using LibraryManagementSystem.Model;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Utilities;
using LibraryManagementSystem.CustomControl;

namespace LibraryManagementSystem.View
{
    public partial class frmBorrowerDetails : Form
    {
        private readonly ToastNotifier _notifier = new ToastNotifier();
        private Books selectedBook;
        private BooksViewModel booksViewModel;
        private BorrowerViewModel borrowerViewModel;
        private int processedBy;
        private ErrorProvider errorProvider1; // Declare the ErrorProvider

        public frmBorrowerDetails(Books book, BooksViewModel viewModel, int processedBy)
        {
            InitializeComponent();

            errorProvider1 = new ErrorProvider();

            // Set the selected book first, then call LoadBookDetails
            selectedBook = book; // Set the selected book
            booksViewModel = viewModel;
            borrowerViewModel = new BorrowerViewModel();

            this.processedBy = processedBy; // Assign the processedBy value (current user's ID)

            LoadBookDetails(); // Now call this after setting the selectedBook
        }

        private void LoadBookDetails()
        {
            
            lblTitle.Text = selectedBook.BookTitle;

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
            // Clear previous errors
            errorProvider1.Clear();

            bool isValid = true;

            // Check if name is provided
            if (string.IsNullOrWhiteSpace(txtStudentName.Texts))
            {
                errorProvider1.SetError(txtStudentName, "Student name is required.");
                isValid = false;
            }

            // Check if course is selected
            if (string.IsNullOrWhiteSpace(cmbSection.Texts))
            {
                errorProvider1.SetError(cmbSection, "Please select a course.");
                isValid = false;
            }

            // Check if address is provided
            if (string.IsNullOrWhiteSpace(txtAddress.Texts))
            {
                errorProvider1.SetError(txtAddress, "Address is required.");
                isValid = false;
            }

            // Check if contact number is provided and valid
            if (string.IsNullOrWhiteSpace(txtContatNumber.Texts))
            {
                errorProvider1.SetError(txtContatNumber, "Contact number is required.");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtContatNumber.Texts, @"^\d+$")) // Check if contact number is numeric
            {
                errorProvider1.SetError(txtContatNumber, "Contact number must be numeric.");
                isValid = false;
            }

            // Check if email is provided and valid
            if (string.IsNullOrWhiteSpace(txtEmailAddress.Texts))
            {
                errorProvider1.SetError(txtEmailAddress, "Email address is required.");
                isValid = false;
            }
            else if (!IsValidEmail(txtEmailAddress.Texts))
            {
                errorProvider1.SetError(txtEmailAddress, "Please enter a valid email address.");
                isValid = false;
            }

            // Check if the return date is in the future
            if (dtpReturnDate.Value <= DateTime.Now)
            {
                errorProvider1.SetError(dtpReturnDate, "Return date must be in the future.");
                isValid = false;
            }

            return isValid; // Return the overall validation result
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
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
                return; 
            }

            // Get borrower details from input fields
            string name = txtStudentName.Texts;
            string sectionCourse = cmbSection.Texts;
            string address = txtAddress.Texts;
            string contactNumber = txtContatNumber.Texts;
            string email = txtEmailAddress.Texts;
            DateTime returnDate = dtpReturnDate.Value;

            // Set borrower details in the ViewModel
            borrowerViewModel.SetBorrowerDetails(name, sectionCourse, address, contactNumber, email, returnDate);

            try
            {
                // Attempt to save to the database
                bool isSaved = await borrowerViewModel.SaveBorrowerAsync(borrowerViewModel.CurrentBorrower, selectedBook.book_id, processedBy);

                if (isSaved)
                {
                    _notifier.Alert("Borrower details saved successfully!", frmAlert.enmType.Success);                 
                    this.Close(); // Close the form after saving
                }
                else
                {
                    _notifier.Alert("Failed to save borrower details.", frmAlert.enmType.Error);
                   
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions and show an error message
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBorrowerDetails_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormDragHandler.DragForm(this); // Call the helper class to handle dragging
            }
        }
    }
}
