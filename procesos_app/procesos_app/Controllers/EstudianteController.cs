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

          
            return View(modelo);


        }

        // GET: Estudiante
        public ActionResult Seleccion()
        {
            ApplicationDbContext _cont = new ApplicationDbContext();
            MotherOfModels modelo = new MotherOfModels();

            var LstSubject = (from x in _cont.Subjects
                              join a in _cont.Areas on x.AreasId equals a.Id
                              select x);

            var ListaArea = (from x in _cont.Subjects
                             join a in _cont.Areas on x.AreasId equals a.Id
                             select a);

            modelo.ListaArea = ListaArea;
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
            
            var w = (from s in _context.Sections
            join r in _context.ClassRooms on s.ClassRoomId equals r.Id
            join ss in _context.SectionSchedule on s.Id equals ss.SectionId
            join sch in _context.Schedule on ss.ScheduleId equals sch.Id
            join b in _context.Builders on r.Builder.Id equals b.Id
            join ts in _context.TeacherSection on s.Id equals ts.SectionId
            join u in _context.Users on ts.TeacherId equals u.Id
            join subj in _context.Subjects on s.SubjectId equals subj.Id
            where subj.Id == id
            select new
            {
                secId = s.Id,
                secName = s.Name,
                secTrimestre = s.Trimester.Name,
                curso = b.NickName + " " + s.ClassRoom.Name,
                dia = sch.Day,
                horaInicio = sch.StartTime.Hour,
                horaFin = sch.EndTime.Hour,
                horario = sch.Day + " de " + sch.StartTime.Hour + " a " + sch.EndTime.Hour,
                profesorId = u.Id,
                nombreProf = u.FirstName + " " + u.SecondName + " " +
                                u.LastName + " " + u.SecondLastName,
                materia = subj.Name

            }).ToList();

            return JsonConvert.SerializeObject(w);
        }
    }
}