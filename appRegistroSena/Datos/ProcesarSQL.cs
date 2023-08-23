﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ProcesarSQL
    {
        public SqlCommand mtdPrceso(string proceso)
        {
            ClConexion objConexion = new ClConexion();
            SqlCommand comando = new SqlCommand(proceso, objConexion.mtdConexion());
            comando.CommandType = CommandType.StoredProcedure;

            return comando;
        }

        //Ejecuta Consulta Select en forma desconectada y retorna DataTable
        public DataTable mtdSelectDesc(string consulta)
        {
            ClConexion obConexion = new ClConexion();
            using (SqlConnection con = obConexion.mtdConexion())
            {
                SqlDataAdapter adap = new SqlDataAdapter(consulta, con);
                DataTable tblDatos = new DataTable();
                adap.Fill(tblDatos);
                obConexion.mtdConexion().Close();
                return tblDatos;
            }

        }

        //Ejecuta consulta Select de forma Conectada y retorna DataReader 
        public int mtdSelectConec(string consul)
        {
            ClConexion obConexion = new ClConexion();
            //obConexion.mtdConexion().Open();
            using (SqlConnection con = obConexion.mtdConexion())
            {
                SqlCommand comando = new SqlCommand(consul, con);
                int verificar = (int)comando.ExecuteScalar();
                obConexion.mtdConexion().Close();
                return verificar;
            }

        }

        // Ejecuta Consulta en Forma Conectada
        public int mtdIUDConec(string consulta)
        {
            ClConexion objConexion = new ClConexion();
            using (SqlConnection con = objConexion.mtdConexion())
            {
                SqlCommand comando = new SqlCommand(consulta, con);
                int registro = comando.ExecuteNonQuery();
                objConexion.mtdConexion().Close();
                return registro;
            }

        }


        public int mtdVerificarExistenciaCorreo(string consul)
        {
            ClConexion obConexion = new ClConexion();
            SqlCommand comando = new SqlCommand(consul, obConexion.mtdConexion());
            int verificar = (int)comando.ExecuteScalar();
            obConexion.mtdConexion().Close();
            return verificar;
        }
    }
}