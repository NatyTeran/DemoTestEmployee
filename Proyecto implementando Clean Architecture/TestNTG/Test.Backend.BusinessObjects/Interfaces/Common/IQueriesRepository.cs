using Test.Shared.BusinessObjects.Dtos;

namespace Test.Backend.BusinessObjects.Interfaces.Common;
public interface IQueriesRepository
{
    Task<IReadOnlyCollection<GetEmployeeDto>> GetEmployeesAsync();
    Task<GetEmployeeDto> GetEmployeeAsync(int id, string userId);
}
