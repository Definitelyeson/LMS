using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Books
    {
        public int book_id { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string BookPublisher { get; set; }
        public int YearPublished { get; set; }
        public string Category { get; set; }
        public string BookSummary { get; set; }  
        public string BookType { get; set; }     

        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        public int BorrowedQuantity { get; set; } // To track how many are currently borrowed


        //public bool IsAvailable => Quantity > BorrowedQuantity;
        public bool IsAvailable => Quantity > BorrowedQuantity;


        public bool IsArchived { get; set; } // New property for archived status
    }
}
