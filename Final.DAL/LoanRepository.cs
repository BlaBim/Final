using Final.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL
{
    public class LoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return _context.Loans
                .Include(l => l.BookName)
                .Include(l => l.UserName)
                .ToList();
        }
        public IEnumerable<Loan> GetAllExpiredLoans(DateTime currentDate)
        {
            //var overdueDate = DateTime.Now.AddDays(-30);
            return _context.Loans
                .Where(l => l.ReturnDate == null) 
                .AsEnumerable()
                .Where(l => (currentDate - l.LoanDate).TotalDays > 30) 
                .ToList(); 
        }
        public Loan GetLoanById(int id)
        {
            return _context.Loans
                .Include(l => l.BookName)
                .Include(l => l.UserName)
                .FirstOrDefault(l => l.Id == id);
        }
        public Loan GetLoanByUserIdAndBookId(int userId, int bookId)
        {
            return _context.Loans
                .Include(l => l.BookName)
                .Include(l => l.UserName)
                .FirstOrDefault(l => l.UserId == userId && l.BookId == bookId);
        }

        public void AddLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void UpdateLoan(Loan loan)
        {
            _context.Loans.Update(loan);
            _context.SaveChanges();
        }

        public void DeleteLoanById(int id)
        {
            var loan = GetLoanById(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
        }

        public void DeleteAllLoans()
        {
            var loans = GetAllLoans();
            _context.Loans.RemoveRange(loans);
            _context.SaveChanges();
        }
        public void DeleteLoan(Loan loan)
        {
            _context.Loans.Remove(loan);
            _context.SaveChanges();
        }
    }
}
