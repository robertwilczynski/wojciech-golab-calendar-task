using System;
using System.Collections.Generic;
using Calendar.Common.Events;

namespace Calendar.Events
{
    public class EventDateCalculator : IEventDateCalculator
    {
        public DateTime CalculateEventEndDate(DateTime startDate, DateTime? endDate, RecurrenceType recurrenceType, int interval, 
                                                int duration, int? occurences, FrequencyType frequencyType, List<DayOfWeek> days)
        {
            switch (recurrenceType)
            {
                case RecurrenceType.Infinite: return DateTime.MaxValue;
                case RecurrenceType.Occurrence: return CalculateOccurrenceEndDate(startDate, duration, interval, occurences.Value, frequencyType, days);
                case RecurrenceType.TillDate:
                case RecurrenceType.None: 
                default: return endDate.Value;
            }
        }

        private DateTime CalculateOccurrenceEndDate(DateTime startDate, int duration, int interval, int occurrences, FrequencyType frequencyType, List<DayOfWeek> days)
        {
            var endDate = startDate.AddMinutes(duration);
            switch (frequencyType)
            {
                case FrequencyType.Daily: endDate = endDate.AddDays((occurrences - 1) * interval); break;
                case FrequencyType.Weekly:
                {
                    var daysInLastWeek = occurrences <= days.Count ? occurrences : (occurrences % days.Count == 0 ? days.Count : occurrences % days.Count);
                    var amountOfWeeks = (occurrences - daysInLastWeek)/days.Count;
                    endDate = endDate.AddDays((7 * interval) * (amountOfWeeks));                    
                    var date = endDate;
                    while (daysInLastWeek > 0)
                    {
                        if (days.Contains(date.DayOfWeek))
                        {
                            endDate = date;
                            daysInLastWeek--;        
                        }
                        date = date.AddDays(1);
                    } 
                    break;
                }
                case FrequencyType.Monthly: endDate = endDate.AddMonths((occurrences - 1) * interval); break;
                case FrequencyType.Yearly: endDate = endDate.AddYears((occurrences - 1) * interval); break;
            }
            return endDate;
        }
    }
}