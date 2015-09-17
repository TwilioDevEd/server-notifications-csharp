using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ServerNotifications.Web.Domain;
using ServerNotifications.Web.Domain.Twilio;
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

        protected void Application_Error(object sender, EventArgs e)
        {
            // At this point we should capture the last exception thrown by doing
            // var exception = Server.GetLastError();
            var notifier = new Notifier(new AdministratorsRepository(), new RestClient());
            notifier.SendMessages();
        }
    }
}
