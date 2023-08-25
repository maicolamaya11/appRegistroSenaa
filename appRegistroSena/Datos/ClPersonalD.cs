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
                obDatos.nombres = BuscarDatos.GetString(1);
                obDatos.apellidos = BuscarDatos.GetString(2);
                obDatos.documento = BuscarDatos.GetString(3);
                obDatos.idPrograma = BuscarDatos.GetInt32(4);
                listaProd.Add(obDatos);
            }
            return listaProd;
        }
        public int mtdRegistrarPersonal(ClPersonalE objPersonal)
        {
            string Registro = "Insert Into Personal(nombres,apellidos,documento,rol,idPrograma) " +
                "Values ('" + objPersonal.nombres + "','" + objPersonal.apellidos + "','" + objPersonal.documento + "','" + objPersonal.rol + "','" + objPersonal.idPrograma + "')";

            ProcesarSQL SQL = new ProcesarSQL();
            int registros = SQL.mtdIUDConec(Registro);
            return registros;
        }
    }
}