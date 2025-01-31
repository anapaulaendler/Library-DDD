using DomainIoC = Library.Domain.Extensions.IoCExtensions;
using InfraIoC = Library.Infra.Extensions.IoCExtensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Library.Application.DI;

public class Initializer
{
    public static IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
    {
        DomainIoC.Register(services, configuration);
        InfraIoC.Register(services, configuration);
        
        return services;
    }
}