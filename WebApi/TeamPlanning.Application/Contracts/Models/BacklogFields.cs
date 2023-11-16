namespace TeamPlanning.Application.Contracts.Models
{
    public class BacklogFields
    {
        public string summary { get; set; }
        public BacklogStatus status { get; set; }
        public BacklogIssueType issuetype { get; set; }
        public BacklogPriority priority { get; set; }
        public decimal customfield_10016 { get; set; }
        public List<BacklogSprint> customfield_10020 { get; set; }
        public string assignee { get; set; }
        public string created { get; set; }
        public BacklogReporter reporter { get; set; }
        public string updated { get; set; }
    }
}
