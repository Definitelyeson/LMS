using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Borrower
    {
        public int borrower_id { get; set; }
        public string Name { get; set; }
        public string SectionCourse { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime ReturnDate { get; set; }

        public int book_id { get; set; } // Book that the borrower has borrowed
        public int ProcessedBy { get; set; } // ID of the user who processed the borrowing
    }
}
