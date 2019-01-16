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
        public IEnumerable<Admin> All => throw new NotImplementedException();

        public void Add(Admin _Admin)
        {
            throw new NotImplementedException();
        }

        public void Edit(Admin _Admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdmin(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
