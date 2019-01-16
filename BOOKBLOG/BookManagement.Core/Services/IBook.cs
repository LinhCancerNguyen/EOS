using BookManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Core.Services
{
    public interface IBook
    {
        IEnumerable<Book> All { get; }
        Book GetBook(int? Id);
        void Add(Book _Book);
        void Remove(int? Id);
        void Edit(Book _Book);
    }
}
