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
        public List<ClProgramasE> mtdListarPrograma()
        {
            ClProgramasD objDatosD = new ClProgramasD();
            List<ClProgramasE> listaPrograma = objDatosD.mtdListarProgramas();
            return listaPrograma;
        }
        public List<ClProgramasE> mtdIdPersonal(int idPrograma)
        {
            ClProgramasD objProgramasD = new ClProgramasD();
            List<ClProgramasE> listaTable = objProgramasD.mtdObtenerProgramasPorId(idPrograma);
            return listaTable;
        }
        public int mtdActualizar(ClProgramasE objDatos)
        {
            ClProgramasD objDatosD = new ClProgramasD();
            int regsitro = objDatosD.mtdActualizar(objDatos);
            return regsitro;
        }
        public int mtdEliminar(int idPrograma)
        {
            ClProgramasD objDatosD = new ClProgramasD();
            int Eliminar = objDatosD.mtdEliminar(idPrograma);
            return Eliminar;
        }


    }
}