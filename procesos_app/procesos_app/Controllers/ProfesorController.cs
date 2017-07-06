using Newtonsoft.Json;
using procesos_app.Models;
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
        public ActionResult PubMT()
        {
            ApplicationDbContext _algo = new ApplicationDbContext();
            MotherOfModels modelo = new MotherOfModels();


            modelo.NombreTrimestre = from c in _algo.Trimesters
                                     where c.Id == 1
                                     select c;

            modelo.SeccionProfesor = from d in _algo.TeacherSection
                                     where d.Section == 
                                     select d;

            return View(modelo);
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