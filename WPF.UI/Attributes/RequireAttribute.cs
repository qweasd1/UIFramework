using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.UI
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RequireAttribute:Attribute
    {
    }
}
