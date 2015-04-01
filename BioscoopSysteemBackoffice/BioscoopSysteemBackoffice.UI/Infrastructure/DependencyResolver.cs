﻿using BioscoopSysteemWebsite.Domain.Implementations;
using BioscoopSysteemWebsite.Domain.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioscoopSysteemBackoffice.UI.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IRepository>().To<PersistentRepository>();
        }
    }
}