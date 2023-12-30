using HotelAPI.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelAPI.Persistence.Utilities.Extentions;

public static class ServiceCollectionExtension
{
    public static  IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<HotelIdentityDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<HotelIdentityDbContext>();
        return services;
    }
}
