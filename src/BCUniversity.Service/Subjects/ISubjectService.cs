using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Service.Dtos;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Subjects
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetSubjects();

        Task<SubjectDto> GetSubjectById(string id);

        Task<string> CreateSubject(SubjectRequestDto requestDto);

        Task CreateLectureForSubject(string subjectId, LectureRequestDto requestDto);

        Task<IEnumerable<LectureDto>> GetLecturesForSubject(string subjectId);

        Task<IEnumerable<StudentDto>> GetStudentsForSubject(string subjectId);

    }
}