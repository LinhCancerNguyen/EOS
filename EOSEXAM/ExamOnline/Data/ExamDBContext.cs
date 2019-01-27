using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Data
{
    public class ExamDBContext : DbContext
    {
        public ExamDBContext()
        {
        }

        public ExamDBContext(DbContextOptions<ExamDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
    }
}
