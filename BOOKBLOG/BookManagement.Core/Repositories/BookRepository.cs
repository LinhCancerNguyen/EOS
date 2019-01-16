using BookManagement.Core.Data;
using BookManagement.Core.Models;
using BookManagement.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Core.Repositories
{
    public class BookRepository : IBook
    {
        private BookDBContext Db;

        public BookRepository(BookDBContext _Db)
        {
            Db = _Db;
        }
        public IEnumerable<Book> All => Db.Book;

        public void Add(Book _Book)
        {
            Db.Book.Add(_Book);
            Db.SaveChanges();
        }

        public void Edit(Book _Book)
        {
            Db.Entry(_Book).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Book GetBook(int? Id)
        {
            return Db.Book.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.Book.Remove(Db.Book.Find(Id));
            Db.SaveChanges();
        }
    }
}
