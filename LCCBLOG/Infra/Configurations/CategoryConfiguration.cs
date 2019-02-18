using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(q => q.CategoryId);
            builder.Property(q => q.Name).IsRequired();
            builder.Property(q => q.UrlSlug).IsRequired();
            builder.Property(q => q.Description).IsRequired();
        }
    }
}
