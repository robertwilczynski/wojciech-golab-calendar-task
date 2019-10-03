using System;
using System.Collections.Generic;

namespace Calendar.DTO.Events
{
    public class RecurrencePattern
    {
        public FrequencyType FrequencyType { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public int Interval { get; set; }
        public int? Occurences { get; set; }
        public DateTime? EndDate { get; set; } 
        public List<DayOfWeek> Days { get; set; } 
    }
}