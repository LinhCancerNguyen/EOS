using EXAMSYSTEM.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Configuration
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Option");

            builder.HasKey(o => o.OptionId);
            builder.Property(o => o.OptionConent).IsRequired();
            builder.Property(o => o.IsCorrect).IsRequired();
            builder.Property(o => o.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(o => o.ModifiedDate).HasDefaultValue(DateTime.Now);

            builder.HasOne(o => o.Question)
                .WithMany(o => o.Options)
                .HasForeignKey(o => o.QuestionId)
                .IsRequired();
        }
    }
}
