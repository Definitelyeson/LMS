using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using MySql.Data.MySqlClient;


namespace LibraryManagementSystem.ViewModel
{
    public class BorrowerViewModel
    {
        private readonly Connection _connection = Connection.Instance;
        public bool OverdueNotificationEnabled { get; set; } = true; // Add toggle for notifications
        public Borrower CurrentBorrower { get; set; }

        public BorrowerViewModel()
        {
            CurrentBorrower = new Borrower();
        }

        // Method to set borrower details
        public void SetBorrowerDetails(string name, string sectionCourse, string address, string contactNumber, string email, DateTime returnDate)
        {
            CurrentBorrower.Name = name;
            CurrentBorrower.SectionCourse = sectionCourse;
            CurrentBorrower.Address = address;
            CurrentBorrower.ContactNumber = contactNumber;
            CurrentBorrower.Email = email;
            CurrentBorrower.ReturnDate = returnDate;
        }

        public async Task<List<(Borrower, Books, string, int)>> LoadAllUnreturnedBooksAsync(string filter)
        {
            string query = @"SELECT b.borrower_id, b.name, b.section_course, b.address, b.contact_number, b.email_address, b.return_date, 
                     bk.book_id, bk.book_title, bk.image_path, bk.author, l.name as processed_by_name,
                     CASE 
                         WHEN b.return_date < CURDATE() THEN DATEDIFF(CURDATE(), b.return_date) * 10 
                         ELSE 0 
                     END AS penalty 
                     FROM borrowers b 
                     JOIN books bk ON b.book_id = bk.book_id 
                     JOIN librarians l ON b.processed_by = l.librarian_id 
                     WHERE b.is_returned = false ";

            // Apply filter to query based on selection
            if (filter == "Overdue")
            {
                query += "AND b.return_date < CURDATE()"; // Only overdue books
            }
            else if (filter == "Regular")
            {
                query += "AND b.return_date >= CURDATE()"; // Only non-overdue books
            }

            List<(Borrower, Books, string, int)> result = new List<(Borrower, Books, string, int)>();

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Borrower borrower = new Borrower
                            {
                                borrower_id = Convert.ToInt32(reader["borrower_id"]),
                                Name = reader["name"].ToString(),
                                SectionCourse = reader["section_course"].ToString(),
                                Address = reader["address"].ToString(),
                                ContactNumber = reader["contact_number"].ToString(),
                                Email = reader["email_address"].ToString(),
                                ReturnDate = Convert.ToDateTime(reader["return_date"]),
                            };

                            Books book = new Books
                            {
                                book_id = Convert.ToInt32(reader["book_id"]),
                                BookTitle = reader["book_title"].ToString(),
                                Author = reader["author"].ToString(),
                                ImagePath = reader["image_path"].ToString(),
                            };

                            string processedBy = reader["processed_by_name"].ToString();
                            int penalty = Convert.ToInt32(reader["penalty"]);

                            result.Add((borrower, book, processedBy, penalty));
                        }
                    }
                }
            }

            return result;
        }
        public async Task<bool> SaveBorrowerAsync(Borrower borrower, int bookId, int processedBy)
        {
            // Query to check the current quantity and borrowed quantity of the book
            string queryCheckBook = "SELECT quantity, borrowed_quantity FROM books WHERE book_id = @BookId";
            string queryBorrower = "INSERT INTO borrowers (name, section_course, address, contact_number, email_address, return_date, book_id, processed_by, is_returned) " +
                                   "VALUES (@Name, @SectionCourse, @Address, @ContactNumber, @Email, @ReturnDate, @BookId, @ProcessedBy, @IsReturned)";

            string queryUpdateBook = "UPDATE books SET borrowed_quantity = borrowed_quantity + 1 WHERE book_id = @BookId";

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlTransaction transaction = await conn.BeginTransactionAsync())
                {
                    try
                    {
                        // Check the current quantity and borrowed quantity of the book
                        using (MySqlCommand cmdCheckBook = new MySqlCommand(queryCheckBook, conn, transaction))
                        {
                            cmdCheckBook.Parameters.AddWithValue("@BookId", bookId);
                            using (var reader = await cmdCheckBook.ExecuteReaderAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    int quantity = Convert.ToInt32(reader["quantity"]);
                                    int borrowedQuantity = Convert.ToInt32(reader["borrowed_quantity"]);

                                    // If all copies are borrowed, show an error message and return
                                    if (borrowedQuantity == quantity)
                                    {
                                        Console.WriteLine("Book is unavailable for borrowing. All copies are currently borrowed.");
                                        return false; // Transaction will not proceed if no copies are available
                                    }
                                }
                            }
                        }

                        // Insert borrower record
                        using (MySqlCommand cmdBorrower = new MySqlCommand(queryBorrower, conn, transaction))
                        {
                            cmdBorrower.Parameters.AddWithValue("@Name", borrower.Name);
                            cmdBorrower.Parameters.AddWithValue("@SectionCourse", borrower.SectionCourse);
                            cmdBorrower.Parameters.AddWithValue("@Address", borrower.Address);
                            cmdBorrower.Parameters.AddWithValue("@ContactNumber", borrower.ContactNumber);
                            cmdBorrower.Parameters.AddWithValue("@Email", borrower.Email);
                            cmdBorrower.Parameters.AddWithValue("@ReturnDate", borrower.ReturnDate);
                            cmdBorrower.Parameters.AddWithValue("@BookId", bookId);
                            cmdBorrower.Parameters.AddWithValue("@ProcessedBy", processedBy);
                            cmdBorrower.Parameters.AddWithValue("@IsReturned", 0); // Book is initially not returned

                            await cmdBorrower.ExecuteNonQueryAsync();
                        }

                        // Update borrowed quantity (do not decrement total quantity)
                        using (MySqlCommand cmdUpdateBook = new MySqlCommand(queryUpdateBook, conn, transaction))
                        {
                            cmdUpdateBook.Parameters.AddWithValue("@BookId", bookId);
                            await cmdUpdateBook.ExecuteNonQueryAsync();
                        }

                        await transaction.CommitAsync();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        await transaction.RollbackAsync();
                        return false;
                    }
                }
            }
        }
        public async Task<bool> ReturnBookAsync(int borrowerId, int bookId, int userId)
        {
            string queryReturnBook = "UPDATE borrowers SET is_returned = true, date_returned = @DateReturned, user_who_returned = @UserWhoReturned, penalty = @Penalty WHERE borrower_id = @BorrowerId";
            string queryUpdateBook = "UPDATE books SET quantity = quantity + 1, borrowed_quantity = borrowed_quantity - 1 WHERE book_id = @BookId";

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlTransaction transaction = await conn.BeginTransactionAsync())
                {
                    try
                    {
                        // Calculate penalty
                        int penalty = 0;
                        DateTime returnDate = DateTime.Now;

                        // Fetch the due date
                        string queryGetDueDate = "SELECT return_date FROM borrowers WHERE borrower_id = @BorrowerId";
                        DateTime dueDate;
                        using (MySqlCommand cmdGetDueDate = new MySqlCommand(queryGetDueDate, conn, transaction))
                        {
                            cmdGetDueDate.Parameters.AddWithValue("@BorrowerId", borrowerId);
                            dueDate = (DateTime)await cmdGetDueDate.ExecuteScalarAsync();
                        }

                        // Calculate penalty (e.g., 10 pesos per day)
                        if (returnDate > dueDate)
                        {
                            int daysLate = (int)(returnDate - dueDate).TotalDays;
                            penalty = daysLate * 10; // 10 pesos per day
                        }

                        // Mark the borrower's book as returned and record the return details
                        using (MySqlCommand cmdReturnBook = new MySqlCommand(queryReturnBook, conn, transaction))
                        {
                            cmdReturnBook.Parameters.AddWithValue("@BorrowerId", borrowerId);
                            cmdReturnBook.Parameters.AddWithValue("@DateReturned", returnDate);
                            cmdReturnBook.Parameters.AddWithValue("@UserWhoReturned", userId);
                            cmdReturnBook.Parameters.AddWithValue("@Penalty", penalty);
                            int rowsAffected = await cmdReturnBook.ExecuteNonQueryAsync();

                            if (rowsAffected == 0)
                            {
                                throw new Exception("No rows updated in borrowers. Invalid borrower ID?");
                            }
                        }

                        // Update the book's quantity and borrowed quantity
                        using (MySqlCommand cmdUpdateBook = new MySqlCommand(queryUpdateBook, conn, transaction))
                        {
                            cmdUpdateBook.Parameters.AddWithValue("@BookId", bookId);
                            int rowsAffected = await cmdUpdateBook.ExecuteNonQueryAsync();

                            if (rowsAffected == 0)
                            {
                                throw new Exception("No rows updated in books. Invalid book ID?");
                            }
                        }

                        await transaction.CommitAsync();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while returning the book: {ex.Message}");
                        await transaction.RollbackAsync();
                        return false;
                    }
                }
            }
        }

        public async Task SendOverdueNotificationAsync()
        {
            if (!OverdueNotificationEnabled) return;

            string query = "SELECT name, email_address, return_date FROM borrowers WHERE is_returned = false AND return_date < CURDATE()";

            List<(string Name, string Email, DateTime ReturnDate)> overdueList = new List<(string, string, DateTime)>();

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string name = reader["name"].ToString();
                            string email = reader["email_address"].ToString();
                            DateTime returnDate = Convert.ToDateTime(reader["return_date"]);

                            overdueList.Add((name, email, returnDate));
                        }
                    }
                }
            }

            if (overdueList.Count == 0) return;

            // Create and configure the SMTP client once
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential("allpurposecreamy@gmail.com", "gypwdjxlhvtksjqg"); // App-specific password
                smtpClient.EnableSsl = true;

                // Use tasks to send multiple emails in parallel
                var emailTasks = overdueList.Select(info => SendEmailAsync(smtpClient, info.Name, info.Email, info.ReturnDate)).ToList();

                // Await all tasks to complete
                await Task.WhenAll(emailTasks);
            }
        }

        // Helper method to send an individual email
        private async Task SendEmailAsync(SmtpClient smtpClient, string name, string email, DateTime returnDate)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("allpurposecreamy@gmail.com"),
                Subject = "Overdue Notice: Library Book Due Date Passed",
                Body = $@"
