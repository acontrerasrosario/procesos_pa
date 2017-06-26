using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace procesos_app.Models.Enums
{
    public class StatusSectionEnum
    {
        public enum SectionStatus
        {
            Cusando = 0,
            Satisfactorio = 1,
            Retiro = 2,
            InSatisfactorio = 3    
        }
    }
}