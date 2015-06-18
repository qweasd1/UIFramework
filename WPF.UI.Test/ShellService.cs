using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ServiceUI;

namespace WPF.UI.Test
{
    public class ShellService:ServiceBase
    {
        [View(ID = "Shell")]
        private SimpleShell _shellView;

        [Export(ViewID=EditorService.View_Editor,TargetID=SimpleShell.Extension_Center)]
        private EditorService service;
    }
}
