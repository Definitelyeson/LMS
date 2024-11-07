using System;
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
using LMS.Utilities;
using System.IO;

namespace LibraryManagementSystem.View
{
    public partial class frmSearchBooks : Form
    {

        private BooksViewModel booksViewModel; // ViewModel for managing book data
        private int currentPage = 1; // Current page being displayed
        private int itemsPerPage = 12; // Number of books per page
        private List<Panel> panelPool = new List<Panel>(); // Pool to store and reuse book panels
        private System.Windows.Forms.Timer debounceTimer = null;

        public frmSearchBooks()
        {
            InitializeComponent();
            InitializeBooksViewModel();
            InitializeUIComponents();
        }

        // Initialize the BooksViewModel to manage book data
        private void InitializeBooksViewModel()
        {
            booksViewModel = new BooksViewModel();
            //LoadBooks();
        }

        // Initialize UI components such as category combo box and layout setup
        private void InitializeUIComponents()
        {
            InitializeCategoryComboBox();
            SetupLayout();
        }

        // Create or update a book panel for displaying book information
        private async Task<Panel> CreateOrUpdateBookPanel(Books book, Panel existingPanel = null)
        {
            // If an existing panel is available from the pool, reuse it
            var bookPanel = existingPanel ?? new Panel
            {
                Size = new Size(278, 200),
                Margin = new Padding(5, 5, 5, 5),
                BackColor = Color.White
            };

            // Create or update the PictureBox for the book cover
            var bookCover = existingPanel?.Controls.OfType<PictureBox>().FirstOrDefault() ??
                            new PictureBox
                            {
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Size = new Size(100, 150),
                                Location = new Point(10, 30),
                                BorderStyle = BorderStyle.FixedSingle,
                                Image = Properties.Resources.books_default // Default placeholder image
                            };

            if (!bookPanel.Controls.Contains(bookCover))
                bookPanel.Controls.Add(bookCover);

            // Load the image asynchronously if the image path is valid
            if (!string.IsNullOrEmpty(book.ImagePath) && File.Exists(book.ImagePath))
            {
                await LoadImageAsync(book.ImagePath, bookCover);
            }

            // Create or update labels for book details
            var lblBookTitle = existingPanel?.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "lblTitle") ??
                               new Label
                               {
                                   Name = "lblTitle",
                                   Location = new Point(5, 10),
                                   Font = new Font("Segoe UI", 8, FontStyle.Bold),
                                   AutoSize = true
                               };
            lblBookTitle.Text = $"Title: {book.BookTitle}";
            if (!bookPanel.Controls.Contains(lblBookTitle))
                bookPanel.Controls.Add(lblBookTitle);

            var lblAuthor = existingPanel?.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "lblAuthor") ??
                            new Label
                            {
                                Name = "lblAuthor",
                                Location = new Point(120, 40),
                                Font = new Font("Segoe UI", 8),
                                AutoSize = true
                            };
            lblAuthor.Text = $"Author: {book.Author}";
            if (!bookPanel.Controls.Contains(lblAuthor))
                bookPanel.Controls.Add(lblAuthor);

