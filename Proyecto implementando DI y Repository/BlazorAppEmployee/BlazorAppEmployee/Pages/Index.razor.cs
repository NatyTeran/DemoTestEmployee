using Test.Domain.Entities;

namespace BlazorAppEmployee.Pages
{
    public partial class Index
    {
        private IEnumerable<Empleado> Empleados;

        protected override async Task OnInitializedAsync()
        {
            Empleados = await EmpleadoService.GetEmpleados();
        }

        private async Task EliminarEmpleado(int id)
        {
            await EmpleadoService.DeleteEmpleado(id);
            Empleados = await EmpleadoService.GetEmpleados();
        }
    }
}
