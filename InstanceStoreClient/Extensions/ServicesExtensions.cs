namespace InstanceStoreService.Extensions;

using Domain.Logger;
using InstanceStoreService;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Operations;

public static class ServicesExtensions
{
    private static void RegisterPutOrchestrator(this IServiceCollection services)
    {
        services.AddSingleton<IPutOrchestration, PutOrchestration>();
    }
    private static void RegisterGetOrchestrator(this IServiceCollection services)
    {
        services.AddSingleton<IGetOrchestration, GetOrchestration>();
    }

    public static void RegisterInstanceStoreService(this IServiceCollection services, string funderCode)
    {
        services.AddSingleton<IInstanceStoreClient>(s =>
        {
            string apiKey = Environment.GetEnvironmentVariable("APIM_KEY");
            string baseUrl = Environment.GetEnvironmentVariable("APIM_BASEURL");
            string instanceStoreUrl = baseUrl + Environment.GetEnvironmentVariable("INSTANCE_STORE_URL");
            
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("OCP-APIM-SUBSCRIPTION-KEY", apiKey);
            ILoggerAdapter<InstanceStoreClient> logger = s.GetRequiredService<ILoggerAdapter<InstanceStoreClient>>(); 
            InstanceStoreClient instanceStoreClient = new(httpClient, logger, funderCode)
            {
                BaseUrl = instanceStoreUrl
            };
            return instanceStoreClient;
        });
        services.RegisterPutOrchestrator();
        services.RegisterGetOrchestrator();
    }
}