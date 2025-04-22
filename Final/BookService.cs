using Final.DAL.Entities;
using Final.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book != null)
            {
                _bookRepository.DeleteBook(book);
            }
        }

        public void DeleteBookByTitle(string name)
        {
            var book = _bookRepository.GetBookByTitle(name);
            if (book != null)
            {
                _bookRepository.DeleteBook(book);
            }
        }
    }
}
