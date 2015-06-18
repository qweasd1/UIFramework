using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.ServiceUI
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ExportAttribute:Attribute
    {
        public string ViewID { get; set; }
        public string TargetID { get; set; }

        public Type RequireUIType { get; set; }

        public string UIFactoryMethod { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RequireAttribute:Attribute
    {
        Type RequireType { get; set; }
        /// <summary>
        /// use to support multi-singleton
        /// </summary>
        public string ID { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ViewAttribute:Attribute
    {
        public string ID { get; set; }

        public Type DefaultUIType { get; set; }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class ExtensionAttribute:Attribute
    {
        public string ID { get; set; }
        public UIExtensionType Type { get; set; }
    }

    public enum UIExtensionType
    {
        One,
        Many
    }
}
