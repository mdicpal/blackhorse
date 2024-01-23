using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Orchestrator.Startup))]

namespace Orchestrator;

using Adapters;
using ApplicationLayer.Extensions.Dependencies;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Database.Extensions;
using KeyVaultService;
using System;
using Triggers;
using InstanceStoreAdapter.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Triggers.Interfaces;
using Domain;
using Domain.Logger;

public class Startup : FunctionsStartup
{
    public const string FunderCode = "BlackHorse";
    
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddLogging();
        builder.Services.RegisterInstanceStoreServiceAdapter(FunderCode);
        builder.Services.AddApplicationLayerDependencies(FunderCode);
        builder.Services.AddSingleton<IRaiseAmendmentTrigger, RaiseAmendmentTrigger>();
        builder.Services.AddSingleton<INewApplicationTrigger, NewApplicationTrigger>();
        builder.Services.AddSingleton<IFunderUpdateEventTrigger, FunderUpdateEventTrigger>();
        builder.Services.AddSingleton<ISecretClient, KeyVaultClient>();
        builder.Services.AddSingleton(_ =>
        {
            Uri clientUri = new Uri(Environment.GetEnvironmentVariable("KeyVaultEndpoint") ?? string.Empty);
            return new SecretClient(clientUri, new DefaultAzureCredential());
        });
        
        builder.Services.AddDatabaseDependencies();
        
        builder.Services.AddLogging();
        builder.Services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
    }
}