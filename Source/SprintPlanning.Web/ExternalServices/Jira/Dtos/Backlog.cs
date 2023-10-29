namespace SprintPlanning.ExternalServices.Jira.Dtos;

public class Backlog
{
    public string Expand { get; set; } = string.Empty;
    public int StartAt { get; set; }
    public int MaxResults { get; set; }
    public int Total { get; set; }
    public List<Ticket> Issues { get; set; } = new List<Ticket>();

}
