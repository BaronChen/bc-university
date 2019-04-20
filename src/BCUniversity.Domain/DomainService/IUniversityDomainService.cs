using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Domain.SubjectAggregate;

namespace BCUniversity.Domain.DomainService
{
    public interface IUniversityDomainService
    {
        Task EnrolStudentToSubject(string studentId, string subjectId);

    }
}