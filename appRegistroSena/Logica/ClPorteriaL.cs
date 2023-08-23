using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClPorteriaL
    {
        public List<ClPorteriaE> mtdListarServicio()
        {
            ClPorteriaD objPorteriaD = new ClPorteriaD();
            List<ClPorteriaE> listaPorteria = objPorteriaD.mtdListarPorteria();
            return listaPorteria;
        }
    }

}