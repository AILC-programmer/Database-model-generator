﻿using System;

namespace CafeParty.WindowsApp.DataLayers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AllowNullColumnAttribute : Attribute { }
}