namespace ApplicationLayer.Extensions.Dependencies;

using Handlers.MakeApplication;
using Handlers.MakeApplication.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class MakeApplicationDependencyExtension
{
    internal static IServiceCollection AddMakeApplicationDependencies(this IServiceCollection services)
    {
        services
            .AddSingleton<IMakeApplicationActivitySuccessResponseMapper, MakeApplicationActivitySuccessResponseMapper>()
            .AddSingleton<IMakeApplicationActivityFailedResponseMapper, MakeApplicationActivityFailedResponseMapper>()
            .AddSingleton<IMakeApplicationHandler, MakeApplicationHandler>();
        return services;
    }
}