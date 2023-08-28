using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
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
                obDatos.idPersonal = BuscarDatos.GetInt32(0);
                obDatos.nombres = BuscarDatos.GetString(1);
                obDatos.apellidos = BuscarDatos.GetString(2);
                obDatos.documento = BuscarDatos.GetString(3);
                obDatos.idPrograma = BuscarDatos.GetInt32(4);
                listaProd.Add(obDatos);
            }
            return listaProd;
        }
    }
}