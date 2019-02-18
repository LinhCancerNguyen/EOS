using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Configurations
{
    public class PostTagConfigution : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.ToTable("PostTag");
            builder.HasKey(p => new { p.PostId, p.TagId });
            builder.HasOne(p => p.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(p => p.PostId)
                .IsRequired();
            builder.HasOne(p => p.Tag)
                .WithMany(p => p.PostTags)
                .HasForeignKey(p => p.TagId)
                .IsRequired();
        }
    }
}
