namespace ApplicationLayer.Extensions.Dependencies
{
    using Handlers.Plans;
    using Handlers.Plans.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class PlanDependencyExtension
    {
        internal static IServiceCollection AddAllPlanDependencies(this IServiceCollection services)
        {
            services                
                .AddSingleton<IPlanHandler, PlanHandler>();
            return services;
        }
    }
}