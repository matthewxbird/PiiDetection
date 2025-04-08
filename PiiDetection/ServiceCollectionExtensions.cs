using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PiiDetection;

/// <summary>
/// Extension methods for registering PII detection services
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds PII detection services to the service collection
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddPiiDetection(this IServiceCollection services)
    {
        services.AddSingleton<PythonAddressDetector>();
        services.AddSingleton<IPiiDetector, PiiDetector>();
        return services;
    }
} 