using Microsoft.EntityFrameworkCore;
using D2CMS.CORE.Models;
using D2CMS.INFRA.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Entities
{
    public class D2CMSEntities : DbContext
    {
        public D2CMSEntities(DbContextOptions<D2CMSEntities> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<EducationBackground> EducationBackgrounds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        //Configuaration for code first
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Master Table Config
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new EducationBackgroundConfiguration());

            //User Table Config
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new TrackingConfiguration());
            //Seed
            D2CMSEntitiesSeed.Run(modelBuilder);
        }
    }
}

