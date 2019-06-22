using HCL.UBP.DataAccess.Interface;
using HCL.UBP.DataAccess.Repositories;
using log4net;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace HCL.UBP.DataAccess
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<ILog>(new Unity.Injection.InjectionFactory(factory => LogManager.GetLogger("",)));
            container.RegisterType<IUserRepository, UserRepository>();
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}