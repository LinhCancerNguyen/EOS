using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Configuration
{
    public class TrackingConfiguration : IEntityTypeConfiguration<Tracking>
    {
        public void Configure(EntityTypeBuilder<Tracking> builder)
        {
            builder.ToTable("tracking_mst");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.DateCreated).HasDefaultValue(DateTime.Now);
        }
    }
}
