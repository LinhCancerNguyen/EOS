using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(q => q.TagId);
            builder.Property(q => q.Name).IsRequired();
            builder.Property(q => q.UrlSlug).IsRequired();
            builder.Property(q => q.Description).IsRequired();
        }
    }
}
