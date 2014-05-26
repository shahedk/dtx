using System;

namespace Dtx
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
