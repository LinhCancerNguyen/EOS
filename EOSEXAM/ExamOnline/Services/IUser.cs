using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Models;

namespace ExamOnline.Services
{
    public interface IUser
    {
        IEnumerable<User> GetAll();
        User GetUser(int? Id);
        void Add(User _User);
        void Remove(int? Id);
        void Edit(User _User);
        User Login(string Username, String Password);
    }
}
