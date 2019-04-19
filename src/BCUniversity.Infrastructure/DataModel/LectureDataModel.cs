using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;
using BCUniversity.Infrastructure.DataModel.Relationships;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("lecture")]
    public class LectureDataModel: EntityDataModelBase
    {
        public string Name { get; set; }
        
        public string SubjectId { get; set; }
        
        public SubjectDataModel Subject { get; set; }
        
        public ICollection<LectureTheatreLink> LectureTheatreLinks { get; set; }
    }
}