using ExamCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Services
{
    public interface IAdmin
    {
        IEnumerable<Admin> All { get; }
        Admin GetAdmin(string username, string password);
        void Add(Admin _Admin);
        void Remove(int? Id);
        void Edit(Admin _Admin);
    }
}
