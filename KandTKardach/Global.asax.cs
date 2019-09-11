using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KandTKardach
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);         
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            HttpException httpEx = ex as HttpException;
            if (httpEx != null)
            {
                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        Response.Redirect("~/ErrorHandler/NotFound");
                        break;
                    default:
                        Response.Redirect($"~/ErrorHandler/Error?exception={httpEx.Message}");
                        break;
                }
            }
        }
    }
}
