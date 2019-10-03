using System;
using System.Collections.Generic;
using Calendar.Common.Events;

namespace Calendar.DAL.Events
{
    public class EventRepository : IEventRepository
    {
        private readonly CalendarContext _dbContext;
        public EventRepository(CalendarContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public int AddEvent(CalendarEvent calendarEvent)
        {
            throw new System.NotImplementedException();
        }

        public int EditEvent(int calendarEventId, CalendarEvent calendarEvent)
        {
            throw new System.NotImplementedException();
        }

        public List<CalendarEvent> GetEvents(int userId, int calendarId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public int RemoveEvent(int calendarEventId)
        {
            throw new System.NotImplementedException();
        }
    }
}