namespace ApplicationLayer.Extensions.Dependencies;

using Handlers.Polling;
using Handlers.Polling.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class PollingDependencies
{
    public static IServiceCollection AddPollingDependencies(this IServiceCollection services)
    {
        return services
            .AddSingleton<IInstanceToPollDtoMapper, InstanceToPollDtoMapper>()
            .AddTransient<IDeletePollingHandler, DeletePollingHandler>()
            .AddTransient<IUpsertPollingHandler, UpsertPollingHandler>();
    }
}