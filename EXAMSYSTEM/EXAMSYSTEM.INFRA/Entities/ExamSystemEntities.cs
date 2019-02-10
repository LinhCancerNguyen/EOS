using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Entities
{
    public class ExamSystemEntities : DbContext
    {
        public ExamSystemEntities(DbContextOptions<ExamSystemEntities> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<Question> Questions { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        //Configuaration for code first
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Master Table Config
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserExamConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            //Seed
            ExamSystemSeedEntities.Run(modelBuilder);
        }
    }
}
