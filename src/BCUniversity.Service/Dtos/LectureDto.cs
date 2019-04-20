using BCUniversity.Domain.SubjectAggregate;

namespace BCUniversity.Service.Dtos
{
    public class LectureDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public LectureScheduleDto LectureSchedule { get; set; }
    }
    
    public static class ConvertToLectureDtoExtensions
    {
        public static LectureDto ToLectureDto(this Lecture lecture)
        {
            return new LectureDto()
            {
                Id = lecture.Id,
                Name = lecture.Name,
                LectureSchedule = lecture.LectureSchedule.ToLectureScheduleDto()
            };
        }
    }
}