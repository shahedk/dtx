using System;
using System.Data;

namespace Dtx.Components.SQLServer
{
    /// <summary>
    /// Converts data types between native SQL Server and .NET CLR Types
    /// </summary>
    public class SqlServerTypeConverter : IDbTypeConverter
    {
        public string GetDatabaseDataType(Type type)
        {
            throw new NotImplementedException();
        }

        public string GetDatabaseFriendlyTypeName(Type type)
        {
            throw new NotImplementedException();
        }

        public Type GetFrameworkTypeFromFriendlyTypeName(string typeName)
        {
            throw new NotImplementedException();
        }

        public Type GetFrameworkTypeFromDatabaseTypeName(string typeName)
        {
            throw new NotImplementedException();
        }

        public DbType GetDbTypeFromDatabaseType(string dataTypeName)
        {
            var type = DbType.String;
            switch (dataTypeName)
            {
                case "bit":
                    type = DbType.Boolean;
                    break;

                case "date":
                    type = DbType.Date;
                    break;

                case "datetime":
                    type = DbType.DateTime;
                    break;

                case "real":
                case "float":
                    type = DbType.Decimal;
                    break;

                case "smallint":
                case "int":
                    type = DbType.Int32;
                    break;

                case "varchar":
                case "nvarchar":
                    type = DbType.String;
                    break;

            }
            return type;
        }
    }
}
