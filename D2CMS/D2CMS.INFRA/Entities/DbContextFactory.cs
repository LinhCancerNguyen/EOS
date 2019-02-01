using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace D2CMS.INFRA.Entities
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<D2CMSEntities>
    {
        private static string ConnectionString => new DatabaseConfiguration().GetConnectionString();
        public D2CMSEntities CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<D2CMSEntities>();
            //optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.UseMySql(ConnectionString);
            return new D2CMSEntities(optionsBuilder.Options);
        }
    }
}
