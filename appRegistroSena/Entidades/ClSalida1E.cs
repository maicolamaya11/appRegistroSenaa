using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace appRegistroSena.Entidades
{
    public class ClSalida1E
    {
        public int idSalida { get; set; }
        public string estado { get; set; }
        public string observacion { get; set; }
        public string horaSalida { get; set; }
        public string fechaSalida { get; set; }
    }
}