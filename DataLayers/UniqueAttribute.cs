﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false)]
    public class UniqueAttribute : Attribute
    {
    }
}
