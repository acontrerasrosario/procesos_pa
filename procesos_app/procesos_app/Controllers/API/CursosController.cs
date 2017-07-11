using procesos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace procesos_app.Controllers.API
{
    public class CursosController : ApiController
    {
        private ApplicationDbContext _context;

        public CursosController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/cursos/getcursos/
        public object getCursos()
        {
            try
            {

                var cursos = from c in _context.ClassRooms
                             join b in _context.Builders on c.Builder.Id equals b.Id
                             select new
                             {
                                 id = c.Id,
                                 name = b.NickName+" "+ c.Name 
                             };

                return cursos;
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
