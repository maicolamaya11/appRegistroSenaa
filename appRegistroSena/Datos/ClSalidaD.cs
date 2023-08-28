using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ClSalidaD
    {
        public int mtdRegistro(ClSalida1E objDatos)
        {
            string Proceso = "InsertarSalida";
            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Registro = objSQL.mtdPrceso(Proceso);
            Registro.Parameters.AddWithValue("@Estado", objDatos.estado);
            Registro.Parameters.AddWithValue("@Observacion", objDatos.observacion);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }
    }
}