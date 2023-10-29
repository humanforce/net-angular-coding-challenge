namespace SprintPlanning.ExternalServices.Jira.Dtos;

public record Fields(
    string Statuscategorychangedate,
    int Workratio,
    string Created,
    double Customfield_10016,
    List<SprintItem> Customfield_10020,
    string Updated,
    string Summary);

