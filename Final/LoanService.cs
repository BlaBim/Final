using Final.DAL.Entities;
using Final.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class LoanService
    {
        private readonly LoanRepository _loanRepository;
        private readonly UserRepository _userRepository;
        private readonly BookRepository _bookRepository;

        public LoanService()
        {
            _loanRepository = new LoanRepository();
            _userRepository = new UserRepository();
            _bookRepository = new BookRepository();
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return _loanRepository.GetAllLoans();
        }
        public IEnumerable<Loan> GetAllExpiredLoans()
        {
            return _loanRepository.GetAllExpiredLoans(DateTime.Now);
        }
        public void AddLoan(int userId, int bookId)
        {
            var user = _userRepository.GetUserById(userId);
            var book = _bookRepository.GetBookById(bookId);

            if (user != null && book != null)
            {
                var loan = new Loan
                {
                    UserId = userId,
                    BookId = bookId,
                    LoanDate = DateTime.Now
                };

                _loanRepository.AddLoan(loan);
            }
        }

        public void ReturnBook(int userId, int bookId)
        {
            var loan = _loanRepository.GetLoanByUserIdAndBookId(userId, bookId);
            if (loan != null)
            {
                loan.ReturnDate = DateTime.Now;
                _loanRepository.UpdateLoan(loan);
            }
        }

        public void DeleteLoan(int userId, int bookId)
        {
            var loan = _loanRepository.GetLoanByUserIdAndBookId(userId, bookId);
            if (loan != null)
            {
                _loanRepository.DeleteLoan(loan);
            }
        }
    }
}
