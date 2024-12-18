using Library.Domain.Interfaces;
using Library.Domain.Services;
using Library.Infra.Context;
using Library.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.DI;

public class Initializer
{
    public static void Configure (IServiceCollection services, string connection)
    {
        services.AddDbContext<AppDbContext> (options => options.UseSqlite(connection));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookService>();

        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<ILoanService, LoanService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
    }
}