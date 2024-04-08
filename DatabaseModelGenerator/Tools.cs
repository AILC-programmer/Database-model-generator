using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DatabaseModelGenerator
{
    internal class Tools
    {
        /// <summary>
        /// Convet SQL data types to CLR Data types.
        /// </summary>
        /// <param name="type">SQL data type</param>
        /// <param name="nullable">True, if this column in the database checked allow null box; otherwise, False.</param>
        /// <returns>Returns the equivalent of the SQL data type in CLR.</returns>
        public static string ConvertSqlToClr(string type, bool nullable)
        {
            switch (type)
            {
                case "int":
                    return nullable ? "int?" : "int";

                case "bigint":
                    return nullable ? "long?" : "long";

                case "datetime":
                case "date":
                case "datetime2":
                    return nullable ? "DateTime?" : "DateTime";

                case "time":
                    return nullable ? "TimeSpan?" : "TimeSpan";

                case "nvarchar":
                case "nchar":
                case "ntext":
                case "varchar":
                case "char":
                    return "string";

                case "bit":
                    return nullable ? "bool?" : "bool";

                case "binary":
                case "image":
                case "rowversion":
                case "timestamp":
                case "varbinary":
                    return "byte[]";

                case "tinyint":
                    return nullable ? "byte?" : "byte";

                case "decimal":
                case "money":
                case "numeric":
                    return nullable ? "decimal?" : "decimal";

                case "float":
                    return nullable ? "double?" : "double";

                case "real":
                    return nullable ? "Single?" : "Single";

                case "uniqueidentifier":
                    return nullable ? "Guid?" : "Guid";

                default:
                    return "object";
            }

        }

        /// <summary>
        /// Get all columns of the table in the database.
        /// </summary>
        /// <param name="TableSchema">The table schema in the database</param>
        /// <param name="TableName">The name of the table whose columns you want to get.</param>
        /// <param name="connectionString">The connection string of the database and server.</param>
        /// <returns>Returns a list of ColumnModel, these are all columns of that table.</returns>
        public static async Task<List<ColumnModel>> getTableColumns(string TableSchema, string TableName, string connectionString)
        {
            var columns = new List<ColumnModel>();
            List<string> primaryKeyColumns = new List<string>();
            List<string> UniqueColumns = new List<string>();
            List<string> identityColumns = new List<string>();
            List<string> computedColumns = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                #region Primary
                using (var keyCommand = new SqlCommand("select TC.CONSTRAINT_SCHEMA,TC.CONSTRAINT_NAME, CCU.COLUMN_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS CCU ON CCU.CONSTRAINT_NAME = TC.CONSTRAINT_NAME WHERE TC.TABLE_SCHEMA = N'"
                    + TableSchema + "' AND TC.TABLE_NAME = N'" + TableName + "' AND TC.CONSTRAINT_TYPE = N'PRIMARY KEY'", connection))
                using (var keyReader = await keyCommand.ExecuteReaderAsync())
                    while (keyReader.Read())
                        primaryKeyColumns.Add(keyReader["COLUMN_NAME"].ToString());
                #endregion
                #region Unique
                using (var keyCommand = new SqlCommand("select TC.CONSTRAINT_SCHEMA,TC.CONSTRAINT_NAME, CCU.COLUMN_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS CCU ON CCU.CONSTRAINT_NAME = TC.CONSTRAINT_NAME WHERE TC.TABLE_SCHEMA = N'"
                    + TableSchema + "' AND TC.TABLE_NAME = N'" + TableName + "' AND TC.CONSTRAINT_TYPE = N'UNIQUE'", connection))
                using (var keyReader = await keyCommand.ExecuteReaderAsync())
                    while (keyReader.Read())
                        UniqueColumns.Add(keyReader["COLUMN_NAME"].ToString());
                #endregion
                #region Identity
                using (var identityCommand = new SqlCommand($"SELECT [NAME] FROM sys.columns WHERE object_id = object_id('{TableSchema}.{TableName}') AND is_identity = 1", connection))
                using (var identityReader = await identityCommand.ExecuteReaderAsync())
                    while (identityReader.Read())
                        identityColumns.Add(identityReader["NAME"].ToString());
                #endregion
                #region Computed
                using (var computedCommand = new SqlCommand($"SELECT [NAME] FROM sys.columns WHERE object_id = object_id('{TableSchema}.{TableName}') AND is_computed = 1", connection))
                using (var computedReader = await computedCommand.ExecuteReaderAsync())
                    while (computedReader.Read())
                        computedColumns.Add(computedReader["NAME"].ToString());
                #endregion

                using (SqlCommand command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @tblSchema AND TABLE_NAME = @tblName", connection))
                {
                    command.Parameters.Add(new SqlParameter("tblSchema", TableSchema));
                    command.Parameters.Add(new SqlParameter("tblName", TableName));
                    using (var reader = await command.ExecuteReaderAsync())
                        while (reader.Read())
                            columns.Add(new ColumnModel()
                            {
                                Name = reader["COLUMN_NAME"].ToString(),
                                DataType = reader["DATA_TYPE"].ToString(),
                                IsNullable = reader["IS_NULLABLE"].ToString() == "YES",
                                MaxLength = reader["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value ? 0 : int.Parse(reader["CHARACTER_MAXIMUM_LENGTH"].ToString()),
                                IsPrimary = primaryKeyColumns.Any(item => item.Equals(reader["COLUMN_NAME"])),
                                IsUnique = UniqueColumns.Any(item => item.Equals(reader["COLUMN_NAME"])),
                                IsIdentity = identityColumns.Any(item => item.Equals(reader["COLUMN_NAME"])),
                                IsComputed = computedColumns.Any(item => item.Equals(reader["COLUMN_NAME"]))
                            });
                }
            }

            return columns;
        }
        
        private static BinaryFormatter formatter = new BinaryFormatter();

        /// <summary>
        /// Serialize an object to the path
        /// </summary>
        /// <param name="Path">The path of the file you want to serialize.
        /// Remember, your path must have a file name.</param>
        /// <param name="obj">That object you want to serialize.</param>
        public static void SerializeObject(string Path, ValuesModel obj)
        {
            try
            {
                using (var stream = File.Open(Path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get the serialized file.
        /// </summary>
        /// <param name="Path">The path of the file serialized.</param>
        /// <returns>Returns ValueModel object</returns>
        public static ValuesModel DeserializeObject(string Path)
        {
            try
            {
                using (var stream = File.Open(Path, FileMode.Open, FileAccess.Read))
                {
                    return (ValuesModel)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
