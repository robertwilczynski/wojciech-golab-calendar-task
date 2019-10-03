using System;
using Calendar.Common.Events;

namespace Calendar.DAL.Events
{
    public class EventEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public bool IsAllDay { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public int Interval { get; set; }
        public int? Occurences { get; set; }
        public Days Days { get; set; } 
    }
}