using Test.Domain.Entities;

namespace Test.Domain.Interfaces;
public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee> GetEmployeeById(int id);
    Task AddEmployee(Employee empleado);
    Task UpdateEmployee(Employee empleado);
    Task DeleteEmployee(int id);
}
