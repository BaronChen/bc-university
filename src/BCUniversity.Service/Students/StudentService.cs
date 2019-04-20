using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.StudentAggregate;

namespace BCUniversity.Service.Implementation
{
    internal class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
       

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
          
        }
        
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.ListAll();
        }

        public async Task<Student> GetStudent(string id)
        {
            return await _studentRepository.GetById(id);
        }
    }
}