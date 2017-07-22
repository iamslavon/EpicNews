using EbaNews.Core.Interfaces;
using EbaNews.Data;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace EbaNews.Ioc
{
    public static class IocContainer
    {
        private static Container container;

        public static void Initialize()
        {
            if (container != null) return;

            container = new Container();
            RegisterTypes();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterTypes()
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
