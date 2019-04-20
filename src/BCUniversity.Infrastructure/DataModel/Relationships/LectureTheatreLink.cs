using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;

namespace BCUniversity.Infrastructure.DataModel.Relationships
{
    /*
     * Use a one to one relationship for now,
     * Should be easily changed to cater multiple schedule per lecture
     */
    [Table("lecture_theatre_relationship")]
    public class LectureTheatreLink
    {   
        [Required]
        public int DayOfWeek { get; set; }
        
        [Required]
        public int StartHour { get; set; }
        
        [Required]
        public int EndHour { get; set; }
        
        [Required]
        public string TheatreId { get; set; }
        
        public TheatreDataModel Theatre { get; set; }

        [Required]
        public string LectureId { get; set; }
        
        public LectureDataModel Lecture { get; set; }
    }
}