using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class StudentEnrolment: ValueObject
    {        
        public string StudentId { get; }
        public string StudentName { get; }
        
        public StudentEnrolment(string studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
        }
    }
}