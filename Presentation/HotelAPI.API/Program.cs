using HotelAPI.Domain.Entities.Identity;
using HotelAPI.Infrastructure.Utilities.Extentions;
using HotelAPI.Persistence.DbContexts;
using HotelAPI.Persistence.Utilities.Extentions;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressMapClientErrors = true; // Optional, to suppress client error mapping
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); ;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));
//TokenOptions tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddApplicationServiceRegistration(builder.Configuration);
builder.Services.AddInfrastructureServiceRegistration(builder.Configuration);
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddApplicationServiceRegistration(builder.Configuration);
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Hotel API", Version = "v1", Description = "Hotel API Swagger Client" });
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "'Bearer yazib sonra tokeni girebilersiz'"
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference=new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }

//            },
//            Array.Empty<string>()
//        }
//    });
//});
builder.Services.AddSwaggerGen
    (c => c.SchemaFilter<EnumSchemaFilter>());

builder.Services.AddIdentity<AppUser,IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<HotelIdentityDbContext>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
