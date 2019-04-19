using System.Collections.Generic;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.StudentAggregate
{
    public class Student: AggregateRoot
    {
        public string Name { get; private set; }


        private readonly List<SubjectEnrolment> _subjectEnrolments;
        public IEnumerable<SubjectEnrolment> SubjectEnrolments => _subjectEnrolments;
        
        public Student(string name, List<SubjectEnrolment> subjectEnrolments)
        {
            Name = name;
            _subjectEnrolments = subjectEnrolments;
        }
    }
}