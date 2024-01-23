namespace ApplicationLayer.Extensions.Dependencies
{
    using Handlers.Amendments;
    using Handlers.Amendments.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class AmendSubmitDependencyExtension
    {
        internal static IServiceCollection AddAmendSubmitDependencies(this IServiceCollection services)
        {
            services                
                .AddSingleton<IAmendSubmitSuccessResponseMapper, AmendSubmitSuccessResponseMapper>()
                .AddSingleton<IAmendSubmitActivityFailedResponseMapper, AmendSubmitActivityFailedResponseMapper>()
                .AddSingleton<IAmendSubmitHandler, AmendSubmitHandler>();
            return services;
        }
    }
}