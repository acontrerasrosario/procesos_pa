using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using procesos_app.Models;

namespace procesos_app.Controllers
{
    public class RegistroController : Controller
    {


        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult NewSubject()
        {
            return View();
        }

        public ActionResult AdmSubject()
        {
            return View();
        }

       
    }
}