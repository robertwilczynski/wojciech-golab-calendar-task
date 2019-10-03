using System;

namespace Calendar.DAL.Events
{
    public class EventExceptionEntity
    {
        public int Id { get; set; }
        public EventEntity EventId { get; set; }
        public DateTime ExcludedDate { get; set; }
    }
}