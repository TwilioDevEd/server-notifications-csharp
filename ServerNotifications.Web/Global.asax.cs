using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ServerNotifications.Web.Domain;
using ServerNotifications.Web.Models.Repository;

namespace ServerNotifications.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected async void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var message = string.Format("[This is a test] ALERT!" +
                "It appears the server is having issues." +
                "Exception: {0}. Go to: http://newrelic.com for more details.", exception.Message);

            var notifier = new Notifier(new AdministratorsRepository());
            await notifier.SendMessagesAsync(message);
        }
    }
}
