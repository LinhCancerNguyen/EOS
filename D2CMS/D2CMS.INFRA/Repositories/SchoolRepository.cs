using Microsoft.EntityFrameworkCore;
using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Repositories
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public School GetByName(string Name)
        {
            var School = this.DbContext.Schools.Where(s => s.Name == Name).FirstOrDefault();
            return School;
        }
    }

    public interface ISchoolRepository : IRepository<School>
    {
        School GetByName(string Name);
    }
}
