namespace InstanceStoreAdapter.Extensions;

using InstanceStoreAdapter;
using InstanceStoreService.Extensions;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class InstanceStoreAdapterExtensions
{
    public static IServiceCollection RegisterInstanceStoreServiceAdapter(this IServiceCollection services, string funderCode)
    {
        services.RegisterInstanceStoreService(funderCode);
        services.AddSingleton<IInstanceStoreServiceAdapter, InstanceStoreServiceAdapter>();
        return services;
    }
}