using System.Collections.Generic;
using System.Linq;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class Subject: AggregateRoot
    {
        public string Name { get; private set; }

        private readonly List<Lecture> _lectures;
        
        public IEnumerable<Lecture> Lectures => _lectures;

        public IEnumerable<StudentEnrolment> StudentEnrolments { get; }

        public Subject(string id, string name, List<Lecture> lectures,
            IEnumerable<StudentEnrolment> studentEnrolments) : base(id)
        {
            StudentEnrolments = studentEnrolments;
            Name = name;
            _lectures = lectures;
        }

        public int GetTotalHours()
        {
            return Lectures.Sum(l => l.GetLectureHours());
        }

        public bool HasCapacity()
        {
            return StudentEnrolments.Count() < Lectures.Min(l => l.GetCapacity());
        }

        public void AddLecture(Lecture lecture)
        {
            _lectures.Add(lecture);
        }
    }
}