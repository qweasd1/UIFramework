using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF.ServiceUI;

namespace WPF.UI.Test
{
    public class EditorService:ServiceBase
    {
        public const string View_Editor = "Editor";
        
        [View(ID=View_Editor)]
        private TextBox textBox;
    }
}
