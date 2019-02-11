using EXAMSYSTEM.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EXAMSYSTEM.INFRA.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");
            builder.HasKey(q => q.QuestionId);
            builder.Property(q => q.QuestionContent).IsRequired();
            builder.Property(q => q.Option1).IsRequired();
            builder.Property(q => q.Option2).IsRequired();
            builder.Property(q => q.Option3);
            builder.Property(q => q.Option4);
            builder.Property(q => q.Answer).IsRequired();
            builder.HasOne(q => q.Subject)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.SubjectId)
                .IsRequired();
        }
    }
}
