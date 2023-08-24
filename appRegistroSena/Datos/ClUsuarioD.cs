using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

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
        public ClUsuarioE mtdLogin(string documento, string contraeña)
        {
            string consulta = "select * from usuario where documento = '" + documento + "' and clave = '" + contraeña + "'";
            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblDatos = objSQL.mtdSelectDesc(consulta);
            ClUsuarioE objUsuarioE = null;

            if (tblDatos.Rows.Count > 0)
            {
                objUsuarioE = new ClUsuarioE();
                objUsuarioE.idUsuario = int.Parse(tblDatos.Rows[0]["idUsuario"].ToString());
                objUsuarioE.documento = tblDatos.Rows[0]["documento"].ToString();
                objUsuarioE.nombre = tblDatos.Rows[0]["nombre"].ToString();
                objUsuarioE.apellido = tblDatos.Rows[0]["apellido"].ToString();
                objUsuarioE.telefono = tblDatos.Rows[0]["telefono"].ToString();
                objUsuarioE.clave = tblDatos.Rows[0]["clave"].ToString();
                objUsuarioE.rol = tblDatos.Rows[0]["rol"].ToString();





            }
            return objUsuarioE;
        }

    }
}