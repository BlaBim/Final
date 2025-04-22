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
        private readonly BookRepository _bookRepository;

        public BookRatingService()
        {
            _bookRatingRepository = new BookRatingRepository();
            _bookRepository = new BookRepository();
        }

        public void AddRating(int bookId, int rating)
        {
            var book = _bookRepository.GetBookById(bookId);

            if (book != null)
            {
                var bookRating = new BookRating
                {
                    BookId = bookId,
                    Rating = rating
                };

                _bookRatingRepository.AddRating(bookRating);
            }
        }

        //public double GetAverageRating(int bookId)
        //{
        //    var ratings = _bookRatingRepository.GetRatingsById(bookId);
        //    return ratings.Any() ? ratings.Average(r => r.Rating) : 0;
        //}
    }
}
