using System.Collections.Generic;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class Lecture: Entity
    {
        public string Name { get; private set; }

        public List<LectureSchedule> LectureSchedules { get; private set; }
       
        public Lecture(string name, List<LectureSchedule> lectureSchedules)
        {
            LectureSchedules = lectureSchedules;
            Name = name;
        }
    }
}