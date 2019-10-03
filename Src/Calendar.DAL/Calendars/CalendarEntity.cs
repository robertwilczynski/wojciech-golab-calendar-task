using Calendar.DAL.Users;

namespace Calendar.DAL.Calendars
{
    public class CalendarEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserEntity Owner { get; set; }
    }
}