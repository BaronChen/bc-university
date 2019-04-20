using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.DomainService;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Service.Dtos;
using BCUniversity.Service.Dtos.Requests;
using BCUniversity.Service.Exceptions;

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
        
        public async Task<IEnumerable<StudentDto>> GetStudents()
        {
            return (await _studentRepository.ListAll()).Select(x => x.ToStudentDto()).ToList();
        }

        public async Task<StudentDto> GetStudent(string id)
        {
            var student = await _studentRepository.GetById(id);
            if (student == null)
            {
                throw new ResourceNotFoundException($"Student id {id} not found.");
            }
            return student.ToStudentDto();
        }

        public async Task<string> CreateStudent(StudentRequestDto requestDto)
        {
           var student = new Student(null, requestDto.Name, new List<SubjectEnrolment>());
            
           var id = await _studentRepository.Save(student);

           return id;
        }

        public async Task EnrolStudentToSubject(string studentId, EnrolmentRequestDto requestDto)
        {
            await _universityDomainService.EnrolStudentToSubject(studentId, requestDto.SubjectId);
        }

        public async Task<IEnumerable<EnrolmentDto>> GetEnrolments(string studentId)
        {
            var student = await _studentRepository.GetById(studentId);

            if (student == null)
            {
                throw new ResourceNotFoundException($"Cannot found student id {studentId}");
            }

            return student.SubjectEnrolments.Select(x => x.ToEnrolmentDto()).ToList();
        }
    }
}