using System.Collections.Generic;
using System.Linq;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Infrastructure.DataModel;

namespace BCUniversity.Infrastructure.Repositories.Extensions
{
    public static class DataModelExtensions
    {
        public static Subject ToSubjectAggregate(this SubjectDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }
            
            var lectures = dataModel.Lectures.Select(l =>
            {
                var theatreLink = l.LectureTheatreLink;
                var lectureSchedules = new LectureSchedule(
                    new TheatreReference(
                        theatreLink.TheatreId, 
                        theatreLink.Theatre.Name, 
                        theatreLink.Theatre.Capacity),
                    theatreLink.DayOfWeek, 
                    theatreLink.StartHour, 
                    theatreLink.EndHour);

                return new Lecture(l.Id, l.Name, lectureSchedules);
            }).ToList();

            var studentEnrolments =
                dataModel.StudentLinks.Select(x => new StudentEnrolment(x.Student.Id, x.Student.Name)).ToList();

            var subject = new Subject(dataModel.Id, dataModel.Name, lectures, studentEnrolments);
            return subject;
        }
        
        public static Student ToStudentAggregate(this StudentDataModel studentDataModel)
        {
            if (studentDataModel == null)
            {
                return null;
            }

            var subjectEnrolments =
                studentDataModel.SubjectLinks.Select(x =>
                        new SubjectEnrolment(x.SubjectId, x.Subject.Name,
                            x.Subject.Lectures.Min(l => l.LectureTheatreLink.EndHour - l.LectureTheatreLink.StartHour))
                    ).ToList();
            var student = new Student(studentDataModel.Id, studentDataModel.Name, subjectEnrolments);
            return student;
        }
        
        public static Theatre ToTheatreAggregate(this TheatreDataModel theatreDataModel)
        {
            if (theatreDataModel == null)
            {
                return null;
            }
            
            var theatre = new Theatre(theatreDataModel.Id, theatreDataModel.Name, theatreDataModel.Capacity);
            return theatre;
        }
        
    }
}