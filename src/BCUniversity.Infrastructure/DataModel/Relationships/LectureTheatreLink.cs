using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;

namespace BCUniversity.Infrastructure.DataModel.Relationships
{
    [Table("lecture_theatre_relationship")]
    public class LectureTheatreLink
    {        
        public int DayOfWeek { get; set; }
        
        public int StartHour { get; set; }
        
        public int EndHour { get; set; }
        
        public string TheatreId { get; set; }
        
        public TheatreDataModel Theatre { get; set; }

        public string LectureId { get; set; }
        
        public LectureDataModel Lecture { get; set; }
    }
}