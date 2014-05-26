using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dtx.Components.SQLServer
{
    public class SqlServerDatabase : IDatabase
    {
        private readonly IDbTypeConverter _typeConverter = new SqlServerTypeConverter();
        private readonly string _connectionString;

        public SqlServerDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TableData GetTableData(TableSchema schema)
        {
            var tableData = new TableData();
            tableData.Schema = schema;

            var scripter = new SqlServerScriptGenerator();
            var sql = scripter.GetData(schema);

            // Create SQL Connection
            var con = new SqlConnection(_connectionString);
            con.Open();

            // Create command to execute sql
            var cmd = new SqlCommand(sql, con);
            var reader = cmd.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                var rowData = new RowData();
                i = 0;
                foreach (var field in schema.Fields)
                {
                    var val = reader.GetValue(i);
                    rowData[field.FieldName] = val == null ? "" : val.ToString();
                    i++;
                }

                tableData.Rows.Add(rowData);

            }
            reader.Close();


            con.Close();

            return tableData;

        }

        public HashSet<TableSchema> GetTables()
        {
            const string getAllTablesSql = "SELECT * FROM information_schema.tables where TABLE_TYPE = 'BASE TABLE' and TABLE_NAME not in ('sysdiagrams')";

            var con = new SqlConnection(_connectionString);
            con.Open();

            var cmd = new SqlCommand(getAllTablesSql, con);
            var reader = cmd.ExecuteReader();

            var tables = new HashSet<TableSchema>();
            while (reader.Read())
            {
                var type = reader.GetString(3);
                if (type == "BASE TABLE")
                {
                    var table = new TableSchema();
                    table.TableName = reader.GetString(2);

                    tables.Add(table);
                }
            }
            reader.Close();

            LoadFieldNames(tables, con);

            con.Close();

            return tables;
        }

        private void LoadFieldNames(HashSet<TableSchema> tables, SqlConnection con)
        {
            const string sqlTemplate = "select * from information_schema.columns where Table_Name = '{0}'";
            foreach (var table in tables)
            {
                var sql = string.Format(sqlTemplate, table.TableName);
                var cmd = new SqlCommand(sql, con);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var fieldSchema = new FieldSchema();
                    fieldSchema.FieldName = reader.GetString(3);
                    var dataTypeName = reader.GetString(7);
                    fieldSchema.DataType = _typeConverter.GetFrameworkTypeFromDatabaseTypeName(dataTypeName);
                    fieldSchema.IsNullable = (reader.GetString(6) == "YES");

                    table.Fields.Add(fieldSchema);
                }
                reader.Close();
            }
        }

    

        public PrimaryKey GetPrimaryKey(string tableName)
        {
            const string getPrimaryKey = @"SELECT column_name AS ColumnName,
Constraint_Name AS [Constraint],
Table_Schema AS [Schema],
Table_Name AS [TableName]
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND TABLE_NAME = '{0}'";

            var con = new SqlConnection(_connectionString);
            con.Open();

            var sql = string.Format(getPrimaryKey, tableName);

            var cmd = new SqlCommand(sql, con);
            var reader = cmd.ExecuteReader();

            PrimaryKey pk = null;
            while (reader.Read())
            {
                pk = new PrimaryKey
                {
                    LocalFieldName = reader.GetString(0),
                    LocalTableName = reader.GetString(3),
                    KeyName = reader.GetString(1)
                };
            }
            reader.Close();
            con.Close();

            return pk; 
        }
        public HashSet<ForeignKey> GetForeignKeys(string tableName)
        {
            const string getForeignKeys = @"
SELECT f.name AS ForeignKey, 
   OBJECT_NAME(f.parent_object_id) AS TableName, 
   COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName, 
   OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName, 
   COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferenceColumnName 
FROM sys.foreign_keys AS f 
INNER JOIN sys.foreign_key_columns AS fc 
   ON f.OBJECT_ID = fc.constraint_object_id
WHERE OBJECT_NAME(f.parent_object_id) = '{0}'";

            var con = new SqlConnection(_connectionString);
            con.Open();

            var sql = string.Format(getForeignKeys, tableName);

            var cmd = new SqlCommand(sql, con);
            var reader = cmd.ExecuteReader();

            var foreignKeys = new HashSet<ForeignKey>();
            while (reader.Read())
            {
                var foreignKey = new ForeignKey
                {
                    KeyName = reader.GetString(0),
                    LocalFieldName = reader.GetString(2),
                    ParentFieldName = reader.GetString(4),
                    ParentTableName = reader.GetString(3),
                    LocalTableName = tableName
                };

                foreignKeys.Add(foreignKey);
            }
            reader.Close();
            con.Close();

            return foreignKeys;
        }

        public void CreateDatabase(string newDbFilePath)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string sql)
        {
            throw new NotImplementedException();
        }


        public HashSet<TableIndex> GetIndexes(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
