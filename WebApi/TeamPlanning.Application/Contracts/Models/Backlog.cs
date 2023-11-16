namespace TeamPlanning.Application.Contracts.Models
{
    public class Backlog
    {
        public string self { get; set; }
        public string key { get; set; }
        public BacklogFields fields { get; set; }
    }
}
