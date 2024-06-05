using System.Reflection;

namespace Test.ADO.SqlServer;
public abstract class DbContext
{
    string ConnectionString;
    public DbContext(string connectionString)
    {
        ConnectionString = connectionString;
        GetDbSets();
        ConfigureDbSets();
    }

    public TEntity Add<TEntity>(TEntity entity) where TEntity : new() => GetDbSet<TEntity>().Add(entity);

    public TEntity Get<TEntity>(Func<string> condition) where TEntity : new() => GetDbSet<TEntity>().Get(condition);

    public TEntity GetDataWithJoin<TEntity>(string stringSelect, string stringJoin, Func<string> condition) where TEntity : new() =>
        GetDbSet<TEntity>().GetDataWithJoin(stringSelect, stringJoin, condition);

    public List<TEntity> GetAllDataWithJoin<TEntity>(string stringSelect, string stringJoin, Func<string> condition) where TEntity : new() =>
       GetDbSet<TEntity>().GetAllDataWithJoin(stringSelect, stringJoin, condition);

    public TEntity ExecuteSQL<TEntity>(string Sql) where TEntity : new() => GetDbSet<TEntity>().ExecuteSQL(Sql);

    public int Update<TEntity>(TEntity entity) where TEntity : new() => GetDbSet<TEntity>().Update(entity);

    public int Delete<TEntity>(TEntity entity) where TEntity : new() => GetDbSet<TEntity>().Delete(entity);

    private DbSet<TEntity> GetDbSet<TEntity>() where TEntity : new() => (DbSet<TEntity>)DbSets[typeof(TEntity)];

    private void ConfigureDbSets()
    {
        foreach (var DbSet in DbSets)
        {
            var ConfigureMethod = DbSet.Value.GetType().GetMethod("Configure",
                BindingFlags.NonPublic | BindingFlags.Instance);

            ConfigureMethod.Invoke(DbSet.Value,
                new object[] {
                        ConnectionString,
                        TableNames,
                        (Func<object, string>)GetInsertSql,
                        (Func<object, string>)GetUpdateSql,
                        (Func<object, string>)GetDeleteSql
                });
        }
    }

    private void GetDbSets()
    {
        var Properties = this.GetType().GetProperties();
        foreach (var property in Properties)
        {
            Type BaseType = property.PropertyType;

            if (BaseType.Name == typeof(DbSet<>).Name) //
            {
                var DbSetBaseInstance = Activator.CreateInstance(BaseType); //Crea una instancia

                property.SetValue(this, DbSetBaseInstance);

                var GenericType = BaseType.GenericTypeArguments[0];

                DbSets.Add(GenericType, DbSetBaseInstance);
                TableNames.Add(GenericType, property.Name);
            }
        }
    }

    Dictionary<Type, object> DbSets = new Dictionary<Type, object>(); //Tipo tabla
    Dictionary<Type, string> TableNames = new Dictionary<Type, string>(); //Nombre tabla

    protected abstract string GetInsertSql(object entity);
    protected abstract string GetUpdateSql(object entity);
    protected abstract string GetDeleteSql(object entity);
}

