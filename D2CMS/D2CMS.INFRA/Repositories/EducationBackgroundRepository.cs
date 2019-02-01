using Microsoft.EntityFrameworkCore;
using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Repositories
{
    public class EducationBackgroundRepository : RepositoryBase<EducationBackground>, IEducationBackgroundRepository
    {
        public EducationBackgroundRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public EducationBackground GetByName(string name)
        {
            var  educationBackground = this.DbContext.EducationBackgrounds            
                .Where(u => u.Name == name).FirstOrDefault();
            return educationBackground;
        }
    }

    public interface IEducationBackgroundRepository : IRepository<EducationBackground>
    {
        EducationBackground GetByName(String name);
    }
}
