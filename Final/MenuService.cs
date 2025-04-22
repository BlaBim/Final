using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class MenuService
    {
        private readonly UserService _userService = new();
        private readonly BookService _bookService = new();
        private readonly LoanService _loanService = new();
        private readonly BookRatingService _ratingService = new();

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Show all Users");
                Console.WriteLine("2. Show all loans");
                Console.WriteLine("3. Show all books");
                //Console.WriteLine("4. Показати активних користувачів");
                //Console.WriteLine("5. Поставити оцінку книзі");
                Console.WriteLine("6. Exit");

                Console.Write("Chose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var users = _userService.GetAllUsersWithLoans();
                        foreach (var user in users)
                        {
                            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Loan count: {user.Loans.Count}");
                        }
                        break;
                    case "2":
                        var loans = _loanService.GetAllLoans();
                        foreach (var loan in loans)
                        {
                            Console.WriteLine($"Loan ID: {loan.Id}, User ID: {loan.UserId}, User name: {loan.UserName}, Book Id: {loan.BookId}, Book name:{loan.BookName}, Loan Date: {loan.LoanDate}");
                        }
                        break;
                    case "3":
                        var loans = _loanService.GetAllLoans();
                        foreach (var loan in loans)
                        {
                            Console.WriteLine($"Loan ID: {loan.Id}, User ID: {loan.UserId}, User name: {loan.UserName}, Book Id: {loan.BookId}, Book name:{loan.BookName}, ");
                        }
                        break;
                        break;
                    //case "4":
                    //    ShowActiveUsers();
                    //    break;
                    //case "5":
                    //    RateBook();
                    //    break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        //private void IssueBook()
        //{
        //    int userId = AskInt("ID користувача:");
        //    int bookId = AskInt("ID книги:");
        //    _loanService.AddLoan(userId, bookId);
        //    Console.WriteLine("Книгу видано.");
        //}

        //private void ReturnBook()
        //{
        //    int userId = AskInt("ID користувача:");
        //    int bookId = AskInt("ID книги:");
        //    _loanService.ReturnBook(userId, bookId);
        //    Console.WriteLine("Книгу повернено.");
        //}

        //private void ShowOverdues()
        //{
        //    var overdueLoans = _loanService.GetOverdueLoans();
        //    foreach (var loan in overdueLoans)
        //    {
        //        Console.WriteLine($"Користувач: {loan.UserName.Name}, Книга: {loan.BookName.Title}, Взято: {loan.LoanDate}");
        //    }
        //}

        //private void ShowActiveUsers()
        //{
        //    var users = _userService.GetActiveUsers();
        //    foreach (var user in users)
        //    {
        //        Console.WriteLine($"Користувач: {user.Name}, Позик: {user.Loans.Count}");
        //    }
        //}

        //private void RateBook()
        //{
        //    int userId = AskInt("ID користувача:");
        //    int bookId = AskInt("ID книги:");
        //    int rating = AskInt("Оцінка (1-5):");
        //    _ratingService.RateBook(userId, bookId, rating);
        //    Console.WriteLine("Оцінку збережено.");
        //}

        //private int AskInt(string message)
        //{
        //    Console.Write(message + " ");
        //    return int.TryParse(Console.ReadLine(), out int result) ? result : 0;
        //}
    }
}
