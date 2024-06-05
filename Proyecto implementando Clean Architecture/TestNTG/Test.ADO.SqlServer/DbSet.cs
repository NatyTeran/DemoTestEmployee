namespace Test.ADO.SqlServer;
public class DbSet<TEntity> where TEntity : new()
{
    string ConnectionString;
    Dictionary<Type, string> TableNames;

    Func<TEntity, string> GetInsertSql;
    Func<TEntity, string> GetUpdateSql;
    Func<TEntity, string> GetDeleteSql;

    public TEntity Add(TEntity entity)
    {
        string SqlQuery = GetInsertSql(entity);
        return ADOHelper.GetEntity<TEntity>(SqlQuery, ConnectionString);
    }

    public TEntity Get(Func<string> condition = null)
    {
        string SqlQuery = $"SELECT * FROM {TableNames[typeof(TEntity)]} WHERE {condition()}";
        return ADOHelper.GetEntity<TEntity>(SqlQuery, ConnectionString);
    }

    public TEntity GetDataWithJoin(string stringSelect, string stringJoin, Func<string> condition = null)
    {
        string Sql = $"SELECT {stringSelect} FROM {TableNames[typeof(TEntity)]} {stringJoin} WHERE {condition()}";
        return ADOHelper.GetEntity<TEntity>(Sql, ConnectionString);
    }

    public List<TEntity> Where(Func<string> condition = null)
    {
        string Where = condition == null ? string.Empty : $"WHERE {condition()}";
        string Sql = $"SELECT * FROM {TableNames[typeof(TEntity)]} {Where}";
        return ADOHelper.GetEntitySet<TEntity>(Sql, ConnectionString);
    }

    public List<TEntity> GetAllDataWithJoin(string stringSelect, string stringJoin, Func<string> condition = null)
    {
        string Where = condition == null ? string.Empty : $"WHERE {condition()}";
        string Sql = $"SELECT {stringSelect} FROM {TableNames[typeof(TEntity)]} {stringJoin} {Where}";
        return ADOHelper.GetEntitySet<TEntity>(Sql, ConnectionString);
    }

    public TEntity ExecuteSQL(string SqlQuery)
    {
        return ADOHelper.GetEntity<TEntity>(SqlQuery, ConnectionString);
    }

    public int Update(TEntity entity) => ADOHelper.ExecuteNonQuery(GetUpdateSql(entity), ConnectionString);

    public int Delete(TEntity entity) => ADOHelper.ExecuteNonQuery(GetDeleteSql(entity), ConnectionString);

    public static implicit operator List<TEntity>(DbSet<TEntity> dbSet) => dbSet.Where();
}

