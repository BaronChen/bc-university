namespace BCUniversity.Service.Subjects.Dtos
{
    public class LectureScheduleRequestDto
    {
        public int DayOfWeek { get; set; }
        
        public int StartHour { get; set; }
        
        public int EndHour { get; set; }
        
        public string TheatreId { get; set; }
    }
}