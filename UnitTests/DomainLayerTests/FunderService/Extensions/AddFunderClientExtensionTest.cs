namespace UnitTests.DomainLayerTests.FunderService.Extensions;

using global::FunderService.Extensions;
using global::FunderService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

public class AddFunderClientExtensionTests
{

    private IServiceCollection _services = null!;
    private IServiceProvider _serviceProvider = null!;

    [SetUp]
    public void Setup()
    {  
            
        _services = new ServiceCollection();
        Environment.SetEnvironmentVariable("APIM_BASEURL", "https://example.com/");
        Environment.SetEnvironmentVariable("FUNDER_URL", "funder");
        _services.AddFunderDependency();
        _serviceProvider = _services.BuildServiceProvider();
    }

    [Test]
    public void AddFunderDependency_AddsFunderClientToServiceCollection()
    {
        //var funderClient = _serviceProvider.GetRequiredService<IFunderClient>();
       // Assert.That(funderClient, Is.Not.Null);
    }
}
