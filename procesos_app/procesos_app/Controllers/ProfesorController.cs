using Newtonsoft.Json;
using procesos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
            string usuarioactivo = User.Identity.GetUserId();


            modelo.NombreTrimestre = from c in _algo.Trimesters
                                     where c.Id == 1
                                     select c;

           modelo.ListaSection = from sc in _algo.Sections
                                    join ts in _algo.TeacherSection on sc.Id equals ts.Section_Id1
                                    join sb in _algo.Subjects on sc.Id equals sb.Id
                                     where ts.ApplicationUser_Id == usuarioactivo
                                     select sc;

            return View(modelo);
        }
        
        //GET: Profesor
         public ActionResult PublicacionFinal()
        {
            return View();
        }
        
        //GET: Profesor
        public ActionResult PublicacionIncompleto()
        {
            return View();
        }
        
        //GET: Profesor
        public ActionResult Revision()
        {
            return View();
        }

    }
}