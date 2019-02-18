using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(q => q.PostId);
            builder.Property(q => q.Title).IsRequired();
            builder.Property(q => q.ShortDescription).IsRequired();
            builder.Property(q => q.Description).IsRequired();
            builder.Property(q => q.Meta).IsRequired();
            builder.Property(q => q.UrlSlug).IsRequired();
            builder.Property(q => q.Published).IsRequired();
            builder.Property(q => q.PostedOn).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(q => q.Modified).HasDefaultValue(DateTime.Now);
            builder.HasOne(q => q.Category)
                .WithMany(q => q.Posts)
                .HasForeignKey(q => q.CategoryId)
                .IsRequired();
        }
    }
}
