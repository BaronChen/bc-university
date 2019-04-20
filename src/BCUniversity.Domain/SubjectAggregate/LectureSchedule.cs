using System;
using System.Collections.Generic;
using BCUniversity.Domain.Common;
using BCUniversity.Domain.Exceptions;

namespace BCUniversity.Domain.SubjectAggregate
{
    /*
     * Set up LectureSchedule as a value object of lecture
     * as we may want one lecture may have more than one schedule in the future 
     */
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
            if (dayOfWeek < 1 || dayOfWeek > 7)
            {
                throw new DomainValidationException($"Invalid dayOfWeek {dayOfWeek}");
            }
            
            if (startHour < 0 || endHour < 0 || endHour <=- startHour)
            {
                throw new DomainValidationException($"Invalid startHour/endHour");
            }
            DayOfWeek = dayOfWeek;
            StartHour = startHour;
            EndHour = endHour;
        }
    }
}