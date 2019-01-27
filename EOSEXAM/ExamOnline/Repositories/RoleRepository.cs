using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Data;
using ExamOnline.Models;
using ExamOnline.Services;

namespace ExamOnline.Repositories
{
    public class RoleRepository : IRole
    {
        private ExamDBContext Db = null;

        public RoleRepository(ExamDBContext _Db)
        {
            Db = _Db;
        }
        public IEnumerable<Role> All => Db.Role;
    }
}
