using System.Text;
using Library.Domain.Interfaces;
using Library.Infra.Context;
using Library.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Library.Infra.Extensions;

public static class IoCExtensions
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddUnitOfWork(services);
        AddContext(services, configuration);
        AddAuthenticationAndAuthorization(services, configuration);

        return services;
    }

    public static void AddContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(x => x.UseSqlite(configuration.GetConnectionString(nameof(AppDbContext))));
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!))
                };
            });

        services.AddAuthorization();

        return services;
    }

}