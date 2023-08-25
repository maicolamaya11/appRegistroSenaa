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

            string Consulta = "SELECT idRegistro, codigo, Registro.estado, Ingreso.fechaIngreso, Ingreso.horaIngreso, Salida.fechaSalida," +
                " Salida.horaSalida, Personal.documento, Porteria.nombrePorteria,Usuario.documento FROM Registro JOIN Ingreso " +
                "ON Ingreso.idIngreso = Registro.idIngreso  JOIN Salida ON Salida.idSalida = Registro.idSalida  JOIN Personal " +
                "ON Personal.idPersonal = Registro.idPersonal JOIN Porteria ON Porteria.idPorteria = Registro.idPorteria " +
                "JOIN Usuario ON Usuario.idUsuario = Registro.idUsuario";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarPersonal = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClRegistroE> ListarRegistros = new List<ClRegistroE>();
            for (int i = 0; i < tblListarPersonal.Rows.Count; i++)
            {
                ClRegistroE objRegistrosE = new ClRegistroE();

                objRegistrosE.idRegistro = int.Parse(tblListarPersonal.Rows[i]["IdRegistro"].ToString());
                objRegistrosE.codigo = tblListarPersonal.Rows[i]["codigo"].ToString();
                objRegistrosE.estado = tblListarPersonal.Rows[i]["estado"].ToString();
                objRegistrosE.fechaIngreso = tblListarPersonal.Rows[i]["fechaIngreso"].ToString();
                objRegistrosE.horaIngreso = tblListarPersonal.Rows[i]["horaIngreso"].ToString();
                objRegistrosE.fechaSalida = tblListarPersonal.Rows[i]["fechaSalida"].ToString();
                objRegistrosE.horaSalida = tblListarPersonal.Rows[i]["horaSalida"].ToString();
                objRegistrosE.documentoPerson = tblListarPersonal.Rows[i]["documento"].ToString();
                objRegistrosE.nombrePort = tblListarPersonal.Rows[i]["nombrePorteria"].ToString();
                objRegistrosE.documentoUsua = tblListarPersonal.Rows[i]["documento"].ToString();

                ListarRegistros.Add(objRegistrosE);


            }
            return ListarRegistros;

        }

        public List<ClRegistroE> mtdObtenerRegistrosCod(int idRegistro)
        {

            string Consulta = "SELECT idRegistro, codigo, Registro.estado, Ingreso.fechaIngreso, Ingreso.horaIngreso, Salida.fechaSalida," +
                " Salida.horaSalida, Personal.documento, Porteria.nombrePorteria,Usuario.documento FROM Registro JOIN Ingreso " +
                "ON Ingreso.idIngreso = Registro.idIngreso  JOIN Salida ON Salida.idSalida = Registro.idSalida  JOIN Personal " +
                "ON Personal.idPersonal = Registro.idPersonal JOIN Porteria ON Porteria.idPorteria = Registro.idPorteria " +
                "JOIN Usuario ON Usuario.idUsuario = Registro.idUsuario WHERE idRegistro = " + idRegistro;

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarPersonal = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClRegistroE> ListarRegistros = new List<ClRegistroE>();
            for (int i = 0; i < tblListarPersonal.Rows.Count; i++)
            {
                ClRegistroE objRegistrosE = new ClRegistroE();

                objRegistrosE.codigo = tblListarPersonal.Rows[i]["codigo"].ToString();
                objRegistrosE.estado = tblListarPersonal.Rows[i]["estado"].ToString();
                objRegistrosE.fechaIngreso = tblListarPersonal.Rows[i]["fechaIngreso"].ToString();
                objRegistrosE.horaIngreso = tblListarPersonal.Rows[i]["horaIngreso"].ToString();
                objRegistrosE.fechaSalida = tblListarPersonal.Rows[i]["fechaSalida"].ToString();
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

            //string actualizar = "Update Registro set codigo = '" + objDatos.codigo + "', estado = '"+objDatos.estado+"', fechaIngreso = '"+objDatos.fechaIngreso+"'," +
            //    " horaIngreso = '"+objDatos.horaIngreso+"', fechaSalida = '"+objDatos.fechaSalida+"', horaSalida = '"+objDatos.horaSalida+"'," +
            //    " documento '"+objDatos.documentoPerson+"', nombrePorteria = '"+objDatos.nombrePort+"', documento = '"+objDatos.documentoUsua+"' where" +
            //    " idRegistro = " + idRegistro"";
            //ClProcesarSQL SQL = new ClProcesarSQL();
            //int Actualizar = SQL.mtdIUDConec(actualizar);
            //return Actualizar;

            string ProcesosAlmacenado = "ActualizarRegistro";
            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Actualizar = objSQL.mtdIUDConect(ProcesosAlmacenado);

            Actualizar.Parameters.AddWithValue("@codigo", objDatos.codigo);
            Actualizar.Parameters.AddWithValue("@estado", objDatos.estado);
            Actualizar.Parameters.AddWithValue("@fechaIngreso", objDatos.fechaIngreso);
            Actualizar.Parameters.AddWithValue("@horaIngreso", objDatos.horaIngreso);
            Actualizar.Parameters.AddWithValue("@fechaSalida", objDatos.fechaSalida);
            Actualizar.Parameters.AddWithValue("@horaSalida", objDatos.horaSalida);
            Actualizar.Parameters.AddWithValue("@documentoPerson", objDatos.documentoPerson);
            Actualizar.Parameters.AddWithValue("@nombrePort", objDatos.nombrePort);
            Actualizar.Parameters.AddWithValue("@documentoUsua", objDatos.documentoUsua);

            int DatosActualizar = Actualizar.ExecuteNonQuery();
            return DatosActualizar;
        }

        public int mtdEliminar(ClRegistroE objDatos)
        {
            string ProcesosAlmacenado = "EliminarRegistro";

            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Eliminar = objSQL.mtdIUDConect(ProcesosAlmacenado);

            Eliminar.Parameters.AddWithValue("@idRegistro", objDatos.idRegistro);

            int DatosActualizar = Eliminar.ExecuteNonQuery();
            return DatosActualizar;

        }
    }
}