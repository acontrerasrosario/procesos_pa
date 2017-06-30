using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace procesos_app.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult One()
        {
            return View();
        }
        public ActionResult Two(int donuts = 40)
        {
            ViewBag.Donuts = donuts;
            return View();
        }
        [Authorize]
        public ActionResult Three()
        {
            return View();
        }
    }
}