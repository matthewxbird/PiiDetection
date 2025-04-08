using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using PiiDetection;

namespace PiiDetection.Tests;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddPiiDetection_ShouldRegisterSingleton()
    {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddPiiDetection();
        
        // Assert
        var piiDetectorDescriptor = services.FirstOrDefault(sd => sd.ServiceType == typeof(IPiiDetector));
        Assert.NotNull(piiDetectorDescriptor);
        Assert.Equal(ServiceLifetime.Singleton, piiDetectorDescriptor.Lifetime);
        Assert.Equal(typeof(PiiDetector), piiDetectorDescriptor.ImplementationType);
    }
} 