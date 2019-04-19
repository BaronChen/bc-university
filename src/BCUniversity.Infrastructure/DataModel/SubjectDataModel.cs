using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;
using BCUniversity.Infrastructure.DataModel.Relationships;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("subject")]
    public class SubjectDataModel : EntityDataModelBase
    {
        public string Name { get; set; }
        
        public ICollection<SubjectStudentLink> StudentLinks { get; set; } 
    }
}