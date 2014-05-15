using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
{
    public class ForeignKey
    {
        public string KeyName { get; set; }
        public string LocalTableName { get; set; }
        public string LocalFieldName { get; set; }
        public string ParentFieldName { get; set; }
        public string ParentTableName { get; set; }
    }
}
