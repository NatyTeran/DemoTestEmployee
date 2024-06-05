namespace Test.Controllers.CreateEmployee;
internal class CreateEmployeeController : ICreateEmployeeController
{
    readonly ICreateEmployeeInputPort InputPort;
    public CreateEmployeeController(ICreateEmployeeInputPort inputPort)
    {
        InputPort = inputPort;
    }
    public async Task<int> CreateEmployeeAsync(CreateEmployeeDto employee)
    {
        return await InputPort.CreateEmployeeAsync(employee);
    }
}
