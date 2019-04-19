using System.ComponentModel.DataAnnotations.Schema;

namespace BCUniversity.Infrastructure.DataModel.Relationships
{
    /*
     * EntityFramework core is not supporting many to many directly, and this feature is being developed
     * https://github.com/aspnet/EntityFrameworkCore/issues/10508
     */
    [Table("subject_student_relationship")]
    public class SubjectStudentLink
    {
        public string StudentId { get; set; }
        
        public StudentDataModel Student { get; set; }
        
        public string SubjectId { get; set; }
        
        public SubjectDataModel Subject { get; set; }
    }
}