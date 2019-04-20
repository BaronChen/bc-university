using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.StudentAggregate;

namespace BCUniversity.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(string id);
    }
}