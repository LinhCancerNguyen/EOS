using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        MyBlogEntity dbContext;

        public MyBlogEntity Init()
        {
            return dbContext ?? (dbContext = new DbContextFactory().CreateDbContext(null));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

    }
}
