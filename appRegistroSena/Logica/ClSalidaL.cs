using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClSalidaL
    {
        public int mtdIngresarSalida(ClSalida1E objDatos)
        {
            ClSalidaD objSalidaD = new ClSalidaD();
            int registro = objSalidaD.mtdRegistro(objDatos);
            return registro;
        }
    }
}