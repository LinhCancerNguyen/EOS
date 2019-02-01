using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("department_mst");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Code).HasMaxLength(20);
            builder.Property(d => d.Name).HasMaxLength(200);
            builder.Property(d => d.OpenDate);
            builder.Property(d => d.Note).HasMaxLength(4000);
            builder.Property(u => u.Status).HasDefaultValue(1);
            builder.Property(u => u.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(u => u.DateModified).HasDefaultValue(DateTime.Now);
        }
    }
}
