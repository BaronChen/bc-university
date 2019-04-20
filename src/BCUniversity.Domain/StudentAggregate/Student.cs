using System;
using System.Collections.Generic;
using System.Linq;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.StudentAggregate
{
    public class Student: AggregateRoot
    {
        public string Name { get; private set; }


        private readonly List<SubjectEnrolment> _subjectEnrolments;
        public IEnumerable<SubjectEnrolment> SubjectEnrolments => _subjectEnrolments;
        
        public Student(string id, string name, List<SubjectEnrolment> subjectEnrolments): base(id)
        {
            Name = name;
            _subjectEnrolments = subjectEnrolments;
        }

        public void EnrolToSubject(string subjectId)
        {
            if (string.IsNullOrWhiteSpace(subjectId))
            {
                throw new ArgumentException("Invalid subject Id");
            }

            if (_subjectEnrolments.Any(x => x.SubjectId == subjectId))
            {
                return;
            }
            
            _subjectEnrolments.Add(new SubjectEnrolment(subjectId, ""));
        }
    }
}