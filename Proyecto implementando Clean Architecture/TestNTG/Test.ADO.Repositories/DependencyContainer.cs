using Microsoft.Extensions.DependencyInjection;

namespace Test.ADO.Repositories;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositoriesServices(
        this IServiceCollection services)
    {

        return services;
    }
}
