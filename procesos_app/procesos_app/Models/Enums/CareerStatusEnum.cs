using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace procesos_app.Models.Enums
{
    public class CareerStatusEnum
    {
        public enum CareerStatus
        {
            Activo = 0,
            Inactivo = 1,
            Rechazado = 2,
            Bloqueado = 3,
            Graduado = 4,
        }
    }
}