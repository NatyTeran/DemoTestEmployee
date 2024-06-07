using Test.Domain.ValueObjects;

namespace Test.Domain.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? Fotografia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int PuestoId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int EstadoId { get; set; }
        public Address Address { get; set; } = new Address();
    }
}
