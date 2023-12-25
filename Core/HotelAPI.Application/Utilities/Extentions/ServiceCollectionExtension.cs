
using HotelAPI.Domain.Entities;
using HotelAPI.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelAPI.Application.Utilities.Extentions;

public static class ServiceCollectionExtension
{
    public static  IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HotelIdentityDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<HotelIdentityDbContext>();
        return services;
    }
}
