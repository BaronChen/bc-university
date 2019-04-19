using System.Collections.Generic;
using BCUniversity.Domain.Common;
using BCUniversity.Domain.SubjectAggregate.ValueObjects;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class Subject: AggregateRoot
    {
        public string Name { get; private set; }
        public List<Lecture> Lectures { get; private set; }
        
        public List<StudentEnrolment> StudentEnrolments { get; private set; }

        public Subject(string name, List<Lecture> lectures, List<StudentEnrolment> studentEnrolments)
        {
            Lectures = lectures;
            StudentEnrolments = studentEnrolments;
            Name = name;
        }

        
    }
}