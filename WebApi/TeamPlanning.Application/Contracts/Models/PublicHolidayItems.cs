namespace TeamPlanning.Application.Contracts.Models
{
    public class PublicHolidayItems
    {
        public string description { get; set; }
        public string summary { get; set; }
        public PublicHolidayStart start { get; set; }
        public PublicHolidayEnd end { get; set; }
    }
}
