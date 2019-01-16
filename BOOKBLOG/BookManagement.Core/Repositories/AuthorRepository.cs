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
    public class AuthorRepository : IAuthor
    {
        private BookDBContext Db;

        public AuthorRepository(BookDBContext _Db)
        {
            Db = _Db;
        }
        public IEnumerable<Author> All => Db.Author;

        public void Add(Author _Author)
        {
            Db.Author.Add(_Author);
            Db.SaveChanges();
        }

        public void Edit(Author _Author)
        {
            Db.Entry(_Author).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Author GetAuthor(int? Id)
        {
            return Db.Author.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.Author.Remove(Db.Author.Find(Id));
            Db.SaveChanges();
        }
    }
}
