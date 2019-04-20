using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.DomainService;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Service.Students.Dtos;

namespace BCUniversity.Service.Students
{
    internal class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUniversityDomainService _universityDomainService;
       

        public StudentService(IStudentRepository studentRepository, IUniversityDomainService universityDomainService)
        {
            _studentRepository = studentRepository;
            _universityDomainService = universityDomainService;
        }
        
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.ListAll();
        }

        public async Task<Student> GetStudent(string id)
        {
            return await _studentRepository.GetById(id);
        }

        public async Task<string> CreateStudent(StudentRequestDto requestDto)
        {
           var student = new Student(null, requestDto.Name, new List<SubjectEnrolment>());
            
           var id = await _studentRepository.Save(student);

           return id;
        }

        public async Task<Student> EnrolStudentToSubject(EnrolmentDto dto)
        {
            await _universityDomainService.EnrolStudentToSubject(dto.StudentId, dto.SubjectId);

            return await _studentRepository.GetById(dto.StudentId);
        }
    }
}