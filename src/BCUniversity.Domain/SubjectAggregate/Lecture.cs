using System.Collections.Generic;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class Lecture: Entity
    {
        public string Name { get; private set; }

        public LectureSchedule LectureSchedule { get; }
       
        public Lecture(string id, string name, LectureSchedule lectureSchedule) : base(id)
        {
            Name = name;
            LectureSchedule = lectureSchedule;
        }
    }
}