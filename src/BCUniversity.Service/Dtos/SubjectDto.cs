using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Dtos
{
    public class SubjectDto : SubjectRequestDto
    {
        public string Id { get; set; }
    }

    public static class ConvertoToSubjectDtoExtensions
    {
        public static SubjectDto ToSubjectDto(this Subject subject)
        {
            return new SubjectDto()
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }
    }
}