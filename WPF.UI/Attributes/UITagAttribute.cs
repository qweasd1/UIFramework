using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.UI
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UITagAttribute:Attribute
    {
        public UITagAttribute()
        {
            
        }
        public string Name { get; set; }
        public string ExtensionPoint { get; set; }
        public int Order { get; set; }
    }
}
