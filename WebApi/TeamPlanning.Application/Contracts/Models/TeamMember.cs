namespace TeamPlanning.Application.Contracts.Models
{
    public class TeamMember
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public TeamMemberLocation Location { get; set; }
    }
}
