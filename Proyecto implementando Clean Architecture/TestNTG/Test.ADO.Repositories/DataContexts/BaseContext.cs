using Test.ADO.Repositories.Entities;

namespace Test.ADO.Repositories.DataContexts;
internal class BaseContext : DbContext
{
    public BaseContext(IOptions<ConnectionStringsOptions> connectionStringOptions) : base(connectionStringOptions.Value.EmployeeDatabase)
    {

    }
    public DbSet<Employee> Employees { get; set; }

    protected override string GetInsertSql(object entity)
    {
        throw new NotImplementedException();
    }

    protected override string GetUpdateSql(object entity)
    {
        throw new NotImplementedException();
    }

    protected override string GetDeleteSql(object entity)
    {
        throw new NotImplementedException();
    }
}

