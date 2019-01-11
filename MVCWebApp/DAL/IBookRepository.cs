using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWebApp.Models;

namespace MVCWebApp.DAL
{
    interface IBookRepository : IDisposable
    {
        IEnumerable<Books> GetBooks();
        Books GetBookByID(int bookId);
        void InsertBook(Books book);
        void DeleteBook(int bookID);
        void UpdateBook(Books book);
        void Save();
    }
}
