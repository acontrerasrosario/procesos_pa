using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace procesos_app.Models
{
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
    }
}