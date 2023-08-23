using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClRegistroL
    {
        public int mtdRegistrar(ClRegistroE objDatos)
        {
            ClRegistroD objRegistroD = new ClRegistroD();
            int registro = objRegistroD.mtdRegistro(objDatos);
            return registro;
        }
    }
}