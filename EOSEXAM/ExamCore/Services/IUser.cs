using ExamCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Services
{
    public interface IUser
    {
        IEnumerable<User> All { get; }
        User GetUser(int? Id);
        void Add(User _User);
        void Remove(int? Id);
        void Edit(User _User);
    }
}
