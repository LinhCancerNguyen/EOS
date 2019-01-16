using BookManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Core.Services
{
    public interface IGenre
    {
        IEnumerable<Genre> All { get; }
        Genre GetGenre(int? Id);
        void Add(Genre _Genre);
        void Remove(int? Id);
        void Edit(Genre _Genre);
    }
}
