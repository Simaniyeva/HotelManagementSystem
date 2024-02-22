using FluentValidation.AspNetCore;
using HotelAPI.Application.Utilities.Security.Encryption;
using HotelAPI.Application.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Token = HotelAPI.Application.Utilities.Security.JWT;

namespace HotelAPI.Infrastructure.Utilities.Extentions;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddControllers().AddFluentValidation(opt =>
        {
            opt.ImplicitlyValidateChildProperties = true;
            opt.ImplicitlyValidateRootCollectionElements = true;
            opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });

        //    services.AddAuthentication(opt =>
        //    {
        //        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })
        //    .AddJwtBearer(opt =>
        //    {
        //        opt.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = tokenOptions,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = tokenOptions.Issuer,
        //            ValidAudience = tokenOptions.Auidence,
        //            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        //        };
        //    });
        // ;
        services.AddAuthorization();
        //    services.AddAuthentication();
        services.AddScoped<ITokenHelper, JWTHelper>();
        //Token.TokenOptions tokenOptions = configuration.GetSection("TokenOptions").Get<Token.TokenOptions>();
        services.Scan(scan => scan.FromAssemblies(
               typeof(IApplicationAssemblyMarker).Assembly).AddClasses(@class =>
               @class.Where(type =>
               !type.Name.StartsWith('I')
               && type.Name.EndsWith("Service")))
               .UsingRegistrationStrategy(RegistrationStrategy.Skip)
               .AsImplementedInterfaces()
               .WithScopedLifetime());
        return services;
        //}
    }
}
