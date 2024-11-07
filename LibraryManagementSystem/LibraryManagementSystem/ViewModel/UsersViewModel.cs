using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using System.Windows.Forms;
using LibraryManagementSystem.CustomControl;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem.ViewModel
{
    public class UsersViewModel
    {
        // Handles database connection
        // Use the Singleton instance of the Connection class
        private readonly Connection _connection = Connection.Instance;
        private readonly ToastNotifier _notifier = new ToastNotifier();


        // Property to keep track of logged-in user
        public Users LoggedInUser { get; private set; }

        // List to store users loaded from the database
        public List<Users> UsersList { get; private set; }

        public UsersViewModel()
        {
            UsersList = new List<Users>();
            LoadUsers(); // Load all users upon initialization
        }

        // Load all users from the database
        public void LoadUsers()
        {
            UsersList.Clear();
            string query = "SELECT librarian_id, name, birth_date, address, contact_no, email_address, position, username, password, photo_path, created_at FROM librarians";
            using (MySqlConnection con = new MySqlConnection(_connection.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users
                            {
                                LibrarianId = Convert.ToInt32(reader["librarian_id"]),
                                Name = reader["name"].ToString(),
                                BirthDate = reader["birth_date"] != DBNull.Value ? Convert.ToDateTime(reader["birth_date"]) : (DateTime?)null,
                                Address = reader["address"].ToString(),
                                ContactNo = reader["contact_no"].ToString(),
                                EmailAddress = reader["email_address"].ToString(),
                                Position = reader["position"].ToString(),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                PhotoPath = reader["photo_path"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            UsersList.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading users: {ex.Message}");
                }
            }
        }


        // Add a new user to the database
        public void AddUser(Users user)
        {
            string query = "INSERT INTO librarians (name, birth_date, address, contact_no, email_address, position, username, password, photo_path) " +
                           "VALUES (@Name, @BirthDate, @Address, @ContactNo, @EmailAddress, @Position, @Username, @Password, @PhotoPath)";
            using (MySqlConnection conn = new MySqlConnection(_connection.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@BirthDate", user.BirthDate.HasValue ? (object)user.BirthDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    cmd.Parameters.AddWithValue("@Position", user.Position);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password); // Store hashed password
                    cmd.Parameters.AddWithValue("@PhotoPath", user.PhotoPath);

                    cmd.ExecuteNonQuery();

                    _notifier.Alert("User added successfully!", frmAlert.enmType.Success);
                    LoadUsers(); // Reload the user list to reflect new changes
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding user: {ex.Message}");
                }
            }
        }

        // Update existing user details in the database
        public void UpdateUser(Users user)
        {
            string query = "UPDATE librarians SET name = @Name, birth_date = @BirthDate, address = @Address, " +
                           "contact_no = @ContactNo, email_address = @EmailAddress, position = @Position, username = @Username, " +
                           "photo_path = @PhotoPath" +
                           (user.Password != null ? ", password = @Password" : "") + // Conditionally update password
                           " WHERE librarian_id = @LibrarianId";
            using (MySqlConnection conn = new MySqlConnection(_connection.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    // Add parameters to SQL command
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@BirthDate", user.BirthDate.HasValue ? (object)user.BirthDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    cmd.Parameters.AddWithValue("@Position", user.Position);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PhotoPath", user.PhotoPath);
                    cmd.Parameters.AddWithValue("@LibrarianId", user.LibrarianId);

                    // Hash password if it's being updated
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        cmd.Parameters.AddWithValue("@Password", user.Password); // Use already hashed password
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully!");
                    LoadUsers(); // Reload to show updated user list
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating user: {ex.Message}");
                }
            }
        }

        // Delete a user from the database
        public void DeleteUser(int librarianId)
        {
            string query = "DELETE FROM librarians WHERE librarian_id = @LibrarianId";
            using (MySqlConnection conn = new MySqlConnection(_connection.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@LibrarianId", librarianId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted successfully!");
                    LoadUsers(); // Reload to show updated user list
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}");
                }
            }
        }

        // Search the user list for matching entries
        public List<Users> SearchUsers(string query)
        {
            return UsersList
                .Where(user => user.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                               user.Username.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        // Handle user login by verifying credentials
        public Users Login(string username, string password)
        {
            string query = "SELECT librarian_id, name, birth_date, address, contact_no, email_address, position, username, password, photo_path, created_at " +
                           "FROM librarians WHERE username = @Username";

            using (MySqlConnection conn = new MySqlConnection(_connection.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHashedPassword = reader["password"].ToString();

                            // Verify the entered password with the hashed password stored in the database
                            if (BCrypt.Net.BCrypt.Verify(password, storedHashedPassword))
                            {
                                // If the password matches, return the user information
                                LoggedInUser = new Users
                                {
                                    LibrarianId = Convert.ToInt32(reader["librarian_id"]),
                                    Name = reader["name"].ToString(),
                                    BirthDate = reader["birth_date"] != DBNull.Value ? Convert.ToDateTime(reader["birth_date"]) : (DateTime?)null,
                                    Address = reader["address"].ToString(),
                                    ContactNo = reader["contact_no"].ToString(),
                                    EmailAddress = reader["email_address"].ToString(),
                                    Position = reader["position"].ToString(),
                                    Username = reader["username"].ToString(),
                                    PhotoPath = reader["photo_path"].ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"])
                                };

                                return LoggedInUser; // Successful login
                            }
                            else
                            {
                                MessageBox.Show("Invalid password. Please try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during login: {ex.Message}");
                }
            }
            return null; // Return null if login fails
        }

    }
}
