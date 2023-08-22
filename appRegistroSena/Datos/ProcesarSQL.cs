﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ProcesarSQL
    {
        public SQlCommand mtdPrceso(string proceso)
        {
            ClConexion objConexion = new ClConexion();
            SqlCommand comando = new SqlCommand(proceso, objConexion.mtdConexion());
            comando.CommandType = CommandType.StoredProcedure;

            return comando;
        }
    }
}