namespace BCUniversity.Service.Subjects.Dtos
{
    public class LectureRequestDto
    {        
        public string Name { get; set; }
        
        public LectureScheduleRequestDto LectureSchedule { get; set; }
        
    }
}