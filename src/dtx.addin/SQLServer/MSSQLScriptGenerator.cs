﻿using dtx.core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace dtx.addin.SQLServer
{
    public class MSSQLScriptGenerator : IScriptGenerator
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
