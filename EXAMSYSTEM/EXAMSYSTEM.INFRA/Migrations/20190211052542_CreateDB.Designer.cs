﻿// <auto-generated />
using EXAMSYSTEM.INFRA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EXAMSYSTEM.INFRA.Migrations
{
    [DbContext(typeof(ExamSystemEntities))]
    [Migration("20190211052542_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EXAMSYSTEM.CORE.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<string>("Option1")
                        .IsRequired();

                    b.Property<string>("Option2")
                        .IsRequired();

                    b.Property<string>("Option3");

                    b.Property<string>("Option4");

                    b.Property<string>("QuestionContent")
                        .IsRequired();

                    b.Property<int>("SubjectId");

                    b.HasKey("QuestionId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("EXAMSYSTEM.CORE.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EXAMSYSTEM.CORE.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(true);

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SubjectId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("EXAMSYSTEM.CORE.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("RoleId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EXAMSYSTEM.CORE.Models.UserExam", b =>
                {
                    b.Property<int>("UserExamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Score");

                    b.Property<int>("SubjectId");

                    b.Property<int>("UserId");

                    b.HasKey("UserExamId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("UserExam");
                });

            modelBuilder.Entity("EXAMSYSTEM.CORE.Models.Question", b =>
                {
                    b.HasOne("EXAMSYSTEM.CORE.Models.Subject", "Subject")
                        .WithMany("Questions")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EXAMSYSTEM.CORE.Models.User", b =>
                {
                    b.HasOne("EXAMSYSTEM.CORE.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EXAMSYSTEM.CORE.Models.UserExam", b =>
                {
                    b.HasOne("EXAMSYSTEM.CORE.Models.Subject", "Subject")
                        .WithMany("UserExams")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EXAMSYSTEM.CORE.Models.User", "User")
                        .WithMany("UserExams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}