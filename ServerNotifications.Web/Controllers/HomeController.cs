﻿using System;
using System.Web.Mvc;

namespace ServerNotifications.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // We reach some exceptional condition, and the
            // applicaiton is gonna throw an exeption.
            throw new Exception("[this is a test] Ups, something went wrong!");
        }
    }
}
