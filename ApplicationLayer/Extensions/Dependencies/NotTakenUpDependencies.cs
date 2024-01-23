namespace ApplicationLayer.Extensions.Dependencies;

using Handlers.NotTakenUp;
using Handlers.NotTakenUp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class NotTakenUpDependencies
{
    public static IServiceCollection AddNotTakenUpDependencies(this IServiceCollection services)
    {
        return services
            .AddSingleton<INotTakenUpHandler, NotTakenUpHandler>()
            .AddSingleton<INotTakenUpActivitySuccessResponseMapper, NotTakenUpActivitySuccessResponseMapper>()
            .AddSingleton<INotTakenUpActivityFailedResponseMapper, NotTakenUpActivityFailedResponseMapper>();
    }
}