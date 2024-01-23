namespace UnitTests.ApplicationLayerTests.Extensions;

using ApplicationLayer.Extensions.Dependencies;
using Microsoft.Extensions.DependencyInjection;

public class ApplicationDependencyExtensionTests
{
    [Test]
    public void AddFunderMapperDependencies_ConfiguresServicesCorrectly()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        services.AddApplicationLayerDependencies("ODDLEV2");
        var serviceProvider = services.BuildServiceProvider();

        // Assert       
        Assert.That(serviceProvider, Is.Not.Null);

    }
}