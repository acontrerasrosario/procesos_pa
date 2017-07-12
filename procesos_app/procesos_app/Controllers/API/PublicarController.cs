using procesos_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;


namespace procesos_app.Controllers.API
{
    public class PublicarController : ApiController
    {

        private ApplicationDbContext _context;

        public PublicarController()
        {
            _context = new ApplicationDbContext();

        }

        // GET /api/publicar/GetSeccion/
        public object GetSeccion()
        {
            string currentTeacher = User.Identity.GetUserId();

            var sec = from s in _context.TeacherSection
                      where s.TeacherId == currentTeacher
                      select new
                      {
                          secName = s.Section.Name + s.Section.Subject.Name + "(" + s.Section.Subject.Codigo + ")",
                          secId = s.Id
                      };

            return sec.ToList();
        }
        //GET /api/Publicar/getStudents/
        public object getStudents(int SeccionId)
        {
            string currentTeacher = User.Identity.GetUserId();

            var students = from ts in _context.TeacherSection
                           join s in _context.Sections on ts.SectionId equals s.Id
                           join ss in _context.StudentSection on s.Id equals ss.SectionId
                           join u in _context.Users on ss.StudentId equals u.Id
                           where ts.SectionId == SeccionId
                           select new
                           {
                               estName = u.FirstName + " " + u.LastName,
                                        
                               estId = u.Id2,
                               cal = ss.FinalScore,
                                status = ss.Status
                           };

            return students.ToList();
        }


        public class PublicarDTO
        {
            public int Id { get; set; }
            public double FinalScore { get; set; }
            public procesos_app.Models.Enums.StatusSectionEnum.SectionStatus Status { get; set; }
            public string StudentId { get; set; }
            public int SectionId { get; set; }

        }

        //[HttpPut]
        //public HttpResponseMessage Publicar(PublicarDTO @actual)
        //{
        //    try
        //    {
        //        var curr = _context.StudentSection.Where(x => x.SectionId == @actual.).FirstOrDefault();

        //        curr.Name = @actual.Name;
        //        curr.Codigo = @actual.Codigo;
        //        curr.QtyCredits = @actual.QtyCredits;
        //        curr.Areas = _context.Areas.Where(a => a.Id == @actual.AreaId).FirstOrDefault();

        //        _context.SaveChanges();

        //        return Request.CreateResponse(HttpStatusCode.Created);
        //    }

        //    catch (Exception e)
        //    {
        //        if (e.InnerException != null)
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

    }
}
