

namespace HotelAPI.Infrastructure.Utilities.Extentions;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(scan => scan.FromAssemblies(
               typeof(IApplicationAssemblyMarker).Assembly).AddClasses(@class =>
               @class.Where(type =>
               !type.Name.StartsWith('I')
               && type.Name.EndsWith("Service")))
               .UsingRegistrationStrategy(RegistrationStrategy.Skip)
               .AsImplementedInterfaces()
               .WithScopedLifetime());
        return services;
    }
}
