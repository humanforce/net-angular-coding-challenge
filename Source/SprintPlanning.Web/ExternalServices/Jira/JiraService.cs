using Careview.Scheduling.Web.Options;
using SprintPlanning.ExternalServices.Jira.Dtos;
using Microsoft.Extensions.Options;
using SprintPlanning.Common.Services;
using SprintPlanning.Common;
using SprintPlanning.Common.Extensions;

namespace SprintPlanning.ExternalServices.Jira;

public sealed class JiraService : IJiraService
{
    private readonly HttpClient _httpClient;
    private readonly JiraOptions _jiraOptions;
    private readonly ILogger<JiraService> _logger;
    private readonly IJsonDataLoader _jsonDataLoader;
    public JiraService(
        IHttpClientFactory httpClientFactory,
       IOptions<JiraOptions> jiraOptions,
        ILogger<JiraService> logger,
        IJsonDataLoader jsonDataLoader)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpClientJira);
        _jiraOptions = jiraOptions.Value;
        _logger = logger;
        _jsonDataLoader = jsonDataLoader;
    }

    public async Task<Sprint> GetSprint(CancellationToken cancellationToken)
    {
        Sprint sprint;
        try
        {
            sprint = await _httpClient.GetAsync<Sprint>(
               _jiraOptions.SprintsEndPoint,
               cancellationToken);


        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred: {ErrorMessage}", ex.Message);
            sprint = await _jsonDataLoader.LoadAsync<Sprint>(
               "wwwroot/Data/JiraAPI/sprints.json",
               cancellationToken);
        }

        return sprint;
    }

    public async Task<Backlog> GetBacklog(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.PostAsync<JiraSearchBacklogRequest, Backlog>(
                new JiraSearchBacklogRequest("SCRUM"),
                _jiraOptions.SearchEndPoint,
                cancellationToken);

            if (response.Value == null)
            {
                throw new ArgumentException("Backlog was not found");
            }

            return response.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred: {ErrorMessage}", ex.Message);
            return await _jsonDataLoader.LoadAsync<Backlog>(
                "wwwroot/Data/JiraAPI/backlog.json",
                cancellationToken);
        }

    }





}
