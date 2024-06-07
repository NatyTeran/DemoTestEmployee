using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Test.BlazorApp;
using Test.BlazorApp.Services;
using Test.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7115/") }); // url web api
builder.Services.AddTestServices();
builder.Services.AddScoped<EmployeeState>();

await builder.Build().RunAsync();
