using System;
using System.Collections.Generic;
using System.Linq;

namespace Dtx.Components.MSAccess
{
    public class AccessScriptGenerator : IScriptGenerator
    {
        private readonly IDbTypeConverter _typeConverter = new AccessTypeConverter();

        public List<string> CreateTables(HashSet<TableSchema> tables)
        {
            return tables.Select(CreateTable).ToList();
        }

        public string CreateTable(TableSchema table)
        {
            const string createTableSqlTemplate = "Create table {0} ({1})";

            var fields = new List<string>(table.Fields.Count);
            fields.AddRange(table.Fields.Select(OnSelector));

            var fieldDefSql = string.Join(", ", fields);

            var sql = string.Format(createTableSqlTemplate, table.TableName, fieldDefSql);

            return sql;
        }

        private string OnSelector(FieldSchema field)
        {
            if (field.FieldName.ToLower() == "id" || field.IsNullable == false)
            {
                return string.Format("[{0}] {1} NOT NULL", field.FieldName, _typeConverter.GetDatabaseDataType(field.DataType));
            }
            else
            {
                return string.Format("[{0}] {1}", field.FieldName, _typeConverter.GetDatabaseDataType(field.DataType));
            }
        }

        public string CreatePrimaryKey(PrimaryKey key)
        {
            const string sqlTemplate = "ALTER TABLE [{0}] ADD CONSTRAINT {2} PRIMARY KEY ({1})";

            return string.Format(sqlTemplate, key.LocalTableName, key.LocalFieldName, key.KeyName);
        }

        public string CreateForeignKey(ForeignKey key)
        {
            //ALTER TABLE Employees
            //ADD CONSTRAINT fk_DeptNo FOREIGN KEY (DeptNo)
            //REFERENCES Departments (DeptNo); 

            const string sqlTemplate = @"ALTER TABLE [{0}] ADD CONSTRAINT [{1}] FOREIGN KEY ([{2}]) REFERENCES [{3}] ([{4}]); ";

            var sql = string.Format(sqlTemplate, key.LocalTableName,
                key.KeyName, key.LocalFieldName, key.ParentTableName, key.ParentFieldName);

            return sql;
        }

        public string InsertRow(TableSchema schema, RowData row)
        {
            const string sqlTemplate = "INSERT INTO {0} ({1}) VALUES ({2})";

            var fields = new List<string>();
            var values = new List<string>();

            foreach (var fieldSchema in schema.Fields)
            {
                fields.Add(fieldSchema.FieldName);

                if (row[fieldSchema.FieldName] ==null && fieldSchema.IsNullable)
                {
                    values.Add("NULL");
                }
                else
                {
                    if (fieldSchema.DataType == typeof(string))
                    {
                        var strValue = "'" + row[fieldSchema.FieldName].ToString().Replace("'", "''") + "'";
                        values.Add(strValue);
                    }
                    else if (fieldSchema.DataType == typeof(DateTime))
                    {
                        var strValue = "'" + row[fieldSchema.FieldName].ToString().Replace("'", "''") + "'";
                        values.Add(strValue);
                    }
                    else 
                    {
                        // Int, double, boolean...
                        values.Add(row[fieldSchema.FieldName].ToString());
                    }
                }
            }

            var fieldNames = "[" + string.Join("], [", fields) + "]";
            var sql = string.Format(sqlTemplate, schema.TableName, fieldNames, string.Join(", ", values));

            return sql;
        }


        public List<string> InsertData(string tableName, List<RowData> row)
        {
            throw new NotImplementedException();
        }
    }
}
