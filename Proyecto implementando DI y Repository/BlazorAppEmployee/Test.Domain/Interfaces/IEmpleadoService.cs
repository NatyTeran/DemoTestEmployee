using Test.Domain.Entities;

namespace Test.Domain.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<Empleado> GetEmpleadoById(int id);
        Task AddEmpleado(Empleado empleado);
        Task UpdateEmpleado(Empleado empleado);
        Task DeleteEmpleado(int id);
    }
}
