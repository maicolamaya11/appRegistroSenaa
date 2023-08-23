using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Entidades
{
    public class ClPersonalE
    {
        public int idPersonal { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string documento { get; set; }
        public int idPrograma { get; set; }
    }
}