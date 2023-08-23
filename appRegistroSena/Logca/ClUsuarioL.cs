using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logca
{
    public class ClUsuarioL
    {
        public ClUsuarioE mtdDatosLogin(string documento, string contraseña)
        {
            ClUsuarioD objUsuarioD = new ClUsuarioD();
            ClUsuarioE objDatos = objUsuarioD.mtdLogin(documento, contraseña);
            return objDatos;
        }
    }
}