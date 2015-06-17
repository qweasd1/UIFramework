using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF.UI.ViewModel;

namespace WPF.UI
{
    public class ConfigService:UIServiceBase
    {
        [RequireAttribute]
        private Grid _grid;

        private List<ParameterViewModel> _parameterVMs;

        public ConfigService()
        {
            _parameterVMs = new List<ParameterViewModel>();
        }

        public void AddParameterRow(string name)
        {
            _grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            var newRowCount = _grid.RowDefinitions.Count - 1;

            //create Parameter view model
            var newParameterVM = new ParameterViewModel(name);
            _parameterVMs.Add(newParameterVM);

            //create control
            var textblock = ControlFactory.TextBlock();
            textblock.SetBinding(TextBlock.TextProperty, "Name");
            textblock.SetValue(Grid.RowProperty, newRowCount);
            var textBox = ControlFactory.TextBox();
            textBox.SetBinding(TextBox.TextProperty, "Value");
            textBox.SetValue(Grid.RowProperty, newRowCount);
            textBox.SetValue(Grid.ColumnProperty, 1);

            _grid.Children.Add(textblock);
            _grid.Children.Add(textBox);
        }

        public object this[string paramName]
        {
            get
            {
                var parameterVM = _parameterVMs.SingleOrDefault(x => x.Name == paramName);
                if (parameterVM == null)
                {
                    throw new ArgumentException("we don't have this parameter: " + paramName);
                }
                else
                {
                    return parameterVM.Value;
                }
            }

            set
            {
                var parameterVM = _parameterVMs.SingleOrDefault(x => x.Name == paramName);
                if (parameterVM == null)
                {
                    throw new ArgumentException("we don't have this parameter: " + paramName);
                }
                else
                {
                    parameterVM.Value = value;
                }
            }
        }


        public T GetValue<T>(string name)
        {
            var parameterVM = _parameterVMs.SingleOrDefault(x => x.Name == name);
            if (parameterVM == null)
            {
                throw new ArgumentException("we don't have this parameter: " + name);
            }
            else
            {
                return (T)parameterVM.Value;
            }
        }
    }
}
