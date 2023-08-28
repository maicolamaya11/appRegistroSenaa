using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClPersonalL
    {
        public List<ClPersonalE> mtdBuscar(string documento)
        {
            ClPersonalD objProductoD = new ClPersonalD();
            List<ClPersonalE> listaPersonal = objProductoD.mtdBuscar(documento);
            return listaPersonal;
        }

        public List<ClPersonalE> mtdListarVigilante()
        {
            ClPersonalD objVigilanteD = new ClPersonalD();
            List<ClPersonalE> listaPersonal = objVigilanteD.mtdListarVigilante();
            return listaPersonal;
        }

        public List<ClPersonalE> mtdBuscarVigilante(string busqueda)
        {
            ClPersonalD objVigilanteD = new ClPersonalD();
            List<ClPersonalE> listaPersonal = objVigilanteD.mtdBusquedaVigilante(busqueda);
            return listaPersonal;
        }
    }
}