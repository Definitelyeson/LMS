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
using LibraryManagementSystem.CustomControl;

namespace LibraryManagementSystem.View
{
    public partial class frmBookBorrowing : Form
    {
        private Users currentUser; // Add field to store current user info
        private readonly ToastNotifier _notifier = new ToastNotifier();
        private BooksViewModel booksViewModel;
        private BorrowerViewModel borrowerViewModel;
        private int currentPage = 1;
        private int itemsPerPage = 12;

        public frmBookBorrowing(Users user)
        {
            InitializeComponent();


            currentUser = user; // Store the logged-in user
            booksViewModel = new BooksViewModel();

            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(20);  // Add padding to make space around the container
            InitializeCategoryComboBox();

            LoadBooks();
        }

        private async void LoadBooks()
        {
            await booksViewModel.LoadBooksAsync();
            DisplayPage(currentPage);
        }

        private async Task<Panel> CreateBookPanel(Books book)
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
                Image = Properties.Resources.placeholder
            };

            if (!string.IsNullOrEmpty(book.ImagePath) && File.Exists(book.ImagePath))
            {
                await LoadImageAsync(book.ImagePath, bookCover); // Use await here
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
                       $"Type: {book.BookType}\n" +
                       $"Summary: {book.BookSummary}",
                Location = new Point(120, 60),
                Font = new Font("Segoe UI", 8),
                AutoSize = true
            };

            System.Windows.Forms.Button btnBorrow = new System.Windows.Forms.Button
            {
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = ColorTranslator.FromHtml("#0038FF"),
                ForeColor = Color.White,
                Size = new Size(60, 35),
                Location = new Point(180, 150),
                Text = "Borrow",
                Enabled = book.IsAvailable // Disable the button if the book is not available
            };

            // Change the button color to red if the book is unavailable
            if (!book.IsAvailable)
            {
                btnBorrow.Size = new Size(80, 35);
                btnBorrow.BackColor = Color.Red;
                btnBorrow.ForeColor = Color.White;
                btnBorrow.Text = "Unavailable"; // Change button text to "Unavailable"
            }

            btnBorrow.Click += (sender, e) =>
            {
                if (!book.IsAvailable)
                {
                    _notifier.Alert("This book is currently not available for borrowing.", frmAlert.enmType.Error);
                    //MessageBox.Show("This book is currently not available for borrowing.");
                    return; // Prevent further processing if the book is unavailable
                }

                var borrowersDetails = new frmBorrowerDetails(book, booksViewModel, currentUser.LibrarianId); // Pass the selected book and ViewModel

                borrowersDetails.ShowDialog();
                DisplayPage(currentPage); // Reload books after borrowing
            };

            bookPanel.Controls.Add(btnBorrow);
            bookPanel.Controls.Add(bookCover);
            bookPanel.Controls.Add(lblBookTitle);
            bookPanel.Controls.Add(lblAuthor);
            bookPanel.Controls.Add(lblDetails);

            return bookPanel;
        }

        private async void DisplayPage(int pageNumber)
        {
            flowLayoutPanel1.Controls.Clear();
            int startIndex = (pageNumber - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, booksViewModel.BooksList.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                var book = booksViewModel.BooksList[i];
                var bookPanel = await CreateBookPanel(book);  // Use await here
                flowLayoutPanel1.Controls.Add(bookPanel);
            }

            lblPage.Text = $"Page {currentPage} of {Math.Ceiling((double)booksViewModel.BooksList.Count / itemsPerPage)}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (booksViewModel.BooksList.Count + itemsPerPage - 1) / itemsPerPage;
        }

        private async void DisplayFilteredBooks(List<Books> filteredBooks)
        {
            flowLayoutPanel1.Controls.Clear();
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, filteredBooks.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                var book = filteredBooks[i];
                var bookPanel = await CreateBookPanel(book);  // Use await here
                flowLayoutPanel1.Controls.Add(bookPanel);
            }

            lblPage.Text = $"Page {currentPage} of {Math.Ceiling((double)filteredBooks.Count / itemsPerPage)}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (filteredBooks.Count + itemsPerPage - 1) / itemsPerPage;
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
                //pictureBox.Image = Properties.Resources.error_image;
            }
        }
        
        private async void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            currentPage = 1; // Reset to the first page when search is applied
            string searchQuery = txtSearch.Texts;
            var filteredBooks = await booksViewModel.SearchBooksAsync(searchQuery);
            DisplayFilteredBooks(filteredBooks);
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

        public async void InitializeCategoryComboBox()
        {
            var categories = await booksViewModel.GetCategoriesAsync();
            categories.Insert(0, "All"); // Add "All" as the first item
            cmbCategory.DataSource = categories;
            cmbCategory.OnSelectedIndexChanged += cmbCategory_SelectedIndexChanged; // Event handler for category selection
            cmbCategory.SelectedIndex = 0; // Select "All" by default
        }

        private async void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1; // Reset to the first page when a new filter is applied

            string selectedCategory = cmbCategory.SelectedItem.ToString();
            if (selectedCategory == "All")
            {
                // Display all books
                DisplayFilteredBooks(booksViewModel.BooksList);
            }
            else
            {
                // Filter books by the selected category
                var filteredBooks = await booksViewModel.FilterBooksByCategoryAsync(selectedCategory);
                DisplayFilteredBooks(filteredBooks);
            }
        }
    }
}

