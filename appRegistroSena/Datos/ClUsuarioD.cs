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
            string Consulta = "Select * From Usuario JOIN Programa ON Usuario.idPrograma = Programa.idPrograma Where rol = 'Instructor'";
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
                objInstru.programa = tblInstru.Rows[i]["programa"].ToString();
                objInstru.ficha = tblInstru.Rows[i]["ficha"].ToString();
                objInstru.jornada = tblInstru.Rows[i]["jornada"].ToString();


                listaProf.Add(objInstru);
            }
            return listaProf;
        }

        public List<ClUsuarioE> mtdBusquedaInstructor(string busqueda)
        {
            string Consulta = "SELECT u.idUsuario, U.nombre, U.apellido, U.telefono, U.email, U.documento, P.ficha, " +
                "P.programa, P.jornada FROM Usuario AS U JOIN Programa AS P ON U.idPrograma = P.idPrograma " +
                "WHERE (P.programa LIKE '" + busqueda + "' OR P.ficha LIKE '" + busqueda + "' OR U.documento LIKE '" + busqueda + "') AND U.rol = 'Instructor'";
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
                objInstru.documento = tblInstru.Rows[i]["documento"].ToString();
                objInstru.ficha = tblInstru.Rows[i]["ficha"].ToString();
                objInstru.programa = tblInstru.Rows[i]["programa"].ToString();
                objInstru.jornada = tblInstru.Rows[i]["jornada"].ToString();

                listaProf.Add(objInstru);

            }
            return listaProf;
        }

        public List<ClProgramasE> mtdListarPrograma()
        {
            string consulta = "select * from Programa";
            ProcesarSQL SQL = new ProcesarSQL();
            DataTable tblPrograma = SQL.mtdSelectDesc(consulta);

            List<ClProgramasE> listaProf = new List<ClProgramasE>();
            for (int i = 0; i < tblPrograma.Rows.Count; i++)
            {
                ClProgramasE objProgramas = new ClProgramasE();
                objProgramas.idPrograma = int.Parse(tblPrograma.Rows[i]["idPrograma"].ToString());
                objProgramas.ficha = tblPrograma.Rows[i]["ficha"].ToString();
                objProgramas.programa = tblPrograma.Rows[i]["programa"].ToString();

                listaProf.Add(objProgramas);
            }
            return listaProf;
        }

        public List<ClUsuarioE> mtdListarAprendices()
        {
            string Consulta = "Select * From Usuario JOIN Programa ON Usuario.idPrograma = Programa.idPrograma Where rol = 'Aprendiz'";
            ProcesarSQL SQL = new ProcesarSQL();
            DataTable tblApren = SQL.mtdSelectDesc(Consulta);

            List<ClUsuarioE> listaApren = new List<ClUsuarioE>();
            for (int i = 0; i < tblApren.Rows.Count; i++)
            {
                ClUsuarioE objAprendiz = new ClUsuarioE();
                objAprendiz.idUsuario = int.Parse(tblApren.Rows[i]["idUsuario"].ToString());
                objAprendiz.nombre = tblApren.Rows[i]["nombre"].ToString();
                objAprendiz.apellido = tblApren.Rows[i]["apellido"].ToString();
                objAprendiz.telefono = tblApren.Rows[i]["telefono"].ToString();
                objAprendiz.email = tblApren.Rows[i]["email"].ToString();
                objAprendiz.clave = tblApren.Rows[i]["clave"].ToString();
                objAprendiz.documento = tblApren.Rows[i]["documento"].ToString();
                objAprendiz.rol = tblApren.Rows[i]["rol"].ToString();
                objAprendiz.programa = tblApren.Rows[i]["programa"].ToString();
                objAprendiz.ficha = tblApren.Rows[i]["ficha"].ToString();
                objAprendiz.jornada = tblApren.Rows[i]["jornada"].ToString();


                listaApren.Add(objAprendiz);
            }
            return listaApren;
        }

        public List<ClUsuarioE> mtdBusquedaAprendiz(string busqueda)
        {
            string Consulta = "SELECT u.idUsuario, U.nombre, U.apellido, U.telefono, U.email, U.documento, P.ficha, " +
                "P.programa, P.jornada FROM Usuario AS U JOIN Programa AS P ON U.idPrograma = P.idPrograma " +
                "WHERE (P.programa LIKE '" + busqueda + "' OR P.ficha LIKE '" + busqueda + "' OR U.documento LIKE '" + busqueda + "') AND U.rol = 'Instructor'";
            ProcesarSQL SQL = new ProcesarSQL();
            DataTable tblInstru = SQL.mtdSelectDesc(Consulta);

            List<ClUsuarioE> listaApren = new List<ClUsuarioE>();
            for (int i = 0; i < tblInstru.Rows.Count; i++)
            {
                ClUsuarioE objAprendiz = new ClUsuarioE();
                objAprendiz.idUsuario = int.Parse(tblInstru.Rows[i]["idUsuario"].ToString());
                objAprendiz.nombre = tblInstru.Rows[i]["nombre"].ToString();
                objAprendiz.apellido = tblInstru.Rows[i]["apellido"].ToString();
                objAprendiz.telefono = tblInstru.Rows[i]["telefono"].ToString();
                objAprendiz.email = tblInstru.Rows[i]["email"].ToString();
                objAprendiz.documento = tblInstru.Rows[i]["documento"].ToString();
                objAprendiz.ficha = tblInstru.Rows[i]["ficha"].ToString();
                objAprendiz.programa = tblInstru.Rows[i]["programa"].ToString();
                objAprendiz.jornada = tblInstru.Rows[i]["jornada"].ToString();

                listaApren.Add(objAprendiz);

            }
            return listaApren;
        }
    }
}