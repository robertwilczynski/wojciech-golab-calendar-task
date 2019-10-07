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

        private int IncludeFirstWeek(int occurences)
        {
            return occurences - 1;
        }

        private DateTime CalculateOccurrenceEndDate(DateTime startDate, int duration, int interval, int occurrences, FrequencyType frequencyType, List<DayOfWeek> days)
        {
            var endDate = startDate.AddMinutes(duration);
            switch (frequencyType)
            {
                case FrequencyType.Daily: endDate = endDate.AddDays(IncludeFirstWeek(occurrences) * interval); break;
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
                case FrequencyType.Monthly: endDate = endDate.AddMonths(IncludeFirstWeek(occurrences) * interval); break;
                case FrequencyType.Yearly: endDate = endDate.AddYears(IncludeFirstWeek(occurrences) * interval); break;
            }
            return endDate;
        }
    }
}