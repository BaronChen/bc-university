using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Dtos
{
    public class SubjectDto : SubjectRequestDto
    {
        public string Id { get; set; }
        
        public int SubjectHours { get; set; }
    }

    public static class ConvertToSubjectDtoExtensions
    {
        public static SubjectDto ToSubjectDto(this Subject subject)
        {
            return new SubjectDto()
            {
                Id = subject.Id,
                Name = subject.Name,
                SubjectHours = subject.GetTotalHours()
            };
        }
    }
}