using System;
using System.Collections.Generic;

namespace Calendar.Common.Events
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsRecurring => RecurrenceType != RecurrenceType.None;
        public List<DateTime> ExceptionDays { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public int Interval { get; set; }
        public int? Occurences { get; set; }
        public List<DayOfWeek> Days { get; set; } 
    }
}