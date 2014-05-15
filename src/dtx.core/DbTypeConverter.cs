using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDbTypeConverter
    {
        /// <summary>
        /// Returns the database specific type for the specified .NET Framework type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetDatabaseDataType(Type type);

        /// <summary>
        /// Returns the database specific display friendly type name for the specified .NET Framework type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetDatabaseFriendlyTypeName(Type type);

        /// <summary>
        /// Returns .NET Framework Type for the specified database specific friendly type name. 
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        Type GetFrameworkTypeFromFriendlyTypeName(string typeName);

        /// <summary>
        /// Returns .NET Framework Type for the specified database specific internal type name. 
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        Type GetFrameworkTypeFromDatabaseTypeName(string typeName);

        /// <summary>
        /// Returns DbType enum value for the specified database specific internal type (i.e. varchar)
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        DbType GetDbTypeFromDatabaseType(string typeName);
    }
}
