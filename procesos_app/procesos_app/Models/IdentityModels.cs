﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace procesos_app.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        public int Id2 { get; set; }
        [Required]
        [MaxLength(13)]
        public char Cedula { get; set; }
        [MaxLength(256)]
        public string InstitutionalEmail { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        [MaxLength(25)]
        public string Genrer { get; set; }
<<<<<<< HEAD
=======
        [MaxLength(100)]
        public string Tanda { get; set; }
        [MaxLength(100)]
        public string Dispnibilidad { get; set; }
        [MaxLength(100)]
        public string UserType { get; set; }
        // AREA
        public Areas Area { get; set; }
        public int AreaId { get; set; }
        // Trimestre (saber trimestre en el que ingreso)
        public Trimester Trimester { get; set; } // trimestre de ingreso
    }

    

    public class Areas
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

    }

    public class Career
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }
        public int NoTrimester { get; set; } // Cant. de trimestre que tiene la carrera
        public int NoCredito { get; set; } // Cant. de creditos que tiene
        public int NoSubjetcs { get; set; } // cant. de materias que tiene
        // Area a la que pertenece la carrera - Uno a Muchos
        public Areas Area { get; set; }
        // Materia - Mucho a Mucho
        public List<Subject> Subject { get; set; }

    }

    public class Subject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int QtyCredits { get; set; }
        // Recursividad por prerequisitos
        public Subject Subject1 { get; set; }// Prerequisito
        public int PreRequisitCredits { get; set; } // prerequisito creditos
        // Carrera - Mucho a Mucho
        public List<Career> Career { get; set; }
    }
    
    public class Trimester
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Inicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fin { get; set; }
    }

    public class StudentSection
    {
        public int Id { get; set; }
        public Section Section { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public double FinalScore { get; set; }
        [Required]
        public string Status { get; set; } // CURSANDO, FINISHED (PASO MATERIA), RETIRO, QUEMO
        

    }

    public class TeacherSection
    {
        public int Id { get; set; }
        public Section Section { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        

    }


    public class Section
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        // Materia - Una materia tiene varias secciones (Uno a Mucho)
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        // Trimestre - Un trimestre tiene varias secciones (Uno a Mucho)
        // Aqui es para saber en que trimestre pertenece la seccion
        public Trimester Trimester { get; set; }
        public string SecType { get; set; } // TEORIA, VIRTUAL, LABORATORIO
        // Aula en la que dan la clase - Un Aula tiene varias Secciones (Uno a Mucho)
        public ClassRoom ClassRoom { get; set; }
        // Horario de la seccion - Mucho a Mucho (una seccion tiene varios horarios)
        // un horario tiene varias secciones
        public List<Schedule> Schedule { get; set; }
    }

    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } // Day + StartTime + EndTime

>>>>>>> bfba1cc4fee7087cef7cc3133144021efaef842d
        

    }

    public class UserRoles : IdentityRole
    {
        [Required]
        public DateTime HoraInicio { get; set; }
        [Required]
<<<<<<< HEAD
        public DateTime HoraFinal { get; set; }
=======
        public string Name { get; set; } // Nombre del aula
        // Edificio al que pertenece
        public Builder Builder { get; set; }

    }  

    public class UserCareer
    {
        [Required]
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public Career Career { get; set; }
        [Required] // resultados con valor inicial 0
        public int QtyApprovedQuarter { get; set; } // cant. trimestres cursados
        [Required] // resultados con valor inicial 0
        public int QtyApprovedCredits { get; set; } // cant. creditos aprobados
        [Required] // resultados con valor inicial 0
        public int QtyApprovedSubjects { get; set; } // cant. materias aprobados
        [Required] // Aqui se calculara, pero en el primer trimestre su indice es 4.0
        public double QuarterlyIndex { get; set; } // Indice Trimestral
        [Required] // Aqui se calculara, pero en el primer trimestre su indice es 4.0
        public double GeneralIndex { get; set; } // Indice General
        [Required] // Estado inicial ACTIVO
        public string Status { get; set; } //GRADUADO,INACTIVO, ACTIVO, BLOQUEADO
    }

    


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Career> Careers { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<UserCareer> UserCareers { get; set; }
        public DbSet<Builder> Builders { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<StudentSection> UserSections { get; set; }
        public DbSet<Trimester> Trimesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> Schedule { get; set; }


        public ApplicationDbContext()
            : base("ProcesosDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


>>>>>>> bfba1cc4fee7087cef7cc3133144021efaef842d
    }

}