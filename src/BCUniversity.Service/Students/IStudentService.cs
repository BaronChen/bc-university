using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Students
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(string id);

        Task<string> CreateStudent(StudentRequestDto studentRequest);
    }
}