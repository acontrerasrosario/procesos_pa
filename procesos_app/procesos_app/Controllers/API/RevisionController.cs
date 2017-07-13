using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using procesos_app.Models;
using Microsoft.AspNet.Identity;

namespace procesos_app.Controllers.API
{
    public class RevisionController : ApiController
    {

        private ApplicationDbContext _context;

        public RevisionController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/revision/getSecciones/
        public object GetSecciones()
        {
            try
            {
                string currentStudent = User.Identity.GetUserId();

                var activo = from r in _context.Revisiones
                             where r.StudentId == currentStudent
                             && r.SolicitudStudiante == true
                             select r.SectionId;

                var seccion = from s in _context.Sections
                              join st in _context.TeacherSection on s.Id equals st.SectionId
                              join ss in _context.StudentSection on s.Id equals ss.SectionId
                              where ss.StudentId == currentStudent && !(activo).Contains(s.Id)
                              select new
                              {
                                  codigo = s.Subject.Codigo,
                                  nombre = s.Subject.Name,
                                  seccion = s.Name,
                                  profesor = st.Teacher.FirstName + " " + st.Teacher.SecondName + " "
                                  + st.Teacher.LastName + " " + st.Teacher.SecondLastName,
                                  id = s.Id,
                                  calificacion = ss.FinalScore,
                                  areaId = s.Subject.AreasId,
                                  teacherId = st.TeacherId,
                                  studentId = ss.StudentId
                              };


                return seccion;



            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }
        // GET /api/revision/GetRevisionHechaEst/
        public object GetRevisionHechaEst()
        {
            try
            {
                var revisionActiva = from r in _context.Revisiones
                                     join s in _context.Sections on r.SectionId equals s.Id
                                     join st in _context.TeacherSection on s.Id equals st.SectionId
                                     join ss in _context.StudentSection on s.Id equals ss.SectionId

                                     where r.SolicitudStudiante == true
                                     select new
                                     {
                                         revisionId = r.Id,
                                         status = r.Cambio,
                                         codigo = s.Subject.Codigo,
                                         nombre = s.Subject.Name,
                                         seccion = s.Name,
                                         profesor = st.Teacher.FirstName + " " + st.Teacher.SecondName + " "
                                            + st.Teacher.LastName + " " + st.Teacher.SecondLastName,
                                         id = s.Id,
                                         calificacion = ss.FinalScore,
                                         motivo = r.Motivo
                                     };

                return revisionActiva;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [HttpDelete]
        //GET /api/revision/CancelarRevision/
        public void CancelarRevision(int id)
        {

            var valDB = _context.Revisiones.Where(v => v.Id == id).FirstOrDefault();

            if (valDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Revisiones.Remove(valDB);

            _context.SaveChanges();

        }

        public class SolicitudDTO
        {
            public string StudentId { get; set; }
            public int SectionId { get; set; }
            public bool SolicitudStudiante { get; set; }
            public int AreaId { get; set; }
            public bool SolicitudArea { get; set; }
            public bool Cambio { get; set; }
            public string TeacherId { get; set; }
            public bool Finished { get; set; }
            public string Motivo { get; set; }

        }

        

        // POST /api/Revision/CrearSolicitud/
        public HttpResponseMessage CrearSolicitud(SolicitudDTO @new)
        {
            try
            {
                _context.Revisiones.Add(new Revision
                {
                    StudentId = @new.StudentId,
                    SectionId = @new.SectionId,
                    SolicitudStudiante = @new.SolicitudStudiante,
                    AreaId = @new.AreaId,
                    SolicidudArea = @new.SolicitudArea,
                    Cambio = @new.Cambio,
                    TeacherId = @new.TeacherId,
                    Finished = @new.Finished,
                    Motivo = @new.Motivo
                    
                    
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
