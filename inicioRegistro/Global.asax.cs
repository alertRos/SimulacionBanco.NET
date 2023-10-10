using inicioRegistro.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace inicioRegistro
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Error()
        {
            Exception ex = Server.GetLastError();
            HttpException exception = ex as HttpException;
            string action;
            if(Server.GetHashCode() == 404)
            {
                action = "Error";
            }
            else
            {
                action = "Error";
            }
            Context.ClearError();
            RouteData route = new RouteData();
            route.Values.Add("controller", "Error");
            route.Values.Add("action", action);
            IController controller = new ErrorController();
            controller.Execute(
                new RequestContext(new HttpContextWrapper(Context), route));
        }
    }
}
