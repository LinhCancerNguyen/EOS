using ExamCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Data
{
    public class ExamDB :DbContext
    {
        public ExamDB()
        {
        }

        public ExamDB(DbContextOptions<ExamDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<ResultDetail> ResultDetail { get; set; }
    }
}
