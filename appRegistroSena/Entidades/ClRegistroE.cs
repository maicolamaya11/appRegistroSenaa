using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Entidades
{
    public class ClRegistroE
    {
        public int idRegistro { get; set; }
        public string codigo { get; set; }
        public string estado { get; set; }
        public string fechaIngreso { get; set; }
        public string horaIngreso { get; set; }
        public string fechaSalida { get; set; }
        public string horaSalida { get; set; }
        public int idPersonal { get; set; }
        public string documentoPerson { get; set; }
        public int idPorteria { get; set; }
        public string nombrePort { get; set; }
        public int idUsuario { get; set; }
        public string documentoUsua { get; set; }


    }
}