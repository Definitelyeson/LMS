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
using LibraryManagementSystem.Model;
using LibraryManagementSystem.ViewModel;

namespace LibraryManagementSystem.View
{
    public partial class frmBookArchives : Form
    {
        private BooksViewModel booksViewModel;
        private int currentPage = 1;
        private int itemsPerPage = 12;

        public frmBookArchives()
        {
            InitializeComponent();

            booksViewModel = new BooksViewModel();


            InitializeCategoryComboBox(); // Initialize the ComboBox here for filtering
            SetupLayout();
        }

        private System.Windows.Forms.Panel CreateBookPanel(Books book)
        {
            System.Windows.Forms.Panel bookPanel = new System.Windows.Forms.Panel
            {
                Size = new Size(250, 200),
                Margin = new Padding(10, 10, 10, 20),// Adding more vertical space between rows

                BackColor = Color.White
            };

            PictureBox bookCover = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(100, 150),
                Location = new Point(10, 30),
                BorderStyle = BorderStyle.FixedSingle,
                Image = Properties.Resources.books_default
            };

            if (!string.IsNullOrEmpty(book.ImagePath) && File.Exists(book.ImagePath))
            {
                bookCover.Image = System.Drawing.Image.FromFile(book.ImagePath);
            }

            System.Windows.Forms.Label lblBookTitle = new System.Windows.Forms.Label
            {
                Text = $"Title: {book.BookTitle}",
                Location = new Point(5, 10),
                Font = new Font("Arial", 8, FontStyle.Bold),
                AutoSize = true
            };

            System.Windows.Forms.Label lblAuthor = new System.Windows.Forms.Label
            {
                Text = $"Author: {book.Author}",
                Location = new Point(120, 40),
                Font = new Font("Arial", 8),
                AutoSize = true
            };

            System.Windows.Forms.Label lblDetails = new System.Windows.Forms.Label
            {
                Text = $"Published: {book.BookPublisher}\n" +
                       $"Year: {book.YearPublished}\n" +
                       $"Category: {book.Category}\n" +
                       $"Quantity: {book.Quantity}\n" +
                       $"Borrowed: {book.BorrowedQuantity}\n" +  // Add this line
                       $"Available: {(book.IsAvailable ? "Yes" : "No")}",  // Check availability
                Location = new Point(120, 60),
                Font = new Font("Arial", 8),
                AutoSize = true
            };

            System.Windows.Forms.Button btnUnarchive = new System.Windows.Forms.Button
            {
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = ColorTranslator.FromHtml("#0066FF"),
                Text = "Unarchive",
                ForeColor = Color.White,
                Size = new Size(70, 30),
                Location = new Point(170, 155),
                ImageAlign = ContentAlignment.MiddleCenter
            };

            btnUnarchive.Click += async (s, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to unarchive this book?", "Unarchive Book", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    await booksViewModel.UnarchiveBookAsync(book.book_id); // Unarchive the book
                    await booksViewModel.LoadArchivesAsync(); // Refresh the book list
                    DisplayPage(currentPage); // Refresh the display
                }
            };

            System.Windows.Forms.Button btnDelete = new System.Windows.Forms.Button
            {
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = ColorTranslator.FromHtml("#FF0000"),
                Text = "Delete",
                ForeColor = Color.White,
                Size = new Size(70, 30),
                Location = new Point(90, 155),
                ImageAlign = ContentAlignment.MiddleCenter
            };

            btnDelete.Click += async (s, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to delete this book?", "Delete Book", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    await booksViewModel.DeleteBookAsync(book.book_id); // Delete the book
                    await booksViewModel.LoadArchivesAsync(); // Refresh the book list
                    DisplayPage(currentPage); // Refresh the display
                }
            };


            bookPanel.Controls.Add(btnUnarchive);
            bookPanel.Controls.Add(btnDelete);
            bookPanel.Controls.Add(bookCover);
            bookPanel.Controls.Add(lblBookTitle);
            bookPanel.Controls.Add(lblAuthor);
            bookPanel.Controls.Add(lblDetails);

            return bookPanel;
        }

        private void SetupLayout()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(20);


            LoadArchives();
        }

        private async void LoadArchives()
        {
            try
            {
                await booksViewModel.LoadArchivesAsync();
                DisplayPage(currentPage);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error loading books: {ex.Message}");
            }
        }


        private async void DisplayPage(int pageNumber)
        {
            flowLayoutPanel1.Controls.Clear();
            int startIndex = (pageNumber - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, booksViewModel.BooksList.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                 var book = booksViewModel.BooksList[i];
                 var bookPanel = CreateBookPanel(book);
                flowLayoutPanel1.Controls.Add(bookPanel);
            }

            lblPage.Text = $"Page {currentPage} of {Math.Ceiling((double)booksViewModel.BooksList.Count / itemsPerPage)}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (booksViewModel.BooksList.Count + itemsPerPage - 1) / itemsPerPage;
        }


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
                pictureBox.Image = Properties.Resources.books_default;
            }
        }

        public async void InitializeCategoryComboBox()
        {
            var categories = await booksViewModel.GetCategoriesAsync();
            categories.Insert(0, "All"); // Add "All" as the first item
            cmbCategory.DataSource = categories;
            cmbCategory.OnSelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            cmbCategory.SelectedIndex = 0; // Select "All" by default
        }


        private void DisplayFilteredBooks(List<Books> filteredBooks)
        {
            flowLayoutPanel1.Controls.Clear();
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, filteredBooks.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                var book = filteredBooks[i];
                var bookPanel = CreateBookPanel(book);
                flowLayoutPanel1.Controls.Add(bookPanel);
            }

            lblPage.Text = $"Page {currentPage} of {Math.Ceiling((double)filteredBooks.Count / itemsPerPage)}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (filteredBooks.Count + itemsPerPage - 1) / itemsPerPage;
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Texts;
            currentPage = 1;
            var filteredBooks = await booksViewModel.SearchArchivedBooksAsync(searchQuery);
            DisplayFilteredBooks(filteredBooks);
        }

        private async void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem.ToString() == "All")
            {
                // Display all books
                DisplayFilteredBooks(booksViewModel.BooksList);
            }
            else
            {
                string selectedCategory = cmbCategory.SelectedItem.ToString();
                var filteredBooks = await booksViewModel.FilterBooksByCategoryAsync(selectedCategory);
                DisplayFilteredBooks(filteredBooks);
            }
        }
    }
}

