using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    // Singleton pattern to ensure single instance for connection string management
    internal class Connection
    {

        // Static read-only instance based on the Singleton pattern
        private static readonly Lazy<Connection> instance = new Lazy<Connection>(() => new Connection());

        // Property to access the single instance of Connection
        public static Connection Instance => instance.Value;

        // Private constructor to prevent direct instantiation
        private Connection()
        {
        }

        // Connection string retrieved from configuration settings
        private string connectionString = ConfigurationManager.ConnectionStrings["db_lms"].ConnectionString;

        // Public property to get the connection string
        public string ConnectionString => connectionString;
    }
}
