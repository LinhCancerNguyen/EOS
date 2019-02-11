using EXAMSYSTEM.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Configuration
{
    public class UserExamConfiguration : IEntityTypeConfiguration<UserExam>
    {
        public void Configure(EntityTypeBuilder<UserExam> builder)
        {
            builder.ToTable("UserExam");

            builder.HasKey(u => u.UserExamId);
            builder.Property(u => u.Score).IsRequired();

            builder.HasOne(u => u.User)
                .WithMany(u => u.UserExams)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
            builder.HasOne(u => u.Subject)
                .WithMany(u => u.UserExams)
                .HasForeignKey(u => u.SubjectId)
                .IsRequired();
        }
    }
}
