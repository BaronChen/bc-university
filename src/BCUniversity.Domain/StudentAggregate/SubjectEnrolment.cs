using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.StudentAggregate
{
    public class SubjectEnrolment: ValueObject
    {
        public string SubjectId { get; }
        
        public string SubjectName { get; }
        
        public SubjectEnrolment(string subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
    }
}