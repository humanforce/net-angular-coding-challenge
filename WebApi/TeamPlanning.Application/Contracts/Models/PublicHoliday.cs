namespace TeamPlanning.Application.Contracts.Models
{
    public class PublicHoliday
    {
        public string description { get; set; }
        public string summary { get; set; }
        public List<PublicHolidayItems> items { get; set; }
    }
}
