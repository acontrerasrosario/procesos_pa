using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using procesos_app.Models;

namespace procesos_app.Controllers.API
{
    public class TrimestreController : ApiController
    {

        private ApplicationDbContext _context;

        public TrimestreController()
        {
            _context = new ApplicationDbContext();
        }


        public object GetTrimestres()
        {
            var trimestre = _context.Trimesters.Select( data => new {
                id = data.Id,
                name = data.Name,
                inicio = data.Inicio,
                fin = data.Fin


            }).ToList();

            return trimestre;
        }

        public object GetTrimestre(int id)
        {
            var trimestre = _context.Trimesters.Where(x => x.Id == id).Select(data => new {
                id = data.Id,
                name = data.Name,
                inicio = data.Inicio,
                fin = data.Fin

            }).ToList();

            return trimestre;
        }

        public class TrimestreDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Inicio { get; set; }
            public DateTime Fin { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage CreateTrimestre(TrimestreDTO @new)
        {
            try
            {
                _context.Trimesters.Add(new Trimester
                {
                    Name = @new.Name,
                    Inicio = @new.Inicio,
                    Fin = @new.Fin
                    
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

        [HttpPut]
        public HttpResponseMessage ModifySubject(TrimestreDTO @actual)
        {
            try
            {
                var curr = _context.Trimesters.Where(x => x.Id == @actual.Id).FirstOrDefault();

                
                curr.Name = @actual.Name;
                curr.Inicio = @actual.Inicio;
                curr.Fin = @actual.Fin;
                
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
