using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayers
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    {
        string schema;
        string tableName;
        string connectionString;

        List<PropertyModel> propertyModels = new List<PropertyModel>();

        #region Constructors

        private GenericRepository()
        {
            var entityType = typeof(TEntity);

            var table = entityType.GetCustomAttributes(typeof(TableAttribute), false).OfType<TableAttribute>().FirstOrDefault();
            if (table != null)
            {
                this.schema = table.Schema;
                this.tableName = table.TableName;
            }
            else
            {
                this.schema = "dbo";
                this.tableName = entityType.Name;
            }

            foreach (var property in entityType.GetProperties())
            {
                propertyModels.Add(new PropertyModel()
                {
                    Name = property.Name,
                    ColumnName = property.Name,
                    MaxLegth = property.GetCustomAttributes(typeof(MaxLengthAttribute), false).Length,
                    IsComputedColumn = property.GetCustomAttributes(typeof(ComputedColumnAttribute), false).Any(),
                    IsIdentityColumn = property.GetCustomAttributes(typeof(IdentityColumnAttribute), false).Any(),
                    IsPrimaryKey = property.GetCustomAttributes(typeof(PrimaryKeyAttribute), false).Any(),
                    IsNullable = property.GetCustomAttributes(typeof(AllowNullColumnAttribute), false).Any(),
                    PropertyInfo = property
                });
            }
        }

        public GenericRepository(string connectionString) : this() => this.connectionString = connectionString;

        public GenericRepository(SqlConnectionStringBuilder connectionString) : this(connectionString.ConnectionString) { }

        #endregion

        #region Methods

        public async Task<int> AddAsync(TEntity entity)
        {
            if (entity == null)
                return 0;

            StringBuilder InsertStatement = new StringBuilder();

            InsertStatement.Append($"INSERT INTO [{schema}].[{tableName}] ((Columns)) VALUES ((Values))");

            List<string> columns = new List<string>();
            List<string> values = new List<string>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            foreach (var model in propertyModels)
            {
                if (model.IsComputedColumn || model.IsIdentityColumn)
                    continue;
                columns.Add(model.ColumnName);
                values.Add(model.Name);
                var value = model.PropertyInfo.GetValue(entity);
                sqlParameters.Add(new SqlParameter(model.Name, value == null ? DBNull.Value : value));
            }

            InsertStatement.Replace("(Columns)", String.Join(",", columns.Select(item => "[" + item + "]")));
            InsertStatement.Replace("(Values)", String.Join(",", values.Select(item => "@" + item)));
            try
            {
                var res = await executionAsyncHelper(InsertStatement.ToString(), sqlParameters.ToArray());
                if (OnAdded != null)
                    OnAdded(entity);

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            if(entity == null)
                return 0;

            StringBuilder quary = new StringBuilder($"UPDATE [{schema}].[{tableName}]");

            var nonComputedNonIdentityColumns = propertyModels.Where(p => !p.IsComputedColumn && !p.IsIdentityColumn);

            var primaryKeys = propertyModels.Where(p => p.IsPrimaryKey);

            List<string> updateStatements = new List<string>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            foreach (var model in nonComputedNonIdentityColumns)
            {
                updateStatements.Add($" [{model.ColumnName}] = @{model.Name}");
                sqlParameters.Add(new SqlParameter(model.Name, model.PropertyInfo.GetValue(entity)));
            }

            quary.Append("SET" + String.Join(",", updateStatements));

            List<string> whereParts = new List<string>();

            foreach (var property in primaryKeys)
            {
                whereParts.Add($"[{property.ColumnName}] = @{property.Name}");
                sqlParameters.Add(new SqlParameter(property.Name, property.PropertyInfo.GetValue(entity)));
            }

            quary.Append(" WHERE " + String.Join(" AND ", whereParts));

            try
            {
                var res = await executionAsyncHelper(quary.ToString(), sqlParameters.ToArray());
                if (OnUpdated != null)
                    OnUpdated(entity);

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                return 0;

            var primaryKeys = propertyModels.Where(model => model.IsPrimaryKey);

            StringBuilder deleteStatement = new StringBuilder();
            deleteStatement.Append($"DELETE FROM [{schema}].[{tableName}]");

            List<string> whereParts = new List<string>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            foreach (var key in primaryKeys)
            {
                whereParts.Add($"[{key.ColumnName}] = @{key.Name}");
                sqlParameters.Add(new SqlParameter(key.Name, key.PropertyInfo.GetValue(entity)));
            }

            deleteStatement.Append(" WHERE " + String.Join(" AND ", whereParts));

            try
            {
                var res = await executionAsyncHelper(deleteStatement.ToString(), sqlParameters.ToArray());
                if (OnDeleted != null)
                    OnDeleted(entity);

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<int> executionAsyncHelper(string query, params SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var command = connection.CreateCommand();
                    command.CommandText = query;

                    foreach (var parameter in sqlParameters)
                        command.Parameters.Add(parameter);

                    return await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var command = connection.CreateCommand();
                    command.CommandText = $"SELECT COUNT(*) FROM [{schema}].[{tableName}]";
                    return (int)await command.ExecuteScalarAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> FindAsync(params object[] keys)
        {
            if(keys == null || keys.Count() == 0)
                return default(TEntity);

            var primaryKeys = propertyModels.Where(property => property.IsPrimaryKey);

            StringBuilder quary = new StringBuilder($"SELECT TOP(1) * FROM [{schema}].[{tableName}]");

            List<string> whereParts = new List<string>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            int parameterCount = 0;
            foreach (PropertyModel property in primaryKeys)
            {
                string columnName = property.ColumnName;
                var propertyValue = keys[parameterCount++];

                whereParts.Add("[" + columnName + "] = @" + columnName);
                sqlParameters.Add(new SqlParameter(columnName, propertyValue));
            }

            quary.Append(" WHERE " + String.Join(" AND ", whereParts));
            try
            {
                return (await RunQuaryAsync(quary.ToString(), sqlParameters.ToArray())).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TEntity>> FindAllAsync()
        {
            var primaryKeys = propertyModels.Where(property => property.IsPrimaryKey);

            StringBuilder quary = new StringBuilder($"SELECT * FROM [{schema}].[{tableName}]");

            try
            {
                return await RunQuaryAsync(quary.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async Task<List<TEntity>> RunQuaryAsync(string commandtxt, params SqlParameter[] parameters)
        {
            List<TEntity> entities = new List<TEntity>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var command = connection.CreateCommand();
                    command.CommandText = commandtxt;

                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        TEntity entity = Activator.CreateInstance<TEntity>();

                        foreach (var model in propertyModels)
                        {
                            var value = reader[model.ColumnName];
                            if (value is DBNull)
                            {
                                model.PropertyInfo.SetValue(entity, null);
                            }
                            else
                            {
                                model.PropertyInfo.SetValue(entity, value);
                            }
                        }
                        entities.Add(entity);
                    }
                }
                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Events

        public event Action<TEntity> OnAdded;
        public event Action<TEntity> OnDeleted;
        public event Action<TEntity> OnUpdated;

        #endregion

        #region Indexers

        public Task<TEntity> this[params object[] keys] { get => FindAsync(keys); }
        public Task<int> this[TEntity entity, bool forUpdate] { set => value = forUpdate ? UpdateAsync(entity) : AddAsync(entity); }

        #endregion
    }
}
