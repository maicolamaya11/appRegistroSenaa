﻿using appRegistroSena.Datos;
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
    }
}