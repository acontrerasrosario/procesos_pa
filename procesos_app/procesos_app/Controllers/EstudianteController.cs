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
            string currentUser = User.Identity.GetUserId();

            ApplicationDbContext _cont = new ApplicationDbContext();
            MotherOfModels modelo = new MotherOfModels();
            
            var LstSubject = (from x in _cont.Subjects
                              join a in _cont.Areas on x.AreasId equals a.Id
                              select x);

            var ListaArea = (from x in _cont.Subjects
                             join a in _cont.Areas on x.AreasId equals a.Id
                             select a);

            var estSection = (from stdS in _cont.StudentSection
                              join s in _cont.Sections on stdS.Section.Id equals s.Id
                              join ss in _cont.SectionSchedule on s.Id equals ss.SectionId
                              join sch in _cont.Schedule on ss.ScheduleId equals sch.Id
                              join u in _cont.Users on stdS.ApplicationUser.Id equals u.Id
                              join m in _cont.Subjects on s.SubjectId equals m.Id
                              join cl in _cont.ClassRooms on s.ClassRoomId equals cl.Id
                              where stdS.ApplicationUser.Id == currentUser
                              select new
                              {
                                  Id = stdS.Id,
                                  Codigo = m.Codigo,
                                  Seccion = s.Name,
                                  Materia = m.Name,
                                  Profesor = u.FirstName+ " " + u.LastName,
                                  Creditos = m.QtyCredits,
                                  Horario = sch.Day + " de " + sch.StartTime.Hour + " a " + sch.EndTime.Hour,
                                  Aula = cl.Name
                              }).ToList();

            
            modelo.ListaArea = ListaArea;
            modelo.ListaSubject = LstSubject;

            List<estSelecion> lista = new List<estSelecion>();
            foreach (var item in estSection)
            {

                lista.Add(new estSelecion
                { 
                    Id = item.Id,
                    Codigo = item.Codigo,
                    Seccion = item.Seccion,
                    Materia = item.Materia,
                    Profesor = item.Profesor,
                    Creditos = item.Creditos,
                    Horario = item.Horario,
                    Aula = item.Aula
                });
            }


            modelo.estSection = lista;
           

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

        public void AgregarSeccion(int id)
        {

            try
            {
                string currentUser = User.Identity.GetUserId();

                var stdSeccion = new StudentSection
                {
                    FinalScore = 0,
                    ApplicationUser = _context.Users.Where(u => u.Id == currentUser).FirstOrDefault(),
                    Section = _context.Sections.Where(s => s.Id == id).FirstOrDefault(),
                    Status = procesos_app.Models.Enums.StatusSectionEnum.SectionStatus.Cusando

                };

                _context.StudentSection.Add(stdSeccion);
                _context.SaveChanges();
            }

            catch (Exception e)
            {           
                return;
            }


        }
    }
}