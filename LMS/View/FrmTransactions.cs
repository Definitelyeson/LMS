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
using LMS.ViewModel;

namespace LMS.View
{
    public partial class FrmTransactions : Form
    {
        private Bunifu.UI.WinForms.BunifuDataGridView transactionDataGridView;
        private BorrowerViewModel _borrowerViewModel; // Declare ViewModel

        public FrmTransactions()
        {
            InitializeComponent();
            _borrowerViewModel = new BorrowerViewModel(); // Initialize ViewModel
            InitializeTransactionDataGridView();
          
        }

        // Method to export the data to PDF
        public void ExportToPDF(List<(string BorrowerName, string BookTitle, DateTime DateBorrowed, DateTime DateReturned, string Address, string Author, string ContactDetails, string Email, string SectionCourse, string ColNumber, string LibrarianName)> transactions)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf"; // Filter for PDF files
                saveFileDialog.Title = "Save as PDF";
                saveFileDialog.FileName = "transactions.pdf"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName; // Get the selected file path

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    doc.Open();

                    // Adding a title to the document
                    doc.Add(new Paragraph("Library Transactions Report"));
                    doc.Add(new Paragraph(" "));

                    // Creating a table with 11 columns for each field in transactions
                    PdfPTable table = new PdfPTable(11);
                    table.AddCell("Borrower's Name");
                    table.AddCell("Book Title");
                    table.AddCell("Date Borrowed");
                    table.AddCell("Date Returned");
                    table.AddCell("Address");
                    table.AddCell("Author");
                    table.AddCell("Contact Details");
                    table.AddCell("Email");
                    table.AddCell("Section/Course");
                    table.AddCell("Col Number");
                    table.AddCell("Librarian Name");

                    // Loop through each transaction and add to the table
                    foreach (var transaction in transactions)
                    {
                        table.AddCell(transaction.BorrowerName);
                        table.AddCell(transaction.BookTitle);
                        table.AddCell(transaction.DateBorrowed.ToString("yyyy-MM-dd"));
                        table.AddCell(transaction.DateReturned.ToString("yyyy-MM-dd"));
                        table.AddCell(transaction.Address);
                        table.AddCell(transaction.Author);
                        table.AddCell(transaction.ContactDetails);
                        table.AddCell(transaction.Email);
                        table.AddCell(transaction.SectionCourse);
                        table.AddCell(transaction.ColNumber);
                        table.AddCell(transaction.LibrarianName);
                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void InitializeTransactionDataGridView()
        {
            // Initialize and configure BunifuDataGridView for transactions
            transactionDataGridView = new Bunifu.UI.WinForms.BunifuDataGridView
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
            transactionDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 121, 255);  // Material blue
            transactionDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            transactionDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
            transactionDataGridView.EnableHeadersVisualStyles = false;

            // Add columns to DataGridView
            transactionDataGridView.Columns.Add("BorrowerName", "Borrower's Name");
            transactionDataGridView.Columns.Add("BookTitle", "Book Title");
            transactionDataGridView.Columns.Add("DateBorrowed", "Date Borrowed");
            transactionDataGridView.Columns.Add("DateReturned", "Date Returned");
            transactionDataGridView.Columns.Add("Address", "Address");
            transactionDataGridView.Columns.Add("Author", "Author");
            transactionDataGridView.Columns.Add("ContactDetails", "Contact Details");
            transactionDataGridView.Columns.Add("Email", "Gmail");
            transactionDataGridView.Columns.Add("SectionCourse", "Section/Course");
            transactionDataGridView.Columns.Add("ColNumber", "Col Number");
            transactionDataGridView.Columns.Add("LibrarianName", "Librarian/SA Name");

            transactionDataGridView.Dock = DockStyle.Fill;

            // Add DataGridView to the panel instead of directly to the form
            panelTransactions.Controls.Add(transactionDataGridView); // Add to the panel

        }

        private async void LoadTransactionsData()
        {
            var returnedBooks = await _borrowerViewModel.LoadReturnedBooksAsync();

            transactionDataGridView.Rows.Clear(); // Clear previous rows if necessary

            foreach (var book in returnedBooks)
            {
                transactionDataGridView.Rows.Add(
                    book.BorrowerName,
                    book.BookTitle,
                    book.DateBorrowed.ToString("yyyy-MM-dd"),  // Format date if needed
                    book.DateReturned.ToString("yyyy-MM-dd"),  // Format date if needed
                    book.Address,
                    book.Author,
                    book.ContactDetails,
                    book.Email,
                    book.SectionCourse,
                    book.ColNumber,
                    book.LibrarianName
                );
            }
        }

        // Method to export the data to Excel
        public void ExportToExcel(List<(string BorrowerName, string BookTitle, DateTime DateBorrowed, DateTime DateReturned, string Address, string Author, string ContactDetails, string Email, string SectionCourse, string ColNumber, string LibrarianName)> transactions)
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
                        worksheet.Cell(1, 10).Value = "Col Number";
                        worksheet.Cell(1, 11).Value = "Librarian Name";

                        // Loop through each transaction and add to the worksheet
                        int row = 2;
                        foreach (var transaction in transactions)
                        {
                            worksheet.Cell(row, 1).Value = transaction.BorrowerName;
                            worksheet.Cell(row, 2).Value = transaction.BookTitle;
                            worksheet.Cell(row, 3).Value = transaction.DateBorrowed.ToString("yyyy-MM-dd");
                            worksheet.Cell(row, 4).Value = transaction.DateReturned.ToString("yyyy-MM-dd");
                            worksheet.Cell(row, 5).Value = transaction.Address;
                            worksheet.Cell(row, 6).Value = transaction.Author;
                            worksheet.Cell(row, 7).Value = transaction.ContactDetails;
                            worksheet.Cell(row, 8).Value = transaction.Email;
                            worksheet.Cell(row, 9).Value = transaction.SectionCourse;
                            worksheet.Cell(row, 10).Value = transaction.ColNumber;
                            worksheet.Cell(row, 11).Value = transaction.LibrarianName;
                            row++;
                        }

                        workbook.SaveAs(filePath);
                    }

                    MessageBox.Show("Excel exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        private void FrmTransactions_Load(object sender, EventArgs e)
        {
            LoadTransactionsData(); 
        }

        private async void BtnExportPdf_Click(object sender, EventArgs e)
        {
            
            var transactions = await _borrowerViewModel.LoadReturnedBooksAsync(); 
            ExportToPDF(transactions); 
        }

        private async void BtnExportExcel_Click(object sender, EventArgs e)
        {
           
            var transactions = await _borrowerViewModel.LoadReturnedBooksAsync(); 
            ExportToExcel(transactions); 
        }
    }
}
