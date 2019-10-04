using System;
using System.Collections.Generic;
using Calendar.Common.Events;

namespace Calendar.Events
{
    public interface IEventDateCalculator
    {
        DateTime CalculateEventEndDate(DateTime endDate, RecurrenceType recurrenceType, DateTime startDate, int interval, 
                                                int? occurences, FrequencyType frequencyType, List<DayOfWeek> days);
    }
}