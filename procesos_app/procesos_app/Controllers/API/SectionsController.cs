using procesos_app.Models;
using System;
using System.Collections.Generic;
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
                                       select x.ApplicationUser.Id).Contains(U.Id)
                           select
                            new
                            {
                                ProfID = U.Id,
                                ProfName = U.FirstName + U.LastName,
                                TandaId = TP.Id,
                                HorId = S.Id
                            };




            return profesor;
        }


    }
}
