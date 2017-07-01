using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using procesos_app.Models;

namespace procesos_app.Controllers.API
{
    public class SubjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/areas/getAreas
        public IEnumerable<Areas> GetAreas()
        {
            var areaList = _context.Areas.ToList();
            return areaList;
        }

        // GET /api/areas/getMaterias
        public IEnumerable<Subject> GetMaterias()
        {
            var SubjectsList = _context.Subjects.ToList();
            return SubjectsList;
        }



        [HttpPost]
        public HttpResponseMessage createSubject(Subject @new)
        {
            try
            {
                _context.Subjects.Add(new Subject
                {
                    Name = @new.Name,
                    QtyCredits = @new.QtyCredits,
                    PreRequisitCredits = @new.PreRequisitCredits,
                    Subject1 = @new.Subject1
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
