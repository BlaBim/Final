using Final.DAL.Entities;
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
                Console.WriteLine("2. Show all Loans");
                Console.WriteLine("3. Show all Books");
                Console.WriteLine("4. *Show Expired loans");
                Console.WriteLine("5. Return Book");
                Console.WriteLine("6. Add User");
                Console.WriteLine("7. Add Book");                
                Console.WriteLine("8. Add Loan");
                Console.WriteLine("9. Delete User by id");
                Console.WriteLine("10. Delete User by name");
                Console.WriteLine("11. Delete Book by id");
                Console.WriteLine("12. Delete Book by title");
                Console.WriteLine("13. Delete Loan");
                Console.WriteLine("14. Show all Ratings");
                Console.WriteLine("15. Add Rating");
                Console.WriteLine("16. Delete Rating");
                Console.WriteLine("17. Show Ratings by Book");
                Console.WriteLine("18. *Show Average rating by Book");
                Console.WriteLine("19. Show Ratings by User");
                Console.WriteLine("0. Exit");

                Console.Write("Chose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        var users = _userService.GetAllUsersWithLoans();
                        foreach (var user in users)
                        {
                            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Loan count: {user.Loans.Count}");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "2":
                        Console.Clear();
                        var loans = _loanService.GetAllLoans();
                        foreach (var loan in loans)
                        {
                            Console.WriteLine($"Loan ID: {loan.Id}, User ID: {loan.UserId}, User name: {loan.UserName.Name}, Book Id: {loan.BookId}, Book name:{loan.BookName.Title}, Loan Date: {loan.LoanDate}, Return Date: {loan.ReturnDate}");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "3":
                        Console.Clear();
                        var books = _bookService.GetAllBooks();
                        foreach (var book in books)
                        {
                            Console.WriteLine($"Book ID: {book.Id}, Book Title: {book.Title}");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "4":
                        Console.Clear();
                        var ExpLoans = _loanService.GetAllExpiredLoans();
                        foreach (var loan in ExpLoans)
                        {
                            Console.WriteLine($"User name: {loan.UserName}, Book name: {loan.BookName}, Loan date: {loan.LoanDate}");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "5":
                        Console.Clear();
                        int userId = ConsoleEnterInt("User ID:");
                        int bookId = ConsoleEnterInt("Book ID:");
                        _loanService.ReturnBook(userId, bookId);
                        Console.WriteLine("Book has been returned");
                        Console.WriteLine("\n");
                        break;
                    case "6":
                        Console.Clear();
                        string name = ConsoleEnter("Enter User name: ");

                        var newUser = new User
                        {
                            Name = name
                        };
                        _userService.AddUser(newUser);
                        Console.WriteLine("User added");
                        Console.WriteLine("\n");
                        break;
                    case "7":
                        Console.Clear();
                        string BookName = ConsoleEnter("Enter Book name: ");

                        var newBook = new Book
                        {
                            Title = BookName
                        };
                        _bookService.AddBook(newBook);
                        Console.WriteLine("Book added");
                        Console.WriteLine("\n");
                        break;
                    case "8":
                        Console.Clear();
                        int LoanUserId = ConsoleEnterInt("Enter User id: ");
                        int LoanBookId = ConsoleEnterInt("Enter Book id: ");

                        _loanService.AddLoan(LoanUserId, LoanBookId);
                        Console.WriteLine("Loan added");
                        Console.WriteLine("\n");
                        break;
                    case "9":
                        Console.Clear();
                        int userIdDel = ConsoleEnterInt("Enter user id: ");

                        _userService.DeleteUser(userIdDel);
                        Console.WriteLine("User deleted");
                        Console.WriteLine("\n");
                        break;
                    case "10":
                        Console.Clear();
                        string userNameDel = ConsoleEnter("Enter user name: ");

                        _userService.DeleteUserByName(userNameDel);
                        Console.WriteLine("User deleted");
                        Console.WriteLine("\n");
                        break;
                    case "11":
                        Console.Clear();
                        int bookIdDel = ConsoleEnterInt("Enter book id: ");

                        _bookService.DeleteBook(bookIdDel);
                        Console.WriteLine("Book deleted");
                        Console.WriteLine("\n");
                        break;
                    case "12":
                        Console.Clear();
                        string bookNameDel = ConsoleEnter("Enter book title: ");

                        _bookService.DeleteBookByTitle(bookNameDel);
                        Console.WriteLine("Book deleted");
                        Console.WriteLine("\n");
                        break;
                    case "13":
                        Console.Clear();
                        int LoanUserIdDel = ConsoleEnterInt("Enter User id: ");
                        int LoanBookIdDel = ConsoleEnterInt("Enter Book id: ");

                        _loanService.DeleteLoan(LoanUserIdDel, LoanBookIdDel);
                        Console.WriteLine("Loan Deleted");
                        Console.WriteLine("\n");
                        break;
                    case "14":
                        Console.Clear();
                        var ratings = _ratingService.GetAllRatings();
                        foreach (var rating in ratings)
                        {
                            Console.WriteLine($"Rating ID: {rating.Id}, User ID: {rating.UserId}, User name: {rating.UserName.Name}, Book Id: {rating.BookId}, Book name: {rating.BookName.Title}, Rating: {rating.Rating}");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "15":
                        Console.Clear();
                        int UserId = ConsoleEnterInt("Enter User Id: ");
                        int BookId = ConsoleEnterInt("Enter Book Id: ");
                        int Rating = ConsoleEnterInt("Enter Book rating 1-5 Id: ");

                        _ratingService.AddRating(BookId, UserId, Rating);
                        Console.WriteLine("Rating added");
                        Console.WriteLine("\n");
                        break;
                    case "16":
                        Console.Clear();
                        int UserIdDel = ConsoleEnterInt("Enter User Id: ");

                        _ratingService.DeleteRatingById(UserIdDel);
                        Console.WriteLine("Rating deleted");
                        Console.WriteLine("\n");
                        break;
                    case "17":
                        Console.Clear();
                        int bookid = ConsoleEnterInt("Enter Book Id: ");

                        var BookRatings = _ratingService.GetRatingsByBookId(bookid);
                        foreach (var rating in BookRatings)
                        {
                            Console.WriteLine($"User name: {rating.UserName.Name}, Rating: {rating.Rating}");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "18":
                        Console.Clear();
                        int bookAvg = ConsoleEnterInt("Enter Book Id: ");
                        Console.WriteLine($"Avg rating: {_ratingService.GetAverageRating(bookAvg)}");
                        Console.WriteLine("\n");
                        break;
                    case "19":
                        Console.Clear();
                        int userid = ConsoleEnterInt("Enter user Id: ");

                        var UserRatings = _ratingService.GetRatingsByUserId(userid);
                        foreach (var rating in UserRatings)
                        {
                            Console.WriteLine($"Book title: {rating.BookName.Title}, Rating: {rating.Rating}");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Error choise");
                        break;
                }
            }
        }
        private string ConsoleEnter(string Text)
        {
            Console.Write($"{Text}");
            string value = Console.ReadLine();
            return value;
        }
        private int ConsoleEnterInt(string Text)
        {
            Console.Write($"{Text}");
            string value = Console.ReadLine();
            int.TryParse(value, out int result);
            return result;
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
