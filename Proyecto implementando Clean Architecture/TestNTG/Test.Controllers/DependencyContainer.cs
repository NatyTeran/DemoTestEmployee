using Test.Controllers.CreateEmployee;

namespace Test.Controllers;
public static class DependencyContainer
{
    public static IServiceCollection AddControllersServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICreateEmployeeController, CreateEmployeeController>();
        return services;
    }
}
