﻿using appRegistroSena.Datos;
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

        public List<ClRegistroE> mtdListarRegistros()
        {
            ClRegistroD objRegistroD = new ClRegistroD();
            List<ClRegistroE> listaTable = objRegistroD.mtdListarRegistros();
            return listaTable;
        }

        public int mtdActualizacion(ClRegistroE objDatos)
        {
            ClRegistroD objPersonalD = new ClRegistroD();
            int actu = objPersonalD.mtdActualizar(objDatos);
            return actu;
        }

        public int mtdEliminar(ClRegistroE objDatos)
        {
            ClRegistroD objPersonalD = new ClRegistroD();
            int Eliminar = objPersonalD.mtdEliminar(objDatos);
            return Eliminar;
        }
    }
}