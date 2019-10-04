namespace Calendar.Events
{
    public interface IEventsService
    {
        int CreateEvent(CreateEventRequest createEventRequest);
    }
}