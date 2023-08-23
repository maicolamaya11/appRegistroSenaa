using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ClRegistroD
    {
        public int mtdRegistro(ClRegistroE objDatos)
        {
            string Proceso = "AgregarObjetos";
            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Registro = objSQL.mtdPrceso(Proceso);
            Registro.Parameters.AddWithValue("@HoraIngreso", objDatos.horaIngreso);
            Registro.Parameters.AddWithValue("@HoraSalida", objDatos.horaSalida);
            Registro.Parameters.AddWithValue("@idPersonal", objDatos.idPersonal);
            Registro.Parameters.AddWithValue("@idPorteria", objDatos.idPorteria);
            Registro.Parameters.AddWithValue("@idUsuario", objDatos.idUsuario);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }

    }
}