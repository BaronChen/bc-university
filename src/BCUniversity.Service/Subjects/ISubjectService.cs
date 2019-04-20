using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Service.Dtos;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Subjects
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetSubjects();

        Task<Subject> GetSubjectById(string id);

        Task<string> CreateSubject(SubjectRequestDto requestDto);

        Task CreateLectureForSubject(string subjectId, LectureRequestDto requestDto);

        Task<IEnumerable<Lecture>> GetLecturesForSubject(string subjectId);

    }
}