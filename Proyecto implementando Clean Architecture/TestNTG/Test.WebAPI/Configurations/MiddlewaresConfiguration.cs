using Test.WebAPI.Endpoints;

namespace Test.WebAPI.Configurations;
internal static class MiddlewaresConfiguration
{
    public static WebApplication ConfigureWebApiMiddlewares(
        this WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseEmployeeEndpoints();

        app.UseCors();

        return app;
    }
}
