using System.Collections.Generic;
using BCUniversity.Infrastructure.DataModel;
using BCUniversity.Infrastructure.DataModel.Relationships;
using Microsoft.EntityFrameworkCore;

namespace BCUniversity.Infrastructure.Common
{
    public class SeedDataFactory
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
             var theatres = new List<TheatreDataModel>
            {
                new TheatreDataModel()
                {
                    Id = "180c5352-2a8b-4941-9728-2790ab5e15af",
                    Name = "Theatre 1",
                    Capacity = 10
                },
                new TheatreDataModel()
                {
                    Id = "dd01bbdf-26b8-43db-8d4c-7d394fbddaac",
                    Name = "Theatre 2",
                    Capacity = 1
                }
            };

            modelBuilder.Entity<TheatreDataModel>().HasData(theatres);

            
            var students = new List<StudentDataModel>
            {
                new StudentDataModel()
                {
                    Id = "c15cef22-35db-4ccb-a725-8bb127b8dcb1",
                    Name = "Student 1"
                },
                new StudentDataModel()
                {
                    Id = "2ea37cfc-72b5-4898-a768-b20f9aa354b9",
                    Name = "Student 2"
                },
                new StudentDataModel()
                {
                    Id = "7bb294f6-a199-4197-bdbd-f010283e7a74",
                    Name = "Student 3"
                }
            };
            modelBuilder.Entity<StudentDataModel>().HasData(students);
            
            var subjects = new List<SubjectDataModel>
            {
                new SubjectDataModel()
                {
                    Id = "81b6ec83-e8b4-4ad5-8893-1f763200393d",
                    Name = "Subject 1"
                },
                new SubjectDataModel()
                {
                    Id = "a9a5db84-7de3-40a0-b464-a9cfd7c60a06",
                    Name = "Subject 2"
                },
                new SubjectDataModel()
                {
                    Id = "9ee3209c-2333-4cd1-ae13-84039e5b8e35",
                    Name = "Subject 3"
                }
            };
            modelBuilder.Entity<SubjectDataModel>().HasData(subjects);
            
            var lectureTheatreLinks = new List<LectureTheatreLink>()
            {
                new LectureTheatreLink()
                {
                    LectureId = "d33ea94a-b2c7-435a-ad8b-0b75f33189cc",
                    TheatreId = "180c5352-2a8b-4941-9728-2790ab5e15af",
                    DayOfWeek = 1,
                    StartHour = 10,
                    EndHour = 18
                },
                new LectureTheatreLink()
                {
                    LectureId = "9735bdc7-79ca-4728-b2dc-ba4ab4f70d1d",
                    TheatreId = "180c5352-2a8b-4941-9728-2790ab5e15af",
                    DayOfWeek = 2,
                    StartHour = 14,
                    EndHour = 16
                },
                new LectureTheatreLink()
                {
                    LectureId = "86b20947-e7f2-4c25-845b-652b74c0a103",
                    TheatreId = "180c5352-2a8b-4941-9728-2790ab5e15af",
                    DayOfWeek = 3,
                    StartHour = 10,
                    EndHour = 12
                },
                new LectureTheatreLink()
                {
                    LectureId = "ca24c626-873b-4d27-8e30-bfd26e760b13",
                    TheatreId = "dd01bbdf-26b8-43db-8d4c-7d394fbddaac",
                    DayOfWeek = 5,
                    StartHour = 10,
                    EndHour = 11
                }
            };
            modelBuilder.Entity<LectureTheatreLink>().HasData(lectureTheatreLinks);
            
            var lectures = new List<LectureDataModel>
            {
                new LectureDataModel()
                {
                    Id = "d33ea94a-b2c7-435a-ad8b-0b75f33189cc",
                    Name = "Lecture 1",
                    SubjectId = "81b6ec83-e8b4-4ad5-8893-1f763200393d"
                },
                
                new LectureDataModel()
                {
                    Id = "9735bdc7-79ca-4728-b2dc-ba4ab4f70d1d",
                    Name = "Lecture 2",
                    SubjectId = "a9a5db84-7de3-40a0-b464-a9cfd7c60a06",
                },
                
                new LectureDataModel()
                {
                    Id = "86b20947-e7f2-4c25-845b-652b74c0a103",
                    Name = "Lecture 3",
                    SubjectId = "a9a5db84-7de3-40a0-b464-a9cfd7c60a06",
                },
                
                new LectureDataModel()
                {
                    Id = "ca24c626-873b-4d27-8e30-bfd26e760b13",
                    Name = "Lecture 4",
                    SubjectId = "9ee3209c-2333-4cd1-ae13-84039e5b8e35",
                }
            };
            modelBuilder.Entity<LectureDataModel>().HasData(lectures);
        }
    }
}