﻿using appRegistroSena.Entidades;
using appRegistroSena.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ClPersonalD
    {
        public List<ClPersonalE> mtdBuscar(string documento)
        {
            ProcesarSQL obSQL = new ProcesarSQL();
            ClPersonalE obDatos = new ClPersonalE();
            string Proceso = "BuscarPersonal";

            SqlCommand ComList = obSQL.mtdPrceso(Proceso);
            List<ClPersonalE> listaProd = new List<ClPersonalE>();
            ComList.Parameters.AddWithValue("@Busqueda", documento);
            SqlDataReader BuscarDatos = ComList.ExecuteReader();

            while (BuscarDatos.Read())
            {
                obDatos = new ClPersonalE();
                obDatos.idPersonal = BuscarDatos.GetInt32(0);
                obDatos.nombres = BuscarDatos.GetString(1);
                obDatos.apellidos = BuscarDatos.GetString(2);
                obDatos.documento = BuscarDatos.GetString(3);
                obDatos.idPrograma = BuscarDatos.GetInt32(4);
                listaProd.Add(obDatos);
            }
            return listaProd;
        }


        public List<ClPersonalE> mtdListarVigilante()
        {
            string consulta = "select * from Personal where rol = 'Vigilante'";
            ProcesarSQL SQL = new ProcesarSQL();
            DataTable tblDatos = SQL.mtdSelectDesc(consulta);

            List<ClPersonalE> listaPerson = new List<ClPersonalE>();
            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                ClPersonalE objPersonal = new ClPersonalE();
                objPersonal.idPersonal = int.Parse(tblDatos.Rows[0]["idPersonal"].ToString());
                objPersonal.nombres = tblDatos.Rows[0]["nombres"].ToString();
                objPersonal.apellidos = tblDatos.Rows[0]["apellidos"].ToString();
                objPersonal.rol = tblDatos.Rows[0]["rol"].ToString();
                objPersonal.documento = tblDatos.Rows[0]["documento"].ToString();

                listaPerson.Add(objPersonal);

            }
            return listaPerson;
        }

        public List<ClPersonalE> mtdBusquedaVigilante(string busqueda)
        {
            string consulta = "select * from Personal where (nombres LIKE '"+busqueda+"' OR apellidos LIKE '"+busqueda+"' " +
                "OR documento LIKE '"+busqueda+"') AND rol = 'Vigilante'";
            ProcesarSQL SQL = new ProcesarSQL();
            DataTable tblDatos = SQL.mtdSelectDesc(consulta);

            List<ClPersonalE> listaPerson = new List<ClPersonalE>();
            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                ClPersonalE objPersonal = new ClPersonalE();
                objPersonal.idPersonal = int.Parse(tblDatos.Rows[0]["idPersonal"].ToString());
                objPersonal.nombres = tblDatos.Rows[0]["nombres"].ToString();
                objPersonal.apellidos = tblDatos.Rows[0]["apellidos"].ToString();
                objPersonal.rol = tblDatos.Rows[0]["rol"].ToString();
                objPersonal.documento = tblDatos.Rows[0]["documento"].ToString();


                listaPerson.Add(objPersonal);

            }
            return listaPerson;
        }
      
        public int mtdRegistrarPersonal(ClPersonalE objPersonal)
        {
            string Registro = "Insert Into Personal(nombres,apellidos,documento,rol,idPrograma) " +
                "Values ('" + objPersonal.nombres + "','" + objPersonal.apellidos + "','" + objPersonal.documento + "','" + objPersonal.rol + "','" + objPersonal.idPrograma + "')";

            ProcesarSQL SQL = new ProcesarSQL();
            int registros = SQL.mtdIUDConec(Registro);
            return registros;
        }
        public List<ClPersonalE> mtdListarAprendices()
        {

            string Consulta = "select idPersonal,nombres,apellidos,documento,programa,rol from Personal inner join Programa on Programa.idPrograma = Personal.idPrograma where rol = '1'";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarAprendices = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClPersonalE> ListarAprendice = new List<ClPersonalE>();
            for (int i = 0; i < tblListarAprendices.Rows.Count; i++)
            {
                ClPersonalE objUsuarioE = new ClPersonalE();

                objUsuarioE.idPersonal = int.Parse(tblListarAprendices.Rows[i]["idPersonal"].ToString());
                objUsuarioE.programa = tblListarAprendices.Rows[i]["Programa"].ToString();

                objUsuarioE.nombres = tblListarAprendices.Rows[i]["nombres"].ToString();
                objUsuarioE.apellidos = tblListarAprendices.Rows[i]["apellidos"].ToString();
                objUsuarioE.documento = tblListarAprendices.Rows[i]["documento"].ToString();
   
                objUsuarioE.rol = tblListarAprendices.Rows[i]["rol"].ToString();
              
                

                ListarAprendice.Add(objUsuarioE);


            }
            return ListarAprendice;

        }
        public List<ClPersonalE> mtdObtenerAprendicesCod(int idPersonal)
        {

            string Consulta = "select idPersonal,nombres,apellidos,documento,programa,rol from Personal inner join Programa on Programa.idPrograma = Personal.idPrograma where idPersonal = '"+ idPersonal + "' ";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarAprendices = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClPersonalE> ListarAprendice = new List<ClPersonalE>();
            for (int i = 0; i < tblListarAprendices.Rows.Count; i++)
            {
                ClPersonalE objUsuarioE = new ClPersonalE();

                objUsuarioE.idPersonal = int.Parse(tblListarAprendices.Rows[i]["idPersonal"].ToString());
                objUsuarioE.programa = tblListarAprendices.Rows[i]["Programa"].ToString();

                objUsuarioE.nombres = tblListarAprendices.Rows[i]["nombres"].ToString();
                objUsuarioE.apellidos = tblListarAprendices.Rows[i]["apellidos"].ToString();
                objUsuarioE.documento = tblListarAprendices.Rows[i]["documento"].ToString();

                objUsuarioE.rol = tblListarAprendices.Rows[i]["rol"].ToString();
 

                ListarAprendice.Add(objUsuarioE);


            }
            return ListarAprendice;

        }
        public int mtdEditar(ClPersonalE objDatos)

        {
            string consulta = "update Personal set documento='" + objDatos.documento + "',nombres='" + objDatos.nombres + "',apellidos='" + objDatos.apellidos + "',programa'" + objDatos.idPrograma + "'";
            ProcesarSQL objConexion = new ProcesarSQL();
            int canReg = objConexion.mtdIUDConec(consulta);
            return canReg;
        }
        public List<ClPersonalE> mtdListarInstructores()
        {

            string Consulta = "select idPersonal,nombres,apellidos,documento,programa,rol from Personal inner join Programa on Programa.idPrograma = Personal.idPrograma where rol = '2'";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarAprendices = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClPersonalE> ListarAprendice = new List<ClPersonalE>();
            for (int i = 0; i < tblListarAprendices.Rows.Count; i++)
            {
                ClPersonalE objUsuarioE = new ClPersonalE();

                objUsuarioE.idPersonal = int.Parse(tblListarAprendices.Rows[i]["idPersonal"].ToString());
                objUsuarioE.programa = tblListarAprendices.Rows[i]["Programa"].ToString();

                objUsuarioE.nombres = tblListarAprendices.Rows[i]["nombres"].ToString();
                objUsuarioE.apellidos = tblListarAprendices.Rows[i]["apellidos"].ToString();
                objUsuarioE.documento = tblListarAprendices.Rows[i]["documento"].ToString();

                objUsuarioE.rol = tblListarAprendices.Rows[i]["rol"].ToString();
   
                ListarAprendice.Add(objUsuarioE);


            }
            return ListarAprendice;

        }
        public List<ClPersonalE> mtdObtenerInstructorCod(int idPersonal)
        {

            string Consulta = "select idPersonal,nombres,apellidos,documento,programa,rol from Personal inner join Programa on Programa.idPrograma = Personal.idPrograma where idPersonal = '" + idPersonal + "' ";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarAprendices = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClPersonalE> ListarAprendice = new List<ClPersonalE>();
            for (int i = 0; i < tblListarAprendices.Rows.Count; i++)
            {
                ClPersonalE objUsuarioE = new ClPersonalE();

                objUsuarioE.idPersonal = int.Parse(tblListarAprendices.Rows[i]["idPersonal"].ToString());
                objUsuarioE.programa = tblListarAprendices.Rows[i]["Programa"].ToString();

                objUsuarioE.nombres = tblListarAprendices.Rows[i]["nombres"].ToString();
                objUsuarioE.apellidos = tblListarAprendices.Rows[i]["apellidos"].ToString();
                objUsuarioE.documento = tblListarAprendices.Rows[i]["documento"].ToString();

                objUsuarioE.rol = tblListarAprendices.Rows[i]["rol"].ToString();
                objUsuarioE.idPrograma = int.Parse(tblListarAprendices.Rows[i]["idPrograma"].ToString());

                ListarAprendice.Add(objUsuarioE);


            }
            return ListarAprendice;

        }
        public int mtdEditarInstru(ClPersonalE objDatos)

        {
            string consulta = "update Personal set documento='" + objDatos.documento + "',nombres='" + objDatos.nombres + "',apellidos='" + objDatos.apellidos + "',programa'" + objDatos.idPrograma + "'";
            ProcesarSQL objConexion = new ProcesarSQL();
            int canReg = objConexion.mtdIUDConec(consulta);
            return canReg;
        }

    }
}