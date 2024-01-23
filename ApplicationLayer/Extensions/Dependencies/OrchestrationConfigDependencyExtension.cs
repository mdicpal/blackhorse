namespace ApplicationLayer.Extensions.Dependencies;

using Handlers.Config;
using ApplicationLayer.Handlers.Config.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class OrchestrationConfigDependencyExtension
{
    internal static IServiceCollection AddConfigDependencies(this IServiceCollection services)
    {
        services
            .AddSingleton<IOrchestrationConfigHandler, OrchestrationConfigHandler>();
        return services;
    }
}