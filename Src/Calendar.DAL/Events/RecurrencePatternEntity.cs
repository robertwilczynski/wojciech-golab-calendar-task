using System;
using System.Collections.Generic;
using Calendar.DTO.Events;

namespace Calendar.DAL.Events
{
    public class RecurrencePatternEntity
    {
        public int Id { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public int Interval { get; set; }
        public int? Occurences { get; set; }
        public DateTime? EndDate { get; set; } 
        public List<DayOfWeek> Days { get; set; } 
    }
}