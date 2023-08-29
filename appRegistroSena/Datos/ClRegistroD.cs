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
            string Proceso = "InsertarRegistro";
            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Registro = objSQL.mtdPrceso(Proceso);
            Registro.Parameters.AddWithValue("@Estado", objDatos.estado);
            //Registro.Parameters.AddWithValue("@idSalida", objDatos.idSalida);
            Registro.Parameters.AddWithValue("@idPersonal", objDatos.idPersonal);
            Registro.Parameters.AddWithValue("@idPorteria", objDatos.idPorteria);
            Registro.Parameters.AddWithValue("@idUsuario", objDatos.idUsuario);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }

        public List<ClSalidaE> mtdListarRegistros()
        {

            string Consulta = "select r.idRegistro,r.codigo,p.documento,CONCAT(p.nombres,' ',p.apellidos) as 'Nombre Personal'," +
                "tipoV.tipoVehiculo,tipoO.nombre,CONCAT(usu.nombre,' ',usu.apellido)as 'Nombre Usuario'," +
                "por.nombrePorteria,ing.horaIngreso, ing.fechaIngreso from Registro as r " +
                "left join Personal as p on r.idPersonal=p.idPersonal" +
                " left join TipoVehiculo tipoV on r.idRegistro = tipoV.idRegistro" +
                " left join Objeto o on r.idRegistro = o.idRegistro" +
                " left join TipoObjeto tipoO on o.idTipoObjeto = tipoO.idTipoObjeto" +
                " left join Usuario usu on r.idUsuario = usu.idUsuario" +
                " left join Porteria por on r.idPorteria = por.idPorteria" +
                " left join Ingreso ing on r.idIngreso = ing.idIngreso";

            //string Consulta = "SELECT idRegistro, codigo, Registro.estado, Ingreso.fechaIngreso, Ingreso.horaIngreso, Salida.fechaSalida," +
            //    " Salida.horaSalida, Personal.documento, Porteria.nombrePorteria,Usuario.documento FROM Registro JOIN Ingreso " +
            //    "ON Ingreso.idIngreso = Registro.idIngreso  JOIN Salida ON Salida.idSalida = Registro.idSalida  JOIN Personal " +
            //    "ON Personal.idPersonal = Registro.idPersonal JOIN Porteria ON Porteria.idPorteria = Registro.idPorteria " +
            //    "JOIN Usuario ON Usuario.idUsuario = Registro.idUsuario";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarPersonal = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClSalidaE> ListarRegistros = new List<ClSalidaE>();
            for (int i = 0; i < tblListarPersonal.Rows.Count; i++)
            {

                ClSalidaE objRegistrosE = new ClSalidaE();
                objRegistrosE.idRegistro = int.Parse(tblListarPersonal.Rows[i]["idRegistro"].ToString());


                objRegistrosE.codigo = tblListarPersonal.Rows[i]["codigo"].ToString();
                objRegistrosE.documento = tblListarPersonal.Rows[i]["documento"].ToString();
                objRegistrosE.NombrePersonal = tblListarPersonal.Rows[i]["Nombre Personal"].ToString();
                objRegistrosE.tipoVehiculo = tblListarPersonal.Rows[i]["tipoVehiculo"].ToString();
                objRegistrosE.nombre = tblListarPersonal.Rows[i]["nombre"].ToString();
                objRegistrosE.NombreUsuario = tblListarPersonal.Rows[i]["Nombre Usuario"].ToString();
                objRegistrosE.nombrePorteria = tblListarPersonal.Rows[i]["nombrePorteria"].ToString();
                objRegistrosE.horaIngreso = tblListarPersonal.Rows[i]["horaIngreso"].ToString();
                objRegistrosE.fechaIngreso = tblListarPersonal.Rows[i]["fechaIngreso"].ToString();

                ListarRegistros.Add(objRegistrosE);


            }
            return ListarRegistros;

        }

        //public List<ClRegistroE> mtdObtenerRegistrosCod(int idRegistro)
        //{

        //    string Consulta = "SELECT idRegistro, codigo, Registro.estado, Ingreso.fechaIngreso, Ingreso.horaIngreso, Salida.fechaSalida," +
        //        " Salida.horaSalida, Personal.documento, Porteria.nombrePorteria,Usuario.documento FROM Registro JOIN Ingreso " +
        //        "ON Ingreso.idIngreso = Registro.idIngreso  JOIN Salida ON Salida.idSalida = Registro.idSalida  JOIN Personal " +
        //        "ON Personal.idPersonal = Registro.idPersonal JOIN Porteria ON Porteria.idPorteria = Registro.idPorteria " +
        //        "JOIN Usuario ON Usuario.idUsuario = Registro.idUsuario WHERE idRegistro = " + idRegistro;

        //    ProcesarSQL objSQL = new ProcesarSQL();
        //    DataTable tblListarPersonal = objSQL.mtdSelectDesc(Consulta);
        //    //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
        //    List<ClRegistroE> ListarRegistros = new List<ClRegistroE>();
        //    for (int i = 0; i < tblListarPersonal.Rows.Count; i++)
        //    {
        //        ClRegistroE objRegistrosE = new ClRegistroE();


        //        objRegistrosE.codigo = tblListarPersonal.Rows[i]["codigo"].ToString();
        //        objRegistrosE.documento = tblListarPersonal.Rows[i]["documento"].ToString();
        //        objRegistrosE.NombrePersonal = tblListarPersonal.Rows[i]["Nombre Personal"].ToString();
        //        objRegistrosE.tipoVehiculo = tblListarPersonal.Rows[i]["tipoVehiculo"].ToString();
        //        objRegistrosE.nombre = tblListarPersonal.Rows[i]["nombre"].ToString();
        //        objRegistrosE.NombreUsuario = tblListarPersonal.Rows[i]["Nombre Usuario"].ToString();
        //        objRegistrosE.nombrePorteria = tblListarPersonal.Rows[i]["nombrePorteria"].ToString();
        //        objRegistrosE.horaIngreso = tblListarPersonal.Rows[i]["horaIngreso"].ToString();
        //        objRegistrosE.fechaIngreso = tblListarPersonal.Rows[i]["fechaIngreso"].ToString();

        //        ListarRegistros.Add(objRegistrosE);


        //    }
        //    return ListarRegistros;

        //}

        public int mtdActualizar(int id)
        {

            string ProcesosAlmacenado = "ActualizarRegistro";
            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Actualizar = objSQL.mtdPrceso(ProcesosAlmacenado);

            Actualizar.Parameters.AddWithValue("@idRegistro", id);


            //string actualizar = "Update Registro set codigo = '" + objDatos.codigo + "', estado = '"+objDatos.estado+"', fechaIngreso = '"+objDatos.fechaIngreso+"'," +
            //    " horaIngreso = '"+objDatos.horaIngreso+"', fechaSalida = '"+objDatos.fechaSalida+"', horaSalida = '"+objDatos.horaSalida+"'," +
            //    " documento '"+objDatos.documentoPerson+"', nombrePorteria = '"+objDatos.nombrePort+"', documento = '"+objDatos.documentoUsua+"' where" +
            //    " idRegistro = " + idRegistro"";
            //ClProcesarSQL SQL = new ClProcesarSQL();
            //int Actualizar = SQL.mtdIUDConec(actualizar);
            //return Actualizar;

            //Actualizar.Parameters.AddWithValue("@codigo", objDatos.codigo);
            //Actualizar.Parameters.AddWithValue("@estado", objDatos.estado);
            //Actualizar.Parameters.AddWithValue("@fechaIngreso", objDatos.fechaIngreso);
            //Actualizar.Parameters.AddWithValue("@horaIngreso", objDatos.horaIngreso);
            //Actualizar.Parameters.AddWithValue("@fechaSalida", objDatos.fechaSalida);
            //Actualizar.Parameters.AddWithValue("@horaSalida", objDatos.horaSalida);
            //Actualizar.Parameters.AddWithValue("@documentoPerson", objDatos.documentoPerson);
            //Actualizar.Parameters.AddWithValue("@nombrePort", objDatos.nombrePort);
            //Actualizar.Parameters.AddWithValue("@documentoUsua", objDatos.documentoUsua);

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

        public List<ClRegistroE> mtdListaRegistros()
        {

            string Consulta = "SELECT idRegistro, codigo, Usuario.documento, Registro.estado, Ingreso.fechaIngreso, Ingreso.horaIngreso, Salida.fechaSalida," +
                " Salida.horaSalida, Porteria.nombrePorteria,Personal.documento AS documentoPer FROM Registro JOIN Ingreso " +
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

                objRegistrosE.idRegistro = int.Parse(tblListarPersonal.Rows[i]["idRegistro"].ToString());
                objRegistrosE.codigo = tblListarPersonal.Rows[i]["codigo"].ToString();
                objRegistrosE.estado = tblListarPersonal.Rows[i]["estado"].ToString();
                objRegistrosE.fechaIngreso = tblListarPersonal.Rows[i]["fechaIngreso"].ToString();
                objRegistrosE.horaIngreso = tblListarPersonal.Rows[i]["horaIngreso"].ToString();
                objRegistrosE.fechaSalida = tblListarPersonal.Rows[i]["fechaSalida"].ToString();
                objRegistrosE.horaSalida = tblListarPersonal.Rows[i]["horaSalida"].ToString();
                objRegistrosE.documentoPerson = tblListarPersonal.Rows[i]["documentoPer"].ToString();
                objRegistrosE.nombrePort = tblListarPersonal.Rows[i]["nombrePorteria"].ToString();
                objRegistrosE.documentoUsua = tblListarPersonal.Rows[i]["documento"].ToString();

                ListarRegistros.Add(objRegistrosE);


            }
            return ListarRegistros;

        }

        public List<ClRegistroE> mtdBuscarRegistros(string busqueda)
        {

            string Consulta = "SELECT idRegistro, codigo, Personal.documento, Registro.estado, Ingreso.fechaIngreso, Ingreso.horaIngreso, Salida.fechaSalida," +
                " Salida.horaSalida, Usuario.documento, Porteria.nombrePorteria,Usuario.documento FROM Registro JOIN Ingreso " +
                "ON Ingreso.idIngreso = Registro.idIngreso  JOIN Salida ON Salida.idSalida = Registro.idSalida  JOIN Personal " +
                "ON Personal.idPersonal = Registro.idPersonal JOIN Porteria ON Porteria.idPorteria = Registro.idPorteria " +
                "JOIN Usuario ON Usuario.idUsuario = Registro.idUsuario WHERE (fechaIngreso LIKE '"+busqueda+"')";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarPersonal = objSQL.mtdSelectDesc(Consulta);
            //DataTable tblListarRegistros = objSQL.mtdSelectDesc(Consulta);
            List<ClRegistroE> ListarRegistros = new List<ClRegistroE>();
            for (int i = 0; i < tblListarPersonal.Rows.Count; i++)
            {
                ClRegistroE objRegistrosE = new ClRegistroE();

                objRegistrosE.idRegistro = int.Parse(tblListarPersonal.Rows[i]["idRegistro"].ToString());
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
    }
}