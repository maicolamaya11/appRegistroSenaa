
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ClConexion
    {
        SqlConnection conexion = null;
        public SqlConnection mtdConexion()
        {


            conexion = new SqlConnection("Data Source=DESKTOP-JRTUVHD\\SQLEXPRESS;Initial Catalog=RegistroSena;Integrated Security=True");

            conexion = new SqlConnection("Data Source=.;Initial Catalog=dbRegistroSena;Integrated Security=True");


            conexion.Open();
            return conexion;
        }
    }
}