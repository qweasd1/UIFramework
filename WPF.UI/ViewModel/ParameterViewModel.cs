using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.UI.ViewModel
{
    class ParameterViewModel
    {
        public ParameterViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public object DefaultValue { get; set; }
        public object Value { get; set; }
    }
}
