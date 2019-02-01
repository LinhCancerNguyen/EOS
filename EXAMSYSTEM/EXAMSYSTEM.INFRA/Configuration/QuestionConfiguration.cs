using EXAMSYSTEM.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");
            builder.HasKey(q => q.QuestionId);
            builder.Property(q => q.QuestionContent).IsRequired();
            builder.Property(q => q.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(q => q.ModifiedDate).HasDefaultValue(DateTime.Now);

            builder.HasOne(q => q.Subject)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.SubjectId)
                .IsRequired();
        }
    }
}
