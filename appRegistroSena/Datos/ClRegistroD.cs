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

        public int mtdActualizar(int id)
        {
            string ProcesosAlmacenado = "ActualizarRegistro";
            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Actualizar = objSQL.mtdPrceso(ProcesosAlmacenado);

            Actualizar.Parameters.AddWithValue("@idRegistro",id);

            int DatosActualizar = Actualizar.ExecuteNonQuery();
            return DatosActualizar;
        }

        public int mtdEliminar(ClRegistroE objDatos)
        {
            string ProcesosAlmacenado = "EliminarRegistro";

            ProcesarSQL objSQL = new ProcesarSQL();
            SqlCommand Eliminar = objSQL.mtdIUDConect(ProcesosAlmacenado);

            Eliminar.Parameters.AddWithValue("@codigo", objDatos.codigo);

            int DatosActualizar = Eliminar.ExecuteNonQuery();
            return DatosActualizar;

        }
    }
}