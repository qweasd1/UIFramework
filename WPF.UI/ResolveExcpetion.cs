using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.UI
{
    public class ResolveAnalysisExcpetion:Exception
    {
        public ResolveAnalysisExcpetion(string message)
            :base(message)
        {

        }
    }

    public class ResovleNotRegisterException:Exception
    {
        public ResovleNotRegisterException(string message)
            : base(message)
        {

        }
    }
}
