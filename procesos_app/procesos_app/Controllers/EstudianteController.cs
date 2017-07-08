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
    public class EstudianteController : Controller
    {
        private ApplicationDbContext _context;

        public EstudianteController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Estudiante
        public ActionResult Inicio()
        {
            MotherOfModels modelo = new MotherOfModels();
            string currentUser = User.Identity.GetUserId();

            var DataInicioUser = (from c in _context.Users
                                 join d in _context.UserCareers
                                 on c.Id equals d.User_Id
                                 join z in _context.Careers
                                 on d.Career_Id equals z.Id
                                 where c.Id == currentUser
                                 select c).FirstOrDefault();

            var DataInicioUserCarrer = (from c in _context.Users
                                       join d in _context.UserCareers
                                       on c.Id equals d.User_Id
                                       join z in _context.Careers
                                       on d.Career_Id equals z.Id
                                       where c.Id == currentUser
                                       select d).FirstOrDefault();

            var DataInicioCarrer = (from c in _context.Users
                                   join d in _context.UserCareers
                                   on c.Id equals d.User_Id
                                   join z in _context.Careers
                                   on d.Career_Id equals z.Id
                                   where c.Id == currentUser
                                   select z).FirstOrDefault();

            modelo.DataInicioUser = DataInicioUser;
            modelo.DataInicioUserCarrer = DataInicioUserCarrer;
            modelo.DataInicioCarrer = DataInicioCarrer;

            var nombre = new
            {
                DataInicioCarrer,
                DataInicioUserCarrer,
                DataInicioUser,
                modelo
            };

            return View(modelo);


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