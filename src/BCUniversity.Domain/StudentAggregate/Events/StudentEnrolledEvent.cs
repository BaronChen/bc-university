using BCUniversity.Domain.Common.Events;

namespace BCUniversity.Domain.StudentAggregate.Events
{
    public class StudentEnrolledEvent : DomainEvent
    {
        public string SubjectName { get; set; }
        
        public string StudentName { get; set; }
        
        public string SubjectId { get; set; }
        
        public string StudentId { get; set; }
    }
}