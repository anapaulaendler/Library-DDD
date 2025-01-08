using Library.Application.Services;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Domain.Extensions;

public static class IoCExtensions
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        JwtConfigurations(services, configuration);
        RegisterServices(services);

        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ILoanService, LoanService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }

    public static IServiceCollection JwtConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        return services;
    }
}
