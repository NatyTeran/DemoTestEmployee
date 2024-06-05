using Test.Shared.BusinessObjects.Dtos;

namespace Test.Backend.BusinessObjects.Interfaces.Common;
public interface ICommandsRepository
{
    Task<int> CreateEmployeeAsync(CreateEmployeeDto employee);
}
