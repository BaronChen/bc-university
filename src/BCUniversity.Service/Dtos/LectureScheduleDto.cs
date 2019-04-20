using BCUniversity.Domain.SubjectAggregate;

namespace BCUniversity.Service.Dtos
{
    public class LectureScheduleDto
    {
        public int DayOfWeek { get; set; }
        
        public int StartHour { get; set; }
        
        public int EndHour { get; set; }
        
        public TheatreDto Theatre { get; set; }
    }
    
    public static class ConvertToLectureScheduleDtoExtensions
    {
        public static LectureScheduleDto ToLectureScheduleDto(this LectureSchedule lectureSchedule)
        {
            return new LectureScheduleDto()
            {
               DayOfWeek = lectureSchedule.DayOfWeek,
               StartHour = lectureSchedule.StartHour,
               EndHour = lectureSchedule.EndHour,
               Theatre = new TheatreDto()
               {
                   Id = lectureSchedule.Theatre.TheatreId,
                   Name = lectureSchedule.Theatre.Name,
                   Capacity = lectureSchedule.Theatre.Capacity
               }
            };
        }
    }
}