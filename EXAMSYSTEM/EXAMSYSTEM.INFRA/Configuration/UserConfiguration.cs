﻿using EXAMSYSTEM.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.RoleId);
            builder.Property(u => u.Username).HasMaxLength(50).IsUnicode(true).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(15).IsRequired();
            builder.Property(u => u.ConfirmPassword).HasMaxLength(15).IsRequired();
            builder.Property(u => u.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(u => u.ModifiedDate).HasDefaultValue(DateTime.Now);

            builder.HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();
        }
    }
}