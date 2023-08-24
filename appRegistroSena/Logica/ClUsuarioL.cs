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
        public ClUsuarioE mtdDatosLogin(string documento, string contraseña)
        {
            ClUsuarioD objUsuarioD = new ClUsuarioD();
            ClUsuarioE objDatos = objUsuarioD.mtdLogin(documento, contraseña);
            return objDatos;
        }
    }
}