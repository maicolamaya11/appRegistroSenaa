using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
    
