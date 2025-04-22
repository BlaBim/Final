using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Entities
{
    public class Loan
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User UserName { get; set; }

        public int BookId { get; set; }
        public Book BookName { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
