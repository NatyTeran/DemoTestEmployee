using Test.Domain.Entities;

namespace BlazorAppEmployee.Pages
{
    public partial class Index
    {
        private IEnumerable<Employee> Empleados;

        protected override async Task OnInitializedAsync()
        {
            Empleados = await EmpleadoService.GetEmployees();
        }

        private async Task EliminarEmpleado(int id)
        {
            await EmpleadoService.DeleteEmployee(id);
            Empleados = await EmpleadoService.GetEmployees();
        }
    }
}
