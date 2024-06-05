using Test.Shared.BusinessObjects.Dtos;

namespace Test.Backend.BusinessObjects.Interfaces.CreateEmployee;
public interface ICreateEmployeeController
{
    Task<int> CreateEmployeeAsync(CreateEmployeeDto employee);
}
