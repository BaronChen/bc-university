using System.Collections.Generic;
using BCUniversity.Domain.Common;
using BCUniversity.Domain.Exceptions;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class Lecture: Entity
    {
        public string Name { get; private set; }

        public LectureSchedule LectureSchedule { get; }
       
        public Lecture(string id, string name, LectureSchedule lectureSchedule) : base(id)
        {
            Name = name;
            
            if (lectureSchedule == null)
            {
                throw new DomainValidationException("Lecture has to have a schedule");
            }
            
            LectureSchedule = lectureSchedule;
        }

        public int GetLectureHours()
        {
            return LectureSchedule.EndHour - LectureSchedule.StartHour;
        }

        public int GetCapacity()
        {
            return LectureSchedule.Theatre.Capacity ?? 0;
        }
    }
}