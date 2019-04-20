using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.Common.Events;
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
        public StudentRepository(UniversityContext dbContext, IDomainEventDispatcher domainEventDispatcher) 
            : base(dbContext, domainEventDispatcher)
        {
        }
        
        public override async Task<string> Save(Student student)
        {
            StudentDataModel studentDataModel = null;
            if (!string.IsNullOrWhiteSpace(student.Id))
            {
                studentDataModel = await GetBaseQuery().SingleOrDefaultAsync(x => x.Id == student.Id);
            }
            
            if (studentDataModel == null)
            {
                studentDataModel = new StudentDataModel()
                {
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

            await DispatchEvents(student);
            return studentDataModel.Id;
        }

        public override async Task<Student> GetById(string id)
        {
            var studentDataModel = await GetBaseQuery().SingleOrDefaultAsync(s => s.Id == id);
            var student = studentDataModel.ToStudentAggregate();

            return student;
        }

        public override async Task<IEnumerable<Student>> ListAll()
        {
            var dataModels = await GetBaseQuery().ToListAsync();

            return dataModels.Select(x => x.ToStudentAggregate()).ToList();
        }
        
        private IQueryable<StudentDataModel> GetBaseQuery()
        {
            return _dbContext.Students
                .Include(x => x.SubjectLinks)
                .ThenInclude(x => x.Subject)
                .ThenInclude(x => x.Lectures)
                .ThenInclude(x => x.LectureTheatreLink);
        }
    }
}