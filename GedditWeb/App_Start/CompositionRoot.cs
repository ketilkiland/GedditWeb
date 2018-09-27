using GedditWeb.Services.Account;
using GedditWeb.Services.POI;
using GedditWeb.Services.POI.Gamesparks;
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
            //container.RegisterInstance<IPOIService>(new GamesparksPOIService());
            container.RegisterInstance<IPOIService>(new MockPOIService());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}