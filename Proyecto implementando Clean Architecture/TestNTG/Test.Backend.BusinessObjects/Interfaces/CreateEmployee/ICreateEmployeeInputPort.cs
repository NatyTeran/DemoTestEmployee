using Test.Shared.BusinessObjects.Dtos;

namespace Test.Backend.BusinessObjects.Interfaces.CreateEmployee;
public interface ICreateEmployeeInputPort
{
    Task<int> CreateEmployeeAsync(CreateEmployeeDto employee);
}
