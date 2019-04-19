using System.Collections.Generic;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class Lecture: Entity
    {
        public string Name { get; private set; }

        private readonly List<LectureSchedule> _lectureSchedules;
        public IEnumerable<LectureSchedule> LectureSchedules => _lectureSchedules;
       
        public Lecture(string name, List<LectureSchedule> lectureSchedules)
        {
            Name = name;
            _lectureSchedules = lectureSchedules;
        }
    }
}