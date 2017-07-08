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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Profesor
        public ActionResult PublicacionMediotermino()
        {
            return View();
        }
        
        //GET: Proesor
         public ActionResult PublicacionFinal()
        {
            return View();
        }
        
        //GET: Proesor
        public ActionResult PublicacionIncompleto()
        {
            return View();
        }
        
        //GET: Proesor
        public ActionResult Revision()
        {
            return View();
        }

    }
}