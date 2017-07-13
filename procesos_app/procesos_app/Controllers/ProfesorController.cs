using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace procesos_app.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        [Authorize(Roles = "Profesor")]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Profesor")]
        public ActionResult Publicar()
        {
            return View();
        }
        [Authorize(Roles = "Profesor")]
        public ActionResult Revision()
        {
            return View();
        }





    }
}