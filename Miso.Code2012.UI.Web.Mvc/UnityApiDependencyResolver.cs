using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;

namespace Miso.Code2012.UI.Web.Mvc
{
    /// <summary>
    /// APIの方のDependencyResolver
    /// </summary>
    public class UnityApiDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        public UnityApiDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        private readonly IUnityContainer _container;

        public IDependencyScope BeginScope()
        {
            // This example does not support child scopes, so we simply return 'this'.
            return this; 
        }

        public object GetService(Type serviceType)
        {
            object service;
            try
            {
                service = _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }
    }
}