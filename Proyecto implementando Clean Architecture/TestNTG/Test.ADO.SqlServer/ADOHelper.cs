using System.Data.SqlClient;
using System.Reflection;

namespace Test.ADO.SqlServer;
public static class ADOHelper
{
    /// <summary>
    /// Inicializa y abre la conexión a la base de datos
    /// </summary>
    /// <param name="ConnectionString">Parámetro que contiene la cadena de conexión</param>
    /// <returns>La conexión</returns>
    static SqlConnection GetOpenedConnection(string connectionString)
    {
        SqlConnection Connection = new SqlConnection(connectionString);
        Connection.Open();
        return Connection;
    }

    /// <summary>
    /// Método que devuelve(abre) una conexión y crea un SqlCommand para ejecutar sentencias SQL Server
    /// </summary>
    /// <param name="sqlQuery">Cadena que contiene un query SQL Server</param>
    /// <param name="connectionString">Contiene la cadena de conexión</param>
    /// <returns></returns>
    static (SqlConnection, SqlCommand) GetConnectionAndCommand(string sqlQuery, string connectionString = "")
    {
        SqlConnection Connection = GetOpenedConnection(connectionString);
        SqlCommand Command = new SqlCommand(sqlQuery, Connection);
        return (Connection, Command);
    }

    /// <summary>
    /// Método que libera recursos de la conexión y el comando
    /// </summary>
    /// <param name="connection">Objeto de tipo SqlConnection que representa una conexión a la base de datos SQL Server </param>
    /// <param name="command">Objeto de tipo SqlCommand para ejecutar sentencias SQL Server</param>
    static void DisposeConnectionAndCommand(SqlConnection connection, SqlCommand command)
    {
        connection.Dispose();
        command.Dispose();
    }

    public static object ExecuteScalar(string sqlquery, string connectionString)
    {
        var (Connection, Command) = GetConnectionAndCommand(sqlquery, connectionString);

        object Name = Command.ExecuteScalar();
        DisposeConnectionAndCommand(Connection, Command);
        return Name;
    }

    public static int ExecuteNonQuery(string sqlquery, string connectionString)
    {
        var (Connection, Command) = GetConnectionAndCommand(sqlquery, connectionString);

        int Result = Command.ExecuteNonQuery();
        DisposeConnectionAndCommand(Connection, Command);
        return Result;
    }

    internal static List<TEntity> GetEntitySet<TEntity>(string sql, string connectionString) where TEntity : new()
    {
        List<TEntity> EntitySet = new List<TEntity>();
        var (Connection, Command) = GetConnectionAndCommand(sql, connectionString);

        SqlDataReader Reader = Command.ExecuteReader();
        while (Reader.Read())
        {
            EntitySet.Add(GetInstanceType<TEntity>(Reader));
        }
        DisposeConnectionAndCommand(Connection, Command);
        return EntitySet;
    }

    /// <summary>
    /// Método genérico
    /// </summary>
    /// <typeparam name="TEntity">Entidad que vamos a devolver, el tipo de datos de la entidad de destino</typeparam>
    /// <param name="sqlQuery">Cadena que contiene un query SQL Server</param>
    /// <param name="connectionString">Contiene la cadena de conexión</param>
    /// <returns>Devuelve una entidad</returns>
    public static TEntity GetEntity<TEntity>(string sqlQuery, string connectionString) where TEntity : new()
    {
        TEntity Entity = default;
        var (Connection, Command) = GetConnectionAndCommand(sqlQuery, connectionString);
        var Reader = Command.ExecuteReader();

        if (Reader.Read())
        {
            Entity = GetInstanceType<TEntity>(Reader);
        }

        DisposeConnectionAndCommand(Connection, Command);

        return Entity;
    }

    private static TEntity GetInstanceType<TEntity>(SqlDataReader reader) where TEntity : new()
    {
        TEntity Result = new TEntity();

        Type TEntityType = typeof(TEntity);
        PropertyInfo PropertyInfo;

        for (int i = 0; i < reader.FieldCount; i++)
        {
            PropertyInfo = TEntityType.GetProperty(reader.GetName(i),
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Instance);

            if (PropertyInfo != null && reader[i] != DBNull.Value)
            {
                PropertyInfo.SetValue(Result, reader[i]);
            }
        }
        return Result;
    }
}
