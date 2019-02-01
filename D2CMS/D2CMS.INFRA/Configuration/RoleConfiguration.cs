using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role_mst");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Status).HasDefaultValue(1);
            builder.Property(u => u.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(u => u.DateModified).HasDefaultValue(DateTime.Now);
        }
    }
}
