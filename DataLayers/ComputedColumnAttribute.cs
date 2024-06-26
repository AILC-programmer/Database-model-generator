using System;

namespace DataLayers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ComputedColumnAttribute : Attribute { }
}
