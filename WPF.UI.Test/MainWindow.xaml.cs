using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var resolver = new Resolver();
            resolver.RegisterDependency<Level2, Level2>();
            resolver.RegisterDependency<Level3, Level3>();
            var t = resolver.ResolveDependency<Level3>();
        }
    }


    public class Level3
    {
        [Require]
        public Level2 Level2 { get; set; }
    }

    public class Level2
    {
        public string Name { get; set; }
    }

   
}
