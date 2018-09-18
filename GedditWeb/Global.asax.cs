using GedditWeb.App_Start;
using GedditWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GedditWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GamesparksConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            CompositionRoot.RegisterComponents();

            GlobalFilters.Filters.Add(new UserProfileActionFilter());
        }
    }
}
