using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Configuration
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("title_mst");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Status).HasDefaultValue(1);
            builder.Property(u => u.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(u => u.DateModified).HasDefaultValue(DateTime.Now);
        }
    }
}
