using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
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
    }
}