namespace Test.UseCases.CreateEmployee;
internal sealed class CreateEmployeeInteractor : ICreateEmployeeInputPort
{
    readonly ICommandsRepository Repository;
    public CreateEmployeeInteractor(ICommandsRepository repository)
    {
        Repository = repository;
    }
    public async Task<int> CreateEmployeeAsync(CreateEmployeeDto employee)
    {
        return await Repository.CreateEmployeeAsync(employee);
    }
}
