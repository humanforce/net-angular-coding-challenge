using Careview.Scheduling.Web.Common.OptionsSetup;

internal static partial class DependencyInjectionSetupOptions
{
    internal static IServiceCollection ConfigureSetupOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<GoogleCalendarOptionsSetup>();
        services.ConfigureOptions<JiraOptionsSetup>();

        return services;

    }
}