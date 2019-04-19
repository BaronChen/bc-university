using System;
using System.Collections.Generic;
using BCUniversity.Domain.Common;
using BCUniversity.Domain.SubjectAggregate.ValueObjects;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class LectureSchedule: Entity
    {
        public string Name { get; private set; }
        
        public int DayInWeek { get; private set; }
        
        /* *
         * as timetable clashed is not in the requirement,
         * I will just use a total hour here instead of custom time object for start and end time
         * */ 
        public decimal Hours { get; private set; }
        
        public List<TheatreReference> Theatres { get; private set; }

        public LectureSchedule(string name, List<TheatreReference> theatres, decimal hours, int dayInWeek)
        {
            Theatres = theatres;
            Hours = hours;
            DayInWeek = dayInWeek;
            Name = name;
        }
    }
}