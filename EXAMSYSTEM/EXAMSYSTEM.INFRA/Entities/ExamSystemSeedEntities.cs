using EXAMSYSTEM.CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Entities
{
    public class ExamSystemSeedEntities
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                
            );
            modelBuilder.Entity<User>().HasData(

            );
            modelBuilder.Entity<Subject>().HasData(

            );
            modelBuilder.Entity<UserExam>().HasData(

            );
            modelBuilder.Entity<Question>().HasData(

            );
            modelBuilder.Entity<Option>().HasData(

            );
        }
    }
}
