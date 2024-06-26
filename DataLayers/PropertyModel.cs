using System.Reflection;

namespace CafeParty.WindowsApp.DataLayers
{
    public class PropertyModel
    {
        public string Name { get; set; }
        public string ColumnName { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsComputedColumn { get; set; }
        public bool IsIdentityColumn { get; set; }
        public bool IsNullable { get; set; }
        public int MaxLegth { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
    }
}
