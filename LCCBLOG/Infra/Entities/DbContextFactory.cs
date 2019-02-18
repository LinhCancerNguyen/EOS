using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Entities
{
    public class DbContextFactory : IDesignTimeDbContextFactory<MyBlogEntity>
    {
        private static string ConnectionString => new DatabaseConfiguration().GetConnectionString();
        public MyBlogEntity CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyBlogEntity>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new MyBlogEntity(optionsBuilder.Options);
        }
    }
}
