using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.CustomControl;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Utilities;
using LibraryManagementSystem.ViewModel;

namespace LibraryManagementSystem.View
{
    public partial class frmAddBooks : Form
    {
        private readonly BooksViewModel bookViewModel;
        private ErrorProvider errorProvider = new ErrorProvider();
        private readonly ToastNotifier _notifier = new ToastNotifier();

        // Property to hold the Books object being edited or added
        public Books CurrentBook { get; set; }

        public frmAddBooks()
        {
            InitializeComponent();
            SetPlaceholderImage();
            bookViewModel = new BooksViewModel();


            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        public void SetBookDetails(Books book)
        {
            txtBookTitle.Texts = book.BookTitle;
            txtAuthor.Texts = book.Author;
            txtPublisher.Texts = book.BookPublisher;
            dtpPublishedYear.Value = new DateTime(book.YearPublished, 1, 1);
            cmbCategory.Texts = book.Category;
            txtQuantity.Texts = book.Quantity.ToString();
            txtSummary.Texts = book.BookSummary;  // Set the Book Summary
            cmbBookType.Texts = book.BookType;    // Set the Book Type

            // Set the image if available, otherwise set the placeholder image
            if (!string.IsNullOrEmpty(book.ImagePath) && File.Exists(book.ImagePath))
            {
                pbCover.ImageLocation = book.ImagePath;
            }
            else
            {
                SetPlaceholderImage();
            }

            btnSave.Visible = false;
            btnUpdate.Visible = true;

            CurrentBook = book;
        }

        private void ResetForm()
        {
            txtBookTitle.Texts = "";
            txtAuthor.Texts = "";
            txtPublisher.Texts = "";
            cmbCategory.SelectedIndex = -1;
            txtQuantity.Texts = "";
            txtSummary.Texts = "";
            cmbBookType.SelectedIndex = -1;
            SetPlaceholderImage();
            dtpPublishedYear.Value = DateTime.Now;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        private bool ValidateInputs()
        {
            // Clear previous error messages
            errorProvider.Clear();
            bool isValid = true;

            // Validate Book Title
            if (string.IsNullOrWhiteSpace(txtBookTitle.Texts))
            {
                errorProvider.SetError(txtBookTitle, "Title is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtBookTitle, null); // Clears the error if valid
            }

            // Validate Author
            if (string.IsNullOrWhiteSpace(txtAuthor.Texts))
            {
                errorProvider.SetError(txtAuthor, "Author is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtAuthor, null);
            }

            // Validate Publisher
            if (string.IsNullOrWhiteSpace(txtPublisher.Texts))
            {
                errorProvider.SetError(txtPublisher, "Publisher is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtPublisher, null);
            }

            // Validate Category
            if (string.IsNullOrWhiteSpace(cmbCategory.Texts))
            {
                errorProvider.SetError(cmbCategory, "Category is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(cmbCategory, null);
            }

            // Validate Published Year
            if (dtpPublishedYear.Value.Year < 1900 || dtpPublishedYear.Value.Year > DateTime.Now.Year)
            {
                errorProvider.SetError(dtpPublishedYear, "Please enter a valid year, 1900 to present.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(dtpPublishedYear, null);
            }

            // Validate Quantity
            if (!int.TryParse(txtQuantity.Texts, out int quantity) || quantity <= 0)
            {
                errorProvider.SetError(txtQuantity, "Quantity must be a positive integer.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtQuantity, null);
            }

            // Validate Book Summary
            if (string.IsNullOrWhiteSpace(txtSummary.Texts))
            {
                errorProvider.SetError(txtSummary, "Book summary is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtSummary, null);
            }

            // Validate Book Type
            if (string.IsNullOrWhiteSpace(cmbBookType.Texts))
            {
                errorProvider.SetError(cmbBookType, "Book type is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(cmbBookType, null);
            }

            return isValid;
        }


        public Books CreateBookFromForm()
        {
            return new Books
            {
                book_id = CurrentBook?.book_id ?? 0,  // Include the ID for updates, use 0 for new books
                BookTitle = txtBookTitle.Texts,
                Author = txtAuthor.Texts,
                BookPublisher = txtPublisher.Texts,
                YearPublished = dtpPublishedYear.Value.Year,
                Category = cmbCategory.Texts,
                Quantity = int.Parse(txtQuantity.Texts),
                BookSummary = txtSummary.Texts,
                BookType = cmbBookType.Texts,
                ImagePath = pbCover.ImageLocation
            };
        }


        private void SetPlaceholderImage()
        {
            pbCover.Image = Properties.Resources.placeholder; 
        }
        private void SetDefaultImage()
        {
            pbCover.Image = Properties.Resources.books_default; // Load a default image from resources
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Check if the book already exists
            if (await bookViewModel.BookExistsAsync(txtBookTitle.Texts, txtAuthor.Texts))
            {
                _notifier.Alert("A book with this title and author already exists.", frmAlert.enmType.Error);
                return;
            }

            // Validate inputs
            if (!ValidateInputs()) return;

            // Handle image selection
            if (string.IsNullOrEmpty(pbCover.ImageLocation) || pbCover.Image == Properties.Resources.placeholder)
            {
                pbCover.Image = Properties.Resources.books_default;

                string defaultImagePath = Path.Combine(Application.StartupPath, "Images", "books_default.png");
                try
                {
                    if (!File.Exists(defaultImagePath))
                    {
                        string imageDirectory = Path.GetDirectoryName(defaultImagePath);
                        if (!Directory.Exists(imageDirectory))
                        {
                            Directory.CreateDirectory(imageDirectory);
                        }

                        using (var defaultImage = Properties.Resources.books_default)
                        {
                            defaultImage.Save(defaultImagePath, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }

                    pbCover.ImageLocation = defaultImagePath;
                }
                catch (ExternalException ex)
                {
                    MessageBox.Show($"An error occurred while saving the default image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Add the book
            try
            {
                var newBook = CreateBookFromForm(); // Create the book object from form fields
                bool isSuccess = await bookViewModel.AddBookAsync(newBook); // Call the ViewModel method and check for success

                if (isSuccess)
                {
                    // Show success notification
                    _notifier.Alert("Book added successfully!", frmAlert.enmType.Success);                 

                    ResetForm(); // Reset the form after successful save
                    this.DialogResult = DialogResult.OK; // Set DialogResult only after success
                }
                else
                {
                    // Show error notification in case of failure
                    _notifier.Alert("An error occurred while adding the book.", frmAlert.enmType.Error);
                  
                }
            }
            catch (Exception)
            {
                _notifier.Alert("An error occurred while adding the book.", frmAlert.enmType.Error);
               
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CurrentBook != null)
            {
                if (!ValidateInputs()) return; // Validate inputs before proceeding

                // Update the CurrentBook object with the form values
                CurrentBook = CreateBookFromForm();

                try
                {
                    // Call the ViewModel method and check for success
                    bool isSuccess = await bookViewModel.UpdateBookAsync(CurrentBook);

                    if (isSuccess)
                    {
                        // Show success notification
                        _notifier.Alert("Book updated successfully!", frmAlert.enmType.Success);                       
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        _notifier.Alert("An error occurred while updating the book.", frmAlert.enmType.Error);
                       
                    }
                }
                catch (Exception)
                {
                    _notifier.Alert("An error occurred while updating the book.", frmAlert.enmType.Error);
                }
            }
            else
            {
                
                _notifier.Alert("No book selected to update!", frmAlert.enmType.Error);
            }
        }

        private void pbCover_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbCover.ImageLocation = ofd.FileName; // Set the selected image to the PictureBox
                    _notifier.Alert("Image selected successfully!", frmAlert.enmType.Success);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddBooks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormDragHandler.DragForm(this); // Call the helper class to handle dragging
            }
        }
    }
}

