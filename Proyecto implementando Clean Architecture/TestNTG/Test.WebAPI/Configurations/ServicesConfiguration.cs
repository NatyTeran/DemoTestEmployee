using Test.Backend.BusinessObjects.ValueObjects.Options;
using Test.Backend.IoC;

namespace Test.WebAPI.Configurations;
internal static class ServicesConfiguration
{
    public static WebApplication ConfigureWebApiServices(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.Configure<ConnectionStringsOptions>(
            builder.Configuration.GetSection(
                ConnectionStringsOptions.SectionKey));

        builder.Services.AddBackendServices();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        return builder.Build();
    }
}