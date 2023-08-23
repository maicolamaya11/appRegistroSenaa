using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClUsuarioL
    {
        public int mtdRegistroUsuario(ClUsuarioE objDatos)
        {
            ClUsuarioD objUsuarioD = new ClUsuarioD();
            int registrar = objUsuarioD.mtdRegistrarUsuario(objDatos);
            return registrar;
        }
    }
}