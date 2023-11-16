namespace TeamPlanning.Application.Data.GoogleCalendarAPI
{
    public static class CalendarID
    {
        public static Dictionary<string, string> calendarIds { get; } = new Dictionary<string, string>
        {
            { "Australia", "en.australian%23holiday%40group.v.calendar.google.com" },
            { "Philippines", "en.philippines%23holiday%40group.v.calendar.google.com" },
            { "Pakistan", "en.pk%23holiday%40group.v.calendar.google.com" }
        };
    }
}
