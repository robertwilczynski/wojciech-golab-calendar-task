using System;

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
        public RecurrencePatternEntity RecurrencePattern { get; set; }
    }
}