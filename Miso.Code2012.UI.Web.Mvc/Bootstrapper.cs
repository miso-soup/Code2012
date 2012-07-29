using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Miso.Code2012.Model.Answers;
using Miso.Code2012.Repository.Repositories;
using Unity.Mvc3;

namespace Miso.Code2012.UI.Web.Mvc
{
    /// <summary>
    /// DIÇÃBootstrapper
    /// </summary>
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            IUnityContainer container = BuildUnityContainer();
            
            //ServiceLocatorÇÃê›íË
            IServiceLocator serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //APIÇÃDependencyResolverÇê›íË
            GlobalConfiguration.Configuration.DependencyResolver = new UnityApiDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IAnswerRepository, AnswerRepository>();

            return container;
        }
    }
}