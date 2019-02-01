using Microsoft.EntityFrameworkCore;
using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Role GetByName(string name)
        {
            var role = this.DbContext.Roles.Where(u => u.Name == name).FirstOrDefault();
            return role;
        }
    }

    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByName(string name);
    }
}
