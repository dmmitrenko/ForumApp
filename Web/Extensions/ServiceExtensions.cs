using ForumApp.Entities.Models;
using ForumApp.LoggerService;
using ForumApp.Repository.Interfaces;
using ForumApp.Repository.Repositories;
using ForumApp.Service.Interfaces;
using ForumApp.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ForumApp.Web.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCORS(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
        });
    }

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options => { });

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services)
        => services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services)
        => services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }

    public static void ConfigureExternalIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ExternalIdentityContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("externalIdentityConnection")));
    }

    public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder)
    {
        return builder.AddMvcOptions(config =>
            config.OutputFormatters.Add(new CsvFormatter()));
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(n =>
        {
            n.Password.RequireDigit = true;
            n.Password.RequireLowercase = false;
            n.Password.RequireUppercase = false;
            n.Password.RequireNonAlphanumeric = false;
            n.Password.RequiredLength = 10;
            n.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<ExternalIdentityContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = Environment.GetEnvironmentVariable("SECRET");

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
    }
}
