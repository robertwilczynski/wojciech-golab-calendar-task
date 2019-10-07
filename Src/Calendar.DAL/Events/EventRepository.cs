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
        
        private Days? TranslateToFlags(List<DayOfWeek> days)
        {
            Days? flags = null;
            foreach (var day in days)
            {
                if(Enum.TryParse(day.ToString(), out Days result))
                {
                    if (flags == null)
                    {
                        flags = result;
                    }
                    else
                    {
                        flags = flags | result;
                    }
                }
                else
                {
                    throw new FormatException($"Given day {day.ToString()} cannot be converted to Days enum");
                }
            }
            return flags;
        }

        public int AddEvent(CalendarEvent calendarEvent)
        {
            if (calendarEvent == null)
            {
                throw new ArgumentNullException(nameof(calendarEvent));
            }
            var eventEntity = new EventEntity
            {
                Duration = calendarEvent.Duration,
                EndDate = calendarEvent.EndDate,
                FrequencyType = calendarEvent.FrequencyType,
                Interval = calendarEvent.Interval,
                IsAllDay = calendarEvent.IsAllDay,
                Name = calendarEvent.Name,
                Occurences = calendarEvent.Occurences,
                RecurrenceType = calendarEvent.RecurrenceType,
                StartDate = calendarEvent.StartDate,
                Days = TranslateToFlags(calendarEvent.Days),
            };
            _dbContext.Events.Add(eventEntity);
            _dbContext.SaveChanges();
            return eventEntity.Id;
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