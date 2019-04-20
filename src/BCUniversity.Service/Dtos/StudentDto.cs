using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Dtos
{
    public class StudentDto : StudentRequestDto
    {
        public string Id { get; set; }
    }
    
    public static class ConvertToStudentDtoExtensions
    {
        public static StudentDto ToStudentDto(this Student student)
        {
            return new StudentDto()
            {
                Id = student.Id,
                Name = student.Name            
            };            
        }
        
        public static StudentDto ToStudentDto(this StudentEnrolment studentEnrolment)
        {
            return new StudentDto()
            {
                Id = studentEnrolment.StudentId,
                Name = studentEnrolment.StudentName
            };            
        }
    }
}