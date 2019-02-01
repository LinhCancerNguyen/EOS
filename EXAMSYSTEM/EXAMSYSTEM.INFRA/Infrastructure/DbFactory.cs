using EXAMSYSTEM.INFRA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ExamSystemEntities dbContext;

        public ExamSystemEntities Init()
        {
            return dbContext ?? (dbContext = new DbContentFactory().CreateDbContext(null));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
