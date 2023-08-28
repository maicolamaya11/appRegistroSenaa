using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ClPersonalD
    {
        public List<ClPersonalE> mtdBuscar(string documento)
        {
            ProcesarSQL obSQL = new ProcesarSQL();
            ClPersonalE obDatos = new ClPersonalE();
            string Proceso = "BuscarPersonal";

            SqlCommand ComList = obSQL.mtdPrceso(Proceso);
            List<ClPersonalE> listaProd = new List<ClPersonalE>();
            ComList.Parameters.AddWithValue("@Busqueda", documento);
            SqlDataReader BuscarDatos = ComList.ExecuteReader();

            while (BuscarDatos.Read())
            {
                obDatos = new ClPersonalE();
                obDatos.nombres = BuscarDatos.GetString(1);
                obDatos.apellidos = BuscarDatos.GetString(2);
                obDatos.documento = BuscarDatos.GetString(3);
                obDatos.idPrograma = BuscarDatos.GetInt32(4);
                listaProd.Add(obDatos);
            }
            return listaProd;
        }

        public List<ClPersonalE> mtdListarVigilante()
        {
            string consulta = "select * from Personal where rol = 'Vigilante'";
            ProcesarSQL SQL = new ProcesarSQL();
            DataTable tblDatos = SQL.mtdSelectDesc(consulta);

            List<ClPersonalE> listaPerson = new List<ClPersonalE>();
            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                ClPersonalE objPersonal = new ClPersonalE();
                objPersonal.idPersonal = int.Parse(tblDatos.Rows[0]["idPersonal"].ToString());
                objPersonal.nombres = tblDatos.Rows[0]["nombres"].ToString();
                objPersonal.apellidos = tblDatos.Rows[0]["apellidos"].ToString();
                objPersonal.rol = tblDatos.Rows[0]["rol"].ToString();
                objPersonal.documento = tblDatos.Rows[0]["documento"].ToString();

                listaPerson.Add(objPersonal);

            }
            return listaPerson;
        }

        public List<ClPersonalE> mtdBusquedaVigilante(string busqueda)
        {
            string consulta = "select * from Personal where (nombres LIKE '"+busqueda+"' OR apellidos LIKE '"+busqueda+"' " +
                "OR documento LIKE '"+busqueda+"') AND rol = 'Vigilante'";
            ProcesarSQL SQL = new ProcesarSQL();
            DataTable tblDatos = SQL.mtdSelectDesc(consulta);

            List<ClPersonalE> listaPerson = new List<ClPersonalE>();
            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                ClPersonalE objPersonal = new ClPersonalE();
                objPersonal.idPersonal = int.Parse(tblDatos.Rows[0]["idPersonal"].ToString());
                objPersonal.nombres = tblDatos.Rows[0]["nombres"].ToString();
                objPersonal.apellidos = tblDatos.Rows[0]["apellidos"].ToString();
                objPersonal.rol = tblDatos.Rows[0]["rol"].ToString();
                objPersonal.documento = tblDatos.Rows[0]["documento"].ToString();

                listaPerson.Add(objPersonal);

            }
            return listaPerson;
        }
    }
}