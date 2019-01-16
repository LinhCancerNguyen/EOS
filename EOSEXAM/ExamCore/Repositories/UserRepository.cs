using ExamCore.Models;
using ExamCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Repositories
{
    public class UserRepository : IUser
    {
        public IEnumerable<User> All => throw new NotImplementedException();

        public void Add(User _User)
        {
            throw new NotImplementedException();
        }

        public void Edit(User _User)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
