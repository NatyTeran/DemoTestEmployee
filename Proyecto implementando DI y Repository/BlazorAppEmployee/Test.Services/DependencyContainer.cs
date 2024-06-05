using Microsoft.Extensions.DependencyInjection;
using Test.Domain.Interfaces;

namespace Test.Services;
public static class DependencyContainer
{
    public static IServiceCollection AddTestServices(
        this IServiceCollection services)
    {
        services.AddScoped<IEmpleadoService, EmpleadoService>();
        return services;
    }
}
