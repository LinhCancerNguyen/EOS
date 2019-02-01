using Microsoft.EntityFrameworkCore;
using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Entities
{
    public static class D2CMSEntitiesSeed
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Code = "Undefined", Name = "Undefined", OpenDate = new DateTime(2018, 01, 01), Note = null, Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Department() { Id = 2, Code = "D1", Name = "D1", OpenDate = new DateTime(2018, 01, 01), Note = null, Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Department() { Id = 3, Code = "D2", Name = "D2", OpenDate = new DateTime(2018, 01, 01), Note = null, Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Department() { Id = 4, Code = "D3", Name = "D3", OpenDate = new DateTime(2018, 01, 01), Note = null, Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Department() { Id = 5, Code = "D4", Name = "D4", OpenDate = new DateTime(2018, 01, 01), Note = null, Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Department() { Id = 6, Code = "P1", Name = "P1", OpenDate = new DateTime(2018, 01, 01), Note = null, Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Department() { Id = 7, Code = "GA", Name = "GA", OpenDate = new DateTime(2018, 01, 01), Note = null, Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            );

            modelBuilder.Entity<EducationBackground>().HasData(
                new EducationBackground() { Id = 1, Name = "Trung học cơ sở", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new EducationBackground() { Id = 2, Name = "Trung học phổ thông", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new EducationBackground() { Id = 3, Name = "Cao đẳng/Dạy nghề", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new EducationBackground() { Id = 4, Name = "Đại học", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new EducationBackground() { Id = 5, Name = "Sau đại học", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "Unknow", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Role() { Id = 2, Name = "Admin", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Role() { Id = 3, Name = "Staff", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Role() { Id = 4, Name = "HR", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Role() { Id = 5, Name = "Bug", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            );

            modelBuilder.Entity<School>().HasData(
               new School() { Id = 1, Name = "Unknow", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
               new School() { Id = 2, Name = "Đại học Bách khoa Hà Nội", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
               new School() { Id = 3, Name = "Đại học FPT", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
               new School() { Id = 4, Name = "Đại học Ngoại ngữ", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
               new School() { Id = 5, Name = "Đại học Công nghệ", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now }               
           );

            modelBuilder.Entity<Title>().HasData(
              new Title() { Id = 1, Code = "NA", Name = "Unknow", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 2, Code = "CEO", Name = "CEO", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 3, Code = "CFO", Name = "CFO", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 4, Code = "COO", Name = "COO", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 5, Code = "GA", Name = "GA", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 6, Code = "PM", Name = "PM", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 7, Code = "DEV", Name = "DEV", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 8, Code = "TEST", Name = "TEST", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 9, Code = "COMTOR", Name = "COMTOR", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 10, Code = "BA", Name = "BA", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now },
              new Title() { Id = 11, Code = "BUG", Name = "BUG", Status = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now }
          );
        }
    }
}
