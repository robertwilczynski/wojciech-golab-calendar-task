using System.Collections.Generic;

namespace Calendar.Events
{
    public class EventsValidator : IEventsValidator
    {
        public List<string> ValidateCreateEventRequest(CreateEventRequest createEventRequest)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(createEventRequest.Name))
            {
                errors.Add("Nazwa wydarzenia nie może być pusta");
            }


            return errors;
        }
    }
}