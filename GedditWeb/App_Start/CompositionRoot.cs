using GedditWeb.Services.Account;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace GedditWeb.App_Start
{
    public static class CompositionRoot
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterInstance<IAccountService>(new GamesparksAccountService());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}