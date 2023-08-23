using System;
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

        //Ejecuta consulta Select en forma desconectada y retorna en DataTable
        public DataTable mtdSelectDesc(string consulta)
        {
            ClConexion objConexion = new ClConexion();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, objConexion.mtdConexion());
            DataTable tblDatos = new DataTable();
            adaptador.Fill(tblDatos);
            objConexion.mtdConexion().Close();
            return tblDatos;
        }
        //Ejecuta consulta insert update delete en forma conectada y retorna entero.
        public int mtdIUDConect(string consulta)
        {
            ClConexion objConexion = new ClConexion();
            SqlCommand comando = new SqlCommand(consulta, objConexion.mtdConexion());
            int registros = comando.ExecuteNonQuery();
            objConexion.mtdConexion().Close();
            return registros;

        }
    }
}