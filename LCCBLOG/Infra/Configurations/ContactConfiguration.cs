using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey(q => q.Name);
            builder.Property(q => q.Email).IsRequired();
            builder.Property(q => q.Website).IsRequired();
            builder.Property(q => q.Subject).IsRequired();
            builder.Property(q => q.Body).IsRequired();
        }
    }
}
