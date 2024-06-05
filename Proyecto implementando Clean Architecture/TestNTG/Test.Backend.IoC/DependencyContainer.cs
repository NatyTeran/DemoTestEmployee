using Microsoft.Extensions.DependencyInjection;
using Test.ADO.Repositories;
using Test.Controllers;
using Test.UseCases;

namespace Test.Backend.IoC;
public static class DependendencyContainer
{
    public static IServiceCollection AddBackendServices(
        this IServiceCollection services)
    {
        services.AddUseCasesServices()
            .AddRepositoriesServices()
            .AddControllersServices();
        //.AddPresentersServices()

        return services;
    }
}
