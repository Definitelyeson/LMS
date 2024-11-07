using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.CustomControl;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.ViewModel;

namespace LibraryManagementSystem.View
{
    public partial class frmBookDetails : Form
    {
        private BooksViewModel booksViewModel;
        private int currentPage = 1;
        private int itemsPerPage = 12;
        private System.Threading.Timer searchDebounceTimer;
        private readonly ToastNotifier _notifier = new ToastNotifier();

        public frmBookDetails()
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
                Size = new Size(278, 200),
                Margin = new Padding(5, 5, 5, 5),
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
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                AutoSize = true
            };

            System.Windows.Forms.Label lblAuthor = new System.Windows.Forms.Label
            {
                Text = $"Author: {book.Author}",
                Location = new Point(120, 40),
                Font = new Font("Segoe UI", 8),
                AutoSize = true
            };

            System.Windows.Forms.Label lblDetails = new System.Windows.Forms.Label
            {
                Text = $"Published: {book.BookPublisher}\n" +
                       $"Year: {book.YearPublished}\n" +
                       $"Category: {book.Category}\n" +
                       $"Quantity: {book.Quantity}\n" +
                       $"Borrowed: {book.BorrowedQuantity}\n" +
                       $"Available: {(book.IsAvailable ? "Yes" : "No")}\n" +  // Check availability
                       $"Type: {book.BookType}\n" + // Added book type
                       $"Summary: {book.BookSummary}", // Added book summary
                Location = new Point(120, 60),
                Font = new Font("Segoe UI", 8),
                AutoSize = true
            };

            System.Windows.Forms.Button btnEdit = new System.Windows.Forms.Button
            {
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = ColorTranslator.FromHtml("#0066FF"),
                Size = new Size(25, 25),
                Location = new Point(220, 170),
                Image = Properties.Resources.edit_1,
                ImageAlign = ContentAlignment.MiddleCenter
            };

            btnEdit.Click += async (s, e) =>
            {
                var editBookForm = new frmAddBooks();
                // Pass the selected book details to the form
                editBookForm.SetBookDetails(book);

                if (editBookForm.ShowDialog() == DialogResult.OK)
                {
                    var updatedBook = editBookForm.CreateBookFromForm();
                    await booksViewModel.UpdateBookAsync(updatedBook);
                    DisplayPage(currentPage);  // Refresh the book list
                }
            };

            System.Windows.Forms.Button btnDelete = new System.Windows.Forms.Button
            {
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = ColorTranslator.FromHtml("#FF0000"),
                Size = new Size(25, 25),
                Location = new Point(249, 170),
                Image = Properties.Resources.bin_1,
                ImageAlign = ContentAlignment.MiddleCenter
            };

            btnDelete.Click += async (s, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to archive this book?", "Archive Book", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    await booksViewModel.ArchiveBookAsync(book.book_id); // Archive the book
                                                                         // Show error message if login fails
                    _notifier.Alert("Book Archived successfully", frmAlert.enmType.Success);
                    await booksViewModel.LoadBooksAsync(); // Refresh the book list
                    DisplayPage(currentPage); // Refresh the display
                }
            };

            bookPanel.Controls.Add(btnEdit);
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


            LoadBooks();
        }
        private async void LoadBooks()
        {
            try
            {
                await booksViewModel.LoadBooksAsync();
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
        private async void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1; // Reset to the first page when filtering

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

            // Update the label to show the current page of the filtered books
            lblPage.Text = $"Page {currentPage} of {Math.Ceiling((double)filteredBooks.Count / itemsPerPage)}";

            // Enable/Disable pagination buttons based on the filtered books count
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (filteredBooks.Count + itemsPerPage - 1) / itemsPerPage;
        }

        private async void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddBooks addBooks = new frmAddBooks();
            if (addBooks.ShowDialog() == DialogResult.OK)
            {
                // Refresh the book list
                await booksViewModel.LoadBooksAsync();
                DisplayPage(currentPage);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage * itemsPerPage < booksViewModel.BooksList.Count)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage(currentPage);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (searchDebounceTimer != null)
            {
                searchDebounceTimer.Dispose();
            }

            searchDebounceTimer = new System.Threading.Timer(async _ =>
            {
                Invoke(new Action(async () =>
                {
                    currentPage = 1; // Reset page
                    string searchQuery = txtSearch.Texts;
                    var filteredBooks = await booksViewModel.SearchBooksAsync(searchQuery);
                    DisplayFilteredBooks(filteredBooks);
                }));
            }, null, 300, Timeout.Infinite); // 300ms debounce delay
        }


    }
}
