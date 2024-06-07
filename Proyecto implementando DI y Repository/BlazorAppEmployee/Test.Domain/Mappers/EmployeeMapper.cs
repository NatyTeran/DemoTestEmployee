using Test.Domain.DTOs;
using Test.Domain.Entities;

namespace Test.Domain.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee ToEmployeeEntity(this EmployeeDto employee) =>
            new Employee()
            {
                Id = employee.Id,
                Nombre = employee.Nombre,
                Apellido = employee.Apellido,
                Fotografia = "",
                PuestoId = employee.PuestoId,
                FechaNacimiento = employee.FechaNacimiento,
                FechaContratacion = employee.FechaContratacion,
                Direccion = $"{employee.Address.Calle} {employee.Address.NumExt} {employee.Address.NumInt} " +
                $"{employee.Address.Colonia} {employee.Address.CodigoPostal}",
                Telefono = employee.Telefono,
                CorreoElectronico = employee.CorreoElectronico,
                EstadoId = employee.EstadoId,
            };
    }
}
