namespace Test.FrontEnd.BusinessObjects.ValueObjects.Options;
public class EndpointsOptions
{
    public const string SectionKey = "Endpoints";
    public string WebApiBaseAddress { get; set; }
    public string CreateEmployee { get; set; }
    public string UpdateEmployee { get; set; }
    public string DeleteEmployee { get; set; }
    public string GetEmployees { get; set; }
    public string GetEmployee { get; set; }
}
