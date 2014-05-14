using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
{
    public class TableSchema
    {
        public string TableName { get; set; }
        public HashSet<FieldSchema> Fields { get; set; }
        public HashSet<ForeignKey> ForeignKeys { get; set; }

        public TableSchema()
        {
            ForeignKeys = new HashSet<ForeignKey>();
            Fields = new HashSet<FieldSchema>();

        }


    }
}
