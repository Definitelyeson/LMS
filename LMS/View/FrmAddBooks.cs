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
using LMS.CustomControls;
using LMS.Model;
using LMS.ViewModel;

namespace LMS.View
{
    public partial class FrmAddBooks : Form
    {
        private readonly BooksViewModel bookViewModel;
        private readonly ToastNotifier _notifier = new ToastNotifier();

        // Property to hold the Books object being edited or added
        public Books CurrentBook { get; set; }

        public FrmAddBooks()
        {
            InitializeComponent();

            SetPlaceholderImage();
            bookViewModel = new BooksViewModel();


            BtnAddBook.Visible = true;
            BtnUpdate.Visible = false;
        }

        public void SetBookDetails(Books book)
        {
            TxtBookTitle.Text = book.BookTitle;
            TxtAuthor.Text = book.Author;
            TxtPublisher.Text = book.BookPublisher;
            dtpPubyear.Value = new DateTime(book.YearPublished, 1, 1);
            cmbCategory.Text = book.Category;
            txtQuantity.Text = book.Quantity.ToString();
            TxtBookSummary.Text = book.BookSummary;  // Set the Book Summary
            DropDownBookType.Text = book.BookType;        // Set the Book Type

            // Set the image as before
            if (!string.IsNullOrEmpty(book.ImagePath) && File.Exists(book.ImagePath))
            {
                pbCover.ImageLocation = book.ImagePath;
            }
            else
            {
                SetPlaceholderImage();
            }

            BtnAddBook.Visible = false;
            BtnUpdate.Visible = true;

            CurrentBook = book;
        }

        private void ResetForm()
        {
            TxtBookTitle.Clear();
            TxtAuthor.Clear();
            TxtPublisher.Clear();
            cmbCategory.SelectedIndex = -1; // Clear the category
            txtQuantity.Clear();
            TxtBookSummary.Clear();
            DropDownBookType.SelectedIndex = -1; // Clear the book type
            SetPlaceholderImage(); // Reset image to placeholder
            dtpPubyear.Value = DateTime.Now; // Reset to current year
            BtnAddBook.Visible = true;
            BtnUpdate.Visible = false;
        }


        private bool ValidateInputs()
        {
            // Check required fields
            if (string.IsNullOrWhiteSpace(TxtBookTitle.Text))
            {
                // Show error message if login fails
                _notifier.Alert("Title is required.", customToast.enmType.Error);
                TxtBookTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtAuthor.Text))
            {
                _notifier.Alert("Author is required.", customToast.enmType.Error);
                TxtAuthor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtPublisher.Text))
            {
                _notifier.Alert("Publisher is required.", customToast.enmType.Error);
                TxtPublisher.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                _notifier.Alert("Category is required.", customToast.enmType.Error);
                cmbCategory.Focus();
                return false;
            }

            // Validate Year Published
            if (dtpPubyear.Value.Year < 1900 || dtpPubyear.Value.Year > DateTime.Now.Year)
            {
                _notifier.Alert("Please enter a valid year, 1900 to present.", customToast.enmType.Error);
                dtpPubyear.Focus();
                return false;
            }

            // Validate Quantity
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                _notifier.Alert("Quantity must be a positive integer.", customToast.enmType.Error);
                txtQuantity.Focus();
                return false;
            }

            // Validate Book Summary
            if (string.IsNullOrWhiteSpace(TxtBookSummary.Text))
            {
                _notifier.Alert("Book summary is required.", customToast.enmType.Error);
                TxtBookSummary.Focus();
                return false;
            }

            // Validate Book Type (DropDownBookType)
            if (string.IsNullOrWhiteSpace(DropDownBookType.Text))
            {
                _notifier.Alert("Book type is required.", customToast.enmType.Error);
                DropDownBookType.Focus();
                return false;
            }

            return true;
        }

        public Books GetBookDetails()
        {
            return new Books
            {
                book_id = CurrentBook?.book_id ?? 0,  // Include the ID for updates, use 0 for new books
                BookTitle = TxtBookTitle.Text,
                Author = TxtAuthor.Text,
                BookPublisher = TxtPublisher.Text,
                YearPublished = dtpPubyear.Value.Year,
                Category = cmbCategory.Text,
                Quantity = int.Parse(txtQuantity.Text),
                BookSummary = TxtBookSummary.Text,  // Capture the Book Summary
                BookType = DropDownBookType.Text,        // Capture the Book Type
                ImagePath = pbCover.ImageLocation
            };
        }


        private void SetPlaceholderImage()
        {
            pbCover.Image = Properties.Resources.placeholder; // Use your actual placeholder resource
        }
        private void SetDefaultImage()
        {
            pbCover.Image = Properties.Resources.books_default; // Load a default image from resources
        }

        private async void BtnAddBook_Click(object sender, EventArgs e)
        {
            if (await bookViewModel.BookExistsAsync(TxtBookTitle.Text, TxtAuthor.Text))
            {
                MessageBox.Show("A book with this title and author already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInputs()) return; // Validate inputs before proceeding
                                           // Check if the user did not upload an image
            if (string.IsNullOrEmpty(pbCover.ImageLocation) || pbCover.Image == Properties.Resources.placeholder)
            {
                // Use the default book image from resources
                pbCover.Image = Properties.Resources.books_default;

                // Assuming you want to save a specific path for book images
                string defaultImagePath = Path.Combine(Application.StartupPath, "Images", "books_default.png");

                try
                {
                    // Check if the default image already exists; if not, save it
                    if (!File.Exists(defaultImagePath))
                    {
                        // Ensure the directory exists
                        string imageDirectory = Path.GetDirectoryName(defaultImagePath);
                        if (!Directory.Exists(imageDirectory))
                        {
                            Directory.CreateDirectory(imageDirectory); // Create directory if it doesn't exist
                        }

                        // Save the default image as a PNG with explicit format
                        using (var defaultImage = Properties.Resources.books_default)
                        {
                            defaultImage.Save(defaultImagePath, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }

                    pbCover.ImageLocation = defaultImagePath; // Set the ImageLocation to the path of the saved default image
                }
                catch (ExternalException ex)
                {
                    MessageBox.Show($"An error occurred while saving the default image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                var newBook = new Books
                {
                    BookTitle = TxtBookTitle.Text,
                    Author = TxtAuthor.Text,
                    BookPublisher = TxtPublisher.Text,
                    YearPublished = dtpPubyear.Value.Year,
                    Category = cmbCategory.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    BookType = DropDownBookType.Text,
                    BookSummary = TxtBookSummary.Text,
                    ImagePath = pbCover.ImageLocation
                };

                await bookViewModel.AddBookAsync(newBook);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (CurrentBook != null)
            {
                if (!ValidateInputs()) return; // Validate before proceeding

                CurrentBook.BookTitle = TxtBookTitle.Text;
                CurrentBook.Author = TxtAuthor.Text;
                CurrentBook.BookPublisher = TxtPublisher.Text;
                CurrentBook.YearPublished = dtpPubyear.Value.Year;
                CurrentBook.Category = cmbCategory.Text;
                CurrentBook.Quantity = int.Parse(txtQuantity.Text);
                CurrentBook.BookSummary = TxtBookSummary.Text;
                CurrentBook.BookType = DropDownBookType.Text;
                CurrentBook.ImagePath = pbCover.ImageLocation;

                try
                {
                    await bookViewModel.UpdateBookAsync(CurrentBook);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _notifier.Alert("No book selected to update!", customToast.enmType.Error);

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
                    _notifier.Alert("Image selected successfully!", customToast.enmType.Success);
                }
            }
        }
    }
}
