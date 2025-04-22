using Final.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL
{
    public class BookRepository
    {
    private readonly AppDbContext _context;

    public BookRepository()
    {
        _context = new AppDbContext();
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _context.Books;
    }

    public Book GetBookById(int id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public Book GetBookByTitle(string title)
    {
        return _context.Books.FirstOrDefault(b => b.Title == title);
    }

    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void UpdateBook(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }

    public void DeleteBook(Book book)
    {
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    public void DeleteBookById(int id)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    public void DeleteBookByTitle(string title)
    {
        var book = GetBookByTitle(title);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    public void DeleteAllBooks()
    {
        var books = GetAllBooks();
        _context.Books.RemoveRange(books);
        _context.SaveChanges();
    }
}

}
