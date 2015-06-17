using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPF.UI
{
    public static class ControlFactory
    {
        public static TextBlock TextBlock()
        {
            return new TextBlock() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        }

        public static TextBox TextBox()
        {
            return new TextBox();
        }

        public static Grid Grid()
        {
            return new Grid();
        }

        public static Grid Grid_Row(int row)
        {
            var grid =  new Grid();
            
            for (int i = 0; i < row; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }

            return grid;
        }
    }
}
