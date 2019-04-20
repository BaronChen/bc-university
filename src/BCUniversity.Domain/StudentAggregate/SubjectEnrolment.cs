using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.StudentAggregate
{
    public class SubjectEnrolment: ValueObject
    {
        public string SubjectId { get; }
        
        public string SubjectName { get; }
        
        public int SubjectHours { get; }
        
        public SubjectEnrolment(string subjectId, string subjectName, int subjectHours)
        {
            SubjectId = subjectId;
            SubjectHours = subjectHours;
            SubjectName = subjectName;
        }
    }
}