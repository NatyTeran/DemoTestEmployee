namespace Test.UseCases;
public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICreateEmployeeInputPort, CreateEmployeeInteractor>();

        return services;
    }
}
