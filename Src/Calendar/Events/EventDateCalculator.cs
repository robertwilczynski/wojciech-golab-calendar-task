using System;
using System.Collections.Generic;
using Calendar.Common.Events;

namespace Calendar.Events
{
    public class EventDateCalculator : IEventDateCalculator
    {
        public DateTime CalculateEventEndDate(DateTime? endDate, RecurrenceType recurrenceType, DateTime startDate, int interval, 
                                                int? occurences, FrequencyType frequencyType, List<DayOfWeek> days)
        {
            switch (recurrenceType)
            {
                case RecurrenceType.Infinite: return DateTime.MaxValue;
                case RecurrenceType.Occurrence: return CalculateOccurrenceEndDate(startDate, interval, occurences.Value, frequencyType, days);
                case RecurrenceType.TillDate:
                case RecurrenceType.None: 
                default: return endDate.Value;
            }
        }

        private DateTime CalculateOccurrenceEndDate(DateTime startDate, int interval, int occurrences, FrequencyType frequencyType, List<DayOfWeek> days)
        {
            var endDate = startDate;
            switch (frequencyType)
            {
                case FrequencyType.Daily: endDate = endDate.AddDays(occurrences * interval); break;
                case FrequencyType.Weekly: endDate = endDate.AddDays(7 * interval * occurrences); break;
                case FrequencyType.Monthly: endDate = endDate.AddMonths(occurrences * interval); break;
                case FrequencyType.Yearly: endDate = endDate.AddYears(occurrences * interval); break;
            }
            return endDate;
        }
    }
}