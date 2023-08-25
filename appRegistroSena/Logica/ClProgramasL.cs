using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClProgramasL
    {
        public int mtdRegistroPrograma(ClProgramasE objDatos)
        {
            ClProgramasD objProgramaD = new ClProgramasD();
            int registrar = objProgramaD.mtdRegistroPrograma(objDatos);
            return registrar;
        }
        public List<ClProgramasE> mtdLlistarPrograma()
        {
            ClProgramasD objProgramaD = new ClProgramasD();
            List<ClProgramasE> listaPrograma = objProgramaD.mtdListarProgramas();
            return listaPrograma;
        }
    }
}