using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Infrastructure.Common;
using BCUniversity.Infrastructure.DataModel;
using BCUniversity.Infrastructure.DataModel.Relationships;
using BCUniversity.Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BCUniversity.Infrastructure.Repositories
{
    public class SubjectRepository: RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(UniversityContext dbContext) : base(dbContext)
        {
        }

        public override async Task Save(Subject subject)
        {
            SubjectDataModel subjectDataModel = null;
            if (!string.IsNullOrWhiteSpace(subject.Id))
            {
                subjectDataModel = await _dbContext.Subjects.SingleOrDefaultAsync(x => x.Id == subject.Id);
            }
            
            if (subjectDataModel == null)
            {
                subjectDataModel = new SubjectDataModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = subject.Name
                };
            }

            var lecturesDataModelById = subjectDataModel.Lectures.ToDictionary(x => x.Id);

            var lectures = GetLectureDataModels(subject, lecturesDataModelById);

            subjectDataModel.Lectures = lectures;
            
            _dbContext.Update(subjectDataModel);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<Subject> GetById(string id)
        {
            var dataModel = await _dbContext.Subjects.SingleOrDefaultAsync(x => x.Id == id);

            return dataModel.ToSubjectAggregate();
        }

        public override async Task<IEnumerable<Subject>> ListAll()
        {
            var dataModels = await _dbContext.Subjects.ToListAsync();

            return dataModels.Select(x => x.ToSubjectAggregate()).ToList();
        }

        private static List<LectureDataModel> GetLectureDataModels(
            Subject subject,
            Dictionary<string, LectureDataModel> lecturesDataModelById
        )
        {
            var lectures = subject.Lectures.Select(l =>
            {
                LectureDataModel lectureDataModel;
                if (!string.IsNullOrWhiteSpace(l.Id) && lecturesDataModelById.ContainsKey(l.Id))
                {
                    lectureDataModel = lecturesDataModelById[l.Id];
                }
                else
                {
                    lectureDataModel = new LectureDataModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = l.Name
                    };
                }

                lectureDataModel.LectureTheatreLinks = l.LectureSchedules.Select(ls => new LectureTheatreLink()
                {
                    DayOfWeek = ls.DayOfWeek,
                    StartHour = ls.StartHour,
                    EndHour = ls.EndHour,
                    LectureId = l.Id,
                    TheatreId = ls.Theatre.TheatreId
                }).ToList();

                return lectureDataModel;
            }).ToList();
            return lectures;
        }
    }
}