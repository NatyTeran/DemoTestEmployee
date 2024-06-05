using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Test.Domain.Interfaces;
using Test.Domain.ValueObjects.Options;
using Test.Infraestructure.Repositories;

namespace Test.Infraestructure;
public static class DependencyContainer
{
    public static IServiceCollection AddInfraestructureServices(
        this IServiceCollection services,
        IOptions<ConnectionStringsOptions> options)
    {
        services.AddScoped<IEmpleadoRepository>(provider =>
            new EmpleadoRepository(options.Value.TestDatabase));

        return services;
    }
}

