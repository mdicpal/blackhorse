namespace ApplicationLayer.Extensions.Dependencies
{
    using Handlers.Amendments;
    using Handlers.Amendments.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class AmendApplicationDependencyExtension
    {
        internal static IServiceCollection AddAmendApplicationDependencies(this IServiceCollection services)
        {
            services
                .AddSingleton<IAmendApplicationActivitySuccessResponseMapper, AmendApplicationActivitySuccessResponseMapper>()
                .AddSingleton<IAmendApplicationHandler, AmendApplicationHandler>();
            return services;
        }
    }
}