﻿// <auto-generated />
using BCUniversity.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BCUniversity.Infrastructure.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20190419075430_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BCUniversity.Infrastructure.DataModel.LectureDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("lecture");
                });

            modelBuilder.Entity("BCUniversity.Infrastructure.DataModel.LectureScheduleDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayOfWeek");

                    b.Property<int>("EndHour");

                    b.Property<string>("LectureId");

                    b.Property<int>("StartHour");

                    b.Property<string>("TheatreId");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.HasIndex("TheatreId");

                    b.ToTable("lecture_schedule");
                });

            modelBuilder.Entity("BCUniversity.Infrastructure.DataModel.Relationships.SubjectStudentLink", b =>
                {
                    b.Property<string>("SubjectId");

                    b.Property<string>("StudentId");

                    b.HasKey("SubjectId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("subject_student_relationship");
                });

            modelBuilder.Entity("BCUniversity.Infrastructure.DataModel.StudentDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("student");
                });

            modelBuilder.Entity("BCUniversity.Infrastructure.DataModel.SubjectDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("subject");
                });

            modelBuilder.Entity("BCUniversity.Infrastructure.DataModel.TheatreDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("theatre");
                });

            modelBuilder.Entity("BCUniversity.Infrastructure.DataModel.LectureScheduleDataModel", b =>
                {
                    b.HasOne("BCUniversity.Infrastructure.DataModel.LectureDataModel", "Lecture")
                        .WithMany("LectureSchedules")
                        .HasForeignKey("LectureId");

                    b.HasOne("BCUniversity.Infrastructure.DataModel.TheatreDataModel", "Theatre")
                        .WithMany("LectureSchedules")
                        .HasForeignKey("TheatreId");
                });

            modelBuilder.Entity("BCUniversity.Infrastructure.DataModel.Relationships.SubjectStudentLink", b =>
                {
                    b.HasOne("BCUniversity.Infrastructure.DataModel.StudentDataModel", "Student")
                        .WithMany("SubjectLinks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BCUniversity.Infrastructure.DataModel.SubjectDataModel", "Subject")
                        .WithMany("StudentLinks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
