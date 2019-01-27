﻿// <auto-generated />
using System;
using ExamOnline.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamOnline.Migrations
{
    [DbContext(typeof(ExamDBContext))]
    partial class ExamDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamOnline.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerContent");

                    b.Property<int?>("QuestionID");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("ExamOnline.Models.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OptionContent");

                    b.Property<int?>("QuestionID");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionID");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("ExamOnline.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionContent");

                    b.Property<int?>("SubjectId");

                    b.HasKey("QuestionId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("ExamOnline.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ExamOnline.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubjectCode");

                    b.Property<string>("SubjectName");

                    b.HasKey("SubjectId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("ExamOnline.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ExamOnline.Models.Answer", b =>
                {
                    b.HasOne("ExamOnline.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionID");
                });

            modelBuilder.Entity("ExamOnline.Models.Option", b =>
                {
                    b.HasOne("ExamOnline.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionID");
                });

            modelBuilder.Entity("ExamOnline.Models.Question", b =>
                {
                    b.HasOne("ExamOnline.Models.Subject", "Subject")
                        .WithMany("Questions")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("ExamOnline.Models.User", b =>
                {
                    b.HasOne("ExamOnline.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
