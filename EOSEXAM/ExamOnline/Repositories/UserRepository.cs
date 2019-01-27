using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Data;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class UserRepository : IUser
    {
        private ExamDBContext Db = null;

        public UserRepository(ExamDBContext _Db)
        {
            Db = _Db;
        }
        public IEnumerable<User> GetAll() {
            var users = from u in Db.User
                        join r in Db.Role
                        on u.RoleId equals r.RoleId
                        select new User
                        {
                            UserId = u.UserId,
                            UserName = u.UserName,
                            Password = u.Password,
                            RoleId = r.RoleId,
                            Role = r
                        };
            return users.ToList();
        }

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
            var user = from u in Db.User
                       join r in Db.Role
                       on u.RoleId equals r.RoleId
                       where u.UserId == Id
                       select new User
                       {
                           UserId = u.UserId,
                           UserName = u.UserName,
                           Password = u.Password,
                           RoleId = r.RoleId,
                           Role = r
                       };
            return user.First();
        }

        public void Remove(int? Id)
        {
            Db.User.Remove(Db.User.Find(Id));
            Db.SaveChanges();
        }

        public User Login(string Username, string Password)
        {
            var user = from u in Db.User
                       join r in Db.Role
                       on u.RoleId equals r.RoleId
                       where u.UserName.Equals(Username) & u.Password.Equals(Password)
                       select new User
                       {
                           UserId = u.UserId,
                           UserName = u.UserName,
                           Password = u.Password,
                           RoleId = r.RoleId,
                           Role = r
                       };
            return user.FirstOrDefault();
        }
    }
}
