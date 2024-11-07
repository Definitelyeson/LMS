using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Users
    {

        public int LibrarianId { get; set; }             // Auto-increment primary key
        public string Name { get; set; }                 // Name of the librarian
        public DateTime? BirthDate { get; set; }          // Birthdate
        public string Address { get; set; }              // Address
        public string ContactNo { get; set; }            // Contact number
        public string EmailAddress { get; set; }         // Email
        public string Position { get; set; }             // Job Position (e.g., Senior Librarian)
        public string Username { get; set; }             // Username for login
        public string Password { get; set; }         // Hashed password (use bcrypt for this)
        public string PhotoPath { get; set; }            // Path to the profile photo
        public DateTime CreatedAt { get; set; } = DateTime.Now;   // Automatically set the date of creation

    }
}
