using System;
using System.Data.OleDb;

namespace Dtx
{
    /// <summary>
    /// 
    /// </summary>
    public class DbTypeMapItem
    {
        public string FriendlyTypeName;
        public string InternalDbTypeName;
        public Type FrameworkType;
        public OleDbType OleDbType;
    }
}