<html>
<head>
    <style>
        /* Main email container styling */
        body {{
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
        }}
        .email-container {{
            width: 100%;
            padding: 20px;
            background-color: #ffffff;
            border: 1px solid #ddd;
            max-width: 600px;
            margin: 0 auto;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }}
        .header {{
            background-color: #2e7d32; /* School's green color */
            color: white;
            padding: 20px;
            text-align: center;
            font-size: 24px;
            font-weight: bold;
        }}
        .header img {{
            max-width: 100px;
            margin-bottom: 10px;
        }}
        .content {{
            padding: 20px;
            color: #333;
            line-height: 1.6;
        }}
        .content p {{
            margin: 10px 0;
        }}
        .footer {{
            margin-top: 20px;
            padding: 10px;
            text-align: center;
            font-size: 12px;
            color: #999;
        }}
        .button {{
            display: inline-block;
            padding: 10px 15px;
            margin-top: 20px;
            font-size: 16px;
            background-color: #2e7d32; /* School's green color */
            color: white;
            text-decoration: none;
            border-radius: 5px;
        }}
        .button:hover {{
            background-color: #1b5e20;
        }}
        .highlight {{
            color: #d9534f;
            font-weight: bold;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <!-- Header section with logo -->
        <div class='header'>
            <img src='' />
            <div>Library Overdue Notice</div>
        </div>

        <!-- Main content section -->
        <div class='content'>
            <p>Dear {name},</p>
            <p>This is a reminder that the book you borrowed from our library was due on <span class='highlight'>{returnDate.ToString("MMMM dd, yyyy")}</span>.</p>
            <p>Please return the book as soon as possible to avoid further penalties. If you have any questions, feel free to contact us.</p>
            <p>Thank you for your cooperation.</p>
        </div>

        <!-- Footer section -->
        <div class='footer'>
            <p>Best regards,</p>
            <p><strong>The Library Team</strong></p>
            <p>COLM Library, Longos, Pulilan, Bulacan</p>
            <p>Contact Information</p>
            <p>&copy; {DateTime.Now.Year} Library Management System. All rights reserved.</p>
        </div>
    </div>
</body>
</html>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine($"Overdue email sent to {email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email to {email}: {ex.Message}");
            }
        }



    }
}
