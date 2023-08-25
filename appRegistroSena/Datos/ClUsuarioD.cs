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

        public List<ClUsuarioE> mtdListarInstructores()
        {
            string Consulta = "Select * From Usuario Where rol = 'Instructor'";
            ProcesarSQL SQL = new ProcesarSQL();
            DataTable tblInstru = SQL.mtdSelectDesc(Consulta);

            List<ClUsuarioE> listaProf = new List<ClUsuarioE>();
            for (int i = 0; i < tblInstru.Rows.Count; i++)
            {
                ClUsuarioE objInstru = new ClUsuarioE();
                objInstru.idUsuario = int.Parse(tblInstru.Rows[i]["idUsuario"].ToString());
                objInstru.nombre = tblInstru.Rows[i]["nombre"].ToString();
                objInstru.apellido = tblInstru.Rows[i]["apellido"].ToString();
                objInstru.telefono = tblInstru.Rows[i]["telefono"].ToString();
                objInstru.email = tblInstru.Rows[i]["email"].ToString();
                objInstru.clave = tblInstru.Rows[i]["clave"].ToString();
                objInstru.documento = tblInstru.Rows[i]["documento"].ToString();
                objInstru.rol = tblInstru.Rows[i]["rol"].ToString();
                
                listaProf.Add(objInstru);
            }
            return listaProf;
        }
    }
}