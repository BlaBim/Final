using Final.DAL.Entities;
using Final.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class BookRatingService
    {
        private readonly BookRatingRepository _bookRatingRepository;
        private readonly UserRepository _userRepository;
        private readonly BookRepository _bookRepository;

        public BookRatingService()
        {
            _bookRatingRepository = new BookRatingRepository();
            _userRepository = new UserRepository();
            _bookRepository = new BookRepository();
        }
        public IEnumerable<BookRating> GetAllRatings()
        {
            return _bookRatingRepository.GetAllRatings();
        }
        public IEnumerable<BookRating> GetRatingsByUserId(int userId)
        {
            return _bookRatingRepository.GetRatingsByUserId(userId);
        }

        public IEnumerable<BookRating> GetRatingsByBookId(int bookId)
        {
            return _bookRatingRepository.GetRatingsByBookId(bookId);
        }

        public BookRating GetRatingBy2Id(int userId, int bookId)
        {
            return _bookRatingRepository.GetRatingBy2Id(userId, bookId);
        }
        public BookRating GetRatingById(int ratingId)
        {
            return _bookRatingRepository.GetRatingById(ratingId);
        }
        public void AddRating(int bookId, int userId, int rating)
        {
            var book = _bookRepository.GetBookById(bookId);
            var user = _userRepository.GetUserById(bookId);

            if (book != null && user != null)
            {
                var bookRating = new BookRating
                {
                    BookId = bookId,
                    UserId = userId,
                    Rating = rating
                };

                _bookRatingRepository.AddRating(bookRating);
            }
        }

        public void DeleteRatingBy2Ids(int bookId, int userId)
        {
            var book = _bookRatingRepository.GetRatingBy2Id(bookId, userId);

            if (book != null)
            {
                _bookRatingRepository.DeleteRating(book);
            }
        }
        public void DeleteRatingById(int ratingId)
        {
            var book = _bookRatingRepository.GetRatingById(ratingId);

            if (book != null)
            {
                _bookRatingRepository.DeleteRating(book);
            }
        }

        public double GetAverageRating(int bookId)
        {
            var ratings = _bookRatingRepository.GetRatingsByBookId(bookId);
            return ratings.Any() ? ratings.Average(r => r.Rating) : 0;
        }
    }
}
