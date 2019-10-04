using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Calendar.Common.Events;
using Calendar.DAL.Events;

namespace Calendar.Events
{
    public class EventsService : IEventsService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventDateCalculator _eventDateCalculator;
        private readonly IEventsValidator _eventRequestsValidator;
        public EventsService(IEventRepository eventRepository, IEventDateCalculator eventDateCalculator, IEventsValidator eventsValidator)
        {
            _eventRepository = eventRepository;
            _eventDateCalculator = eventDateCalculator;
            _eventRequestsValidator = eventsValidator;
        }
        public int CreateEvent(CreateEventRequest request)
        {                
            var errors = _eventRequestsValidator.ValidateCreateEventRequest(request);
            if (errors.Count > 0)
            {
                throw new ValidationException();
            }
            var endDate = _eventDateCalculator.CalculateEventEndDate(request.EndDate, request.RecurrenceType, request.StartDate, request.Interval, 
                                                request.Occurences, request.FrequencyType, request.Days);
            return _eventRepository.AddEvent(new CalendarEvent
            {
                Duration = request.Duration,
                EndDate = endDate,
                IsAllDay = request.IsAllDay,
                Name = request.Name,
                StartDate = request.StartDate,
                Days = request.Days,
                FrequencyType = request.FrequencyType,
                Interval = request.Interval,
                RecurrenceType = request.RecurrenceType,
                Occurences = request.Occurences,
            });
        }
    }
}
