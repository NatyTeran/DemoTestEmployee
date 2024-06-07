using Test.Domain.DTOs;
namespace Test.BlazorApp.Services;
public class EmployeeState
{
    public EmployeeDto Employee { get; private set; } = new();

    public void Reset()
    {
        Employee = new EmployeeDto();
    }
}
