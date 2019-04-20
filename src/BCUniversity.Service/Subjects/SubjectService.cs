using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.DomainService;
using BCUniversity.Domain.Exceptions;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Service.Dtos;
using BCUniversity.Service.Dtos.Requests;
using BCUniversity.Service.Exceptions;
using BCUniversity.Service.Theatres;

namespace BCUniversity.Service.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITheatreRepository _theatreRepository;

        private IUniversityDomainService _universityDomainService;

        public SubjectService(
            ISubjectRepository subjectRepository,
            IUniversityDomainService universityDomainService,
            ITheatreRepository theatreRepository
        )
        {
            _subjectRepository = subjectRepository;
            _universityDomainService = universityDomainService;
            _theatreRepository = theatreRepository;
        }

        public async Task<IEnumerable<SubjectDto>> GetSubjects()
        {
            return (await _subjectRepository.ListAll()).Select(x => x.ToSubjectDto()).ToList();
        }

        public async Task<SubjectDto> GetSubjectById(string id)
        {
            return (await _subjectRepository.GetById(id)).ToSubjectDto();
        }

        public async Task<string> CreateSubject(SubjectRequestDto requestDto)
        {  
            var subject = new Subject(null, requestDto.Name, new List<Lecture>(), new List<StudentEnrolment>());
        
            var id = await _subjectRepository.Save(subject);

            return id;
        }
        
        public async Task CreateLectureForSubject(string subjectId, LectureRequestDto requestDto)
        {
            var subject = await GetSubject(subjectId);

            var theatreReference = await GetTheatreReference(requestDto.LectureSchedule.TheatreId);
            var lectureSchedule = new LectureSchedule(
                theatreReference,
                requestDto.LectureSchedule.DayOfWeek,
                requestDto.LectureSchedule.StartHour,
                requestDto.LectureSchedule.EndHour
            );
            
            var lecture = new Lecture(null, requestDto.Name, lectureSchedule);
            
            subject.AddLecture(lecture);
            await _subjectRepository.Save(subject);
        }

       
        public async Task<IEnumerable<LectureDto>> GetLecturesForSubject(string subjectId)
        {
            var subject = await GetSubject(subjectId);

            return subject.Lectures.Select(x => x.ToLectureDto()).ToList();
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsForSubject(string subjectId)
        {
            var subject = await GetSubject(subjectId);

            return subject.StudentEnrolments.Select(x => x.ToStudentDto()).ToList();
        }

        private async Task<TheatreReference> GetTheatreReference(string theatreId)
        {
            var theatre = await _theatreRepository.GetById(theatreId);

            if (theatre == null)
            {
                throw new InvalidInputException($"Invalid theatre id {theatreId}");
            }

            return new TheatreReference(theatre.Id, theatre.Name, theatre.Capacity);
        }
        
        private async Task<Subject> GetSubject(string subjectId)
        {
            var subject = await _subjectRepository.GetById(subjectId);

            if (subject == null)
            {
                throw new ResourceNotFoundException($"Cannot found subject id {subjectId}");
            }

            return subject;
        }

    }
}