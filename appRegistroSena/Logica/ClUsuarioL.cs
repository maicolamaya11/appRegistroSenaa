using appRegistroSena.Datos;
using appRegistroSena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Logica
{
    public class ClUsuarioL
    {
        public int mtdRegistroUsuario(ClUsuarioE objDatos)
        {
            ClUsuarioD objUsuarioD = new ClUsuarioD();
            int registrar = objUsuarioD.mtdRegistrarUsuario(objDatos);
            return registrar;
        }
        public ClUsuarioE mtdDatosLogin(string documento, string contraseña)
        {
            ClUsuarioD objUsuarioD = new ClUsuarioD();
            ClUsuarioE objDatos = objUsuarioD.mtdLogin(documento, contraseña);
            return objDatos;
        }

        public List<ClUsuarioE> mtdListarInstructor()
        {
            ClUsuarioD objProf = new ClUsuarioD();
            List<ClUsuarioE> lista = objProf.mtdListarInstructores();
            return lista;
        }

        public List<ClUsuarioE> mtdBuscarInstructor(string busqueda)
        {
            ClUsuarioD objProf = new ClUsuarioD();
            List<ClUsuarioE> lista = objProf.mtdBusquedaInstructor(busqueda);
            return lista;
        }

        public List<ClProgramasE> mtdListarProgramas()
        {
            ClUsuarioD objProf = new ClUsuarioD();
            List<ClProgramasE> lista = objProf.mtdListarPrograma();
            return lista;
        }

        public List<ClUsuarioE> mtdListarAprendices()
        {
            ClUsuarioD objApren = new ClUsuarioD();
            List<ClUsuarioE> lista = objApren.mtdListarAprendices();
            return lista;
        }

        public List<ClUsuarioE> mtdBuscarAprendiz(string busqueda)
        {
            ClUsuarioD objApren = new ClUsuarioD();
            List<ClUsuarioE> lista = objApren.mtdBusquedaAprendiz(busqueda);
            return lista;
        }
    }
}