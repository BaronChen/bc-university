using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Dtos
{
    public class EnrolmentDto
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectHours { get; set; }
    }
    
    public static class ConvertToEnrolmentDtoExtensions
    {
        public static EnrolmentDto ToEnrolmentDto(this SubjectEnrolment enrolment)
        {
            return new EnrolmentDto()
            {
                SubjectId = enrolment.SubjectId,
                SubjectName = enrolment.SubjectName,
                SubjectHours = enrolment.SubjectHours
            };
        }
    }
}