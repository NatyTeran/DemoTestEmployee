using System.Net.Http.Json;
using Test.Domain.Entities;
using Test.Domain.Interfaces;

namespace Test.Services;
public class EmpleadoService : IEmpleadoService
{
    private readonly HttpClient _httpClient;

    public EmpleadoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Empleado>> GetEmpleados()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Empleado>>("api/empleado");
    }

    public async Task<Empleado> GetEmpleadoById(int id)
    {
        return await _httpClient.GetFromJsonAsync<Empleado>($"api/empleado/{id}");
    }

    public async Task AddEmpleado(Empleado empleado)
    {
        await _httpClient.PostAsJsonAsync("api/empleado", empleado);
    }

    public async Task UpdateEmpleado(Empleado empleado)
    {
        await _httpClient.PutAsJsonAsync($"api/empleado/{empleado.Id}", empleado);
    }

    public async Task DeleteEmpleado(int id)
    {
        await _httpClient.DeleteAsync($"api/empleado/{id}");
    }
}
