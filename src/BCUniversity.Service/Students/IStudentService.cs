using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Service.Dtos;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Students
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudents();
        Task<StudentDto> GetStudent(string id);

        Task<string> CreateStudent(StudentRequestDto studentRequest);

        Task EnrolStudentToSubject(string studentId, EnrolmentRequestDto requestDto);
        
        Task<IEnumerable<EnrolmentDto>> GetEnrolments(string studentId);

    }
}