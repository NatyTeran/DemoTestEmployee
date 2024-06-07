using System.Net.Http.Json;
using Test.Domain.Entities;
using Test.Domain.Interfaces;

namespace Test.Services;
public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient) =>
        _httpClient = httpClient;


    public async Task<IEnumerable<Employee>> GetEmployees() =>
        await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/empleado");

    public async Task<Employee> GetEmployeeById(int id) =>
        await _httpClient.GetFromJsonAsync<Employee>($"api/empleado/{id}");

    public async Task AddEmployee(Employee empleado) =>
        await _httpClient.PostAsJsonAsync("api/empleado", empleado);

    public async Task UpdateEmployee(Employee empleado) =>
        await _httpClient.PutAsJsonAsync($"api/empleado/{empleado.Id}", empleado);

    public async Task DeleteEmployee(int id) =>
        await _httpClient.DeleteAsync($"api/empleado/{id}");
}
