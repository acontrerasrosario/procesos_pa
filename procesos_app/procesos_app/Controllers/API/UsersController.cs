using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using procesos_app.Models;

namespace procesos_app.Controllers.API
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/users/GetStudents
        public IEnumerable<ApplicationUser> GetStudents()
        {
           

            var studentRole = _context.Roles.FirstOrDefault(x => x.Name == "ESTUDIANTE");

            var allStudents = _context.Users
                .Where(x => x.Roles
                    .Select(role => role.RoleId)
                    .Contains(studentRole.Id)
                );

            return allStudents.ToList();
        }

        // GET /api/users/GetTeachers
        public IEnumerable<ApplicationUser> GetTeachers()
        {
            var teacherRole = _context.Roles.FirstOrDefault(x => x.Name == "PROFESOR");

            var allTeachers = _context.Users
                .Where(x => x.Roles
                    .Select(role => role.RoleId)
                    .Contains(teacherRole.Id)
                );

            return allTeachers.ToList();
        }

        // GET /api/users
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.Users.ToList(); ;
        }


        // GET /api/users/GetStudents/1
        public IEnumerable<ApplicationUser> GetStudents(int id)
        {
            var studentRole = _context.Roles.FirstOrDefault(x => x.Name == "ESTUDIANTE");

            var student = _context.Users
                .Where(x => x.Roles
                    .Select(role => role.RoleId) 
                    .Contains(studentRole.Id) && x.Id2 == id 
                );


            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return student.ToList();

        }

        // GET /api/users/GetTeachers/1
        public IEnumerable<ApplicationUser> GetTeachers(int id)
        {
            var teacherRole = _context.Roles.FirstOrDefault(x => x.Name == "PROFESOR");

            var teachers = _context.Users
                .Where(x => x.Roles
                                .Select(role => role.RoleId)
                                .Contains(teacherRole.Id) && x.Id2 == id
                );


            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return teachers.ToList();

        }

        // POST /api/users/
        [HttpPost]
        public ApplicationUser CreateUser(ApplicationUser user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);




            _context.Users.Add(user);
            _context.SaveChanges();


            return user;
        }



        // PUT /api/teacher/1
        [HttpPut]
        public void UpdateTeacher(int id, ApplicationUser user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var userInDb = _context.Users.FirstOrDefault(u => u.Id2 == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Mapper.Map<UserDto, ApplicationUser>;

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
