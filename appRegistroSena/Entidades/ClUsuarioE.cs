using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Entidades
{
    public class ClUsuarioE
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get;set; }
        public string telefono { get; set; }
        public string clave { get; set; }
        public string documento { get; set;}
        public string rol { get; set; }
    }
}