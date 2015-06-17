using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF.UI.View
{
    /// <summary>
    /// ShellContainer.xaml 的交互逻辑
    /// </summary>
    public partial class ShellContainer : Window
    {
        public ShellContainer()
        {
            InitializeComponent();
        }

        [Extension(Name="Menu")]
        public void SetMenuRegion(Menu menu)
        {
            this.menuRegion.Children.Add(menu);
        }

        [Extension(Name="Toolbar",Mode= ExtensionType.Many)]
        public void AddToolbarRegion(ToolBar toolbar)
        {
            this.toolBarRegion.Children.Add(toolbar);
        }

        [Extension(Name = "Left", Mode = ExtensionType.Many)]
        public void AddLeftRegion(UIElement element, string name)
        {
            this.leftRegion.Items.Add(new TabItem() { Header = name });
        }

        [Extension(Name = "Right", Mode = ExtensionType.Many)]
        public void AddRightRegion(UIElement element, string name)
        {
            this.rightRegion.Items.Add(new TabItem() { Header = name });
        }

        [Extension(Name = "Status", Mode = ExtensionType.Many)]
        public void AddStatusRegion(StatusBar statusBar)
        {

        }

        [Extension(Name = "Center")]
        public void SetCenterRegion(UIElement element)
        {

        }

        
    }
}
