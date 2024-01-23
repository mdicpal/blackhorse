namespace FunderService.Extensions;

using Clients;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

internal static class AddFunderClientExtension
{
    internal static IServiceCollection AddFunderDependency(this IServiceCollection services)
    {
        services.AddSingleton(_ =>
        {
            string funderEndpoint =
                Environment.GetEnvironmentVariable("APIM_BASEURL") +
                Environment.GetEnvironmentVariable("FUNDER_URL");

            return new FunderClient(funderEndpoint, new HttpClient());
        });

        services.AddSingleton<IFunderClient, FunderClient>();
        return services;
    }
}