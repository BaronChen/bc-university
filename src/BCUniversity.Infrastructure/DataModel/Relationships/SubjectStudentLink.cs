using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string StudentId { get; set; }
        
        public StudentDataModel Student { get; set; }
        
        [Required]
        public string SubjectId { get; set; }
        
        public SubjectDataModel Subject { get; set; }
    }
}