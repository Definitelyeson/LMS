using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem.ViewModel
{
    public class BooksViewModel
    {
        private readonly Connection _connection = Connection.Instance;
        public List<Books> BooksList { get; private set; }

        public BooksViewModel()
        {
            BooksList = new List<Books>();
            /*  InitializeBooks();*/ // Call to load books when ViewModel is created

        }

        private async void InitializeBooks()
        {
            await LoadBooksAsync();
        }

        public async Task<bool> BookExistsAsync(string title, string author)
        {
            string query = "SELECT COUNT(*) FROM books WHERE book_title = @Title AND author = @Author";
            using (var conn = new MySqlConnection(_connection.ConnectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Author", author);
                    var result = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(result) > 0;
                }
            }
        }

        public async Task LoadBooksAsync()
        {
            BooksList.Clear();
            try
            {
                using (var con = new MySqlConnection(_connection.ConnectionString))
                {
                    string query = "SELECT book_id, book_title, author, book_publisher, year_published, category, quantity, image_path, borrowed_quantity, book_summary, book_type, is_archived FROM books WHERE is_archived = FALSE";
                    await con.OpenAsync();
                    using (var cmd = new MySqlCommand(query, con))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var book = new Books
                                {
                                    book_id = int.Parse(reader["book_id"].ToString()),
                                    BookTitle = reader["book_title"].ToString(),
                                    Author = reader["author"].ToString(),
                                    BookPublisher = reader["book_publisher"].ToString(),
                                    YearPublished = int.Parse(reader["year_published"].ToString()),
                                    Category = reader["category"].ToString(),
                                    Quantity = int.Parse(reader["quantity"].ToString()),
                                    ImagePath = reader["image_path"].ToString(),
                                    BorrowedQuantity = int.Parse(reader["borrowed_quantity"].ToString()),
                                    BookSummary = reader["book_summary"].ToString(), 
                                    BookType = reader["book_type"].ToString() 
                                };

                                BooksList.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load books: " + ex.Message);
            }
        }
        public async Task<bool> AddBookAsync(Books book)
        {
            string query = "INSERT INTO books (book_title, author, book_publisher, year_published, category, quantity, image_path, borrowed_quantity, book_summary, book_type) " +
                           "VALUES (@BookTitle, @Author, @BookPublisher, @YearPublished, @Category, @Quantity, @ImagePath, @BorrowedQuantity, @BookSummary, @BookType)";
            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookTitle", book.BookTitle);
                        cmd.Parameters.AddWithValue("@Author", book.Author);
                        cmd.Parameters.AddWithValue("@BookPublisher", book.BookPublisher);
                        cmd.Parameters.AddWithValue("@YearPublished", book.YearPublished);
                        cmd.Parameters.AddWithValue("@Category", book.Category);
                        cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                        cmd.Parameters.AddWithValue("@ImagePath", book.ImagePath);
                        cmd.Parameters.AddWithValue("@BorrowedQuantity", 0);
                        cmd.Parameters.AddWithValue("@BookSummary", book.BookSummary);
                        cmd.Parameters.AddWithValue("@BookType", book.BookType);

                        await cmd.ExecuteNonQueryAsync();
                        await LoadBooksAsync();
                        return true; 
                    }
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error: " + ex.Message);
                return false; 
            }
        }
        public async Task DeleteBookAsync(int bookId)
        {
            string query = "DELETE FROM books WHERE book_id = @BookId";

            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookId", bookId);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting book: " + ex.Message);
            }
        }

        public async Task<bool> UpdateBookAsync(Books book)
        {
            string query = "UPDATE books SET book_title = @BookTitle, author = @Author, book_publisher = @BookPublisher, " +
                           "year_published = @YearPublished, category = @Category, quantity = @Quantity, image_path = @ImagePath, " +
                           "borrowed_quantity = @BorrowedQuantity, book_type = @BookType, book_summary = @BookSummary " +
                           "WHERE book_id = @BookId";

            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookTitle", book.BookTitle);
                        cmd.Parameters.AddWithValue("@Author", book.Author);
                        cmd.Parameters.AddWithValue("@BookPublisher", book.BookPublisher);
                        cmd.Parameters.AddWithValue("@YearPublished", book.YearPublished);
                        cmd.Parameters.AddWithValue("@Category", book.Category);
                        cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                        cmd.Parameters.AddWithValue("@ImagePath", book.ImagePath);
                        cmd.Parameters.AddWithValue("@BorrowedQuantity", book.BorrowedQuantity);  
                        cmd.Parameters.AddWithValue("@BookType", book.BookType); 
                        cmd.Parameters.AddWithValue("@BookSummary", book.BookSummary); 
                        cmd.Parameters.AddWithValue("@BookId", book.book_id);  

                        await cmd.ExecuteNonQueryAsync();
                        await LoadBooksAsync();  
                        return true;  
                    }
                }
            }
            catch (Exception ex)
            {
           
                Console.WriteLine("Error updating book: " + ex.Message);
                return false;  
            }
        }
        public async Task<List<Books>> SearchArchivedBooksAsync(string searchText)
        {
            var filteredBooks = new List<Books>();
            string query = "SELECT book_id, book_title, author, book_publisher, year_published, category, quantity, image_path, borrowed_quantity " +
                           "FROM books WHERE (book_title LIKE @searchText OR author LIKE @searchText) AND is_archived = TRUE";

            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var book = new Books
                                {
                                    book_id = int.Parse(reader["book_id"].ToString()),
                                    BookTitle = reader["book_title"].ToString(),
                                    Author = reader["author"].ToString(),
                                    BookPublisher = reader["book_publisher"].ToString(),
                                    YearPublished = int.Parse(reader["year_published"].ToString()),
                                    Category = reader["category"].ToString(),
                                    Quantity = int.Parse(reader["quantity"].ToString()),
                                    ImagePath = reader["image_path"].ToString(),
                                    BorrowedQuantity = int.Parse(reader["borrowed_quantity"].ToString())
                                };
                                filteredBooks.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }

            return filteredBooks;
        }
        public async Task<List<Books>> SearchBooksAsync(string searchText)
        {
            var filteredBooks = new List<Books>();
            string query = "SELECT book_title, author, book_publisher, year_published, category, quantity, image_path , borrowed_quantity, book_summary, book_type FROM books WHERE (book_title LIKE @searchText OR author LIKE @searchText) AND is_archived = FALSE";

            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var book = new Books
                                {
                                    BookTitle = reader["book_title"].ToString(),
                                    Author = reader["author"].ToString(),
                                    BookPublisher = reader["book_publisher"].ToString(),
                                    YearPublished = int.Parse(reader["year_published"].ToString()),
                                    Category = reader["category"].ToString(),
                                    Quantity = int.Parse(reader["quantity"].ToString()),
                                    ImagePath = reader["image_path"].ToString(),
                                    BorrowedQuantity = int.Parse(reader["borrowed_quantity"].ToString()),
                                    BookSummary = reader["book_summary"].ToString(),
                                    BookType = reader["book_type"].ToString()
                                   
                                };
                                filteredBooks.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }

            return filteredBooks;
        }
        public async Task<List<string>> GetCategoriesAsync()
        {
            var categories = new List<string>();
            string query = "SELECT DISTINCT category FROM books";

            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                categories.Add(reader["category"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories: " + ex.Message);
            }

            return categories;
        }
        public async Task<List<Books>> FilterBooksByCategoryAsync(string category)
        {
            var filteredBooks = new List<Books>();
            string query = "SELECT book_id, book_title, author, book_publisher, year_published, category, quantity, image_path, borrowed_quantity, book_summary, book_type FROM books WHERE category = @category AND is_archived = FALSE";

            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var book = new Books
                                {
                                    book_id = int.Parse(reader["book_id"].ToString()),
                                    BookTitle = reader["book_title"].ToString(),
                                    Author = reader["author"].ToString(),
                                    BookPublisher = reader["book_publisher"].ToString(),
                                    YearPublished = int.Parse(reader["year_published"].ToString()),
                                    Category = reader["category"].ToString(),
                                    Quantity = int.Parse(reader["quantity"].ToString()),
                                    ImagePath = reader["image_path"].ToString(),
                                    BorrowedQuantity = int.Parse(reader["borrowed_quantity"].ToString()),
                                    BookSummary = reader["book_summary"].ToString(),
                                    BookType = reader["book_type"].ToString()


                                };
                                filteredBooks.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to filter books by category: " + ex.Message);
            }

            return filteredBooks;
        }
        public async Task ArchiveBookAsync(int bookId)
        {
            string query = "UPDATE books SET is_archived = TRUE WHERE book_id = @BookId";

            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookId", bookId);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error archiving book: " + ex.Message);
            }
        }
        public async Task UnarchiveBookAsync(int bookId)
        {
            string query = "UPDATE books SET is_archived = FALSE WHERE book_id = @BookId";

            try
            {
                using (var conn = new MySqlConnection(_connection.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookId", bookId);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error unarchiving book: " + ex.Message);
            }
        }
        public async Task LoadArchivesAsync()
        {

            BooksList.Clear();
            try
            {
                using (var con = new MySqlConnection(_connection.ConnectionString))
                {
                    string query = "SELECT book_id, book_title, author, book_publisher, year_published, category, quantity, image_path, borrowed_quantity, is_archived FROM books WHERE is_archived = TRUE";
                    await con.OpenAsync();
                    using (var cmd = new MySqlCommand(query, con))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Books book = new Books
                                {
                                    book_id = int.Parse(reader["book_id"].ToString()),
                                    BookTitle = reader["book_title"].ToString(),
                                    Author = reader["author"].ToString(),
                                    BookPublisher = reader["book_publisher"].ToString(),
                                    YearPublished = int.Parse(reader["year_published"].ToString()),
                                    Category = reader["category"].ToString(),
                                    Quantity = int.Parse(reader["quantity"].ToString()),
                                    ImagePath = reader["image_path"].ToString(),
                                    BorrowedQuantity = int.Parse(reader["borrowed_quantity"].ToString()) // Add this line
                                };

                                BooksList.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load books: " + ex.Message);
                // Consider using logging here
            }

        }
    }

}
