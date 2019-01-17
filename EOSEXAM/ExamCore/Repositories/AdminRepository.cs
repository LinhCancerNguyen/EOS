using ExamCore.Data;
using ExamCore.Models;
using ExamCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Repositories
{
    public class AdminRepository : IAdmin
    {
        private ExamDB Db = null;

        public AdminRepository(ExamDB _Db)
        {
            Db = _Db;
        }

        public IEnumerable<Admin> All => Db.Admin;

        public void Add(Admin _Admin)
        {
            throw new NotImplementedException();
        }

        public void Edit(Admin _Admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdmin(string username, string password)
        {
            var admin = Db.Admin
                .Where(a => a.Username.Equals(username) && a.Password.Equals(password))
                .SingleOrDefault();           
            return admin;
        }

        public void Remove(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
