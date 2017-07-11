using System;
using System.Collections.Generic;
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
        // GET /api/subjects/getMaterias
        public object GetMaterias()
        {
            var SubjectsList = _context.Subjects.Select( data => new {
                codigo = data.Codigo,
                id= data.Id,
                name = data.Name,
                QtyCredits = data.QtyCredits,
                Area = data.Areas.Name,
                areaid = data.Areas.Id
            }).ToList();

            return SubjectsList;
        }

        public object GetMateria(int id)
        {
            var SubjectsList = _context.Subjects.Where( x=> x.Id == id).Select(data => new {
                codigo = data.Codigo,
                id = data.Id,
                name = data.Name,
                QtyCredits = data.QtyCredits,
                Area = data.Areas.Name,
                areaid = data.Areas.Id

            }).ToList();

            return SubjectsList;
        }



        public class SubjectsDTO
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string Name { get; set; }
            public int QtyCredits { get; set; }
            public int AreaId { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage CreateSubject(SubjectsDTO @new)
        {
            try
            {
                _context.Subjects.Add(new Subject
                {
                    Codigo = @new.Codigo,
                    Name = @new.Name,
                    QtyCredits = @new.QtyCredits,
                    Areas = _context.Areas.Where(x => x.Id == @new.AreaId).FirstOrDefault()

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
        public HttpResponseMessage ModifySubject(SubjectsDTO @actual)
        {
            try
            {
                var curr = _context.Subjects.Where(x => x.Id == @actual.Id).FirstOrDefault();

                curr.Name = @actual.Name;
                curr.Codigo = @actual.Codigo;
                curr.QtyCredits = @actual.QtyCredits;
                curr.Areas = _context.Areas.Where(a=>a.Id == @actual.AreaId).FirstOrDefault();

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
