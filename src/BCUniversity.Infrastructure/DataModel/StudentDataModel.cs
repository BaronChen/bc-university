using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;
using BCUniversity.Infrastructure.DataModel.Relationships;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("student")]
    public class StudentDataModel : EntityDataModelBase
    {
        public string Name { get; set; }
        
        public ICollection<SubjectStudentLink> SubjectLinks { get; set; }
        
    }
}