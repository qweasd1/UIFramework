using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.UI
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExtensionAttribute:Attribute
    {
        public ExtensionAttribute()
        {
            Mode = ExtensionType.One;
        }
        public string Name { get; set; }
        public ExtensionType Mode { get; set; }
    }

    public enum ExtensionType
    {
        One,
        Many
    }
}
