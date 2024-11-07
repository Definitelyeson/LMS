using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Transaction
    {
        public string BorrowerId { get; set; }
        public string BorrowerName { get; set; }
        public string BookTitle { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }
        public string Address { get; set; }
        public string Author { get; set; }
        public string ContactDetails { get; set; }
        public string Email { get; set; }
        public string SectionCourse { get; set; }
        public string LibrarianName { get; set; }

        public decimal Penalty { get; set; }
    }
}
