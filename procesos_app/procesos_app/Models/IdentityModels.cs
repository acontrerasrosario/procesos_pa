using System;
using System.Collections.Generic;
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
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [Required]
        [MaxLength(25)]
        public string Genrer { get; set; }
        [MaxLength(100)]
        public string Tanda { get; set; }
        [MaxLength(100)]
        public string Dispnibilidad { get; set; }
        [MaxLength(100)]
        public string UserType { get; set; }

        public List<Areas> Area { get; set; }
        public int AreaId { get; set; }
    }

    

    public class Areas
    {
        public int Id { get; set; }
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

        public Areas Area { get; set; }

        public List<Subject> Subject { get; set; }

    }

    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QtyCredits { get; set; }
        public List<Career> Career { get; set; }
    }

    public class Trimester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }

    public class UserSection
    {
        public int Id { get; set; }
        public Section Section { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public double FinalScore { get; set; }
        public string Status { get; set; }
        

    }

    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public Trimester Trimester { get; set; }
        public int TrimesterId { get; set; }
        public string SecType { get; set; }
        public object Horario { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int ClassRoomId { get; set; }
    }

    public class Builder
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Builder Builder { get; set; }
        public int BuilderId { get; set; }

    }  

    public class UserCareer
    {
        [Required]
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public Career Career { get; set; }
        
        public int QtyApprovedQuarter { get; set; } // cant. trimestres cursados
        public int QtyApprovedCredits { get; set; } // cant. creditos aprobados
        public int QtyApprovedSubjects { get; set; } // cant. materias aprobados
        public double QuarterlyIndex { get; set; } // Indice Trimestral
        public double GeneralIndex { get; set; } // Indice General
        public string Status { get; set; } //GRADUADO,INACTIVO, ACTIVO, BLOQUEADO
    }

    


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Career> Career { get; set; }
        public DbSet<Areas> Areas { get; set; }
        
        public ApplicationDbContext()
            : base("ProcesosDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}