using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClRegistroL
    {
        public int mtdRegistrar(ClRegistroE objDatos)
        {
            ClRegistroD objRegistroD = new ClRegistroD();
            int registro = objRegistroD.mtdRegistro(objDatos);
            return registro;
        }

        public List<ClSalidaE> mtdListarRegistros()
        {
            ClRegistroD objRegistroD = new ClRegistroD();
            List<ClSalidaE> listaTable = objRegistroD.mtdListarRegistros();
            return listaTable;
        }

        public List<ClRegistroE> mtdListaRegistros()
        {
            ClRegistroD objRegistroD = new ClRegistroD();
            List<ClRegistroE> listaTable = objRegistroD.mtdListaRegistros();
            return listaTable;
        }

        //public List<ClRegistroE> mtdRegistroCodigo(int idRegistro)
        //{
        //    ClRegistroD objRegistroD = new ClRegistroD();
        //    List<ClRegistroE> listaTable = objRegistroD.mtdObtenerRegistrosCod(idRegistro);
        //    return listaTable;
        //}

        public int mtdActualizacion(int id)
        {
            ClRegistroD objPersonalD = new ClRegistroD();
            int actu = objPersonalD.mtdActualizar(id);
            return actu;
        }

        public int mtdEliminar(ClRegistroE objDatos)
        {
            ClRegistroD objPersonalD = new ClRegistroD();
            int Eliminar = objPersonalD.mtdEliminar(objDatos);
            return Eliminar;
        }

        public List<ClRegistroE> mtdBuscarRegistro(string busqueda)
        {
            ClRegistroD objProf = new ClRegistroD();
            List<ClRegistroE> lista = objProf.mtdBuscarRegistros(busqueda);
            return lista;
        }
    }
}