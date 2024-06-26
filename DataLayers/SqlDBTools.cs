using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CafeParty.WindowsApp.DataLayers
{
    public class SqlDBTools
    {
        private SqlConnectionStringBuilder connectionStringBuilder;
        private string DBname;

        public SqlDBTools(string connectionString)
        {
            connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            this.DBname = connectionStringBuilder.InitialCatalog;
        }
        public SqlDBTools(SqlConnectionStringBuilder connectionStringBuilder) : this(connectionStringBuilder.ConnectionString) { }

        public async Task<bool> CheckDatabaseConnectionAsync()
        {
            connectionStringBuilder.InitialCatalog = "Master";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connectionStringBuilder.InitialCatalog = DBname;
            }
        }

        public async Task<bool> CheckDatabaseExistsAsync()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE [name] = @dbName", connection);
                    command.Parameters.Add(new SqlParameter("dbName", DBname));

                    var result = (int)await command.ExecuteScalarAsync();
                    return result > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateDatabaseAsync(string schemaScript, string DbScript)
        {
            connectionStringBuilder.InitialCatalog = "Master";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = $"CREATE DATABASE {DBname}";
                        await command.ExecuteNonQueryAsync();
                    }
                    connection.ChangeDatabase(DBname);

                    foreach (var schema in getSchemas(schemaScript))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = schema;
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                    
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = DbScript.Replace("GO", "").Replace("[Cafe]", "[" + DBname + "]");
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectionStringBuilder.InitialCatalog = DBname;
            }
        }

        List<string> getSchemas(string schemaScript)
        {
            List<string> schemas = new List<string>();

            var lines = schemaScript.Split('\n');
            foreach (var line in lines)
            {
                if (line.Contains("GO") || line.StartsWith("/***") || line.Contains("\n") || line.StartsWith("\r"))
                    continue;
                if(!string.IsNullOrEmpty(line))
                    schemas.Add(line);
            }
            return schemas;
        }

        public void changeConnection(SqlConnectionStringBuilder connectionStringBuilder)
        {
            this.connectionStringBuilder = connectionStringBuilder;
        }
    }
}
