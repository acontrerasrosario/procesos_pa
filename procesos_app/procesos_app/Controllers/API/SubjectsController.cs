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
    }
}
