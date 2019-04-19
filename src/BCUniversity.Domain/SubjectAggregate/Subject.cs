using System.Collections.Generic;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class Subject: AggregateRoot
    {
        public string Name { get; private set; }

        private readonly List<Lecture> _lectures;
        
        public IEnumerable<Lecture> Lectures => _lectures;

        public IEnumerable<StudentEnrolment> StudentEnrolments { get; }

        public Subject(string name, List<Lecture> lectures, IEnumerable<StudentEnrolment> studentEnrolments)
        {
            StudentEnrolments = studentEnrolments;
            Name = name;
            _lectures = lectures;
        }
    }
}