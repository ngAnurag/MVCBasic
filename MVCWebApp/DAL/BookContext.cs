using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCWebApp.Models;

namespace MVCWebApp.DAL
{
    public class BookContext: DbContext
    {
        public BookContext()
            : base("name=BookStoreConnectionString")
        {
        }
        public DbSet<Books> Books { get; set; }
    }
}