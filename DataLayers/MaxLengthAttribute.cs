﻿using System;

namespace DataLayers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MaxLengthAttribute : Attribute
    {
        public int Length;
        public MaxLengthAttribute(int Length)
        {
            this.Length = Length;
        }
    }
}
