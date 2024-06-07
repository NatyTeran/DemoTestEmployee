using Microsoft.Extensions.DependencyInjection;
using Test.Domain.Interfaces;

namespace Test.Services;
public static class DependencyContainer
{
    public static IServiceCollection AddTestServices(
        this IServiceCollection services)
    {
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPositionService, PositionService>();

        return services;
    }
}
