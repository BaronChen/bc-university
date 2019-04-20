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
                var lectureSchedules = l.LectureTheatreLinks.Select(x =>
                    new LectureSchedule(new TheatreReference(x.TheatreId, x.Theatre.Name, x.Theatre.Capacity),
                        x.DayOfWeek, x.StartHour, x.EndHour)).ToList();

                return new Lecture(l.Name, lectureSchedules);
            }).ToList();

            var studentEnrolments =
                dataModel.StudentLinks.Select(x => new StudentEnrolment(x.Student.Id, x.Student.Name)).ToList();

            var subject = new Subject(dataModel.Name, lectures, studentEnrolments);
            return subject;
        }
        
        public static Student ToStudentAggregate(this StudentDataModel studentDataModel)
        {
            if (studentDataModel == null)
            {
                return null;
            }
            
            var subjectEnrolments =
                studentDataModel.SubjectLinks.Select(x => new SubjectEnrolment(x.SubjectId, x.Subject.Name)).ToList();
            var student = new Student(studentDataModel.Name, subjectEnrolments);
            return student;
        }
        
        public static Theatre ToTheatreAggregate(this TheatreDataModel theatreDataModel)
        {
            if (theatreDataModel == null)
            {
                return null;
            }
            
            var theatre = new Theatre(theatreDataModel.Name, theatreDataModel.Capacity);
            return theatre;
        }
        
    }
}