using Test.Backend.BusinessObjects.Interfaces.CreateEmployee;
using Test.Shared.BusinessObjects.Dtos;

namespace Test.WebAPI.Endpoints;
internal static class Employees
{
    public static WebApplication UseEmployeeEndpoints(
        this WebApplication app)
    {
        app.MapPost("/createemployee",
            async (ICreateEmployeeController controller,
                CreateEmployeeDto employee) =>
            {
                var EmployeeId = await controller.CreateEmployeeAsync(employee);
                return Results.Ok(EmployeeId);
            });

        return app;
    }
}

