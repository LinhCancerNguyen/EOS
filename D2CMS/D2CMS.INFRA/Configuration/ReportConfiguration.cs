using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("report_mst");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Note).HasMaxLength(4000);
            builder.Property(r => r.Status).HasDefaultValue(1);
            builder.Property(r => r.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(r => r.DateModified).HasDefaultValue(DateTime.Now);

            builder.HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId);
        }
    }
}
