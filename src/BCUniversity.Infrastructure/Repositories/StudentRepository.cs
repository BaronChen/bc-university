using System;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Infrastructure.Common;
using BCUniversity.Infrastructure.DataModel;
using BCUniversity.Infrastructure.DataModel.Relationships;
using Microsoft.EntityFrameworkCore;

namespace BCUniversity.Infrastructure.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(UniversityContext dbContext) : base(dbContext)
        {
        }
        
        public override async Task Save(Student student)
        {
            StudentDataModel studentDataModel = null;
            if (!string.IsNullOrWhiteSpace(student.Id))
            {
                studentDataModel = await _dbContext.Students.SingleOrDefaultAsync(x => x.Id == student.Id);
            }
            
            if (studentDataModel == null)
            {
                studentDataModel = new StudentDataModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = student.Name
                };
            }

            studentDataModel.SubjectLinks = student.SubjectEnrolments.Select(s => new SubjectStudentLink()
            {
                StudentId = student.Id,
                SubjectId = s.SubjectId
            }).ToList();

            _dbContext.Update(studentDataModel);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<Student> GetById(string id)
        {
            var studentDataModel = await _dbContext.Students.SingleOrDefaultAsync(s => s.Id == id);
            var subjectEnrolments =
                studentDataModel.SubjectLinks.Select(x => new SubjectEnrolment(x.SubjectId, x.Subject.Name)).ToList();
            var student = new Student(studentDataModel.Name, subjectEnrolments);

            return student;
        }
    }
}