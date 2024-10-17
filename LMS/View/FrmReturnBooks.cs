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
using LMS.Model;
using LMS.ViewModel;

namespace LMS.View
{
    public partial class FrmReturnBooks : Form
    {
        private Users currentUser; // Add field to store current user info
        private BorrowerViewModel borrowerViewModel;
        private int currentPage = 1;
        private int itemsPerPage = 10;  // Set number of items per page for pagination

        public FrmReturnBooks(Users user)
        {
            InitializeComponent();
            currentUser = user; // Store the logged-in user

            borrowerViewModel = new BorrowerViewModel();

            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(20);  // Add padding to make space around the container

            LoadUnreturnedBooks();  // Load the unreturned books on form load
        }
      

        // Load all unreturned books
        private async void LoadUnreturnedBooks()
        {
            var unreturnedBooks = await borrowerViewModel.LoadAllUnreturnedBooksAsync();
            DisplayPage(unreturnedBooks, currentPage);
        }

        // Display unreturned books on a paginated view
        private async void DisplayPage(List<(Borrower, Books, string)> unreturnedBooks, int pageNumber)
        {
            flowLayoutPanel1.Controls.Clear();
            int startIndex = (pageNumber - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, unreturnedBooks.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                var (borrower, book, processedBy) = unreturnedBooks[i];

                // Create a panel for each unreturned book entry
                System.Windows.Forms.Panel bookPanel = new System.Windows.Forms.Panel
                {
                    Size = new Size(300, 200),
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                // Display book cover
                PictureBox bookCover = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(100, 150),
                    Location = new Point(10, 30),
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = Properties.Resources.placeholder // Fallback image
                };

                if (!string.IsNullOrEmpty(book.ImagePath) && File.Exists(book.ImagePath))
                {
                    await LoadImageAsync(book.ImagePath, bookCover);
                }

                // Label for book title
                System.Windows.Forms.Label lblBookTitle = new System.Windows.Forms.Label
                {
                    Text = $"{book.BookTitle}",
                    Location = new Point(10, 10),
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    AutoSize = true
                };

                // Label for borrower details
                System.Windows.Forms.Label lblBorrowerDetails = new System.Windows.Forms.Label
                {
                    Text = $"Borrower: {borrower.Name}\n" +
                           $"Section/Course: {borrower.SectionCourse}\n" +
                           $"Address: {borrower.Address}\n" +
                           $"Email Address: {borrower.Email}\n" +
                           $"Contact No: {borrower.ContactNumber}\n" +
                           $"Due Date: {borrower.ReturnDate.ToShortDateString()}\n" +
                           $"Processed By: {processedBy}",
                    Location = new Point(120, 30),
                    Font = new Font("Arial", 8),
                    AutoSize = true
                };

                // Button for handling the return action
                System.Windows.Forms.Button btnReturnBook = new System.Windows.Forms.Button
                {
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    BackColor = ColorTranslator.FromHtml("#FF0000"),
                    ForeColor = Color.White,
                    Size = new Size(100, 35),
                    Location = new Point(170, 146),
                    Text = "Return Book"
                };

                btnReturnBook.Click += async (sender, e) =>
                {
                    // Log the borrower_id and book_id to make sure they are valid
                    Console.WriteLine($"Attempting to return book for Borrower ID: {borrower.borrower_id}, Book ID: {book.book_id}");

                    // Check if IDs are correctly populated
                    if (borrower.borrower_id <= 0 || book.book_id <= 0)
                    {
                        MessageBox.Show("Invalid borrower or book ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Call the return method in BorrowerViewModel to mark the book as returned
                    bool isReturned = await borrowerViewModel.ReturnBookAsync(borrower.borrower_id, book.book_id, currentUser.LibrarianId);

                    if (isReturned)
                    {
                        MessageBox.Show($"Successfully returned {book.BookTitle} borrowed by {borrower.Name}");

                        // Refresh the list of unreturned books
                        LoadUnreturnedBooks();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while returning the book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };


                // Adding controls to the panel
                bookPanel.Controls.Add(bookCover);
                bookPanel.Controls.Add(lblBookTitle);
                bookPanel.Controls.Add(lblBorrowerDetails);
                bookPanel.Controls.Add(btnReturnBook);

                flowLayoutPanel1.Controls.Add(bookPanel);
            }

            // Update pagination info
            LabelPage.Text = $"Page {currentPage} of {Math.Ceiling((double)unreturnedBooks.Count / itemsPerPage)}";
            BtnPrev.Enabled = currentPage > 1;
            BtnNext.Enabled = currentPage < (unreturnedBooks.Count + itemsPerPage - 1) / itemsPerPage;
        }

        // Helper method to load image asynchronously
        private async Task LoadImageAsync(string imagePath, PictureBox pictureBox)
        {
            try
            {
                var image = await Task.Run(() => System.Drawing.Image.FromFile(imagePath));
                pictureBox.Image = image;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
        }
    
        
    
    }
}
