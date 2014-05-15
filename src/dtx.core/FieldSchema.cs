using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
{
    public class FieldSchema
    {
        public string FieldName { get; set; }
        public Type DataType { get; set; }
        public bool IsNullable { get; set; }
        public bool IsUnique { get; set; }
        public string DefaultValue { get; set; }

    }
}
