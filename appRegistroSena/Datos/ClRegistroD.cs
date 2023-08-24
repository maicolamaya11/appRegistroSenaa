using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<ClRegistroE> mtdListarRegistros()
        {

            string Consulta = "SELECT codigo, horaIngreso, horaSalida, Personal.documento, Porteria.nombrePorteria,Usuario.documento " +
                "FROM Registro JOIN Personal ON Personal.idPersonal = Registro.idPersonal JOIN Porteria ON Porteria.idPorteria = Registro.idPorteria " +
                "JOIN Usuario ON Usuario.idUsuario = Registro.idUsuario;";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarPersonal = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClRegistroE> ListarRegistros = new List<ClRegistroE>();
            for (int i = 0; i < tblListarPersonal.Rows.Count; i++)
            {
                ClRegistroE objRegistrosE = new ClRegistroE();

                objRegistrosE.Codigo = tblListarPersonal.Rows[i]["codigo"].ToString();
                objRegistrosE.horaIng = tblListarPersonal.Rows[i]["horaIngreso"].ToString();
                objRegistrosE.horaSalida = tblListarPersonal.Rows[i]["horaSalida"].ToString();
                objRegistrosE.documentoPerson = tblListarPersonal.Rows[i]["documento"].ToString();
                objRegistrosE.nombrePort = tblListarPersonal.Rows[i]["nombrePorteria"].ToString();
                objRegistrosE.documentoUsua = tblListarPersonal.Rows[i]["documento"].ToString();

                ListarRegistros.Add(objRegistrosE);


            }
            return ListarRegistros;

        }

        public int mtdActualizar(ClRegistroE objDatos)
        {
            string ProcesosAlmacenado = "ActualizarRegistros";
            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Actualizar = objSQL.mtdIUDConect(ProcesosAlmacenado);

            Actualizar.Parameters.AddWithValue("@codigo", objDatos.Codigo);
            Actualizar.Parameters.AddWithValue("@horaIngreso", objDatos.horaIng);
            Actualizar.Parameters.AddWithValue("@horaSalida", objDatos.horaSalida);
            Actualizar.Parameters.AddWithValue("@documento", objDatos.documentoPerson);
            Actualizar.Parameters.AddWithValue("@nombrePorteria", objDatos.nombrePort);
            Actualizar.Parameters.AddWithValue("@documento", objDatos.documentoUsua);

            int DatosActualizar = Actualizar.ExecuteNonQuery();
            return DatosActualizar;
        }

        public int mtdEliminar(ClRegistroE objDatos)
        {
            string ProcesosAlmacenado = "EliminarRegistro";

            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Eliminar = objSQL.mtdIUDConect(ProcesosAlmacenado);

            Eliminar.Parameters.AddWithValue("@codigo", objDatos.Codigo);

            int DatosActualizar = Eliminar.ExecuteNonQuery();
            return DatosActualizar;

        }
    }
}