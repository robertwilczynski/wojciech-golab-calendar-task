using System;
using System.Collections.Generic;
using Calendar.Common.Events;

namespace Calendar.Events
{
    public class CreateEventRequest
    {
        public int CalendarId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public bool IsAllDay { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public int Interval { get; set; }
        public int? Occurences { get; set; }
        public List<DayOfWeek> Days { get; set; }
    }
}