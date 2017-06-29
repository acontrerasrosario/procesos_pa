using Newtonsoft.Json;
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
     
        // GET: Estudiante
        public ActionResult Seleccion()
        {
            ApplicationDbContext _cont = new ApplicationDbContext();
            MotherOfModels modelo = new MotherOfModels();

            var LstSubject = (from x in _cont.Subjects
                              select x);

            modelo.ListaSubject = LstSubject;

            return View(modelo);
        }

        // GET: Estudiante
        public ActionResult Preseleccion()
        {
            return View();
        }

        // GET: Estudiante
        public ActionResult Retiro()
        {
            return View();
        }

        // get: Estudiante
        public ActionResult Revision()
        {
            return View();
        }

        // GET: Estudiante
        public ActionResult OfertaAcademica()
        {
            ApplicationDbContext _cont = new ApplicationDbContext();
            MotherOfModels modelo = new MotherOfModels();


            //var LstAreas = (from x in _cont.Areas
            //          select x);
            var LstSubject = (from x in _cont.Subjects
                      select x);

            //modelo.ListaArea = LstAreas;
            modelo.ListaSubject = LstSubject;

            return View(modelo);
        }

        public string _DetalleSeccion(int id)
        {
            ApplicationDbContext _cont = new ApplicationDbContext();
            MotherOfModels modelo = new MotherOfModels();

            var x = from z in _cont.Sections
                    join c in _cont.Subjects on z.Subject.Id equals c.Id
                    where c.Id == id
                    select z;

            return JsonConvert.SerializeObject(x);
        }
    }
}