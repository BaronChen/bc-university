using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Service.Subjects.Dtos;

namespace BCUniversity.Service.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITheatreRepository _theatreRepository;

        public SubjectService(ISubjectRepository subjectRepository, ITheatreRepository theatreRepository)
        {
            _subjectRepository = subjectRepository;
            _theatreRepository = theatreRepository;
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _subjectRepository.ListAll();
        }

        public async Task<Subject> GetSubjectById(string id)
        {
            return await _subjectRepository.GetById(id);
        }

        public async Task<string> CreateSubject(SubjectRequestDto requestDto)
        {
            var theatreIds = requestDto.Lectures.Select(x => x.LectureSchedule.TheatreId).ToList();
            var theatreById = (await _theatreRepository.GetByIds(theatreIds)).ToDictionary(x => x.Id);
         
            var lectures = GetLectures(requestDto, theatreById);
            
            var subject = new Subject(null, requestDto.Name, lectures, new List<StudentEnrolment>());
        
            var id = await _subjectRepository.Save(subject);

            return id;
        }

        private static List<Lecture> GetLectures(SubjectRequestDto requestDto, Dictionary<string, Theatre> theatreById)
        {
            return requestDto.Lectures.Select(l =>
            {
                if (!theatreById.ContainsKey(l.LectureSchedule.TheatreId))
                {
                    throw new ArgumentException($"Invalid Theatre id {l.LectureSchedule.TheatreId} in lecture {l.Name}");
                }
                
                var theatre = theatreById[l.LectureSchedule.TheatreId];
              
                var lectureSchedule = new LectureSchedule(
                    new TheatreReference(theatre.Id, theatre.Name, theatre.Capacity), 
                    l.LectureSchedule.DayOfWeek,
                    l.LectureSchedule.StartHour,
                    l.LectureSchedule.EndHour
                );
                return new Lecture(null, l.Name, lectureSchedule);
            }).ToList();
        }
    }
}