using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dtx.core;

namespace dtx.addin.MSAccess
{
    public class MSAccessTypeConverter : IDbTypeConverter
    {
        #region Data type mappings
        private static readonly List<DbTypeMapItem> DataTypeMap = new List<DbTypeMapItem>
        {
            // NOTE: Data source: http://support.microsoft.com/kb/320435

            new DbTypeMapItem
            {
                FriendlyTypeName = "Text",
                 InternalDbTypeName = "VarWChar",
                 OleDbType = OleDbType.VarWChar,
                 FrameworkType = typeof(System.String)
            },
            new DbTypeMapItem
            {
                FriendlyTypeName = "Memo",
                 InternalDbTypeName = "LongVarWChar",
                 OleDbType = OleDbType.LongVarWChar,
                 FrameworkType = typeof(System.String)
            },
            new DbTypeMapItem
            {
                 InternalDbTypeName = "UnsignedTinyInt",
                  FriendlyTypeName= "Number: Byte",
                 OleDbType = OleDbType.UnsignedTinyInt,
                 FrameworkType = typeof(System.Byte)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Yes/No",
                  InternalDbTypeName= "Boolean",
                 OleDbType = OleDbType.Boolean,
                 FrameworkType = typeof(System.Boolean)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName  = "Date/Time",
                  InternalDbTypeName= "DateTime",
                 OleDbType = OleDbType.Date,
                 FrameworkType = typeof(System.DateTime)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Currency",
                 InternalDbTypeName = "Decimal",
                 OleDbType = OleDbType.Numeric,
                 FrameworkType = typeof(System.Decimal)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Number: Decimal",
                 InternalDbTypeName = "Decimal",
                 OleDbType = OleDbType.Numeric,
                 FrameworkType = typeof(System.Decimal)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Number: Double",
                 InternalDbTypeName = "Double",
                 OleDbType = OleDbType.Double,
                 FrameworkType = typeof(System.Double)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Autonumber (Replication ID)",
                 InternalDbTypeName = "GUID",
                 OleDbType = OleDbType.Guid,
                 FrameworkType = typeof(System.Guid)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Number: (Replication ID)",
                 InternalDbTypeName = "GUID",
                 OleDbType = OleDbType.Guid,
                 FrameworkType = typeof(System.Guid)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Autonumber (Long Integer)",
                 InternalDbTypeName = "Integer",
                 OleDbType = OleDbType.Integer,
                 FrameworkType = typeof(System.Int32)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Number: (Long Integer)",
                 InternalDbTypeName = "Integer",
                 OleDbType = OleDbType.Integer,
                 FrameworkType = typeof(System.Int32)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "OLE Object",
                 InternalDbTypeName = "LongVarBinary",
                 OleDbType = OleDbType.LongVarBinary,
                 FrameworkType = typeof(System.Byte[])
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Number: Single",
                 InternalDbTypeName = "Single",
                 OleDbType = OleDbType.Single,
                 FrameworkType = typeof(System.Single)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Number: Integer",
                 InternalDbTypeName = "SmallInt",
                 OleDbType = OleDbType.SmallInt,
                 FrameworkType = typeof(System.Int16)
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Binary",
                 InternalDbTypeName = "VarBinary",
                 OleDbType = OleDbType.VarBinary,
                 FrameworkType = typeof(System.Byte[])
            },
            new DbTypeMapItem
            {
                 FriendlyTypeName = "Hyperlink",
                 InternalDbTypeName = "VarWChar",
                 OleDbType = OleDbType.VarWChar,
                 FrameworkType = typeof(System.String)
            }
        };
        #endregion

        /// <summary>
        /// Returns the database specific type for the specified .NET Framework type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetDatabaseDataType(Type type)
        {
            var map = DataTypeMap.SingleOrDefault(t => t.FrameworkType == type);
            return (map != null ? map.InternalDbTypeName : string.Empty);
        }

        /// <summary>
        /// Returns the database specific display friendly type name for the specified .NET Framework type.
        /// For example, for type "Text" it returns System.String.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetDatabaseFriendlyTypeName(Type type)
        {
            var map = DataTypeMap.SingleOrDefault(t => t.FrameworkType == type);
            return (map != null ? map.FriendlyTypeName : string.Empty);
        }

        /// <summary>
        /// Returns .NET Framework Type for the specified Access type name. 
        /// For example, for type "Text" it returns System.String.
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public Type GetFrameworkTypeFromFriendlyTypeName(string typeName)
        {
            var map = DataTypeMap.SingleOrDefault(t => t.FriendlyTypeName == typeName);
            return (map != null ? map.FrameworkType : null);
        }

        /// <summary>
        /// Returns .NET Framework Type for the specified Access database type name. 
        /// For example, for type "VarWChar" it returns System.String.
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public Type GetFrameworkTypeFromDatabaseTypeName(string typeName)
        {
            var map = DataTypeMap.SingleOrDefault(t => t.InternalDbTypeName == typeName);
            return (map != null ? map.FrameworkType : null);
        }


        public DbType GetDbTypeFromDatabaseType(string typeName)
        {
            throw new NotImplementedException();
        }
    }
}
