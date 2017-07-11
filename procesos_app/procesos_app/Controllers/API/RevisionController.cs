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

                var seccion = from s in _context.Sections
                              join st in _context.TeacherSection on s.Id equals st.SectionId

                              join ss in _context.StudentSection on s.Id equals ss.SectionId
                              where ss.StudentId == currentStudent
                                  select new
                                  {
                                      codigo = s.Subject.Codigo,
                                      nombre = s.Subject.Name,
                                      seccion = s.Name,
                                      profesor = st.Teacher.FirstName + " " + st.Teacher.SecondName + " "
                                      + st.Teacher.LastName + " " + st.Teacher.SecondLastName,
                                      id = s.Id,
                                      //calificacion = ss.FinalScore
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
       


    }
}
