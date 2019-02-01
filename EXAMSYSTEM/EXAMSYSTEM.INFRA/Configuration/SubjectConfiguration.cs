using EXAMSYSTEM.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");

            builder.HasKey(s => s.SubjectId);
            builder.Property(s => s.SubjectName).HasMaxLength(50).IsRequired();
            builder.Property(s => s.SubjectCode).HasMaxLength(10).IsUnicode().IsRequired();
        }
    }
}
