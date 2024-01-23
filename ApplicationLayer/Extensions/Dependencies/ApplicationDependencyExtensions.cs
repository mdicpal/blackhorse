namespace ApplicationLayer.Extensions.Dependencies;

using ApplicationLayer.Interfaces;
using FunderService.Extensions;
using Handlers;
using Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationDependencyExtensions
{
    public static IServiceCollection AddApplicationLayerDependencies(this IServiceCollection services, string funderCode)
    {
        services.AddSingleton<ICommonResponseMapper, CommonResponseMapper>(_ => new CommonResponseMapper(funderCode));
        services.AddSingleton<IValidationFailedResponseMapper, ValidationFailedResponseMapper>();
        services.AddMakeApplicationDependencies();       
        services.AddAmendApplicationDependencies();
        services.AddAmendSubmitDependencies();
        services.AddDomainFunderDependencies();
        services.AddFunderUpdateDependencies();
        services.AddAllPlanDependencies();
        services.AddPollingDependencies();
        services.AddConfigDependencies();
        services.AddNotTakenUpDependencies();
        return services;
    }
}