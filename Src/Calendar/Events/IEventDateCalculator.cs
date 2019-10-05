using System;
using System.Collections.Generic;
using Calendar.Common.Events;

namespace Calendar.Events
{
    public interface IEventDateCalculator
    {
        DateTime CalculateEventEndDate(DateTime startDate, DateTime? endDate, RecurrenceType recurrenceType, int interval, 
                                                int duration, int? occurences, FrequencyType frequencyType, List<DayOfWeek> days);
    }
}