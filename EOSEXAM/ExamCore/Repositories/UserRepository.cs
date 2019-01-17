using ExamCore.Data;
using ExamCore.Models;
using ExamCore.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Repositories
{
    public class UserRepository : IUser
    {
        private ExamDB Db = null;

        public UserRepository(ExamDB _Db)
        {
            Db = _Db;
        }

        public IEnumerable<User> All => Db.User;

        public void Add(User _User)
        {
            Db.User.Add(_User);
            Db.SaveChanges();
        }

        public void Edit(User _User)
        {
            Db.Entry(_User).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public User GetUser(int? Id)
        {
            return Db.User.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.User.Remove(Db.User.Find(Id));
            Db.SaveChanges();
        }
    }
}
