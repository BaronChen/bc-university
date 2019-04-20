using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Infrastructure.Common;
using BCUniversity.Infrastructure.DataModel;
using BCUniversity.Infrastructure.DataModel.Relationships;
using BCUniversity.Infrastructure.Repositories.Extensions;
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
            var student = studentDataModel.ToStudentAggregate();

            return student;
        }

        public override async Task<IEnumerable<Student>> ListAll()
        {
            var dataModels = await _dbContext.Students.ToListAsync();

            return dataModels.Select(x => x.ToStudentAggregate()).ToList();
        }
    }
}