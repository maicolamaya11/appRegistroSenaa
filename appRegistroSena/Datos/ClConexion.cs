﻿
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
            conexion = new SqlConnection("Data Source=SOGAPRRBCFSD539;Initial Catalog=RegistroSena;Integrated Security=True");
            conexion.Open();
            return conexion;
        }
    }
}