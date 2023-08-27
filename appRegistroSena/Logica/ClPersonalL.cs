using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClPersonalL
    {
        public List<ClPersonalE> mtdBuscar(string documento)
        {
            ClPersonalD objProductoD = new ClPersonalD();
            List<ClPersonalE> listaPersonal = objProductoD.mtdBuscar(documento);
            return listaPersonal;
        }
        public int mtdRegistroPersonal(ClPersonalE objDatos)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            int registrar = objPersonalD.mtdRegistrarPersonal(objDatos);
            return registrar;
        }
        public List<ClPersonalE> mtdListarAprendices()
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            List<ClPersonalE> listaAprendices = objPersonalD.mtdListarAprendices();
            return listaAprendices;
        }
        public List<ClPersonalE> mtdRegistroPersonal(int idPersonal)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            List<ClPersonalE> listaTable = objPersonalD.mtdObtenerAprendicesCod(idPersonal); 
            return listaTable;
        }
        public int mtdEditarP(ClPersonalE objDatos)
        {

            ClPersonalD objUsuarioD = new ClPersonalD();
            int reg = objUsuarioD.mtdEditar(objDatos);
            return reg;
        }
        public List<ClPersonalE> mtdListarInstructor()
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            List<ClPersonalE> listaAprendices = objPersonalD.mtdListarInstructores();
            return listaAprendices;
        }
        public List<ClPersonalE> mtdRegistroInstructor(int idPersonal)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            List<ClPersonalE> listaTable = objPersonalD.mtdObtenerInstructorCod(idPersonal);
            return listaTable;
        }
        public int mtdEditarI(ClPersonalE objDatos)
        {

            ClPersonalD objUsuarioD = new ClPersonalD();
            int reg = objUsuarioD.mtdEditarInstru(objDatos);
            return reg;
        }
    }
}