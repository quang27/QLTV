using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GUIs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["Count"] = 0;
        }
        protected void Session_Start()
        {
            Application["Count"] = Convert.ToInt16(Application["Count"]) + 1;
        }
        protected void Session_End()
        {
            Application["Count"] = Convert.ToInt16(Application["Count"]) - 1;
        }
    }
}
