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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem.View
{
    public partial class frmReturnBooks : Form
    {
        private Users currentUser; // Add field to store current user info
        private BorrowerViewModel borrowerViewModel;
        private readonly ToastNotifier _notifier = new ToastNotifier();
        private int currentPage = 1;
        private int itemsPerPage = 10;  // Set number of items per page for pagination
        private Timer notificationTimer;

        public frmReturnBooks(Users user)
        {
            InitializeComponent();

            currentUser = user; // Store the logged-in user

            borrowerViewModel = new BorrowerViewModel();

            // Initialize the Toggle Button for notifications
            toggleOverdueNotifications.Checked = borrowerViewModel.OverdueNotificationEnabled; // Set initial state based on model
            toggleOverdueNotifications.CheckedChanged += toggleOverdueNotifications_CheckedChanged;

            // Set up the notification timer
            notificationTimer = new Timer();
            notificationTimer.Interval = 3600000; // 1 hour in milliseconds
            notificationTimer.Tick += async (s, e) => await CheckAndSendOverdueNotifications();
            if (borrowerViewModel.OverdueNotificationEnabled) notificationTimer.Start();


            // Initialize filter ComboBox
            cmbFilter.Items.Add("All");
            cmbFilter.Items.Add("Overdue");
            cmbFilter.Items.Add("Regular");
            cmbFilter.SelectedIndex = 0; // Default to "All"
            cmbFilter.OnSelectedIndexChanged += async (s, e) => await LoadUnreturnedBooks();




            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(20);  // Add padding to make space around the container

            this.Load += async (s, e) => await InitializeDataAsync();
        }

        private async void toggleOverdueNotifications_CheckedChanged(object sender, EventArgs e)
        {
            // Update the OverdueNotificationEnabled property
            borrowerViewModel.OverdueNotificationEnabled = toggleOverdueNotifications.Checked;

            if (borrowerViewModel.OverdueNotificationEnabled)
            {
                // Send notifications immediately when enabling
                await CheckAndSendOverdueNotifications();

                // Start the timer for subsequent checks every 60 minutes
                notificationTimer.Start();
            }
            else
            {
                // Stop the timer when notifications are disabled
                notificationTimer.Stop();
            }

            string status = borrowerViewModel.OverdueNotificationEnabled ? "enabled" : "disabled";
            _notifier.Alert($"Overdue notifications have been {status}.", frmAlert.enmType.Info);
            
        }

       
        private async Task CheckAndSendOverdueNotifications()
        {
            if (borrowerViewModel.OverdueNotificationEnabled)
            {
                await borrowerViewModel.SendOverdueNotificationAsync();
            }
        }


        // Separate async method to load initial data
        private async Task InitializeDataAsync()
        {
            await LoadUnreturnedBooks();  // Load the unreturned books on form load
        }

        // Async Task method to load unreturned books with selected filter
        private async Task LoadUnreturnedBooks()
        {
            string filter = cmbFilter.SelectedItem.ToString();
            var unreturnedBooks = await borrowerViewModel.LoadAllUnreturnedBooksAsync(filter);
            DisplayPage(unreturnedBooks, currentPage);
        }



        // Display unreturned books on a paginated view
        private async void DisplayPage(List<(Borrower, Books, string, int)> unreturnedBooks, int pageNumber)
        {
            flowLayoutPanel1.Controls.Clear();
            int startIndex = (pageNumber - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, unreturnedBooks.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                var (borrower, book, processedBy, penalty) = unreturnedBooks[i];

                System.Windows.Forms.Panel bookPanel = new System.Windows.Forms.Panel
                {
                    Size = new Size(300, 220),
                    Margin = new Padding(10),
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
                    await LoadImageAsync(book.ImagePath, bookCover);
                }

                System.Windows.Forms.Label lblBookTitle = new System.Windows.Forms.Label
                {
                    Text = $"{book.BookTitle}",
                    Location = new Point(10, 10),
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    AutoSize = true
                };

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

                System.Windows.Forms.Label lblPenalty = new System.Windows.Forms.Label
                {
                    Text = penalty > 0 ? $"Penalty: {penalty} pesos" : "No Penalty",
                    Location = new Point(120, 140),
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    AutoSize = true,
                    ForeColor = penalty > 0 ? Color.Red : Color.Black
                };

                System.Windows.Forms.Button btnReturnBook = new System.Windows.Forms.Button
                {
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    BackColor = ColorTranslator.FromHtml("#28a745"), // Green color for Return button
                    ForeColor = Color.White,
                    Size = new Size(100, 35),
                    Location = new Point(170, 176),
                    Text = "Return Book"
                };

                btnReturnBook.Click += async (sender, e) =>
                {
                    Console.WriteLine($"Attempting to return book for Borrower ID: {borrower.borrower_id}, Book ID: {book.book_id}");

                    if (borrower.borrower_id <= 0 || book.book_id <= 0)
                    {
                        MessageBox.Show("Invalid borrower or book ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool isReturned = await borrowerViewModel.ReturnBookAsync(borrower.borrower_id, book.book_id, currentUser.LibrarianId);

                    if (isReturned)
                    {
                        _notifier.Alert($"Successfully returned {book.BookTitle}.", frmAlert.enmType.Success);
                        //MessageBox.Show($"Successfully returned {book.BookTitle} borrowed by {borrower.Name}");
                        await LoadUnreturnedBooks();
                    }
                    else
                    {
                        _notifier.Alert($"An error occurred while returning the book.", frmAlert.enmType.Error);
                        //MessageBox.Show("An error occurred while returning the book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                bookPanel.Controls.Add(bookCover);
                bookPanel.Controls.Add(lblBookTitle);
                bookPanel.Controls.Add(lblBorrowerDetails);
                bookPanel.Controls.Add(lblPenalty);  // Add the penalty label to the panel
                bookPanel.Controls.Add(btnReturnBook);

                flowLayoutPanel1.Controls.Add(bookPanel);
            }

            lblPage.Text = $"Page {currentPage} of {Math.Ceiling((double)unreturnedBooks.Count / itemsPerPage)}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < (unreturnedBooks.Count + itemsPerPage - 1) / itemsPerPage;
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
