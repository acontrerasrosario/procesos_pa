using procesos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace procesos_app.Controllers.API
{
    public class ValidarProfesorController : ApiController
    {

        private ApplicationDbContext _context;

        public ValidarProfesorController()
        {
            _context = new ApplicationDbContext();
        }

        
        public object getValidacion()
        {
            try
            {
                var val = from PA in _context.ProfesorAutorizacion
                          select new
                          {
                              materiaId = PA.SubjectId,
                              materiaName = PA.Subject.Name,
                              profesorId = PA.ProfesorId,
                              profesorName = PA.Profesor.FirstName+ " "+ PA.Profesor.LastName,
                              id = PA.Id
                          };

                return val;

            }

            catch (Exception e)
            {
                if (e.InnerException != null)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        //public object Validacion()

        // GET /api/ValidarProfesor/validacion
        [HttpGet]
        public object Validacion(string profesorId)
        {

            
            try
            {


                var val = from pa in _context.ProfesorAutorizacion
                          join s in _context.Subjects on pa.SubjectId equals s.Id
                          where profesorId != pa.ProfesorId &&
                          !(from paa in _context.ProfesorAutorizacion
                            where paa.ProfesorId == profesorId
                            select paa.SubjectId).Contains(pa.SubjectId)
                          select new
                          {
                              materiaId = pa.SubjectId,
                              materiaName = pa.Subject.Name
                          };

                return val;
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
        public void DeleteValidacion(int validacionId)
        {
            
                var valDB = _context.ProfesorAutorizacion.Where(v => v.Id == validacionId).FirstOrDefault();

                if (valDB == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                _context.ProfesorAutorizacion.Remove(valDB);


            _context.SaveChanges();
        }
            

        public class ValDTO
        {
            public string ProfesorId { get; set; }
            public int MateriaId { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage CrearValidacion(ValDTO @new)
        {
            try
            {
                _context.ProfesorAutorizacion.Add(new ProfesorAutorizacion
                {
                    ProfesorId = @new.ProfesorId,
                    SubjectId = @new.MateriaId

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
