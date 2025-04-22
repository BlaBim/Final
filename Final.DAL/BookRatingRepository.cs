using Final.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL
{
    public class BookRatingRepository
    {
        private readonly AppDbContext _context;

        public BookRatingRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<BookRating> GetAllRatings()
        {
            return _context.BookRatings
                .Include(r => r.BookName)
                .Include(r => r.UserName)
                .ToList();
        }

        public BookRating GetRatingById(int id)
        {
            return _context.BookRatings
                .Include(r => r.BookName)
                .Include(r => r.UserName)
                .FirstOrDefault(r => r.Id == id);
        }

        public void AddRating(BookRating rating)
        {
            _context.BookRatings.Add(rating);
            _context.SaveChanges();
        }

        public void UpdateRating(BookRating rating)
        {
            _context.BookRatings.Update(rating);
            _context.SaveChanges();
        }

        public void DeleteRatingById(int id)
        {
            var rating = GetRatingById(id);
            if (rating != null)
            {
                _context.BookRatings.Remove(rating);
                _context.SaveChanges();
            }
        }

        public void DeleteAllRatings()
        {
            var ratings = GetAllRatings();
            _context.BookRatings.RemoveRange(ratings);
            _context.SaveChanges();
        }
    }
}
