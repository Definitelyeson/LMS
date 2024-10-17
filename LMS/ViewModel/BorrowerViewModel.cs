using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LMS.Model;
using MySql.Data.MySqlClient;


namespace LMS.ViewModel
{
    public class BorrowerViewModel
    {
        private readonly Connection _connection = Connection.Instance;
        public Borrower CurrentBorrower { get; set; }

        public BorrowerViewModel()
        {
            CurrentBorrower = new Borrower();
        }

        // Method to notify users 1 day before the due date via email
        public async Task NotifyNearDueDatesAsync()
        {
            string query = "SELECT name, email_address, return_date FROM borrowers WHERE is_returned = false";

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

                            // Check if the return date is one day away from today
                            if ((returnDate - DateTime.Today).TotalDays == 1)
                            {
                                // Send an email notification to the borrower
                                await SendEmailNotificationAsync(name, email, returnDate);
                            }
                        }
                    }
                }
            }
        }

        // Method to send an email notification
        private async Task SendEmailNotificationAsync(string name, string email, DateTime returnDate)
        {
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential("allpurposecreamy@gmail.com", "gypwdjxlhvtksjqg"); // App-specific password, no spaces
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("allpurposecreamy@gmail.com"),
                    Subject = "Reminder: Your Library Book is Due Tomorrow",
                    Body = $@"
<html>
<body>
    <p>Dear {name},</p>
    <p>We hope you're enjoying the book you borrowed from our library. This is a friendly reminder that the book titled <strong>title test</strong> is due tomorrow, <strong>{returnDate.ToString("MMMM dd, yyyy")}</strong>.</p>
    <p>Please return the book by the due date to avoid any late fees. If you need to extend the loan period, feel free to contact us before the due date.</p>
    <p>Thank you for using our library services. We look forward to assisting you in the future.</p>
    <br/>
    <p>Best regards,</p>
    <p><strong>The Library Team</strong></p>
    <p>[Library Name/Address/Contact Information]</p>
</body>
</html>",
                    IsBodyHtml = true

                };

                mailMessage.To.Add(email);

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine("Email successfully sent.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }

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

        public async Task<List<(Borrower, Books, string)>> LoadAllUnreturnedBooksAsync()
        {
            string query = "SELECT b.borrower_id, b.name, b.section_course, b.address, b.contact_number, b.email_address, b.return_date, " +
               "bk.book_id, bk.book_title, bk.image_path, bk.author, l.name as processed_by_name " +
               "FROM borrowers b " +
               "JOIN books bk ON b.book_id = bk.book_id " +
               "JOIN librarians l ON b.processed_by = l.librarian_id " +
               "WHERE b.is_returned = false";

            List<(Borrower, Books, string)> result = new List<(Borrower, Books, string)>();

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
                                borrower_id = Convert.ToInt32(reader["borrower_id"]), // Make sure to populate this field
                                Name = reader["name"] != DBNull.Value ? reader["name"].ToString() : string.Empty,
                                SectionCourse = reader["section_course"] != DBNull.Value ? reader["section_course"].ToString() : string.Empty,
                                Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : string.Empty,
                                ContactNumber = reader["contact_number"] != DBNull.Value ? reader["contact_number"].ToString() : string.Empty,
                                Email = reader["email_address"] != DBNull.Value ? reader["email_address"].ToString() : string.Empty,
                                ReturnDate = Convert.ToDateTime(reader["return_date"]),
                            };

                            Books book = new Books
                            {
                                book_id = Convert.ToInt32(reader["book_id"]), // Populate book_id
                                BookTitle = reader["book_title"] != DBNull.Value ? reader["book_title"].ToString() : string.Empty,
                                Author = reader["author"] != DBNull.Value ? reader["author"].ToString() : string.Empty,
                                ImagePath = reader["image_path"] != DBNull.Value ? reader["image_path"].ToString() : string.Empty,
                            };


                            // Retrieve the processed by user's name
                            string processedBy = reader["processed_by_name"] != DBNull.Value ? reader["processed_by_name"].ToString() : string.Empty;

                            // Add the tuple (Borrower, Book, ProcessedBy) to the result list
                            result.Add((borrower, book, processedBy));
                        }
                    }
                }
            }

            return result;
        }

        public async Task<bool> SaveBorrowerAsync(Borrower borrower, int bookId, int processedBy)
        {
            string queryBorrower = "INSERT INTO borrowers (name, section_course, address, contact_number, email_address, return_date, book_id, processed_by, is_returned) " +
                        "VALUES (@Name, @SectionCourse, @Address, @ContactNumber, @Email, @ReturnDate, @BookId, @ProcessedBy, @IsReturned)";

            string queryUpdateBook = "UPDATE books SET quantity = quantity - 1, borrowed_quantity = borrowed_quantity + 1 WHERE book_id = @BookId AND quantity > 0";

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlTransaction transaction = await conn.BeginTransactionAsync())
                {
                    try
                    {
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

                        // Update book quantity and borrowed quantity
                        using (MySqlCommand cmdUpdateBook = new MySqlCommand(queryUpdateBook, conn, transaction))
                        {
                            cmdUpdateBook.Parameters.AddWithValue("@BookId", bookId);
                            int bookRowsAffected = await cmdUpdateBook.ExecuteNonQueryAsync();

                            if (bookRowsAffected == 0)
                            {
                                throw new Exception("Book is not available or out of stock.");
                            }
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
            string queryReturnBook = "UPDATE borrowers SET is_returned = true, date_returned = @DateReturned, user_who_returned = @UserWhoReturned WHERE borrower_id = @BorrowerId";
            string queryUpdateBook = "UPDATE books SET quantity = quantity + 1, borrowed_quantity = borrowed_quantity - 1 WHERE book_id = @BookId";

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlTransaction transaction = await conn.BeginTransactionAsync())
                {
                    try
                    {
                        // Mark the borrower's book as returned and record the return details
                        using (MySqlCommand cmdReturnBook = new MySqlCommand(queryReturnBook, conn, transaction))
                        {
                            cmdReturnBook.Parameters.AddWithValue("@BorrowerId", borrowerId);
                            cmdReturnBook.Parameters.AddWithValue("@DateReturned", DateTime.Now);
                            cmdReturnBook.Parameters.AddWithValue("@UserWhoReturned", userId); // Assuming userId is passed to represent the librarian's ID
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

        public async Task<List<(string BorrowerName, string BookTitle, DateTime DateBorrowed, DateTime DateReturned, string Address, string Author, string ContactDetails, string Email, string SectionCourse, string ColNumber, string LibrarianName)>> LoadReturnedBooksAsync()
        {
            string query = "SELECT b.name AS BorrowerName, " +
                           "bk.book_title AS BookTitle, " +
                           "b.return_date AS DateBorrowed, " +
                           "b.date_returned AS DateReturned, " +
                           "b.address AS Address, " +
                           "bk.author AS Author, " +
                           "b.contact_number AS ContactDetails, " +
                           "b.email_address AS Email, " +
                           "b.section_course AS SectionCourse, " +
                           "b.contact_number AS ColNumber, " +
                           "l.name AS LibrarianName, " +
                           "b.date_returned AS ReturnedTime " +
                           "FROM borrowers b " +
                           "JOIN books bk ON b.book_id = bk.book_id " +
                           "JOIN librarians l ON b.user_who_returned = l.librarian_id " +
                           "WHERE b.is_returned = true";

            List<(string BorrowerName, string BookTitle, DateTime DateBorrowed, DateTime DateReturned, string Address, string Author, string ContactDetails, string Email, string SectionCourse, string ColNumber, string LibrarianName)> result = new List<(string, string, DateTime, DateTime, string, string, string, string, string, string, string)>();

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add((
                                reader["BorrowerName"].ToString(),
                                reader["BookTitle"].ToString(),
                                Convert.ToDateTime(reader["DateBorrowed"]),
                                Convert.ToDateTime(reader["DateReturned"]),
                                reader["Address"].ToString(),
                                reader["Author"].ToString(),
                                reader["ContactDetails"].ToString(),
                                reader["Email"].ToString(),
                                reader["SectionCourse"].ToString(),
                                reader["ColNumber"].ToString(),
                                reader["LibrarianName"].ToString()
                            ));
                        }
                    }
                }
            }

            return result;
        }




    }
}
