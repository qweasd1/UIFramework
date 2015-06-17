using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.UI
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MenuAttribute:Attribute
    {
        public MenuAttribute(params string[] paths)
        {
            Paths = paths;
        }

        public string[] Paths { get; set; }
        public string Name { get; set; }
       
    }

    public enum MenuType
    {
        Menu = 1,
        Toolbar = 2,
        Context = 4
    }
}
