using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
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
