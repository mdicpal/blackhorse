namespace FunderService.Extensions;

using Microsoft.Extensions.DependencyInjection;

public static class AddDomainFunderDependencyExtension
{
    public static IServiceCollection AddDomainFunderDependencies(this IServiceCollection services)
    {
        return services
            .AddFunderDependency()
            .AddFunderMapperDependencies();
    }
}