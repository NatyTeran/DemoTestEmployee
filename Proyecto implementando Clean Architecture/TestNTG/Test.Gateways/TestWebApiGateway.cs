using System.Net.Http.Json;
using Test.Shared.BusinessObjects.Dtos;

namespace Test.Gateways;
internal sealed class TestWebApiGateway : ITestWebApiGateway
{
    readonly HttpClient Client;
    readonly EndpointsOptions EndpointsOptions;

    public TestWebApiGateway(HttpClient client, IOptions<EndpointsOptions> endpointsOptions)
    {
        Client = client;
        EndpointsOptions = endpointsOptions.Value;
    }

    public async Task<int> CreateEmployeeAsync(CreateEmployeeDto employee)
    {
        var Response = await Client
            .PostAsJsonAsync(EndpointsOptions.CreateEmployee, employee);

        return await Response.Content.ReadFromJsonAsync<int>();
    }
}
