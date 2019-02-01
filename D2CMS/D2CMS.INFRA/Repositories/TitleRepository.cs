using Microsoft.EntityFrameworkCore;
using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Repositories
{
    public class TitleRepository : RepositoryBase<Title>, ITitleRepository
    {
        public TitleRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Title GetByCode(string Code)
        {
            var Title = this.DbContext.Titles.Where(t => t.Code == Code).FirstOrDefault();
            return Title;
        }
    }

    public interface ITitleRepository : IRepository<Title>
    {
        Title GetByCode(string Code);
    }
}
