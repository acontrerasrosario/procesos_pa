using procesos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace procesos_app.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Inicio()
        {
            return View();
        }

        // get: Estudiante
        public ActionResult _Inicio( )
        {
            return View();
        }

        // GET: Estudiante
        public ActionResult _Seleccion()
        {
            return View();
        }

        // GET: Estudiante
        public ActionResult _ProgramaAsignatura()
        {
            return View();
        }

        // GET: Estudiante
        public ActionResult _OfertaAcademica()
        {
            return View();
        }

    }
}