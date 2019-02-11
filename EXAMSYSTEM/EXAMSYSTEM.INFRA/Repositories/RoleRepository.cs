using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXAMSYSTEM.INFRA.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IRoleRepository : IRepository<Role>
    {
    }
}
