using D2CMS.INFRA.Entities;

namespace D2CMS.INFRA.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        D2CMSEntities dbContext;

        public D2CMSEntities Init()
        {
            return dbContext ?? (dbContext = new DesignTimeDbContextFactory().CreateDbContext(null));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
