using Calendar.DAL.Events;

namespace Calendar.Events
{
    public class EventsService : IEventsService
    {
        private readonly IEventRepository _eventRepository;
        public EventsService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
    }
}
