using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Log.Interface;
using MvcPL.Controllers;

namespace MvcPL
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

        /// <summary>
        /// Actions when error is occured
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (ReferenceEquals(exception, null)) return;

            Response.Clear();
            var routeData = new RouteData();
            var httpErrorCode = (exception as HttpException)?.GetHttpCode();

            routeData.Values.Add("httpErrorCode", httpErrorCode);
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("exception", exception);

            var logger = (ILogger)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILogger));
            IController controller = new ErrorController(logger);
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));

            Response.End();
        }

    }
}
