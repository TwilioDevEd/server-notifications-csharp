using System;
using System.Web.Mvc;

namespace ServerNotifications.WebMvc3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // We reach some exceptional condition, and the
            // applicaiton is gonna throw an exeption.
            throw new Exception("Ups, something went wrong!");
        }
    }
}