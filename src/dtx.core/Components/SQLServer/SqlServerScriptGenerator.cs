using System;
using System.Collections.Generic;
using System.Linq;

namespace Dtx.Components.SQLServer
{
    public class SqlServerScriptGenerator : IScriptGenerator
    {
        public string GetData(TableSchema schema)
        {
            const string sqlTemplate = "SELECT {0} FROM {1}";

            var fields = schema.Fields.Select(x => x.FieldName).ToArray();
            var fieldNames = "[" + string.Join("],[", fields) + "]";

            var sql = string.Format(sqlTemplate, fieldNames, schema.TableName);

            return sql;
        }

        public List<string> CreateTables(HashSet<TableSchema> tables)
        {
            throw new NotImplementedException();
        }

        public string CreateTable(TableSchema table)
        {
            throw new NotImplementedException();
        }

        public List<string> InsertData(string tableName, List<RowData> row)
        {
            throw new NotImplementedException();
        }
    }
}
