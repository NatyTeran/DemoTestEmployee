using Test.WebAPI.Configurations;

try
{
    WebApplication.CreateBuilder(args)
    .ConfigureWebApiServices()
    .ConfigureWebApiMiddlewares()
    .Run();

}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
    if (ex is AggregateException aggregateException)
    {
        foreach (var innerException in aggregateException.InnerExceptions)
        {
            Console.WriteLine($"Inner exception: {innerException.Message}");
        }
    }
}


