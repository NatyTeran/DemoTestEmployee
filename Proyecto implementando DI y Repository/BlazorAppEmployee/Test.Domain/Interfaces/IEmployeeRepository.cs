using Test.Domain.Entities;

namespace Test.Domain.Interfaces;
public interface IEmployeeRepository
{
    Task Add(Employee empleado);
    Task Update(Employee empleado);
    Task Delete(int id);
    Task<IEnumerable<Employee>> GetAll();
    Task<Employee> GetById(int id);
}
