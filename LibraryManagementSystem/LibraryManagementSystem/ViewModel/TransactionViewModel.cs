using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibraryManagementSystem.Model;
using System.Windows.Forms;

namespace LibraryManagementSystem.ViewModel
{
    public class TransactionViewModel
    {
        private readonly Connection _connection = Connection.Instance;



        public async Task<List<Transaction>> LoadReturnedBooksAsync()
        {
            string query = "SELECT b.borrower_id AS BorrowerId, " +  // Add borrower_id to the query
                           "b.name AS BorrowerName, " +
                           "bk.book_title AS BookTitle, " +
                           "b.return_date AS DateBorrowed, " +
                           "b.date_returned AS DateReturned, " +
                           "b.address AS Address, " +
                           "bk.author AS Author, " +
                           "b.contact_number AS ContactDetails, " +
                           "b.email_address AS Email, " +
                           "b.section_course AS SectionCourse, " +
                           "l.name AS LibrarianName, " +
                           "b.penalty AS Penalty " +
                           "FROM borrowers b " +
                           "JOIN books bk ON b.book_id = bk.book_id " +
                           "JOIN librarians l ON b.user_who_returned = l.librarian_id " +
                           "WHERE b.is_returned = true";

            List<Transaction> transactions = new List<Transaction>();

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            transactions.Add(new Transaction
                            {
                                BorrowerId = reader["BorrowerId"].ToString(),  // Add borrower_id to the transaction
                                BorrowerName = reader["BorrowerName"].ToString(),
                                BookTitle = reader["BookTitle"].ToString(),
                                DateBorrowed = Convert.ToDateTime(reader["DateBorrowed"]),
                                DateReturned = Convert.ToDateTime(reader["DateReturned"]),
                                Address = reader["Address"].ToString(),
                                Author = reader["Author"].ToString(),
                                ContactDetails = reader["ContactDetails"].ToString(),
                                Email = reader["Email"].ToString(),
                                SectionCourse = reader["SectionCourse"].ToString(),
                                LibrarianName = reader["LibrarianName"].ToString(),
                                Penalty = Convert.ToDecimal(reader["Penalty"])
                            });
                        }
                    }
                }
            }
            return transactions;
        }


        // Method to delete a transaction by borrower_id
        public async Task<bool> DeleteTransactionAsync(string BorrowerId)
        {
            string query = "DELETE FROM borrowers WHERE borrower_id = @BorrowerID";

            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BorrowerID", BorrowerId);

                    try
                    {
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        // If one or more rows were affected, the deletion was successful
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log the error here if needed
                        return false;
                    }
                }
            }
        }

    }
}
