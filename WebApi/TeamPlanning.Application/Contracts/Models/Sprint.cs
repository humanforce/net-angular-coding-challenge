namespace TeamPlanning.Application.Contracts.Models
{
    public class Sprint
    {
        public int id { get; set; }
        public string? self { get; set; }
        public string? state { get; set; }
        public string? name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<Backlog> backlogs { get; set; }
    }
}
