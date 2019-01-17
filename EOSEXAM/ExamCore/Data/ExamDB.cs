using ExamCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Data
{
    public class ExamDB : DbContext
    {
        public ExamDB()
        {
        }

        public ExamDB(DbContextOptions<ExamDB> options) : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<ResultDetail> ResultDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired();
                entity.Property(e => e.SubjectId)
                    .IsRequired();
                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Subject_SubjectId");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.QuestionId)
                    .IsRequired();
                entity.Property(e => e.Content)
                    .IsRequired();
                entity.Property(e => e.IsRight)
                    .IsRequired().HasColumnType("bit");
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Option_Question_QuestionId");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.SubjectId)
                    .IsRequired();
                entity.Property(e => e.UserId)
                    .IsRequired();
                entity.Property(e => e.Mark)
                    .IsRequired().HasColumnType("float");
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Result_User_UserId");
                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_User_UserId");
            });

            modelBuilder.Entity<ResultDetail>(entity =>
            {
                entity.Property(e => e.ResultId)
                    .IsRequired();
                entity.Property(e => e.QuestionId)
                    .IsRequired();
                entity.Property(e => e.IsRight)
                    .IsRequired().HasColumnType("bit");
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.ResultDetails)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultDetail_Question_QuestionId");
                entity.HasOne(d => d.Result)
                    .WithMany(p => p.ResultDetails)
                    .HasForeignKey(d => d.ResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultDetail_Result_ResultId");
            });

        }
    }
}
