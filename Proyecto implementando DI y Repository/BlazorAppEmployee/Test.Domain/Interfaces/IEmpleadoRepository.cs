using Test.Domain.Entities;

namespace Test.Domain.Interfaces;
public interface IEmpleadoRepository
{
    Task Add(Empleado empleado);
    Task Update(Empleado empleado);
    Task Delete(int id);
    Task<IEnumerable<Empleado>> GetAll();
    Task<Empleado> GetById(int id);
}
