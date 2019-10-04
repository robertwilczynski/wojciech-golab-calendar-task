using System;
using System.Collections.Generic;
using Calendar.Common.Events;

namespace Calendar.Events
{
    public class EventDateCalculator : IEventDateCalculator
    {
        public DateTime CalculateEventEndDate(DateTime endDate, RecurrenceType recurrenceType, DateTime startDate, int interval, 
                                                int? occurences, FrequencyType frequencyType, List<DayOfWeek> days)
        {
            var date = endDate;
            if (recurrenceType != RecurrenceType.None)
            {
                switch (recurrenceType)
                {
                    case RecurrenceType.Infinite: endDate = DateTime.MaxValue; break;
                    case RecurrenceType.Occurrence: endDate = CalculateOccurrenceEndDate(startDate, interval, occurences.Value, frequencyType, days); break;
                    case RecurrenceType.TillDate: break;
                }
            }
            return date;
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