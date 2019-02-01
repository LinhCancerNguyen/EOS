using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user_mst");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Code).HasMaxLength(10);
            builder.Property(u => u.Account).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Firstname).HasMaxLength(50);
            builder.Property(u => u.Lastname).HasMaxLength(50);
            builder.Property(u => u.DepartmentId);
            builder.Property(u => u.TitleId);
            builder.Property(u => u.RoleId);
            builder.Property(u => u.Sex).HasDefaultValue(1);
            builder.Property(u => u.Dob);
            builder.Property(u => u.PhoneNumber).HasMaxLength(24);
            builder.Property(u => u.IdCard).HasMaxLength(40);
            builder.Property(u => u.IdDate);
            builder.Property(u => u.IdLocation).HasMaxLength(200);
            builder.Property(u => u.BankAccount).HasMaxLength(50);
            builder.Property(u => u.TaxCode).HasMaxLength(100);
            builder.Property(u => u.SocialInsurrance).HasMaxLength(100);
            builder.Property(u => u.HealthInsurrance).HasMaxLength(100);
            builder.Property(u => u.Household).HasMaxLength(1000);
            builder.Property(u => u.Address).HasMaxLength(1000);
            builder.Property(u => u.EducationBackgroundId);
            builder.Property(u => u.SchoolId);
            builder.Property(u => u.Specialized).HasMaxLength(200);
            builder.Property(u => u.Email).HasMaxLength(200);
            builder.Property(u => u.JoinDate);
            builder.Property(u => u.LeaveDate);
            builder.Property(u => u.TrainingContactStart);
            builder.Property(u => u.TrainingContactEnd);
            builder.Property(u => u.TrailContactStart);
            builder.Property(u => u.TrailContactEnd);
            builder.Property(u => u.OfficialContactStart);
            builder.Property(u => u.OfficialContactEnd);
            builder.Property(u => u.CurrentContract);
            builder.Property(u => u.Status).HasDefaultValue(1);
            builder.Property(u => u.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(u => u.DateModified).HasDefaultValue(DateTime.Now);

            builder.HasOne(u => u.Department).WithMany(d => d.Users).HasForeignKey(u => u.DepartmentId);
            builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.HasOne(u => u.School).WithMany(s => s.Users).HasForeignKey(u => u.SchoolId);
            builder.HasOne(u => u.Title).WithMany(t => t.Users).HasForeignKey(u => u.TitleId);
            builder.HasOne(u => u.EducationBackground).WithMany(e => e.Users).HasForeignKey(u => u.EducationBackgroundId);
        }
    }
}
