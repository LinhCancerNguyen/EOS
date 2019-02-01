using Microsoft.EntityFrameworkCore;
using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory) : base(dbFactory) { }
        public Department GetByCode(string Code)
        {
            var department = this.DbContext.Departments
                .Where(u => u.Code == Code).FirstOrDefault();
            return department;
        }
        public Department GetByName(string Name)
        {
            var department = this.DbContext.Departments
                .Where(u => u.Name == Name).FirstOrDefault();
            return department;
        }
    }

    public interface IDepartmentRepository : IRepository<Department>
    {
        Department GetByCode(string Code);
        Department GetByName(string Name);
    }
}
