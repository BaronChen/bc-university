using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;
using BCUniversity.Infrastructure.DataModel.Relationships;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("lecture")]
    public class LectureDataModel: EntityDataModelBase
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string SubjectId { get; set; }
        
        public SubjectDataModel Subject { get; set; }
        
        public LectureTheatreLink LectureTheatreLink { get; set; }
    }
}