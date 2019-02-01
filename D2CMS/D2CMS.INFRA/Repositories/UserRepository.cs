using Microsoft.EntityFrameworkCore;
using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public User GetByAccount(string Account)
        {
            var user = this.DbContext.Users.Where(u => u.Account == Account).FirstOrDefault();
            return user;
        }

        public User GetDetailById(int Id)
        {
            var user = this.DbContext.Users
                .Include(u => u.Department)
                .Include(u => u.Title)
                .Include(u => u.Role)
                .Include(u => u.EducationBackground)
                .Include(u => u.School)
                .Where(u => u.Id == Id).FirstOrDefault();
            return user;
        }
    }
    public interface IUserRepository : IRepository<User>
    {
        User GetByAccount(string Account);
        User GetDetailById(int Id);
    }
}
