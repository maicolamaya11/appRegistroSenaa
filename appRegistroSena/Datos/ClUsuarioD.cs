using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ClUsuarioD
    {
        public int mtdRegistrarUsuario(ClUsuarioE objUsuario)
        {
            string Registro = "Insert Into Usuario(nombre,apellido,telefono,email,clave,documento,rol) " +
                "Values('" + objUsuario.nombre + "','" + objUsuario.apellido + "','" + objUsuario.telefono + "','" + objUsuario.email + "'," +
                "'" + objUsuario.clave + "','" + objUsuario.documento + "','" + objUsuario.rol + "')";

            ProcesarSQL SQL = new ProcesarSQL();
            int registros = SQL.mtdIUDConec(Registro);
            return registros;
        }
    }
}