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
    public class GenreRepository : IGenre
    {
        private BookDBContext Db;
        public GenreRepository(BookDBContext _Db)
        {
            Db = _Db;
        }

        public IEnumerable<Genre> All => Db.Genre;

        public void Add(Genre _Genre)
        {
            Db.Genre.Add(_Genre);
            Db.SaveChanges();
        }

        public void Edit(Genre _Genre)
        {
            Db.Entry(_Genre).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Genre GetGenre(int? Id)
        {
            return Db.Genre.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.Genre.Remove(Db.Genre.Find(Id));
            Db.SaveChanges();
        }
    }
}
