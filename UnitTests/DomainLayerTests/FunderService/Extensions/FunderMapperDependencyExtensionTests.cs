namespace UnitTests.DomainLayerTests.FunderService.Extensions;

using ApplicationLayer.Extensions.Dependencies;
using global::FunderService.Extensions;
using Microsoft.Extensions.DependencyInjection;

public class FunderMapperDependencyExtensionTests
{
    [Test]
    public void Fundertest()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        services.AddDomainFunderDependencies();
        var serviceProvider = services.BuildServiceProvider();

        // Assert       
        Assert.That(serviceProvider, Is.Not.Null);
    }
    [Test]
    public void AddFunderMapperDependenciesCorrectly()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        services.AddDomainFunderDependencies();
        var serviceProvider0 = services.AddDomainFunderDependencies();
        var serviceProvider1 = services.AddLogging();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(serviceProvider0, Is.Not.Null);
            Assert.That(serviceProvider1, Is.Not.Null);
        });
    }

    [Test]
    public void MakeApplicationMapperDependenciesTest()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        var serviceProvider = services.AddMakeApplicationDependencies();

        // Assert       
        Assert.That(serviceProvider, Is.Not.Null);
    }

    [Test]
    public void ESignMapperDependenciesTest()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        var serviceProvider = services.AddAmendApplicationDependencies();

        // Assert       
        Assert.That(serviceProvider, Is.Not.Null);
    }

    [Test]
    public void OrchestratorConfigDependenciesTest()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        var serviceProvider = services.AddConfigDependencies();

        // Assert       
        Assert.That(serviceProvider, Is.Not.Null);
    }

    [Test]
    public void PollingConfigDependenciesTest()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        var serviceProvider = services.AddPollingDependencies();

        // Assert       
        Assert.That(serviceProvider, Is.Not.Null);
    }

    [Test]
    public void FunderUpdatedDependenciesTest()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        var serviceProvider = services.AddFunderUpdateDependencies();

        // Assert       
        Assert.That(serviceProvider, Is.Not.Null);
    }

    [Test]
    public void AmendApplicationMapperDependenciesTest()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        services.AddLogging();
        var serviceProvider = services.AddAmendApplicationDependencies();

        // Assert       
        Assert.That(serviceProvider, Is.Not.Null);
    }
}