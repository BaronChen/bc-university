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

        public override async Task<string> Save(Subject subject)
        {
            SubjectDataModel subjectDataModel = null;
            if (!string.IsNullOrWhiteSpace(subject.Id))
            {
                subjectDataModel = await GetBaseQuery().SingleOrDefaultAsync(x => x.Id == subject.Id);
            }
            
            if (subjectDataModel == null)
            {
                subjectDataModel = new SubjectDataModel()
                {
                    Name = subject.Name
                };
            }

            var lecturesDataModelById = subjectDataModel.Lectures.ToDictionary(x => x.Id);
            
            var lectures = GetLectureDataModels(subject, lecturesDataModelById);

            subjectDataModel.Lectures = lectures;
            
            _dbContext.Update(subjectDataModel);
            await _dbContext.SaveChangesAsync();
            return subjectDataModel.Id;
        }

        public override async Task<Subject> GetById(string id)
        {
            var dataModel = await GetBaseQuery().SingleOrDefaultAsync(x => x.Id == id);

            return dataModel.ToSubjectAggregate();
        }

        public override async Task<IEnumerable<Subject>> ListAll()
        {
            var dataModels = await GetBaseQuery().ToListAsync();

            return dataModels.Select(x => x.ToSubjectAggregate()).ToList();
        }

        private IQueryable<SubjectDataModel> GetBaseQuery()
        {
            return _dbContext.Subjects
                .Include(x => x.Lectures)
                .ThenInclude(l => l.LectureTheatreLink).ThenInclude(t => t.Theatre)
                .Include(x => x.StudentLinks);
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
                        Name = l.Name
                    };
                }

                lectureDataModel.LectureTheatreLink = new LectureTheatreLink()
                {
                    DayOfWeek = l.LectureSchedule.DayOfWeek,
                    StartHour = l.LectureSchedule.StartHour,
                    EndHour = l.LectureSchedule.EndHour,
                    TheatreId = l.LectureSchedule.Theatre.TheatreId
                };

                return lectureDataModel;
            }).ToList();
            return lectures;
        }
    }
}