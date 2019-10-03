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
        public bool IsRecurring => RecurrencePattern != null;
        public List<DateTime> ExceptionDays { get; set; }
        public RecurrencePattern RecurrencePattern { get; set; }
    }
}