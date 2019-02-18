using Core.Models;
using Infra.Configuration;
using Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Entities
{
    public class MyBlogEntity:DbContext
    {
        public MyBlogEntity(DbContextOptions<MyBlogEntity> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        //Configuaration for code first
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Master Table Config
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfigution());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            //Seed
            MyBlogEntitySeed.Run(modelBuilder);
        }
    }
}
