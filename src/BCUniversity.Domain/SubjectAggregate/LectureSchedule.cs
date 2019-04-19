using System;
using System.Collections.Generic;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class LectureSchedule: ValueObject
    {        
        public int DayOfWeek { get; }
        
        public int StartHour { get; }
        public int EndHour { get; }
        
        public TheatreReference Theatre { get; }

        public LectureSchedule(TheatreReference theatre, int dayOfWeek,
            int startHour, int endHour)
        {
            Theatre = theatre;
            DayOfWeek = dayOfWeek;
            StartHour = startHour;
            EndHour = endHour;
        }
    }
}