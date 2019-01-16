using BookManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Core.Services
{
    public interface IAuthor
    {
        IEnumerable<Author> All { get; }
        Author GetAuthor(int? Id);
        void Add(Author _Author);
        void Remove(int? Id);
        void Edit(Author _Author);
    }
}
