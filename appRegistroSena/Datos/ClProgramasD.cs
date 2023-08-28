using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;


using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ClProgramasD
    {
        public int mtdRegistroPrograma(ClProgramasE objPrograma)
        {
            string Registro = "Insert Into Programa(programa,ficha) " +
                "Values('" + objPrograma.programa + "','" + objPrograma.ficha + "')";

            ProcesarSQL SQL = new ProcesarSQL();
            int registros = SQL.mtdIUDConec(Registro);
            return registros;

        }
        public List<ClProgramasE> mtdListarProgramas()
        {
            ClProgramasE objDatos = new ClProgramasE();
            ProcesarSQL objSQL = new ProcesarSQL();
            string proceso = "ListarPrograma";
            SqlCommand comando = objSQL.mtdPrceso(proceso);
            SqlDataReader dr = comando.ExecuteReader();
            List<ClProgramasE> listaProgramas = new List<ClProgramasE>();

            while (dr.Read())
            {
                objDatos = new ClProgramasE();
                objDatos.idPrograma = Convert.ToInt32(dr["idPrograma"].ToString());
                objDatos.programa = dr["programa"].ToString();
                objDatos.ficha = dr["ficha"].ToString();
                objDatos.jornada = dr["jornada"].ToString();
                listaProgramas.Add(objDatos);
            }
            return listaProgramas;
        }
        public List<ClProgramasE> mtdObtenerProgramasPorId(int idPrograma)
        {

            string Consulta = "SELECT * FROM Programa WHERE idPrograma = " + idPrograma;

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarPrograma = objSQL.mtdSelectDesc(Consulta);
            List<ClProgramasE> ListarPrograma = new List<ClProgramasE>();
            for (int i = 0; i < tblListarPrograma.Rows.Count; i++)
            {
                ClProgramasE objProgramaE = new ClProgramasE();
                objProgramaE.idPrograma = int.Parse(tblListarPrograma.Rows[i]["idPrograma"].ToString());

                objProgramaE.programa = tblListarPrograma.Rows[i]["programa"].ToString();
                objProgramaE.ficha = tblListarPrograma.Rows[i]["ficha"].ToString();
                objProgramaE.jornada = tblListarPrograma.Rows[i]["jornada"].ToString();

                ListarPrograma.Add(objProgramaE);


            }
            return ListarPrograma;

        }
        public int mtdActualizar(ClProgramasE objDatos)
        {
            ProcesarSQL obSQL = new ProcesarSQL();
            string Proceso = "ActualizarPrograma";
            SqlCommand Actualizar = obSQL.mtdPrceso(Proceso);
            Actualizar.Parameters.AddWithValue("@idPrograma", objDatos.idPrograma);
            Actualizar.Parameters.AddWithValue("@Programa", objDatos.programa);
            Actualizar.Parameters.AddWithValue("@Ficha", objDatos.ficha);
            Actualizar.Parameters.AddWithValue("@Jornada", objDatos.jornada);
            int Actu = Actualizar.ExecuteNonQuery();
            return Actu;
        }
        public int mtdEliminar(int idPrograma)
        {
            ProcesarSQL obSQL = new ProcesarSQL();
            string Proceso = "EliminarPrograma";
            SqlCommand Borrar = obSQL.mtdPrceso(Proceso);
            Borrar.Parameters.AddWithValue("@idPrograma", idPrograma);
            int Eliminar = Borrar.ExecuteNonQuery();
            return Eliminar;
        }

            string Consulta = "select * from Programa";

            ProcesarSQL objSQL = new ProcesarSQL();
            DataTable tblListarProgramas = objSQL.mtdSelectDesc(Consulta);

            List<ClProgramasE> ListarProgramas = new List<ClProgramasE>();
            for (int i = 0; i < tblListarProgramas.Rows.Count; i++)
            {
                ClProgramasE objProgramas = new ClProgramasE();

                objProgramas.idPrograma = int.Parse(tblListarProgramas.Rows[i]["idPrograma"].ToString());
                objProgramas.programa = tblListarProgramas.Rows[i]["programa"].ToString();
                objProgramas.ficha = tblListarProgramas.Rows[i]["ficha"].ToString();

                ListarProgramas.Add(objProgramas);


            }
            return ListarProgramas;

        }
    }
}
    
