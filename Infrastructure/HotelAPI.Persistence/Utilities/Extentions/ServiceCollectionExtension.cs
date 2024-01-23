using HotelAPI.Domain.Entities.Identity;
using HotelAPI.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelAPI.Persistence.Utilities.Extentions;

public static class ServiceCollectionExtension
{
    public static  IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(scan => scan.FromAssemblies(
               typeof(IInfrastructureAssemblyMarker).Assembly).AddClasses(@class =>
               @class.Where(type =>
               !type.Name.StartsWith('I')
               && type.Name.EndsWith("Repository")))
               .UsingRegistrationStrategy(RegistrationStrategy.Skip)
               .AsImplementedInterfaces()
               .WithScopedLifetime());

        services.AddDbContext<HotelIdentityDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<HotelIdentityDbContext>();
        return services;
    }
}
