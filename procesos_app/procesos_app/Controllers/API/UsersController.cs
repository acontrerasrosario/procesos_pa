using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Security;

namespace procesos_app.Models.API
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/students
        public IEnumerable<ApplicationUser> GetStudents()
        {
            var students = from s in _context.Users
                join r in _context.Roles
                on s.Roles equals r.Users
                where r.Name == "ESTUDIANTE"
                select s;

            return students.ToList();
        }

        // GET /api/teacher
        public IEnumerable<ApplicationUser> GetTeacher()
        {
            var teacher = from s in _context.Users
                join r in _context.Roles
                on s.Roles equals r.Users
                where r.Name == "PROFESOR"
                select s;

            return teacher.ToList();
        }

        // GET /api/users
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }


        // GET /api/users/1
        public IEnumerable<ApplicationUser> GetStudents(int id)
        {
            var students = from s in _context.Users
                        join r in _context.Roles
                        on s.Roles equals r.Users
                        where r.Name == "ESTUDIANTE" && s.Id2 == id
                        select s;


            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return students.ToList();

        }

        // GET /api/users/1
        public IEnumerable<ApplicationUser> GetTeachers(int id)
        {
            var students = from s in _context.Users
                join r in _context.Roles
                on s.Roles equals r.Users
                where r.Name == "PROFESOR" && s.Id2 == id
                select s;


            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return students.ToList();

        }

        // POST /api/users/
        [HttpPost]
        public ApplicationUser CreateUser(ApplicationUser user)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }


        
        // PUT /api/teacher/1
        [HttpPut]
        public void UpdateTeacher(int id, ApplicationUser user)
        {
            if(!ModelState.IsValid)
                throw  new HttpResponseException(HttpStatusCode.BadRequest);


            var userInDb = _context.Users.FirstOrDefault(u => u.Id2 == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            userInDb.UserName = user.UserName;
            userInDb.Area = user.Area;
            userInDb.BirthDay = user.BirthDay;
            userInDb.Dispnibilidad = user.Dispnibilidad;
            userInDb.Cedula = user.Cedula;
            userInDb.Genrer = user.Genrer;
            userInDb.Tanda = user.Tanda;
            userInDb.InstitutionalEmail = user.InstitutionalEmail;
            userInDb.Email = user.Email;
            userInDb.PhoneNumber = user.PhoneNumber;

            _context.SaveChanges();

        }

        public void UpdateStudent(string id, ApplicationUser user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var userInDb = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            userInDb.UserName = user.UserName;
            userInDb.BirthDay = user.BirthDay;
            userInDb.Cedula = user.Cedula;
            userInDb.Genrer = user.Genrer;
            userInDb.Tanda = user.Tanda;
            userInDb.InstitutionalEmail = user.InstitutionalEmail;
            userInDb.Email = user.Email;
            userInDb.PhoneNumber = user.PhoneNumber;
            
            _context.SaveChanges();
            
        }

        // DELETE /api/customer/1
        public void DeleteUser(string id)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userInDb == null)
               throw new HttpResponseException(HttpStatusCode.NotFound);


            _context.Users.Remove(userInDb);
        }






    }
}
