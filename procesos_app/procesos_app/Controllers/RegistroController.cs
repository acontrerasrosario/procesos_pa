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

        ApplicationDbContext _context;

        public void ApplicationDbContext()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            
            return View();
        }

       


        [Authorize(Roles = "Registro")]
        public ActionResult Index()
        {
            

            return View();
        }
        [Authorize(Roles = "Registro")]
        public ActionResult NewSubject()
        {
            return View();
        }
        [Authorize(Roles = "Registro")]
        public ActionResult AdmSubject()
        {
            return View();
        }
        

        
        
        [Authorize(Roles = "Registro")]
        public ActionResult NewTrimester()
        {
            return View();
        }
        [Authorize(Roles = "Registro")]
        public ActionResult ProfesorAutorizado()
        {
            return View();
        }
        [Authorize(Roles = "Registro")]
        public ActionResult CrearSecciones()
        {
            return View();
        }



       
    }
}