using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WPF.UI
{

    class ViewMeta
    {
        public List<ExtensionMeta> ExtensionMetas { get; set; }
        public Type Type { get; set; }

        public ViewMeta()
        {
            ExtensionMetas = new List<ExtensionMeta>();
        }

    }

    class ExtensionMeta
    {
        public string Name { get; set; }
        public ExtensionType Type { get; set; }

        public MethodInfo MethodInfo { get; set; }
    }

    class TypeMeta
    {
        public bool IsAbstract { get; set; }

        public Type Type { get; set; }
        public List<PropertyMeta> RequirePropertyMetas { get; set; }

        public ConstructorInfo DefaultConstructorInfo { get; set; }

        public TypeMeta()
        {
            RequirePropertyMetas = new List<PropertyMeta>();
        }

        
    }

    class UIServiceMeta:ServicecMeta
    {
        public UITagAttribute UITag { get; set; }
    }

    class ServicecMeta:PropertyMeta
    {
        public ServicecMeta()
        {
            RequireProperties = new List<PropertyInfo>();
        }
        
        public List<PropertyInfo> RequireProperties { get; set; }

    }


    class PropertyMeta
    {
        public PropertyType PropertyType { get; set; }
       

        public PropertyInfo PropertyInfo { get; set; }

        public FieldInfo FieldInfo { get; set; }

        public TypeMeta TypeMeta { get; set; }

    }

    enum PropertyType
    {
        Field,
        Property
    }

    
}
