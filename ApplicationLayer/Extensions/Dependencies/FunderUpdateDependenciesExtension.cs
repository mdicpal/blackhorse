namespace ApplicationLayer.Extensions.Dependencies;

using Handlers.FunderUpdates;
using Handlers.FunderUpdates.Interfaces;
using Handlers.Polling;
using Handlers.Polling.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class FunderUpdateDependenciesExtension
{
    internal static IServiceCollection AddFunderUpdateDependencies(this IServiceCollection services)
    {
        services
            .AddSingleton<IPollingHandler, PollingHandler>()
            .AddSingleton<IFunderUpdateSuccessResponseMapper, FunderUpdateSuccessResponseMapper>()
            .AddSingleton<IFunderUpdateHandler, FunderUpdateHandler>();
        return services;
    }
}