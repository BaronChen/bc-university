using System;
using System.Collections.Generic;
using System.Linq;
using BCUniversity.Domain.Common;
using BCUniversity.Domain.Exceptions;

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

        public void EnrolInSubject(SubjectEnrolment subjectEnrolment)
        {
            var currentTotalSubjectHour = SubjectEnrolments.Sum(x => x.SubjectHours);

            if (currentTotalSubjectHour + subjectEnrolment.SubjectHours > 10)
            {
                throw new DomainValidationException("Subject hour longer than 10 per week.");
            }
            _subjectEnrolments.Add(subjectEnrolment);
        }
    }
}