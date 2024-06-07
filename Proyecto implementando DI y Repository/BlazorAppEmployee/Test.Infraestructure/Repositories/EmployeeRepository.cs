using System.Data.SqlClient;
using Test.Domain.Entities;
using Test.Domain.Interfaces;

namespace Test.Infraestructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string ConnectionString;

        public EmployeeRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task Add(Employee empleado)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Empleados (Fotografia, Nombre, Apellido, PuestoId, FechaNacimiento, FechaContratacion, Direccion, Telefono, CorreoElectronico, EstadoId) VALUES (@Fotografia, @Nombre, @Apellido, @PuestoId, @FechaNacimiento, @FechaContratacion, @Direccion, @Telefono, @CorreoElectronico, @EstadoId)", conn);
                cmd.Parameters.AddWithValue("@Fotografia", empleado.Fotografia);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                cmd.Parameters.AddWithValue("@PuestoId", empleado.PuestoId);
                cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion);
                cmd.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("@CorreoElectronico", empleado.CorreoElectronico);
                cmd.Parameters.AddWithValue("@EstadoId", empleado.EstadoId);
                cmd.ExecuteNonQuery();
            }
        }

        public async Task Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Empleados WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var empleados = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Empleados", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empleados.Add(new Employee
                        {
                            Id = (int)reader["Id"],
                            Fotografia = reader["Fotografia"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            PuestoId = (int)reader["PuestoId"],
                            FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                            FechaContratacion = (DateTime)reader["FechaContratacion"],
                            Direccion = reader["Direccion"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            CorreoElectronico = reader["CorreoElectronico"].ToString(),
                            EstadoId = (int)reader["EstadoId"]
                        });
                    }
                }
            }
            return empleados;
        }

        public async Task<Employee> GetById(int id)
        {
            Employee empleado = null;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Empleados WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        empleado = new Employee
                        {
                            Id = (int)reader["Id"],
                            Fotografia = reader["Fotografia"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            PuestoId = (int)reader["PuestoId"],
                            FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                            FechaContratacion = (DateTime)reader["FechaContratacion"],
                            Direccion = reader["Direccion"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            CorreoElectronico = reader["CorreoElectronico"].ToString(),
                            EstadoId = (int)reader["EstadoId"]
                        };
                    }
                }
            }
            return empleado;
        }

        public async Task Update(Employee empleado)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Empleados SET Fotografia = @Fotografia, Nombre = @Nombre, Apellido = @Apellido, PuestoId = @PuestoId, FechaNacimiento = @FechaNacimiento, FechaContratacion = @FechaContratacion, Direccion = @Direccion, Telefono = @Telefono, CorreoElectronico = @CorreoElectronico, EstadoId = @EstadoId WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", empleado.Id);
                cmd.Parameters.AddWithValue("@Fotografia", empleado.Fotografia);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                cmd.Parameters.AddWithValue("@PuestoId", empleado.PuestoId);
                cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion);
                cmd.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("@CorreoElectronico", empleado.CorreoElectronico);
                cmd.Parameters.AddWithValue("@EstadoId", empleado.EstadoId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
