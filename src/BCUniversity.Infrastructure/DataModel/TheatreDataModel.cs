using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;
using BCUniversity.Infrastructure.DataModel.Relationships;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("theatre")]
    public class TheatreDataModel: EntityDataModelBase
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Capacity { get; set; }
        
        public ICollection<LectureTheatreLink> Lectures { get; set; }
    }
}