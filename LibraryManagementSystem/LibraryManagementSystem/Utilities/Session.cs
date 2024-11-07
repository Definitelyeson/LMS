using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using Newtonsoft.Json;

namespace LibraryManagementSystem.Utilities
{
    public static class Session
    {
        // Holds the current logged-in user information
        public static Users CurrentUser { get; private set; }

        // Indicates if a user is logged in based on the presence of CurrentUser
        public static bool IsLoggedIn => CurrentUser != null;

        // Login the user and save session data
        public static void Login(Users user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
            SessionFileManager.SaveSession(user); // Delegate session saving to utility class
        }

        // New method to check user role
        public static bool IsUserInRole(string role)
        {
            return IsLoggedIn && CurrentUser?.Position == role;
        }

        // Logout the current user and clear the session data
        public static void Logout()
        {
            CurrentUser = null;
            SessionFileManager.ClearSession(); // Delegate session clearing to utility class
        }

        // Load session data from storage
        public static void LoadSession()
        {
            CurrentUser = SessionFileManager.LoadUserSession(); // Delegate session loading to utility class
        }
    }

    // Utility class for handling session file operations
    public static class SessionFileManager
    {
        private const string SessionFilePath = "userSession.json"; // Path for storing session data

        // Save the current user session to a file
        public static void SaveSession(Users user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user)); // Ensure user is not null

            var sessionData = new
            {
                user.LibrarianId,
                user.Name,
                user.ContactNo,
                user.BirthDate,
                user.Username,
                user.Address,
                user.EmailAddress,
                user.Position,
                user.PhotoPath,
            };

            string json = JsonConvert.SerializeObject(sessionData); // Convert session data to JSON

            try
            {
                // Write session JSON to a file
                File.WriteAllText(SessionFilePath, json);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        // Load user session from a file
        public static Users LoadUserSession()
        {
            try
            {
                if (File.Exists(SessionFilePath))
                {
                    // Read JSON session data from file
                    string json = File.ReadAllText(SessionFilePath);
                    // Deserialize JSON to Users object
                    return JsonConvert.DeserializeObject<Users>(json);
                }
            }
            catch (FileNotFoundException ex)
            {
                LogException(ex);
            }
            catch (JsonException ex)
            {
                LogException(ex);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return null;
        }

        // Clear the session file
        public static void ClearSession()
        {
            try
            {
                if (File.Exists(SessionFilePath))
                {
                    // Delete the session file
                    File.Delete(SessionFilePath);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        // Log exceptions for troubleshooting
        private static void LogException(Exception ex)
        {
            // Implement a logging mechanism here
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
