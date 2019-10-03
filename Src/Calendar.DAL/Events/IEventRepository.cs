using System;
using System.Collections.Generic;
using Calendar.Common.Events;

namespace Calendar.DAL.Events
{
    public interface IEventRepository
    {
        int AddEvent(CalendarEvent calendarEvent);
        int RemoveEvent(int calendarEventId);
        int EditEvent(int calendarEventId, CalendarEvent calendarEvent);
        List<CalendarEvent> GetEvents(int userId, int calendarId, DateTime startDate, DateTime endDate);
    }
}