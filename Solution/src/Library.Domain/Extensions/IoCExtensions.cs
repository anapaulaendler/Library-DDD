using Library.Application.Services;
using Library.Domain.Interfaces;
using Library.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Domain.Extensions;

public static class IoCExtensions
{
    public static IServiceCollection Register(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ILoanService, LoanService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}