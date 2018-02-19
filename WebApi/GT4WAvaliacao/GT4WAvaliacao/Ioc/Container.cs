using CommonServiceLocator;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GT4WAvaliacao.Ioc
{
    public static class Container
    {
        private static StandardKernel kernel;
        public static StandardKernel GetModule()
        {
            if (kernel == null)
            {
                kernel = new StandardKernel(new NinjectModulo());
                ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
            }
            return kernel;
        }
    }
}