using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate.ValueObjects
{
    public class StudentEnrolment: ValueObject
    {
        public string StudentId { get; private set; }
        
        public StudentEnrolment(string studentId)
        {
            StudentId = studentId;
        }
    }
}