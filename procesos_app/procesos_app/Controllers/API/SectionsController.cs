using procesos_app.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace procesos_app.Controllers.API
{
    public class SectionsController : ApiController
    {
        private ApplicationDbContext _context;

        public SectionsController()
        {
            _context = new ApplicationDbContext();
        }
        


        // GET /api/sections/GetProfesor
        public object GetProfesor(int materiaId, int HorarioId)
        {

            
                var teacherRole = _context.Roles.FirstOrDefault(x => x.Name == "Profesor");

            var profesor = from U in _context.Users
                           join TP in _context.TandaProfesor
                                                                        on U.Id equals TP.ProfesorId
                           join S in _context.Schedule
                                                                        on TP.TandaId equals S.Id
                           join paa in _context.ProfesorAutorizacion
                                                                        on U.Id equals paa.ProfesorId
                           where (TP.TandaId == HorarioId)
                                  && paa.SubjectId == materiaId
                                  && !(from x in _context.TeacherSection
                                       join sec in _context.Sections on x.Section.Id equals sec.Id
                                       join ss in _context.SectionSchedule on sec.Id equals ss.SectionId
                                       join sch in _context.Schedule on ss.ScheduleId equals sch.Id
                                       where sch.Id == HorarioId
                                       select x.TeacherId).Contains(U.Id)
                           select U.Id;
                               




                return profesor;

           
           


        }

        // GET /api/sections/getsectype/
        public object getSecType()
        {
            try
            {

                var tipo = Enum.GetValues(typeof(procesos_app.Models.Enums.SectionTypeEnum.SectionType))
                    .Cast<procesos_app.Models.Enums.SectionTypeEnum.SectionType>()
                    .Select(t => new
                    {
                        Value = (int)t, Name = t.ToString()

                    });


                return tipo;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

       
        // GET /api/sections/getHorarios?classRoomActual=
        public object getHorarios(int classRoomActual)
        {
            try
            {

                var horarios = from s in _context.Schedule
                               join ss in _context.SectionSchedule on s.Id equals ss.ScheduleId
                               join sec in _context.Sections on ss.SectionId equals sec.Id
                               where !(from r in _context.ClassRooms
                                       join secc in _context.Sections on r.Id equals secc.ClassRoomId
                                       join secs in _context.SectionSchedule on secc.Id equals secs.SectionId
                                       join sch in _context.Schedule on secs.ScheduleId equals sch.Id
                                       where secc.ClassRoomId == classRoomActual
                                       select sch.Id).Contains(s.Id)
                               select new
                               {
                                   horarioId = s.Id,
                                   dia = s.Day,
                                   horaInicio = s.StartTime,
                                   horaFinal = s.EndTime,
                                   nameTotal = s.Day + " de " +
                                   (s.StartTime).Hour + " a " 
                                   + (s.EndTime).Hour

                               };
                          
                return horarios;
            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // GET /api/sections/GetActualTrimestre/
        public object GetActualTrimestre()
        {
            try
            {
                var today = DateTime.Now;

                var trimestre = from t in _context.Trimesters
                                where (today >= t.Inicio && today <= t.Fin)
                                select t.Id;


                return trimestre;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        //GET /api/sections/GetSecciones/
        public object GetSecciones()
        {
            try
            {
                var secciones = from s in _context.Sections
                                join r in _context.ClassRooms on s.ClassRoomId equals r.Id
                                join ss in _context.SectionSchedule on s.Id equals ss.SectionId
                                join sch in _context.Schedule on ss.ScheduleId equals sch.Id
                                join b in _context.Builders on r.Builder.Id equals b.Id
                                join ts in _context.TeacherSection on s.Id equals ts.SectionId
                                join u in _context.Users on ts.TeacherId equals u.Id
                                join subj in _context.Subjects on s.SubjectId equals subj.Id
                                select new
                                {

                                    secId = s.Id,
                                    secName = s.Name,
                                    secTrimestre = s.Trimester.Name,
                                    curso = b.NickName+ " "+ s.ClassRoom.Name,
                                    dia = sch.Day,
                                    horaInicio = sch.StartTime.Hour,
                                    horaFin = sch.EndTime.Hour,
                                    horario = sch.Day + " de "+ sch.StartTime.Hour + " a "+ sch.EndTime.Hour,
                                    profesorId = u.Id,
                                    nombreProf = u.FirstName+ " "+ u.SecondName+ " "+
                                                    u.LastName+ " " + u.SecondLastName,
                                    materia = subj.Name

                                };


                return secciones;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public class SeccionDTO
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public int SubjectId { get; set; }
            public procesos_app.Models.Enums.SectionTypeEnum.SectionType SecType { get; set; }
            public int Trimester_Id { get; set; }
            public int ClassRoomId { get; set; }
            public int HorarioId { get; set; }
        }


        public class ProfesorSeccionDTO
        {
            public string ProfesorId { get; set; }
            public int SeccionId { get; set; }
        }

        //POST /api/sections/crearSeccion/

        [HttpPost]
        public HttpResponseMessage CrearSeccion(SeccionDTO @nuevaSeccion)
        {
            try
            {
                var errorProf = "No hay profesor disponible para esta seccion";
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, errorProf);


                
                var today = DateTime.Now;
                
                var objeto = new Section
                {

                    Name = @nuevaSeccion.Name,
                    SubjectId = @nuevaSeccion.SubjectId,
                    TrimesterId = (from t in _context.Trimesters
                                  where today >= t.Inicio && today <= t.Fin
                                  select t.Id).FirstOrDefault(),
                    SecType = @nuevaSeccion.SecType,
                    ClassRoomId = @nuevaSeccion.ClassRoomId

                };

                _context.Sections.Add(objeto);
                _context.SaveChanges();


                _context.SectionSchedule.Add(
                    
                    new SectionSchedule{
                       ScheduleId = @nuevaSeccion.HorarioId,
                        SectionId = objeto.Id
                    });

                var profesor = (from U in _context.Users
                                join TP in _context.TandaProfesor
                                                                             on U.Id equals TP.ProfesorId
                                join S in _context.Schedule
                                                                             on TP.TandaId equals S.Id
                                join paa in _context.ProfesorAutorizacion
                                                                             on U.Id equals paa.ProfesorId

                                where (TP.TandaId == @nuevaSeccion.HorarioId)
                                       && paa.SubjectId == @nuevaSeccion.SubjectId
                                       && !(from x in _context.TeacherSection
                                            join sec in _context.Sections on x.Section.Id equals sec.Id
                                            join ss in _context.SectionSchedule on sec.Id equals ss.SectionId
                                            join sch in _context.Schedule on ss.ScheduleId equals sch.Id
                                            where sch.Id == @nuevaSeccion.HorarioId
                                            select x.TeacherId).Contains(U.Id)
                                select U.Id).ToList();


                if (profesor.Count < 1)
                    return errorResponse;

                Random rdn = new Random();
                int ax = rdn.Next(profesor.Count());

                _context.TeacherSection.Add(new TeacherSection
                {
                    TeacherId = profesor[ax],
                    SectionId = objeto.Id
                });


                _context.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                
                if (e.InnerException != null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}
