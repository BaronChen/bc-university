namespace BCUniversity.Service.Dtos.Requests
{
    public class LectureRequestDto
    {                
        public string Name { get; set; }
        
        public LectureScheduleRequestDto LectureSchedule { get; set; }
        
    }
}