using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Service.Subjects.Dtos;

namespace BCUniversity.Service.Subjects
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetSubjects();

        Task<Subject> GetSubjectById(string id);

        Task<string> CreateSubject(SubjectRequestDto requestDto);

    }
}