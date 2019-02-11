using Microsoft.EntityFrameworkCore;
using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EXAMSYSTEM.CORE.ModelViews;

namespace EXAMSYSTEM.INFRA.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public User Login(string Username, string Password)
        {
            var user = (from u in this.DbContext.Users
                        join r in this.DbContext.Roles
                        on u.RoleId equals r.RoleId
                        where u.Username == Username && u.Password == Password
                        select new User
                        {
                            Username = u.Username,
                            Password = u.Password,
                            Email = u.Email,
                            RoleId = r.RoleId,
                            Role = r
                        })
                       .FirstOrDefault();
            return user;
        }

        public User GetDetailById(int Id)
        {
            var user = (from u in this.DbContext.Users
                        join r in this.DbContext.Roles
                        on u.RoleId equals r.RoleId
                        where u.UserId == Id
                        select new User {
                            UserId = u.UserId,
                            Username = u.Username,
                            Email = u.Email,
                            Password = u.Password,
                            RoleId = r.RoleId,
                            Role = r
                        }).FirstOrDefault();
            return user;
        }

        public IEnumerable<UserView> GetUsers()
        {
            var users = (from u in this.DbContext.Users
                        join r in this.DbContext.Roles
                        on u.RoleId equals r.RoleId
                        select new UserView
                        {
                            UserId = u.UserId,
                            Username = u.Username,
                            Email = u.Email,
                            Password = u.Password,
                            Role = r.RoleName
                        }).ToList();

            return users;
        }
    }
    public interface IUserRepository : IRepository<User>
    {
        User Login(string Username, string Password);
        User GetDetailById(int Id);
        IEnumerable<UserView> GetUsers();
    }
}
