using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ServiceUI;

namespace WPF.UI.Test
{
    /// <summary>
    /// SimpleShell.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleShell : Window
    {
        public const string Extension_Center = "Center";

        public SimpleShell()
        {
            InitializeComponent();
        }

        [Extension(ID=Extension_Center,Type= UIExtensionType.One)]
        public void SetContent(FrameworkElement content)
        {
            gd_contentContainer.Children.Add(content);
        }
    }
}
