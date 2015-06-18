using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPF.ServiceUI
{
    public class Resolver
    {
        public void Register<Target, Impl>(bool isSingleton = true)
        {

        }

        public void Register<Target>(Func<Target> factoryMethod, bool isSingleton)
        {

        }

        public TService Resolve<TService, TShell>()
            where TService:ServiceBase
            where TShell:Window
        {
            throw new NotImplementedException();
        }
    }
}
