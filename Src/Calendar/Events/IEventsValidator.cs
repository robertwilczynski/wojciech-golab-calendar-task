using System.Collections.Generic;

namespace Calendar.Events
{
    public interface IEventsValidator
    {
        List<string> ValidateCreateEventRequest(CreateEventRequest createEventRequest); 
    }
}