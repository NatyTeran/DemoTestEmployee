namespace Test.Domain.ValueObjects.Options;
public class ConnectionStringsOptions
{
    public const string SectionKey = "ConnectionStrings";
    public string TestDatabase { get; set; }
}
