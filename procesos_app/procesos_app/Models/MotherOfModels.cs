using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace procesos_app.Models
{
    public class estSelecion
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Seccion { get; set; }
        public string Materia { get; set; }
        public string Profesor { get; set; }
        public string Horario { get; set; }
        public string Aula { get; set; }
        public int Creditos { get; set; }

    }
    public class MotherOfModels
    {

        public Career Careers { get; set; }
        public Areas Areas { get; set; }
        public UserCareer UserCareers { get; set; }
        public Builder Builders { get; set; }
        public ClassRoom ClassRooms { get; set; }
        public Section Sections { get; set; }
        public StudentSection StudentSection { get; set; }
        public TeacherSection TeacherSection { get; set; }
        public Trimester Trimesters { get; set; }
        public Subject Subjects { get; set; }
        public Schedule Schedule { get; set; }



        // miguel
        public IEnumerable<Section> ListaSection { get; set; }
        public IEnumerable<Subject> ListaSubject { get; set; }
        public IEnumerable<MotherOfModels> Prueba { get; set; }
        public IEnumerable<Areas> ListaArea { get; set; }
        public ApplicationUser DataInicioUser { get; set; }
        public UserCareer DataInicioUserCarrer { get; set; }
        public Career DataInicioCarrer { get; set; }

        public List<estSelecion> estSection { get; set; }
        public IEnumerable<Section> estSectionS { get; set; }
        public IEnumerable<Subject> estSectionM { get; set; }
        public IEnumerable<ApplicationUser> estSectionU { get; set; }



    }
}