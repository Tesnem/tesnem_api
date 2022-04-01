﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tesnem.Api.Data;

#nullable disable

namespace Tesnem.Api.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220331141808_AutoEnrollmentNumber")]
    partial class AutoEnrollmentNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ClassStudent", b =>
                {
                    b.Property<Guid>("ClassesId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("char(36)");

                    b.HasKey("ClassesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ClassStudent");
                });

            modelBuilder.Entity("CourseProfessor", b =>
                {
                    b.Property<Guid>("ProfessorsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeacherOfCoursesId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProfessorsId", "TeacherOfCoursesId");

                    b.HasIndex("TeacherOfCoursesId");

                    b.ToTable("CourseProfessor");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<Guid>("CoursesCurrentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("char(36)");

                    b.HasKey("CoursesCurrentId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Course_Id")
                        .HasColumnType("char(36)");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Course_Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Program_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Program_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("EnrollmentNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.PersonalData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AdditionalAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AddressHouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("PersonalData");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.ProgramMajor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Av")
                        .HasColumnType("int");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Grade")
                        .HasColumnType("double");

                    b.Property<Guid>("Student_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("Student_Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Professor", b =>
                {
                    b.HasBaseType("Tesnem.Api.Domain.Models.Person");

                    b.HasDiscriminator().HasValue("Professor");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Student", b =>
                {
                    b.HasBaseType("Tesnem.Api.Domain.Models.Person");

                    b.Property<DateTime>("ConclusionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ProgramMajorId")
                        .HasColumnType("char(36)");

                    b.HasIndex("ProgramMajorId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("ClassStudent", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseProfessor", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("TeacherOfCoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCurrentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Class", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Professor", "Professor")
                        .WithMany("TeacherOfClasses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Course", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.ProgramMajor", "Program")
                        .WithMany("Courses")
                        .HasForeignKey("Program_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Enrollment", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Person", null)
                        .WithOne("Enrollment")
                        .HasForeignKey("Tesnem.Api.Domain.Models.Enrollment", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.PersonalData", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Person", "Person")
                        .WithOne("Data")
                        .HasForeignKey("Tesnem.Api.Domain.Models.PersonalData", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Test", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Class", null)
                        .WithMany("Tests")
                        .HasForeignKey("ClassId");

                    b.HasOne("Tesnem.Api.Domain.Models.Course", null)
                        .WithMany("Tests")
                        .HasForeignKey("CourseId");

                    b.HasOne("Tesnem.Api.Domain.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Student", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.ProgramMajor", "ProgramMajor")
                        .WithMany()
                        .HasForeignKey("ProgramMajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramMajor");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Class", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Course", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Person", b =>
                {
                    b.Navigation("Data")
                        .IsRequired();

                    b.Navigation("Enrollment")
                        .IsRequired();
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.ProgramMajor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Professor", b =>
                {
                    b.Navigation("TeacherOfClasses");
                });
#pragma warning restore 612, 618
        }
    }
}