using procesos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace procesos_app.Controllers.API
{
    public class AreasController : ApiController
    {
        private ApplicationDbContext _context;

        public AreasController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        // GET /api/areas/getAreas
        public object GetAreas()
        {
            var areaList = _context.Areas.Select(data => new {
                id = data.Id,
                Name = data.Name

            }).ToList();

            return areaList;
        }

    }
}
