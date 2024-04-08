using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModelGenerator
{
    internal class ColumnModel
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsComputed { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsNullable { get; set; }
        public bool IsUnique { get; set; }
        public int MaxLength { get; set; }

    }
}
