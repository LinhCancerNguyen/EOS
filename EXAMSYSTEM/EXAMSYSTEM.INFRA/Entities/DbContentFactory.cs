using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Entities
{
    public class DbContentFactory : IDesignTimeDbContextFactory<ExamSystemEntities>
    {
        private static string ConnectionString => new DatabaseConfiguration().GetConnectionString();
        public ExamSystemEntities CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExamSystemEntities>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new ExamSystemEntities(optionsBuilder.Options);
        }
    }
}
