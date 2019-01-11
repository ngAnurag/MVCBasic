using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCWebApp.Models;

namespace MVCWebApp.DAL
{
    public class BookRepository : IBookRepository
    {
        private BookContext _context;
        public BookRepository(BookContext bookContext)
        {
            this._context = bookContext;
        }
        public IEnumerable<Books> GetBooks()
        {
            return _context.Books.ToList();
        }
        public Books GetBookByID(int id)
        {
            return _context.Books.Find(id);
        }
        public void InsertBook(Books book)
        {
            _context.Books.Add(book);
        }
        public void DeleteBook(int bookID)
        {
            Books book = _context.Books.Find(bookID);
            _context.Books.Remove(book);
        }
        public void UpdateBook(Books book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}