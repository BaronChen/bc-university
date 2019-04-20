using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;
using BCUniversity.Infrastructure.DataModel.Relationships;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("subject")]
    public class SubjectDataModel : EntityDataModelBase
    {
        [Required]
        public string Name { get; set; }
        
        public ICollection<LectureDataModel> Lectures { get; set; }
        
        public ICollection<SubjectStudentLink> StudentLinks { get; set; } 
    }
}