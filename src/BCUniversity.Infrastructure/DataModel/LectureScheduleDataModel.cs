using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("lecture_schedule")]
    public class LectureScheduleDataModel: EntityDataModelBase
    {        
        public int DayOfWeek { get; private set; }
        
        public int StartHour { get; private set; }
        
        public int EndHour { get; private set; }
        
        public string TheatreId { get; set; }
        
        public TheatreDataModel Theatre { get; set; }

        public string LectureId { get; set; }
        
        public LectureDataModel Lecture { get; set; }
    }
}