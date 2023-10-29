using Careview.Scheduling.Web.Options;
using Microsoft.Extensions.Options;
using SprintPlanning.Common;
using SprintPlanning.Common.Services;
using SprintPlanning.DelegatingHandlers;
using SprintPlanning.ExternalServices.GoogleCalendar;
using SprintPlanning.ExternalServices.Jira;

namespace SprintPlanning.Configuration;

public static class DependencyInjection
{
    internal static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Add services to the container.
        var serviceProvider = services.BuildServiceProvider();
        services.AddExternalServices(serviceProvider)
            .AddSingleton<IJsonDataLoader, JsonDataLoader>();

        return services;

    }

    private static IServiceCollection AddExternalServices(this IServiceCollection services,
              IServiceProvider serviceProvider)
    {
        // Add services to the container.
        var jiraOptions = serviceProvider.GetService<IOptions<JiraOptions>>()!.Value;

        services.AddTransient<JiraAuthenticationHandler>();

        services.AddHttpClient(Constants.HttpClientGoogleCalendar);
        services.AddHttpClient(Constants.HttpClientJira, httpClient =>
        {
            // Configure the base address, timeout, etc. here
            httpClient.BaseAddress = new Uri(jiraOptions.BaseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }).AddHttpMessageHandler<JiraAuthenticationHandler>();

        services.AddScoped<IGoogleCalendarService, GoogleCalendarService>();
        services.AddScoped<IJiraService, JiraService>();

        return services;

    }

}
