using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.View
{
    public partial class frmBookTransactions : Form
    {
        private DataGridView dgvTransactions;
        private TransactionViewModel _transactionViewModel; // Declare ViewModel
        private Dictionary<int, string> borrowerIdMapping = new Dictionary<int, string>();


        // Pagination Variables
        private int currentPage = 1;
        private int totalPageCount = 0;
        private const int pageSize = 20; // Number of rows per page
        private List<Transaction> allTransactions; // Store all data in a structured Transaction class

        public frmBookTransactions()
        {
            InitializeComponent();

            _transactionViewModel = new TransactionViewModel(); // Initialize ViewModel
            InitializeTransactionDataGridView();
            dgvTransactions.CellContentClick += dgvTransactions_CellContentClick;         
            dgvTransactions.CellFormatting += dgvTransactions_CellFormatting;


        }


        private void InitializeTransactionDataGridView()
        {
            // Initialize and configure BunifuDataGridView for transactions
            dgvTransactions = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,  // Fill columns to fit the grid
                AllowUserToAddRows = false,  // Disallow adding new rows
                AllowUserToDeleteRows = false,
                ReadOnly = true,  // Make grid read-only
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,  // Full row selection mode
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.White,
                RowHeadersVisible = false  // Hide row headers
            };

            // Set header style for material design
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 121, 255);  // Material blue
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
            dgvTransactions.EnableHeadersVisualStyles = false;

            // Add columns to DataGridView
            dgvTransactions.Columns.Add("BorrowerId", "Borrower ID");
            dgvTransactions.Columns["BorrowerId"].Visible = false;  // Hide the column
            dgvTransactions.Columns.Add("BorrowerName", "Borrower's Name");
            dgvTransactions.Columns.Add("BookTitle", "Book Title");
            dgvTransactions.Columns.Add("DateBorrowed", "Date Borrowed");
            dgvTransactions.Columns.Add("DateReturned", "Date Returned");
            dgvTransactions.Columns.Add("Address", "Address");
            dgvTransactions.Columns.Add("Author", "Author");
            dgvTransactions.Columns.Add("ContactDetails", "Contact Details");
            dgvTransactions.Columns.Add("Email", "Email");
            dgvTransactions.Columns.Add("SectionCourse", "Section/Course");     
            dgvTransactions.Columns.Add("LibrarianName", "Librarian/SA Name");
            dgvTransactions.Columns.Add("Penalty", "Penalty (₱)");

            // Add Delete Button Column
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Action";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
          
            btnDelete.UseColumnTextForButtonValue = true;  // This ensures all cells show "Delete"
            dgvTransactions.Columns.Add(btnDelete);


            dgvTransactions.Dock = DockStyle.Fill;

            // Add DataGridView to the panel instead of directly to the form
            panelTransactions.Controls.Add(dgvTransactions); // Add to the panel

        }

        private async Task LoadPageAsync(int pageNumber)
        {
            await Task.Delay(1);  // Simulate a non-blocking delay

            currentPage = pageNumber;
            int startRow = (currentPage - 1) * pageSize;
            var transactionsToShow = allTransactions.Skip(startRow).Take(pageSize).ToList();

            dgvTransactions.Rows.Clear();

            foreach (var transaction in transactionsToShow)
            {
                AddTransactionToGrid(transaction);
            }

            UpdatePaginationControls();
        }


        private void AddTransactionToGrid(Transaction transaction)
        {
            int rowIndex = dgvTransactions.Rows.Add(
                transaction.BorrowerId,  // Add the borrower ID (but hidden or visible)
                transaction.BorrowerName,
                transaction.BookTitle,
                transaction.DateBorrowed.ToString("yyyy-MM-dd"),
                transaction.DateReturned.ToString("yyyy-MM-dd hh:mm tt"),
                transaction.Address,
                transaction.Author,
                transaction.ContactDetails,
                transaction.Email,
                transaction.SectionCourse,
                transaction.LibrarianName,
                string.Format("₱{0:N2}", transaction.Penalty)
            );

            // Map the row index to the BorrowerId
            borrowerIdMapping[rowIndex] = transaction.BorrowerId;
        }


        private async void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTransactions.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;

                // Confirm deletion
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this transaction?",
                                                            "Confirm Delete",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    // Retrieve the BorrowerId from the borrowerIdMapping dictionary
                    if (borrowerIdMapping.TryGetValue(rowIndex, out string borrowerId))
                    {
                        // Call the async method to delete the transaction
                        bool isDeleted = await _transactionViewModel.DeleteTransactionAsync(borrowerId);

                        // Show appropriate message based on success or failure
                        if (isDeleted)
                        {
                            MessageBox.Show("Transaction deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete transaction. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Refresh the DataGridView after deletion, if successful
                        if (isDeleted)
                        {
                            allTransactions = await _transactionViewModel.LoadReturnedBooksAsync();
                            await LoadPageAsync(currentPage);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Borrower ID not found for the selected transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void dgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            if (dgvTransactions.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
               
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgvTransactions.Rows[e.RowIndex].Cells[e.ColumnIndex];
                buttonCell.FlatStyle = FlatStyle.Popup;               
                buttonCell.Style.BackColor = Color.Red;
                buttonCell.Style.ForeColor = Color.White; 
            }
        }

        public void ExportToPDF(List<Transaction> transactions)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save as PDF";
                saveFileDialog.FileName = "transactions.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    doc.Open();
                    doc.Add(new Paragraph("Library Transactions Report"));
                    doc.Add(new Paragraph(" "));

                    PdfPTable table = new PdfPTable(10);
                    table.AddCell("Borrower's Name");
                    table.AddCell("Book Title");
                    table.AddCell("Date Borrowed");
                    table.AddCell("Date Returned");
                    table.AddCell("Address");
                    table.AddCell("Author");
                    table.AddCell("Contact Details");
                    table.AddCell("Email");
                    table.AddCell("Section/Course");
                    table.AddCell("Librarian Name");

                    foreach (var transaction in transactions)
                    {
                        table.AddCell(transaction.BorrowerName);
                        table.AddCell(transaction.BookTitle);
                        table.AddCell(transaction.DateBorrowed.ToString("yyyy-MM-dd"));
                        table.AddCell(transaction.DateReturned.ToString("yyyy-MM-dd hh:mm tt"));
                        table.AddCell(transaction.Address);
                        table.AddCell(transaction.Author);
                        table.AddCell(transaction.ContactDetails);
                        table.AddCell(transaction.Email);
                        table.AddCell(transaction.SectionCourse);
                        table.AddCell(transaction.LibrarianName);
                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        // Method to export the data to Excel
        public void ExportToExcel(List<(string BorrowerName, string BookTitle, DateTime DateBorrowed, DateTime DateReturned, string Address, string Author, string ContactDetails, string Email, string SectionCourse,string LibrarianName)> transactions)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx"; // Filter for Excel files
                saveFileDialog.Title = "Save as Excel";
                saveFileDialog.FileName = "transactions.xlsx"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName; // Get the selected file path

                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Transactions");

                        // Add headers
                        worksheet.Cell(1, 1).Value = "Borrower's Name";
                        worksheet.Cell(1, 2).Value = "Book Title";
                        worksheet.Cell(1, 3).Value = "Date Borrowed";
                        worksheet.Cell(1, 4).Value = "Date Returned";
                        worksheet.Cell(1, 5).Value = "Address";
                        worksheet.Cell(1, 6).Value = "Author";
                        worksheet.Cell(1, 7).Value = "Contact Details";
                        worksheet.Cell(1, 8).Value = "Email";
                        worksheet.Cell(1, 9).Value = "Section/Course";
                        worksheet.Cell(1, 11).Value = "Librarian Name";

                        // Loop through each transaction and add to the worksheet
                        int row = 2;
                        foreach (var transaction in transactions)
                        {
                            worksheet.Cell(row, 1).Value = transaction.BorrowerName;
                            worksheet.Cell(row, 2).Value = transaction.BookTitle;
                            worksheet.Cell(row, 3).Value = transaction.DateBorrowed.ToString("yyyy-MM-dd");
                            worksheet.Cell(row, 4).Value = transaction.DateReturned.ToString("yyyy-MM-dd hh:mm tt");
                            worksheet.Cell(row, 5).Value = transaction.Address;
                            worksheet.Cell(row, 6).Value = transaction.Author;
                            worksheet.Cell(row, 7).Value = transaction.ContactDetails;
                            worksheet.Cell(row, 8).Value = transaction.Email;
                            worksheet.Cell(row, 9).Value = transaction.SectionCourse;
                            worksheet.Cell(row, 11).Value = transaction.LibrarianName;
                            row++;
                        }

                        workbook.SaveAs(filePath);
                    }

                    MessageBox.Show("Excel exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void BtnExportPdf_Click(object sender, EventArgs e)
        {

            var transactions = await _transactionViewModel.LoadReturnedBooksAsync();
            ExportToPDF(transactions);
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePaginationControls()
        {
            btnPrev.Enabled = currentPage > 1;  
            btnNext.Enabled = currentPage < totalPageCount;  
            lblPage.Text = $"Page {currentPage} of {totalPageCount}";  
        }


        private async void frmBookTransactions_Load(object sender, EventArgs e)
        {
            // Load all transactions asynchronously when the form loads
            allTransactions = await _transactionViewModel.LoadReturnedBooksAsync();

            // Calculate total page count based on the number of transactions
            totalPageCount = (int)Math.Ceiling((double)allTransactions.Count / pageSize);

            // Load the first page asynchronously
            await LoadPageAsync(1);
        }

        
        private void DisplayFilteredData(List<Transaction> filteredTransactions)
        {
            dgvTransactions.Rows.Clear();

            if (filteredTransactions.Any())
            {
                foreach (var transaction in filteredTransactions)
                {
                    AddTransactionToGrid(transaction);
                }
            }
            else
            {
                dgvTransactions.Rows.Add("No records found", "", "", "", "", "", "", "", "");
            }

            currentPage = 1;
            totalPageCount = (int)Math.Ceiling((double)filteredTransactions.Count / pageSize);
            UpdatePaginationControls();
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            int diff = (7 + (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private DateTime GetStartOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        private void btnThisWeek_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = GetStartOfWeek(today);

            var filteredTransactions = allTransactions
                .Where(t => t.DateReturned.Date >= startOfWeek && t.DateReturned.Date <= today.Date)  // Use DateReturned.Date to ignore time
                .ToList();

            DisplayFilteredData(filteredTransactions);
        }

        private void btnLast3Days_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime last3DaysStart = today.AddDays(-3);

            var filteredTransactions = allTransactions
                .Where(t => t.DateReturned.Date >= last3DaysStart && t.DateReturned.Date <= today.Date)  // Compare only the date part
                .ToList();

            DisplayFilteredData(filteredTransactions);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime startOfMonth = GetStartOfMonth(today);

            var filteredTransactions = allTransactions
                .Where(t => t.DateReturned.Date >= startOfMonth && t.DateReturned.Date <= today.Date)  // Use DateReturned.Date
                .ToList();

            DisplayFilteredData(filteredTransactions);
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;  
            DateTime endDate = dtpEndDate.Value.Date; 

            // Validate the date range
            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be later than the end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Filter the transactions based on the selected date range using DateReturned.Date
            var filteredTransactions = allTransactions
                .Where(t => t.DateReturned.Date >= startDate && t.DateReturned.Date <= endDate)  
                .ToList();

            // Display the filtered data in the DataGridView
            DisplayFilteredData(filteredTransactions);
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true; 
            dtpEndDate.Enabled = true;      
        }
     

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                await LoadPageAsync(currentPage - 1);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPageCount)
            {
                await LoadPageAsync(currentPage + 1);
            }
        }
    }
    } 
