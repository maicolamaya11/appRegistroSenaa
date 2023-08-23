using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appRegistroSena.Datos
{
    public class ClPorteriaD
    {
        public List<ClPorteriaE> mtdListarPorteria()
        {
            ClPorteriaE obDatos = new ClPorteriaE();
            ProcesarSQL SQL = new ProcesarSQL();
            string Proceso = "ListarPorteria";
            SqlCommand ComanList = SQL.mtdPrceso(Proceso);
            SqlDataReader reader = ComanList.ExecuteReader();

            List<ClPorteriaE> listServicio = new List<ClPorteriaE>();

            while (reader.Read())
            {
                obDatos = new ClPorteriaE();
                obDatos.idPorteria = Convert.ToInt32(reader["idPorteria"]);
                obDatos.nombrePorteria = reader["nombrePorteria"].ToString();

                listServicio.Add(obDatos);
            }
            return listServicio;

        }
    }
}