            var lblDetails = existingPanel?.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "lblDetails") ??
                             new Label
                             {
                                 Name = "lblDetails",
                                 Location = new Point(120, 60),
                                 Font = new Font("Segoe UI", 8),
                                 AutoSize = true
                             };
            lblDetails.Text = $"Published: {book.BookPublisher}\n" +
                       $"Year: {book.YearPublished}\n" +
                       $"Category: {book.Category}\n" +
                       $"Quantity: {book.Quantity}\n" +
                       $"Borrowed: {book.BorrowedQuantity}\n" +
                       $"Available: {(book.IsAvailable ? "Yes" : "No")}\n" +  // Check availability
                       $"Type: {book.BookType}\n" + // Added book type
                       $"Summary: {book.BookSummary}";// Added book summary
            if (!bookPanel.Controls.Contains(lblDetails))
                bookPanel.Controls.Add(lblDetails);

            return bookPanel;
        }

        // Set up the layout for the FlowLayoutPanel
        private void SetupLayout()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(20);

            // Load books on initialization
            LoadBooks();
        }

        // Load book data asynchronously and display it
        private async void LoadBooks()
        {
            try
            {
                await booksViewModel.LoadBooksAsync(); // Load book data
                DisplayPage(currentPage); // Display the first page
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during book loading
                Console.WriteLine($"Error loading books: {ex.Message}");
                MessageBox.Show("Failed to load books. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Display a specific page of books
        private async void DisplayPage(int pageNumber)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear(); // Clear existing controls before displaying new ones

                // Calculate the range of books to display on the current page
                int startIndex = (pageNumber - 1) * itemsPerPage;
                int endIndex = Math.Min(startIndex + itemsPerPage, booksViewModel.BooksList.Count);

                var tasks = new List<Task<Panel>>();
                for (int i = startIndex; i < endIndex; i++)
                {
                    var book = booksViewModel.BooksList[i];
                    Panel existingPanel = panelPool.Count > i ? panelPool[i] : null; // Reuse panel if available
                    tasks.Add(CreateOrUpdateBookPanel(book, existingPanel)); // Create or update book panel
                }

                // Wait for all panels to be created/updated
                var panels = await Task.WhenAll(tasks);

                // Add the created panels to the FlowLayoutPanel
                foreach (var panel in panels)
                {
                    flowLayoutPanel1.Controls.Add(panel);
                }

                // Update pagination controls and preload the next page
                UpdatePaginationControls(pageNumber, booksViewModel.BooksList.Count);
                PreloadNextPage(pageNumber);

                // Store the panels in the pool for reuse
                if (panelPool.Count < endIndex)
                {
                    panelPool.AddRange(panels);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during page display
                Console.WriteLine($"Error displaying page: {ex.Message}");
                MessageBox.Show("Error displaying books. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Update the pagination controls based on the current page and total number of books
        private void UpdatePaginationControls(int currentPage, int totalItems)
        {
            int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
            lblPage.Text = $"Page {currentPage} of {totalPages}";
            btnPrev.Enabled = currentPage > 1; // Enable/disable Previous button
            btnNext.Enabled = currentPage < totalPages; // Enable/disable Next button
        }

        // Preload the next page in the background to ensure smooth transitions
        private async void PreloadNextPage(int currentPage)
        {
            if ((currentPage + 1) * itemsPerPage < booksViewModel.BooksList.Count)
            {
                int nextStartIndex = currentPage * itemsPerPage;
                int nextEndIndex = Math.Min(nextStartIndex + itemsPerPage, booksViewModel.BooksList.Count);

                var tasks = new List<Task<Panel>>();
                for (int i = nextStartIndex; i < nextEndIndex; i++)
                {
                    var book = booksViewModel.BooksList[i];
                    Panel existingPanel = panelPool.Count > i ? panelPool[i] : null; // Reuse panel if available
                    tasks.Add(Task.Run(() => CreateOrUpdateBookPanel(book, existingPanel))); // Preload panels
                }

                await Task.WhenAll(tasks); // Preload panels for the next page
            }
        }

        // Load images asynchronously to prevent blocking the UI thread
        private async Task LoadImageAsync(string imagePath, PictureBox pictureBox)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    var cachedImage = ImageCache.GetImage(imagePath);
                    if (cachedImage == null)
                    {
                        cachedImage = await Task.Run(() => Image.FromFile(imagePath)); // Load image in the background
                        ImageCache.StoreImage(imagePath, cachedImage); // Cache the image
                    }
                    pictureBox.Image = cachedImage; // Set the PictureBox image
                }
                else
                {
                    pictureBox.Image = Properties.Resources.books_default; // Set default image if no file exists
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during image loading
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

        private async Task DisplayFilteredBooks(List<Books> filteredBooks)
        {
            flowLayoutPanel1.Controls.Clear();
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, filteredBooks.Count);

            var tasks = new List<Task<Panel>>();
            for (int i = startIndex; i < endIndex; i++)
            {
                var book = filteredBooks[i];
                tasks.Add(CreateOrUpdateBookPanel(book)); // Collect tasks for each book panel
            }

            var panels = await Task.WhenAll(tasks); // Await all the tasks to complete

            foreach (var panel in panels)
            {
                flowLayoutPanel1.Controls.Add(panel); // Add each panel to the flow layout
            }

            UpdatePaginationControls(currentPage, filteredBooks.Count);
        }


        private async void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1; // Reset to the first page when the filter is applied

            if (cmbCategory.SelectedItem.ToString() == "All")
            {
                await DisplayFilteredBooks(booksViewModel.BooksList);
            }
            else
            {
                string selectedCategory = cmbCategory.SelectedItem.ToString();
                var filteredBooks = await booksViewModel.FilterBooksByCategoryAsync(selectedCategory);
                await DisplayFilteredBooks(filteredBooks);
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

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            if (debounceTimer != null)
            {
                debounceTimer.Stop();
                debounceTimer.Dispose();
            }

            debounceTimer = new System.Windows.Forms.Timer();
            debounceTimer.Interval = 500; // 500ms delay
            debounceTimer.Tick += async (s, args) =>
            {
                debounceTimer.Stop();
                debounceTimer.Dispose();
                string searchQuery = txtSearch.Texts;
                var filteredBooks = await booksViewModel.SearchBooksAsync(searchQuery);
                await DisplayFilteredBooks(filteredBooks);
            };
            debounceTimer.Start();
        }
    }
}

